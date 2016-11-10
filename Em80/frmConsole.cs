using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Em80
{
    public partial class frmConsole : Form
    {
        public frmConsole()
        {
            InitializeComponent();

            setConsolePort(consolePort.sio);
        }

        public enum consolePort { sio, sio2, dj, none }
        private consolePort serialPort;

        private void PrintChar(object sender, SerialEventArgs e)
        {
            if (e.data == 0x08)
            {
                // this was a backspace
                if (textBox1.Text.Length > 0) textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                textBox1.SelectionStart = textBox1.Text.Length;
                textBox1.ScrollToCaret();
            }
            else
            {
                // this was something else
                textBox1.AppendText(char.ToString((char)e.data));
            }
        }

        public void ClearConsole()
        {
            textBox1.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (serialPort == consolePort.sio) EmulatedSystem.sio.serialIn((byte)e.KeyChar);
            else if (serialPort == consolePort.dj) EmulatedSystem.DiskJockey.serialIn((byte)e.KeyChar);
        }

        public void setConsolePort(consolePort port)
        {
            switch (port)
            {
                case consolePort.none:
                    serialPort = consolePort.none;
                    EmulatedSystem.sio.serialOut -= PrintChar;
                    EmulatedSystem.DiskJockey.serialOut -= PrintChar;
                    break;

                case consolePort.sio:
                    serialPort = consolePort.sio;
                    EmulatedSystem.DiskJockey.serialOut -= PrintChar;
                    EmulatedSystem.sio.serialOut += PrintChar;
                    break;

                case consolePort.dj:
                    serialPort = consolePort.dj;
                    EmulatedSystem.sio.serialOut -= PrintChar;
                    EmulatedSystem.DiskJockey.serialOut += PrintChar;
                    break;
            }
        }

        private void frmConsole_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
    }
}
