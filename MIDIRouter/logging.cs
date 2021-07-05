using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIDIRouter
{
    public partial class logging : Form
    {
        public logging()
        {
            InitializeComponent();
           //logging.ActiveForm.Close += new System.EventHandler(this.logging_FormClosing);
        }
        public string logText
        {
            get { return LoggingWindow.Text; }
            set { LoggingWindow.AppendText(Environment.NewLine + value); }
        }

        private void logging_Load(object sender, EventArgs e)
        {
            this.Hide();
            this.Parent = null;
           // e.Cancel = true;
      
        }
        private void logging_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }
    }
}
