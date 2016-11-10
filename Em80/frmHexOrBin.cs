using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Em80
{
    public partial class frmHexOrBin : Form
    {
        private string theFileName;

        public frmHexOrBin(string inFileName)
        {
            InitializeComponent();

            theFileName = inFileName;
        }

        private void radioBin_CheckedChanged(object sender, EventArgs e)
        {
            textOffset.Enabled = true;
        }

        private void radioHex_CheckedChanged(object sender, EventArgs e)
        {
            textOffset.Enabled = false;
        }

        private void frmHexOrBin_Load(object sender, EventArgs e)
        {
            string theExt = Path.GetExtension(theFileName);

            if (theExt.ToLower() == ".hex")
            {
                radioBin.Checked = false;
                radioHex.Checked = true;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ValidateHexInput(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar > 64 && e.KeyChar < 71))   // 0-9, A-F
            {
                return;
            }
            else if (e.KeyChar > 96 && e.KeyChar < 103) // a-f
            {
                e.KeyChar -= (char)32;
                return;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
