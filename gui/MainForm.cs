using rsid;
using System.IO.Ports;

namespace IntelRealSenseIdGUI
{
    public partial class MainForm : Form
    {
        private RealSenseCamera camera = new RealSenseCamera();

        public MainForm()
        {
            InitializeComponent();

            camera.OnNewCameraInformation += Camera_OnNewCameraInformation;
            camera.OnNewConnectionState += Camera_OnNewConnectionState;
            camera.OnNewUserDatabase += Camera_OnNewUserDatabase;
            camera.OnNewAuthentication += Camera_OnNewAuthentication;
            camera.OnNewServerModeUserDatabase += Camera_OnNewServerModeUserDatabase;
            camera.OnNewServerModeAuthenticateResult += Camera_OnNewServerModeAuthenticateResult;
        }

        /// <summary>
        /// Event handler: a new "server mode" authenticate result (with success) is available
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="users"></param>
        /// <param name="success"></param>
        /// <param name="score"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Camera_OnNewServerModeAuthenticateResult(object sender, string[] users, int[] success, int[] score)
        {
            serverModeUsersListView.Items.Clear();
            for (int i = 0; i < users.Length; i++)
            {
                ListViewItem item = new ListViewItem(new string[] { users[i], score[i].ToString(), success[i].ToString() });
                serverModeUsersListView.Items.Add(item);
            }
            serverModeUsersListView.Invalidate();
        }

        /// <summary>
        /// Event handler: a new "server mode" user database is available
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="users"></param>
        private void Camera_OnNewServerModeUserDatabase(object sender, string[] users)
        {
            serverModeUsersListView.Items.Clear();
            for (int i = 0; i < users.Length; i++)
            {
                ListViewItem item = new ListViewItem(new string[] { users[i], "-", "-" });
                serverModeUsersListView.Items.Add(item);
            }
            serverModeUsersListView.Invalidate();
        }

        private void Camera_OnNewAuthentication(object sender, RealSenseCamera.AuthenticateResult result, string userId)
        {
            switch (result)
            {
                case RealSenseCamera.AuthenticateResult.AccessForbidden:
                    logView.AddLog("Access Forbidden");
                    break;
                case RealSenseCamera.AuthenticateResult.AccessOk:
                    logView.AddLog("Access OK - user is: " + userId);
                    break;
                case RealSenseCamera.AuthenticateResult.Spoof:
                    logView.AddLog("Spoof detected");
                    break;
                case RealSenseCamera.AuthenticateResult.Error:
                    logView.AddLog("Error during authentication");
                    break;
            }
        }

        /// <summary>
        /// Event handler: new user database is available
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="users"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Camera_OnNewUserDatabase(object sender, string[] users)
        {
            usersListView.Items.Clear();
            for (int i = 0; i < users.Length; i++)
            {
                ListViewItem item = new ListViewItem(new string[] { users[i] });
                usersListView.Items.Add(item);
            }
            usersListView.Invalidate();
        }

        /// <summary>
        /// Event handler: new connection state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="state"></param>
        private void Camera_OnNewConnectionState(object sender, RealSenseCamera.ConnectionState state)
        {
            switch (state)
            {
                case RealSenseCamera.ConnectionState.Connected:
                    {
                        connectButton.Enabled = false;
                        disconnectButton.Enabled = true;
                        refreshButton.Enabled = false;
                        authenticateButton.Enabled = true;
                        enrollButton.Enabled = true;
                        deleteAllButton.Enabled = true;
                        authFacePrintButton.Enabled = true;
                        enrollFacePrintButton.Enabled = true;
                        serverModeDeleteAllButton.Enabled = true;
                        break;
                    }
                case RealSenseCamera.ConnectionState.Iddle:
                case RealSenseCamera.ConnectionState.Error:
                    {
                        connectButton.Enabled = true;
                        disconnectButton.Enabled = false;
                        refreshButton.Enabled = true;
                        fwVersionToolStripStatusLabel.Text = string.Empty;
                        authenticateButton.Enabled = false;
                        enrollButton.Enabled = false;
                        deleteAllButton.Enabled = false;
                        authFacePrintButton.Enabled = false;
                        enrollFacePrintButton.Enabled = false;
                        serverModeDeleteAllButton.Enabled = false;
                        break;
                    }
            }
        }

