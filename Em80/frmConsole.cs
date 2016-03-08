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
        }

        public void WriteToConsole(byte val)
        {
            textBox1.AppendText(char.ToString((char)val));
        }

        public void ClearConsole()
        {
            textBox1.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            em80.emulatedSystem.io.Keyboard.KeyPress((byte)e.KeyChar);
        }
    }
}
