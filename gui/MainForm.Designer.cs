namespace IntelRealSenseIdGUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comPortLabel = new Label();
            comPortComboBox = new ComboBox();
            refreshButton = new Button();
            connectButton = new Button();
            disconnectButton = new Button();
            statusStrip = new StatusStrip();
            fwVersionToolStripStatusLabel = new ToolStripStatusLabel();
            logView = new LogView();
            authenticateButton = new Button();
            enrollButton = new Button();
            usersListView = new ListView();
            idColumnHeader = new ColumnHeader();
            usersGroupBox = new GroupBox();
            deleteAllButton = new Button();
            authFacePrintButton = new Button();
            enrollFacePrintButton = new Button();
            mainTabControl = new TabControl();
            deviceModeTabPage = new TabPage();
            serverModeTabPage = new TabPage();
            serverModeDeleteAllButton = new Button();
            serverModeGroupBox = new GroupBox();
            serverModeUsersListView = new ListView();
            serverModeUserIDColumnHeader = new ColumnHeader();
            scoreColumnHeader = new ColumnHeader();
            matchColumnHeader = new ColumnHeader();
            statusStrip.SuspendLayout();
            usersGroupBox.SuspendLayout();
            mainTabControl.SuspendLayout();
            deviceModeTabPage.SuspendLayout();
            serverModeTabPage.SuspendLayout();
            serverModeGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // comPortLabel
            // 
            comPortLabel.AutoSize = true;
            comPortLabel.Location = new Point(12, 15);
            comPortLabel.Name = "comPortLabel";
            comPortLabel.Size = new Size(77, 20);
            comPortLabel.TabIndex = 0;
            comPortLabel.Text = "COM port:";
            // 
            // comPortComboBox
            // 
            comPortComboBox.FormattingEnabled = true;
            comPortComboBox.Location = new Point(95, 12);
            comPortComboBox.Name = "comPortComboBox";
            comPortComboBox.Size = new Size(151, 28);
            comPortComboBox.TabIndex = 1;
            // 
            // refreshButton
            // 
            refreshButton.Location = new Point(252, 11);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(94, 29);
            refreshButton.TabIndex = 2;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = true;
            refreshButton.Click += refreshButton_Click;
            // 
            // connectButton
            // 
            connectButton.Location = new Point(352, 11);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(94, 29);
            connectButton.TabIndex = 3;
            connectButton.Text = "Connect";
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // disconnectButton
            // 
            disconnectButton.Enabled = false;
            disconnectButton.Location = new Point(452, 11);
            disconnectButton.Name = "disconnectButton";
            disconnectButton.Size = new Size(94, 29);
            disconnectButton.TabIndex = 4;
            disconnectButton.Text = "Disconnect";
            disconnectButton.UseVisualStyleBackColor = true;
            disconnectButton.Click += disconnectButton_Click;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { fwVersionToolStripStatusLabel });
            statusStrip.Location = new Point(0, 470);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(888, 26);
            statusStrip.TabIndex = 5;
            statusStrip.Text = "statusStrip1";
            // 
            // fwVersionToolStripStatusLabel
            // 
            fwVersionToolStripStatusLabel.Name = "fwVersionToolStripStatusLabel";
            fwVersionToolStripStatusLabel.Size = new Size(95, 20);
            fwVersionToolStripStatusLabel.Text = "FW Version: -";
            // 
            // logView
            // 
            logView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            logView.Location = new Point(392, 75);
            logView.Name = "logView";
            logView.Size = new Size(484, 392);
            logView.TabIndex = 6;
            // 
            // authenticateButton
            // 
            authenticateButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            authenticateButton.Enabled = false;
            authenticateButton.Location = new Point(229, 16);
            authenticateButton.Name = "authenticateButton";
            authenticateButton.Size = new Size(128, 29);
            authenticateButton.TabIndex = 7;
            authenticateButton.Text = "Authenticate";
            authenticateButton.UseVisualStyleBackColor = true;
            authenticateButton.Click += authenticateButton_Click;
            // 
            // enrollButton
            // 
            enrollButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            enrollButton.Enabled = false;
            enrollButton.Location = new Point(232, 51);
            enrollButton.Name = "enrollButton";
            enrollButton.Size = new Size(128, 29);
            enrollButton.TabIndex = 8;
            enrollButton.Text = "Enroll";
            enrollButton.UseVisualStyleBackColor = true;
            enrollButton.Click += enrollButton_Click;
            // 
            // usersListView
            // 
            usersListView.Columns.AddRange(new ColumnHeader[] { idColumnHeader });
            usersListView.Dock = DockStyle.Fill;
            usersListView.FullRowSelect = true;
            usersListView.GridLines = true;
            usersListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            usersListView.Location = new Point(3, 23);
            usersListView.MultiSelect = false;
            usersListView.Name = "usersListView";
            usersListView.Size = new Size(214, 350);
            usersListView.TabIndex = 9;
            usersListView.UseCompatibleStateImageBehavior = false;
            usersListView.View = View.Details;
            // 
            // idColumnHeader
            // 
            idColumnHeader.Text = "User Id";
            idColumnHeader.Width = 200;
            // 
            // usersGroupBox
            // 
            usersGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            usersGroupBox.Controls.Add(usersListView);
            usersGroupBox.Location = new Point(6, 6);
            usersGroupBox.Name = "usersGroupBox";
            usersGroupBox.Size = new Size(220, 376);
            usersGroupBox.TabIndex = 10;
            usersGroupBox.TabStop = false;
            usersGroupBox.Text = "Users";
            // 
            // deleteAllButton
            // 
            deleteAllButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            deleteAllButton.Enabled = false;
            deleteAllButton.Location = new Point(232, 347);
            deleteAllButton.Name = "deleteAllButton";
            deleteAllButton.Size = new Size(128, 35);
            deleteAllButton.TabIndex = 11;
            deleteAllButton.Text = "Delete all";
            deleteAllButton.UseVisualStyleBackColor = true;
            deleteAllButton.Click += deleteAllButton_Click;
            // 
            // authFacePrintButton
            // 
            authFacePrintButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            authFacePrintButton.Enabled = false;
            authFacePrintButton.Location = new Point(6, 350);
            authFacePrintButton.Name = "authFacePrintButton";
            authFacePrintButton.Size = new Size(102, 29);
            authFacePrintButton.TabIndex = 12;
            authFacePrintButton.Text = "Authenticate";
            authFacePrintButton.UseVisualStyleBackColor = true;
            authFacePrintButton.Click += authFacePrintButton_Click;
            // 
            // enrollFacePrintButton
            // 
            enrollFacePrintButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            enrollFacePrintButton.Enabled = false;
            enrollFacePrintButton.Location = new Point(114, 350);
            enrollFacePrintButton.Name = "enrollFacePrintButton";
            enrollFacePrintButton.Size = new Size(72, 29);
            enrollFacePrintButton.TabIndex = 13;
            enrollFacePrintButton.Text = "Enroll";
            enrollFacePrintButton.UseVisualStyleBackColor = true;
            enrollFacePrintButton.Click += enrollFacePrintButton_Click;
            // 
            // mainTabControl
            // 
            mainTabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            mainTabControl.Controls.Add(deviceModeTabPage);
            mainTabControl.Controls.Add(serverModeTabPage);
            mainTabControl.Location = new Point(12, 46);
            mainTabControl.Name = "mainTabControl";
            mainTabControl.SelectedIndex = 0;
            mainTabControl.Size = new Size(374, 421);
            mainTabControl.TabIndex = 14;
            // 
            // deviceModeTabPage
            // 
            deviceModeTabPage.Controls.Add(authenticateButton);
            deviceModeTabPage.Controls.Add(enrollButton);
            deviceModeTabPage.Controls.Add(deleteAllButton);
            deviceModeTabPage.Controls.Add(usersGroupBox);
            deviceModeTabPage.Location = new Point(4, 29);
            deviceModeTabPage.Name = "deviceModeTabPage";
            deviceModeTabPage.Padding = new Padding(3);
            deviceModeTabPage.Size = new Size(366, 388);
            deviceModeTabPage.TabIndex = 0;
            deviceModeTabPage.Text = "Device mode";
            deviceModeTabPage.UseVisualStyleBackColor = true;
            // 
            // serverModeTabPage
            // 
            serverModeTabPage.Controls.Add(serverModeDeleteAllButton);
            serverModeTabPage.Controls.Add(serverModeGroupBox);
            serverModeTabPage.Controls.Add(enrollFacePrintButton);
            serverModeTabPage.Controls.Add(authFacePrintButton);
            serverModeTabPage.Location = new Point(4, 29);
            serverModeTabPage.Name = "serverModeTabPage";
            serverModeTabPage.Padding = new Padding(3);
            serverModeTabPage.Size = new Size(366, 388);
            serverModeTabPage.TabIndex = 1;
            serverModeTabPage.Text = "Server mode";
            serverModeTabPage.UseVisualStyleBackColor = true;
            // 
            // serverModeDeleteAllButton
            // 
            serverModeDeleteAllButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            serverModeDeleteAllButton.Enabled = false;
            serverModeDeleteAllButton.Location = new Point(236, 350);
            serverModeDeleteAllButton.Name = "serverModeDeleteAllButton";
            serverModeDeleteAllButton.Size = new Size(124, 29);
            serverModeDeleteAllButton.TabIndex = 14;
            serverModeDeleteAllButton.Text = "Delete all";
            serverModeDeleteAllButton.UseVisualStyleBackColor = true;
            serverModeDeleteAllButton.Click += serverModeDeleteAllButton_Click;
            // 
            // serverModeGroupBox
            // 
            serverModeGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            serverModeGroupBox.Controls.Add(serverModeUsersListView);
            serverModeGroupBox.Location = new Point(6, 6);
            serverModeGroupBox.Name = "serverModeGroupBox";
            serverModeGroupBox.Size = new Size(354, 338);
            serverModeGroupBox.TabIndex = 0;
            serverModeGroupBox.TabStop = false;
            serverModeGroupBox.Text = "Users";
            // 
            // serverModeUsersListView
            // 
            serverModeUsersListView.Columns.AddRange(new ColumnHeader[] { serverModeUserIDColumnHeader, scoreColumnHeader, matchColumnHeader });
            serverModeUsersListView.Dock = DockStyle.Fill;
            serverModeUsersListView.FullRowSelect = true;
            serverModeUsersListView.GridLines = true;
            serverModeUsersListView.Location = new Point(3, 23);
            serverModeUsersListView.Name = "serverModeUsersListView";
            serverModeUsersListView.Size = new Size(348, 312);
            serverModeUsersListView.TabIndex = 1;
            serverModeUsersListView.UseCompatibleStateImageBehavior = false;
            serverModeUsersListView.View = View.Details;
            // 
            // serverModeUserIDColumnHeader
            // 
            serverModeUserIDColumnHeader.Text = "User Id";
            serverModeUserIDColumnHeader.Width = 150;
            // 
            // scoreColumnHeader
            // 
            scoreColumnHeader.Text = "Score";
            scoreColumnHeader.Width = 100;
            // 
            // matchColumnHeader
            // 
            matchColumnHeader.Text = "Match";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(888, 496);
            Controls.Add(mainTabControl);
            Controls.Add(logView);
            Controls.Add(statusStrip);
            Controls.Add(disconnectButton);
            Controls.Add(connectButton);
            Controls.Add(refreshButton);
            Controls.Add(comPortComboBox);
            Controls.Add(comPortLabel);
            Name = "MainForm";
            Text = "Rutronik - Intel RealSense Id Demo v1.0";
            Load += MainForm_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            usersGroupBox.ResumeLayout(false);
            mainTabControl.ResumeLayout(false);
            deviceModeTabPage.ResumeLayout(false);
            serverModeTabPage.ResumeLayout(false);
            serverModeGroupBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label comPortLabel;
        private ComboBox comPortComboBox;
        private Button refreshButton;
        private Button connectButton;
        private Button disconnectButton;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel fwVersionToolStripStatusLabel;
        private LogView logView;
        private Button authenticateButton;
        private Button enrollButton;
        private ListView usersListView;
        private GroupBox usersGroupBox;
        private ColumnHeader idColumnHeader;
        private Button deleteAllButton;
        private Button authFacePrintButton;
        private Button enrollFacePrintButton;
        private TabControl mainTabControl;
        private TabPage deviceModeTabPage;
        private TabPage serverModeTabPage;
        private GroupBox serverModeGroupBox;
        private ListView serverModeUsersListView;
        private ColumnHeader serverModeUserIDColumnHeader;
        private Button serverModeDeleteAllButton;
        private ColumnHeader scoreColumnHeader;
        private ColumnHeader matchColumnHeader;
    }
}
