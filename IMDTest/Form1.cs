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
    public partial class frmMain : Form
    {
        ImageDisk disk;

        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = null;
            DialogResult res = openFileDialog1.ShowDialog();
            if (res != DialogResult.OK) return;

            readImage();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblHeader.Text = "";
            lblSectorInfo.Text = "";
            textComment.Text = "";
        }

        private void readImage()
        {
            disk = new ImageDisk();

            try {
                disk.loadImage(openFileDialog1.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblHeader.Text = disk.header;
            textComment.Text = disk.comment;

            numCylinder.Maximum = disk.cylinders - 1;
            numCylinder.Value = 0;
            numHead.Maximum = disk.heads - 1;
            numHead.Value = 0;
            numSector.Minimum = 0;
            numSector.Maximum = disk.getNumSectors(0, 0) + 1;
            numSector.Value = 1;

            updateSectorDisplay();
        }

        private void numCylinder_ValueChanged(object sender, EventArgs e)
        {
                int s = disk.getNumSectors((byte)numCylinder.Value, (byte)numHead.Value);
                if (numSector.Value > s) numSector.Value = s;
                numSector.Maximum = s + 1;
                if (numSector.Value != numSector.Minimum) updateSectorDisplay();
          
        }

        private void numSector_ValueChanged(object sender, EventArgs e)
        {
            if (numSector.Value == numSector.Maximum)
            {
                if (numHead.Value < numHead.Maximum)
                {
                    numHead.Value++;
                    numSector.Value = numSector.Minimum + 1;
                }
                else if (numCylinder.Value < numCylinder.Maximum)
                {
                    numHead.Value = numHead.Minimum;
                    numCylinder.Value++;
                    numSector.Value = numSector.Minimum + 1;
                }
                else
                {
                    numSector.Value--;
                }
            }

            if (numSector.Value == numSector.Minimum)
            {
                if (numHead.Value > numHead.Minimum)
                {
                    numHead.Value--;
                    numSector.Value = numSector.Maximum - 1;
                }
                else if (numCylinder.Value > numCylinder.Minimum)
                {
                    numHead.Value = numHead.Maximum;
                    numCylinder.Value--;
                    numSector.Value = numSector.Maximum - 1;
                }
                else
                {
                    numSector.Value++;
                }
            }

            updateSectorDisplay();
        }

        private void updateSectorDisplay()
        {
            byte cyl = (byte)numCylinder.Value;
            byte head = (byte)numHead.Value;
            byte sec = (byte)numSector.Value;

            ImageDisk.Sector sector = disk.getSector(cyl, head, sec);

            hexBox1.ByteProvider = new Be.Windows.Forms.DynamicByteProvider(sector.data);

            lblSectorInfo.Text = sector.deleted ? "Deleted" : "Not deleted";
            lblSectorInfo.Text += sector.error ? ", error" : ", no error";
            lblSectorInfo.Text += ", " + disk.getModeString(cyl, head);
            lblSectorInfo.Text += ", " + sector.data.Length.ToString() + " bytes.";
        }
    }
}
