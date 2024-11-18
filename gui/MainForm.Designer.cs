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
            statusStrip.SuspendLayout();
            usersGroupBox.SuspendLayout();
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
            statusStrip.Location = new Point(0, 393);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(900, 26);
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
            logView.Location = new Point(491, 56);
            logView.Name = "logView";
            logView.Size = new Size(397, 334);
            logView.TabIndex = 6;
            // 
            // authenticateButton
            // 
            authenticateButton.Enabled = false;
            authenticateButton.Location = new Point(352, 56);
            authenticateButton.Name = "authenticateButton";
            authenticateButton.Size = new Size(128, 29);
            authenticateButton.TabIndex = 7;
            authenticateButton.Text = "Authenticate";
            authenticateButton.UseVisualStyleBackColor = true;
            authenticateButton.Click += authenticateButton_Click;
            // 
            // enrollButton
            // 
            enrollButton.Enabled = false;
            enrollButton.Location = new Point(349, 204);
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
            usersListView.Size = new Size(328, 318);
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
            usersGroupBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            usersGroupBox.Controls.Add(usersListView);
            usersGroupBox.Location = new Point(12, 46);
            usersGroupBox.Name = "usersGroupBox";
            usersGroupBox.Size = new Size(334, 344);
            usersGroupBox.TabIndex = 10;
            usersGroupBox.TabStop = false;
            usersGroupBox.Text = "Users";
            // 
            // deleteAllButton
            // 
            deleteAllButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            deleteAllButton.Enabled = false;
            deleteAllButton.Location = new Point(357, 358);
            deleteAllButton.Name = "deleteAllButton";
            deleteAllButton.Size = new Size(128, 29);
            deleteAllButton.TabIndex = 11;
            deleteAllButton.Text = "Delete all";
            deleteAllButton.UseVisualStyleBackColor = true;
            deleteAllButton.Click += deleteAllButton_Click;
            // 
            // authFacePrintButton
            // 
            authFacePrintButton.Enabled = false;
            authFacePrintButton.Location = new Point(349, 91);
            authFacePrintButton.Name = "authFacePrintButton";
            authFacePrintButton.Size = new Size(125, 29);
            authFacePrintButton.TabIndex = 12;
            authFacePrintButton.Text = "Auth - Face Print";
            authFacePrintButton.UseVisualStyleBackColor = true;
            authFacePrintButton.Click += authFacePrintButton_Click;
            // 
            // enrollFacePrintButton
            // 
            enrollFacePrintButton.Enabled = false;
            enrollFacePrintButton.Location = new Point(349, 239);
            enrollFacePrintButton.Name = "enrollFacePrintButton";
            enrollFacePrintButton.Size = new Size(125, 29);
            enrollFacePrintButton.TabIndex = 13;
            enrollFacePrintButton.Text = "Enr - Face Print";
            enrollFacePrintButton.UseVisualStyleBackColor = true;
            enrollFacePrintButton.Click += enrollFacePrintButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 419);
            Controls.Add(enrollFacePrintButton);
            Controls.Add(authFacePrintButton);
            Controls.Add(deleteAllButton);
            Controls.Add(usersGroupBox);
            Controls.Add(enrollButton);
            Controls.Add(authenticateButton);
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
    }
}
