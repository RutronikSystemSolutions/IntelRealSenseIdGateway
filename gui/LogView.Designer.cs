namespace IntelRealSenseIdGUI
{
    partial class LogView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox = new GroupBox();
            logTextBox = new TextBox();
            groupBox.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox
            // 
            groupBox.Controls.Add(logTextBox);
            groupBox.Dock = DockStyle.Fill;
            groupBox.Location = new Point(0, 0);
            groupBox.Name = "groupBox";
            groupBox.Size = new Size(401, 192);
            groupBox.TabIndex = 0;
            groupBox.TabStop = false;
            groupBox.Text = "Logs";
            // 
            // logTextBox
            // 
            logTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            logTextBox.Location = new Point(6, 26);
            logTextBox.Multiline = true;
            logTextBox.Name = "logTextBox";
            logTextBox.ReadOnly = true;
            logTextBox.ScrollBars = ScrollBars.Vertical;
            logTextBox.Size = new Size(389, 160);
            logTextBox.TabIndex = 0;
            // 
            // LogView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox);
            Name = "LogView";
            Size = new Size(401, 192);
            groupBox.ResumeLayout(false);
            groupBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox;
        private TextBox logTextBox;
    }
}
