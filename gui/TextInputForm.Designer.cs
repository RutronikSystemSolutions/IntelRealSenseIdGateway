namespace IntelRealSenseIdGUI
{
    partial class TextInputForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            userTextLabel = new Label();
            inputFieldTextBox = new TextBox();
            okButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // userTextLabel
            // 
            userTextLabel.AutoSize = true;
            userTextLabel.Location = new Point(12, 9);
            userTextLabel.Name = "userTextLabel";
            userTextLabel.Size = new Size(63, 20);
            userTextLabel.TabIndex = 0;
            userTextLabel.Text = "userText";
            // 
            // inputFieldTextBox
            // 
            inputFieldTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            inputFieldTextBox.Location = new Point(12, 32);
            inputFieldTextBox.Name = "inputFieldTextBox";
            inputFieldTextBox.Size = new Size(234, 27);
            inputFieldTextBox.TabIndex = 1;
            // 
            // okButton
            // 
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            okButton.Location = new Point(12, 65);
            okButton.Name = "okButton";
            okButton.Size = new Size(94, 29);
            okButton.TabIndex = 2;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.Location = new Point(152, 65);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(94, 29);
            cancelButton.TabIndex = 3;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // TextInputForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(258, 102);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(inputFieldTextBox);
            Controls.Add(userTextLabel);
            Name = "TextInputForm";
            Text = "Title";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label userTextLabel;
        private TextBox inputFieldTextBox;
        private Button okButton;
        private Button cancelButton;
    }
}