        /// <summary>
        /// Event handler: new information from the camera are available
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="firmwareVersion"></param>
        /// <param name="serialNumber"></param>
        private void Camera_OnNewCameraInformation(object sender, string firmwareVersion, string serialNumber)
        {
            fwVersionToolStripStatusLabel.Text = firmwareVersion;
        }

        /// <summary>
        /// Callback function beeing called when the form is loaded for the first time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateComPortList();
        }

        /// <summary>
        /// Discover the available COM port and update the combobox
        /// </summary>
        private void UpdateComPortList()
        {
            // Load the possible com ports
            string[] serialPorts = SerialPort.GetPortNames();
            comPortComboBox.DataSource = serialPorts;
        }

        /// <summary>
        /// Event handler: click on the "refresh" button. Used to update the list of available COM ports
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refreshButton_Click(object sender, EventArgs e)
        {
            UpdateComPortList();
        }

        /// <summary>
        /// Event handler: click on the "Connect" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connectButton_Click(object sender, EventArgs e)
        {
            if ((comPortComboBox.SelectedIndex < 0) || (comPortComboBox.SelectedIndex >= comPortComboBox.Items.Count)) return;

            var selectedItem = comPortComboBox.Items[comPortComboBox.SelectedIndex];
            if (selectedItem != null)
            {
                string? portName = selectedItem.ToString();
                if (portName != null)
                {
                    connectButton.Enabled = false;

                    if (camera.InitializeConnection(portName) != 0)
                    {
                        logView.AddLog(camera.GetLastError());
                    }
                }
            }
        }

        /// <summary>
        /// Event handler: click on the "Disconnect" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void disconnectButton_Click(object sender, EventArgs e)
        {
            camera.Disconnect();
        }


        /// <summary>
        /// Event handler: requests an authentication
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void authenticateButton_Click(object sender, EventArgs e)
        {
            if (camera.Authenticate() != 0)
            {
                logView.AddLog(camera.GetLastError());
            }
        }

        /// <summary>
        /// Event handler: delete all users
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteAllButton_Click(object sender, EventArgs e)
        {
            if (camera.DeleteAllUsers() != 0)
            {
                logView.AddLog(camera.GetLastError());
            }

            camera.GetUserIds(out string[] userIds);
            Camera_OnNewUserDatabase(camera, userIds);
        }

        /// <summary>
        /// Event handler: click on the "enroll" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enrollButton_Click(object sender, EventArgs e)
        {
            TextInputForm form = new TextInputForm("User name", "Please enter a user name");
            if (form.ShowDialog() != DialogResult.OK) return;

            string userId = form.GetInputValue();
            if (userId.Length == 0)
            {
                logView.AddLog("User ID cannot be null");
                return;
            }

            if (camera.Enroll(userId) != 0)
            {
                logView.AddLog(camera.GetLastError());
            }
        }

        #region "Server mode events"

        /// <summary>
        /// Event handler: click on the "auth - face print" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void authFacePrintButton_Click(object sender, EventArgs e)
        {
            // Request user list to update success and score
            camera.RequestServerModeUserList();

            if (camera.ExtractFacePrintForAuth() != 0)
            {
                logView.AddLog(camera.GetLastError());
            }
        }

        /// <summary>
        /// Event handler: click on the "enroll - face print" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enrollFacePrintButton_Click(object sender, EventArgs e)
        {
            TextInputForm form = new TextInputForm("User name", "Please enter a user name");
            if (form.ShowDialog() != DialogResult.OK) return;

            string userId = form.GetInputValue();
            if (userId.Length == 0)
            {
                logView.AddLog("User ID cannot be null");
                return;
            }

            // Request user list to update success and score
            camera.RequestServerModeUserList();

            if (camera.ExtractFacePrintForEnroll(userId) != 0)
            {
                logView.AddLog(camera.GetLastError());
            }
        }

        /// <summary>
        /// Event handler: delete all "server mode" user
        /// Reminder: server mode means that the database is not stored on the camera module but somewhere else
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void serverModeDeleteAllButton_Click(object sender, EventArgs e)
        {
            camera.DeleteServerModeUserList();
        }

        #endregion
    }
}
