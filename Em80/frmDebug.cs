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
    public partial class frmDebug : Form
    {
        public frmDebug()
        {
            InitializeComponent();
        }

        private void updateRegisterDisplay()
        {
            txtRegA.Text = emulatedSystem.cpu.registers.a.ToString("X2");
            txtRegB.Text = emulatedSystem.cpu.registers.b.ToString("X2");
            txtRegC.Text = emulatedSystem.cpu.registers.c.ToString("X2");
            txtRegD.Text = emulatedSystem.cpu.registers.d.ToString("X2");
            txtRegE.Text = emulatedSystem.cpu.registers.e.ToString("X2");
            txtRegF.Text = emulatedSystem.cpu.registers.f.ToString("X2");
            txtRegH.Text = emulatedSystem.cpu.registers.h.ToString("X2");
            txtRegL.Text = emulatedSystem.cpu.registers.l.ToString("X2");
            txtRegPC.Text = emulatedSystem.cpu.registers.pc.ToString("X4");
            txtRegSP.Text = emulatedSystem.cpu.registers.sp.ToString("X4");

            lblFlagC.Enabled = emulatedSystem.cpu.flags.c;
            lblFlagA.Enabled = emulatedSystem.cpu.flags.a;
            lblFlagI.Enabled = emulatedSystem.cpu.flags.i;
            lblFlagP.Enabled = emulatedSystem.cpu.flags.p;
            lblFlagS.Enabled = emulatedSystem.cpu.flags.s;
            lblFlagZ.Enabled = emulatedSystem.cpu.flags.z;

            hexMemory.Select(emulatedSystem.cpu.registers.pc, Assembly.currentInstructionLength);

            lblInstruction.Text = Assembly.disassembleCurrentInstruction();
        }

        Be.Windows.Forms.DynamicByteProvider provMem;

        private void updateMemoryFromHex()
        {
            if (provMem.HasChanges())
            {
                emulatedSystem.memory.bytes = provMem.Bytes.ToArray();
                provMem.ApplyChanges();
            }
        }

        private void resetSystem()
        {
            emulatedSystem.cpu.running = false;
            emulatedSystem.cpu.reset();
            updateRegisterDisplay();
        }

        private void frmDebug_Load(object sender, EventArgs e)
        {
            resetSystem();
            emulatedSystem.memory.init();
            provMem = new Be.Windows.Forms.DynamicByteProvider(emulatedSystem.memory.bytes);
            hexMemory.ByteProvider = provMem;
            hexMemory.Select();
        }

        private void btnStep_Click(object sender, EventArgs e)
        {
            if (emulatedSystem.cpu.running)
            {
                emulatedSystem.cpu.running = false;
                return;
            }

            updateMemoryFromHex();
            updateRegistersFromTextBoxes();

            Step();
        }

        private void Step()
        {
            emulatedSystem.cpu.exec();

            provMem = new Be.Windows.Forms.DynamicByteProvider(emulatedSystem.memory.bytes);
            hexMemory.ByteProvider = provMem;
            updateRegisterDisplay();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetSystem();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            emulatedSystem.memory.init();
            provMem = new Be.Windows.Forms.DynamicByteProvider(emulatedSystem.memory.bytes);
            hexMemory.ByteProvider = provMem;
        }

        private void btnRunStop_Click(object sender, EventArgs e)
        {
            if (provMem.HasChanges())
            {
                emulatedSystem.memory.bytes = provMem.Bytes.ToArray();
                provMem.ApplyChanges();
            }

            updateMemoryFromHex();
            updateRegistersFromTextBoxes();

            emulatedSystem.cpu.running = true;
            txtRegA.ReadOnly = true;
            txtRegB.ReadOnly = true;
            txtRegC.ReadOnly = true;
            txtRegD.ReadOnly = true;
            txtRegE.ReadOnly = true;
            txtRegF.ReadOnly = true;
            txtRegH.ReadOnly = true;
            txtRegL.ReadOnly = true;
            txtRegPC.ReadOnly = true;
            txtRegSP.ReadOnly = true;
            hexMemory.ReadOnly = true;
            btnRunStop.Enabled = false;
            btnStep.Text = "&Stop";
            lblInstruction.Text = "(running)";

            while (emulatedSystem.cpu.running)
            {
                if (trackBarCycleDelay.Value == 0)
                {
                    emulatedSystem.cpu.exec();
                    Application.DoEvents();
                }
                else
                {
                    Step();
                    System.Threading.Thread.Sleep(trackBarCycleDelay.Value);
                    Application.DoEvents();
                }
            }

            try {
                provMem = new Be.Windows.Forms.DynamicByteProvider(emulatedSystem.memory.bytes);
                hexMemory.ByteProvider = provMem;
                updateRegisterDisplay();

                txtRegA.ReadOnly = false;
                txtRegB.ReadOnly = false;
                txtRegC.ReadOnly = false;
                txtRegD.ReadOnly = false;
                txtRegE.ReadOnly = false;
                txtRegF.ReadOnly = false;
                txtRegH.ReadOnly = false;
                txtRegL.ReadOnly = false;
                txtRegPC.ReadOnly = false;
                txtRegSP.ReadOnly = false;
                hexMemory.ReadOnly = false;
                btnRunStop.Enabled = true;
                btnStep.Text = "&Step";
            }
            catch (ObjectDisposedException)
            {
                Application.Exit();
            }
        }

        private void trackBarCycleDelay_Scroll(object sender, EventArgs e)
        {
            lblCycleDelay.Text = "Cycle Delay: " + trackBarCycleDelay.Value.ToString() + "ms";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            emulatedSystem.io.formConsole.Show();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            emulatedSystem.io.formConsole.ClearConsole();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                using (frmHexOrBin f = new frmHexOrBin(openFileDialog1.FileName))
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        if (f.checkClear.Checked) emulatedSystem.memory.init();

                        if (f.radioBin.Checked)
                        {
                            try
                            {
                                byte[] bytes = System.IO.File.ReadAllBytes(openFileDialog1.FileName);
                                bytes.CopyTo(emulatedSystem.memory.bytes, Convert.ToInt32(f.textOffset.Text, 16));
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error opening file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else if (f.radioHex.Checked)
                        {
                            Hex.LoadIntoMem(openFileDialog1.FileName);
                        }
                    }

                    provMem = new Be.Windows.Forms.DynamicByteProvider(emulatedSystem.memory.bytes);
                    hexMemory.ByteProvider = provMem;
                    updateRegisterDisplay();

                }
            }
        }

        private void frmDebug_FormClosing(object sender, FormClosingEventArgs e)
        {
            emulatedSystem.cpu.running = false;
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

        private void updateRegistersFromTextBoxes()
        {
            emulatedSystem.cpu.registers.a = Convert.ToByte(txtRegA.Text, 16);
            emulatedSystem.cpu.registers.b = Convert.ToByte(txtRegB.Text, 16);
            emulatedSystem.cpu.registers.c = Convert.ToByte(txtRegC.Text, 16);
            emulatedSystem.cpu.registers.d = Convert.ToByte(txtRegD.Text, 16);
            emulatedSystem.cpu.registers.e = Convert.ToByte(txtRegE.Text, 16);
            emulatedSystem.cpu.registers.f = Convert.ToByte(txtRegF.Text, 16);
            emulatedSystem.cpu.registers.h = Convert.ToByte(txtRegH.Text, 16);
            emulatedSystem.cpu.registers.l = Convert.ToByte(txtRegL.Text, 16);
            emulatedSystem.cpu.registers.pc = Convert.ToUInt16(txtRegPC.Text, 16);
            emulatedSystem.cpu.registers.sp = Convert.ToUInt16(txtRegSP.Text, 16);
            updateRegisterDisplay();
        }
    }
}
