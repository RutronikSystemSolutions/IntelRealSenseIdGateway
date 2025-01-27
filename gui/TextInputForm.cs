using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntelRealSenseIdGUI
{
    public partial class TextInputForm : Form
    {
        public TextInputForm()
        {
            InitializeComponent();
        }

        public TextInputForm(string title, string description)
        {
            InitializeComponent();
            this.Text = title;
            this.userTextLabel.Text = description;
        }

        public string GetInputValue()
        {
            return inputFieldTextBox.Text;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
