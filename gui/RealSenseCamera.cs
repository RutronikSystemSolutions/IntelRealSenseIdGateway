﻿using rsid;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IntelRealSenseIdGUI
{
    public class RealSenseCamera
    {
        private List<Faceprints> enrolledFacePrints = new List<Faceprints>();

        public enum ConnectionState
        {
            Iddle,
            Error,
            Connected
        }

        public enum AuthenticateResult
        {
            Spoof,
            AccessOk,
            AccessForbidden,
            Error
        }

        #region "Events"

        public delegate void OnNewConnectionStateEventHandler(object sender, ConnectionState state);
        public event OnNewConnectionStateEventHandler? OnNewConnectionState;

        public delegate void OnNewCameraInformationEventHandler(object sender, string firmwareVersion, string serialNumber);
        public event OnNewCameraInformationEventHandler? OnNewCameraInformation;

        public delegate void OnNewUserDatabaseEventHandler(object sender, string[] users);
        public event OnNewUserDatabaseEventHandler? OnNewUserDatabase;

        public delegate void OnNewAuthenticationEventHandler(object sender, AuthenticateResult result, string userId);
        public event OnNewAuthenticationEventHandler? OnNewAuthentication;

        #endregion

        #region "Members"

        private Authenticator? authenticator;
        private string? lastError;

        #endregion

        /// <summary>
        /// Initialize the connection
        /// Open the COM port and try to read the firmware version
        /// </summary>
        /// <param name="portName">COM port to be opened</param>
        /// <returns>0 on success</returns>
        public int InitializeConnection(string portName)
        {
            if (authenticator != null) return -1;

            DeviceController deviceController = new DeviceController();
            Status retval = deviceController.Connect(new SerialConfig {  port = portName });
            if (retval != Status.Ok)
            {
                AddError("InitializeConnection - deviceController.Connect: " + retval.ToString());
                return -2;
            }

            string firmwareVersion = deviceController.QueryFirmwareVersion();
            string serialNumber = deviceController.QuerySerialNumber();

            if (firmwareVersion == null || serialNumber == null)
            {
                AddError("InitializeConnection - Cannot read firmware version or serial number.");
                OnNewConnectionState?.Invoke(this, ConnectionState.Error);
                deviceController.Disconnect();
                deviceController.Dispose();
                return -3;
            }

            OnNewCameraInformation?.Invoke(this, firmwareVersion, serialNumber);

            deviceController.Disconnect();
            deviceController.Dispose();

            // SDK compatible with host version?
            //if (Authenticator.IsFwCompatibleWithHost(firmwareVersion) == false)
            //{
            //    AddError(string.Format(
            //        "InitializeConnection - SDK not compatible. Should be {0} but is {1}",
            //        Authenticator.CompatibleFirmwareVersion(),
            //        firmwareVersion));
            //    OnNewConnectionState?.Invoke(this, ConnectionState.Error);
            //    return -4;
            //}

            authenticator = new Authenticator();
            retval = authenticator.Connect(new SerialConfig { port = portName });
            if (retval != Status.Ok)
            {
                AddError("InitializeConnection - authenticator.Connect: " + retval.ToString());
                OnNewConnectionState?.Invoke(this, ConnectionState.Error);
                return -5;
            }

            // Set device configuration -> we want to authenticate users
            DeviceConfig deviceConfig = new DeviceConfig();
            deviceConfig.algoFlow = DeviceConfig.AlgoFlow.All;
            deviceConfig.faceSelectionPolicy = DeviceConfig.FaceSelectionPolicy.Single;

            retval = authenticator.SetDeviceConfig(deviceConfig);
            if (retval != Status.Ok)
            {
                AddError("InitializeConnection - authenticator.SetDeviceConfig: " + retval.ToString());
                OnNewConnectionState?.Invoke(this, ConnectionState.Error);
                return -6;
            }

            // get the user database
            if (GetUserIds(out string[] userIds) != 0)
            {
                authenticator.Disconnect();
                authenticator.Dispose();
                OnNewConnectionState?.Invoke(this, ConnectionState.Error);
                return -7;
            }
            OnNewUserDatabase?.Invoke(this, userIds);

            OnNewConnectionState?.Invoke(this, ConnectionState.Connected);

            return 0;
        }

        /// <summary>
        /// Get the list of users inside the database
        /// </summary>
        /// <param name="userIds"></param>
        /// <returns></returns>
        public int GetUserIds(out string[] userIds)
        {
            if (authenticator == null)
            {
                AddError("GetUserIds - authenticator is null");
                userIds = [];
                return -1;
            }

            // Get the available user ids
            Status retval = authenticator.QueryUserIds(out userIds);
            if (retval != Status.Ok)
            {
                AddError("GetUserIds: " + retval.ToString());
                return -2;
            }

            return 0;
        }

        /// <summary>
        /// Delete all the users
        /// </summary>
        /// <returns></returns>
        public int DeleteAllUsers()
        {
            if (authenticator == null)
            {
                AddError("DeleteAllUsers - authenticator is null");
                return -1;
            }

            Status retval = authenticator.RemoveAllUsers();
            if (retval != Status.Ok)
            {
                AddError("DeleteAllUsers: retval is " + retval.ToString());
                return -2;
            }

            return 0;
        }

        /// <summary>
        /// Disconnect from device
        /// </summary>
        public void Disconnect()
        {
            if (authenticator == null) return;

            authenticator.Disconnect();
            authenticator.Dispose();
            authenticator = null;

            OnNewConnectionState?.Invoke(this, ConnectionState.Iddle);
        }

        /// <summary>
        /// Add an error
        /// </summary>
        /// <param name="message"></param>
        private void AddError(string message)
        {
            lastError = message;
        }

        /// <summary>
        /// Get the last error
        /// </summary>
        /// <returns></returns>
        public string GetLastError()
        {
            if (lastError == null) { return string.Empty; }
            return lastError;
        }

        #region "Authentication callbacks"


        void OnAuthResult(AuthStatus status, string userId, IntPtr ctx)
        {
            AuthenticateResult result = AuthenticateResult.Error;
            switch(status)
            {
                case AuthStatus.Success:
                    result = AuthenticateResult.AccessOk;

                    break;
                case AuthStatus.Spoof:
                    result = AuthenticateResult.Spoof;
                    break;
                case AuthStatus.Forbidden:
                    result = AuthenticateResult.AccessForbidden;
                    break;
            }
            OnNewAuthentication?.Invoke(this, result, userId);
        }

        #endregion

        /// <summary>
        /// Perform an authentication
        /// </summary>
        /// <returns></returns>
        public int Authenticate()
        {
            if (authenticator == null)
            {
                AddError("Authenticate - authenticator is null");
                return -1;
            }

            var authArgs = new AuthArgs { resultClbk = OnAuthResult};
            Status retval = authenticator.Authenticate(authArgs);

            if (retval != Status.Ok)
            {
                AddError("Authenticate: " + retval.ToString());
                return -2;
            }

            return 0;
        }

        #region "Enroll callbacks"

        private void OnEnrollResult(EnrollStatus status, IntPtr ctx)
        {
            System.Diagnostics.Debug.WriteLine("OnEnrollResult " + status);
        }

        private void OnEnrollHint(EnrollStatus status, IntPtr ctx)
        {
            System.Diagnostics.Debug.WriteLine("OnEnrollHint " + status);
        }

        private void OnEnrollProgress(FacePose status, IntPtr ctx)
        {
            System.Diagnostics.Debug.WriteLine("OnEnrollProgress " + status);
        }

        private void OnEnrollFaceDetected(IntPtr faces, int count, uint ts, IntPtr ctx)
        {
            System.Diagnostics.Debug.WriteLine("OnEnrollFaceDetected " + count.ToString());
        }

        #endregion

        public int Enroll(string userId)
        {
            if (authenticator == null)
            {
                AddError("Enroll - authenticator is null");
                return -1;
            }

            EnrollArgs enrollArgs = new EnrollArgs { userId = userId , 
                resultClbk = OnEnrollResult, 
                hintClbk = OnEnrollHint,
                progressClbk = OnEnrollProgress,
                faceDetectedClbk = OnEnrollFaceDetected
                };

            Status retval = authenticator.Enroll(enrollArgs);
            if (retval != Status.Ok)
            {
                AddError("Enroll: " + retval.ToString());
                return -2;
            }

            return 0;
        }

        #region "Authenticate face print callbacks"

        public void AuthFacePrintHintCallback(AuthStatus status, IntPtr ctx)
        {
            System.Diagnostics.Debug.WriteLine("AuthFacePrintHintCallback");
        }

        public void AuthFacePrintFaceDetecedCallback(IntPtr faces, int count, uint ts, IntPtr ctx)
        {
            System.Diagnostics.Debug.WriteLine("AuthFacePrintFaceDetecedCallback");
        }

        public void AuthFacePrintExtractionResultCallback(AuthStatus status, IntPtr faceprints, IntPtr ctx)
        {
            System.Diagnostics.Debug.WriteLine("AuthFacePrintExtractionResultCallback");
            System.Diagnostics.Debug.WriteLine("status " + status);

            if (status != AuthStatus.Success) return;

            if (authenticator == null)
            {
                System.Diagnostics.Debug.WriteLine("authenticator is null");
                return;
            }

            // Convert
            var tmp = Marshal.PtrToStructure(faceprints, typeof(ExtractedFaceprints));
            if (tmp == null)
            {
                System.Diagnostics.Debug.WriteLine("Cannot convert object to ExtractedFacePrints");
                return;
            }
            ExtractedFaceprints extractedFaceprints = (ExtractedFaceprints)tmp;

            for (int i = 0; i < enrolledFacePrints.Count; ++i)
            {
                MatchArgs matchArgs = new MatchArgs();
                matchArgs.matcherConfidenceLevel = MatcherConfidenceLevel.Medium;

                // Remark: strange because MatchElement as exactly the same definition as ExtractedFaceprints
                var tmpMatchElement = Marshal.PtrToStructure(faceprints, typeof(MatchElement));
                if (tmpMatchElement == null)
                {
                    System.Diagnostics.Debug.WriteLine("Cannot convert object to MatchElement");
                    return;
                }
                matchArgs.newFaceprints = (MatchElement)tmpMatchElement;
                matchArgs.existingFaceprints = enrolledFacePrints[i];
                matchArgs.updatedFaceprints = new Faceprints();

                MatchResult matchResult = authenticator.MatchFaceprintsToFaceprints(ref matchArgs);
                System.Diagnostics.Debug.WriteLine("Match result success" + matchResult.success);
                System.Diagnostics.Debug.WriteLine("Match result score" + matchResult.score);
                System.Diagnostics.Debug.WriteLine("Match result shouldUpdate" + matchResult.shouldUpdate);
            }

            return;
        }

        #endregion

        public int ExtractFacePrintForAuth()
        {
            if (authenticator == null)
            {
                AddError("ExtractFacePrintForAuth - authenticator is null");
                return -1;
            }

            AuthExtractArgs authExtractArgs = new AuthExtractArgs
            {
                resultClbk = AuthFacePrintExtractionResultCallback,
                hintClbk = AuthFacePrintHintCallback,
                faceDetectedClbk = AuthFacePrintFaceDetecedCallback
            };

            Status retval = authenticator.AuthenticateExtractFaceprints(authExtractArgs);
            if (retval != Status.Ok)
            {
                AddError("ExtractFacePrintForAuth: " + retval);
                return -2;
            }

            return 0;
        }

        #region "Enroll face print callbacks"

        public void EnrollFacePrintFaceDetectedCallback(IntPtr faces, int count, uint ts, IntPtr ctx)
        {
            System.Diagnostics.Debug.WriteLine("EnrollFacePrintFaceDetectedCallback");
        }
        public void EnrollFacePrintHintCallback(EnrollStatus status, IntPtr ctx)
        {
            System.Diagnostics.Debug.WriteLine("EnrollFacePrintHintCallback: " + status);
        }
        public void EnrollFacePrintProgressCallback(FacePose status, IntPtr ctx)
        {
            System.Diagnostics.Debug.WriteLine("EnrollFacePrintProgressCallback");
        }

        /// <summary>
        /// Callback being called when the enroll (using face prints) proces is over
        /// Warning: the pointer points on a Faceprints object (and not on an ExtractedFacePrints as the authenticate process
        /// </summary>
        /// <param name="status"></param>
        /// <param name="faceprintsHandle"></param>
        /// <param name="ctx"></param>
        public void EnrollFacePrintExtractionResultCallback(EnrollStatus status, IntPtr faceprintsHandle, IntPtr ctx)
        {
            System.Diagnostics.Debug.WriteLine("EnrollFacePrintExtractionResultCallback");
            System.Diagnostics.Debug.WriteLine("status " + status);

            if (status != EnrollStatus.Success) return;

            // Convert
            var tmp = Marshal.PtrToStructure(faceprintsHandle, typeof(Faceprints));
            if (tmp == null)
            {
                System.Diagnostics.Debug.WriteLine("Cannot convert object");
                return;
            }
            Faceprints extractedFaceprints = (Faceprints)tmp;

            enrolledFacePrints.Add(extractedFaceprints);

            System.Diagnostics.Debug.WriteLine(string.Format("{0} faces stored inside enrolled DB.", enrolledFacePrints.Count));

            return;
        }

        #endregion

        public int ExtractFacePrintForEnroll()
        {
            if (authenticator == null)
            {
                AddError("ExtractFacePrintForAuth - authenticator is null");
                return -1;
            }

            EnrollExtractArgs enrollExtractArgs = new EnrollExtractArgs
            {
                resultClbk = EnrollFacePrintExtractionResultCallback,
                progressClbk = EnrollFacePrintProgressCallback,
                hintClbk = EnrollFacePrintHintCallback,
                faceDetectedClbk = EnrollFacePrintFaceDetectedCallback
            };

            Status retval = authenticator.EnrollExtractFaceprints(enrollExtractArgs);
            if (retval != Status.Ok)
            {
                AddError("ExtractFacePrintForEnroll: " + retval);
                return -2;
            }

            return 0;
        }

    }
}
