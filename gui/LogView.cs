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
    public partial class LogView : UserControl
    {
        private const int MAX_LOGS_COUNT = 10;

        List<string> logs = new List<string>();

        public LogView()
        {
            InitializeComponent();
        }

        public void AddLog(string message)
        {
            logs.Add(message);
            if (logs.Count > MAX_LOGS_COUNT) logs.RemoveAt(0);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < logs.Count; i++)
            {
                sb.Append(logs[logs.Count - 1 - i] + Environment.NewLine);
            }

            logTextBox.Text = sb.ToString();
        }
    }
}
