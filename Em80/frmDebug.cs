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
        frmConsole formConsole = new frmConsole();

        public frmDebug()
        {
            InitializeComponent();
        }

        private void updateRegisterDisplay()
        {
            txtRegA.Text = EmulatedSystem.cpu.registers.a.ToString("X2");
            txtRegB.Text = EmulatedSystem.cpu.registers.b.ToString("X2");
            txtRegC.Text = EmulatedSystem.cpu.registers.c.ToString("X2");
            txtRegD.Text = EmulatedSystem.cpu.registers.d.ToString("X2");
            txtRegE.Text = EmulatedSystem.cpu.registers.e.ToString("X2");
            txtRegF.Text = EmulatedSystem.cpu.registers.f.ToString("X2");
            txtRegH.Text = EmulatedSystem.cpu.registers.h.ToString("X2");
            txtRegL.Text = EmulatedSystem.cpu.registers.l.ToString("X2");
            txtRegPC.Text = EmulatedSystem.cpu.registers.pc.ToString("X4");
            txtRegSP.Text = EmulatedSystem.cpu.registers.sp.ToString("X4");

            lblFlagC.Enabled = EmulatedSystem.cpu.flags.c;
            lblFlagA.Enabled = EmulatedSystem.cpu.flags.a;
            lblFlagI.Enabled = EmulatedSystem.cpu.flags.i;
            lblFlagP.Enabled = EmulatedSystem.cpu.flags.p;
            lblFlagS.Enabled = EmulatedSystem.cpu.flags.s;
            lblFlagZ.Enabled = EmulatedSystem.cpu.flags.z;

            hexMemory.Select(EmulatedSystem.cpu.registers.pc, i8080Assembly.currentInstructionLength);

            lblInstruction.Text = i8080Assembly.disassembleCurrentInstruction();
        }

        Be.Windows.Forms.DynamicByteProvider provMem;

        private void updateMemoryFromHex()
        {
            if (provMem.HasChanges())
            {
                EmulatedSystem.memory.copyIn(0, provMem.Bytes.ToArray());
                provMem.ApplyChanges();
            }
        }

        private void resetCPU()
        {
            EmulatedSystem.cpu.running = false;
            EmulatedSystem.cpu.reset();
            updateRegisterDisplay();
        }

        private void frmDebug_Load(object sender, EventArgs e)
        {
            EmulatedSystem.DiskJockey.Init(0xf800);
            EmulatedSystem.sio.Init();
            resetCPU();
            EmulatedSystem.memory.clear();

            provMem = new Be.Windows.Forms.DynamicByteProvider(EmulatedSystem.memory.getArray());
            hexMemory.ByteProvider = provMem;
            hexMemory.Select();      
        }

        private void btnStep_Click(object sender, EventArgs e)
        {
            if (EmulatedSystem.cpu.running)
            {
                EmulatedSystem.cpu.running = false;
                return;
            }

            updateMemoryFromHex();
            updateRegistersFromTextBoxes();

            Step();
        }

        private void Step()
        {
            EmulatedSystem.cpu.exec();

            provMem = new Be.Windows.Forms.DynamicByteProvider(EmulatedSystem.memory.getArray());
            hexMemory.ByteProvider = provMem;
            updateRegisterDisplay();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetCPU();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            EmulatedSystem.memory.clear();
            provMem = new Be.Windows.Forms.DynamicByteProvider(EmulatedSystem.memory.getArray());
            hexMemory.ByteProvider = provMem;
        }

        private void btnRunStop_Click(object sender, EventArgs e)
        {
            if (provMem.HasChanges())
            {
                EmulatedSystem.memory.copyIn(0, provMem.Bytes.ToArray());
                provMem.ApplyChanges();
            }

            updateMemoryFromHex();
            updateRegistersFromTextBoxes();

            EmulatedSystem.cpu.running = true;
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

            while (EmulatedSystem.cpu.running)
            {
                if (trackBarCycleDelay.Value == 0)
                {
                    EmulatedSystem.cpu.exec();
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
                provMem = new Be.Windows.Forms.DynamicByteProvider(EmulatedSystem.memory.getArray());
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
            formConsole.Show();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formConsole.ClearConsole();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                using (frmHexOrBin f = new frmHexOrBin(openFileDialog1.FileName))
                {
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        if (f.checkClear.Checked) EmulatedSystem.memory.clear();

                        try
                        {
                            if (f.radioBin.Checked)
                            {

                                byte[] bytes = System.IO.File.ReadAllBytes(openFileDialog1.FileName);
                                EmulatedSystem.memory.copyIn(Convert.ToInt32(f.textOffset.Text, 16), bytes);
                            }
                            else if (f.radioHex.Checked)
                            {
                                Hex.LoadIntoMem(new FileStream(openFileDialog1.FileName, FileMode.Open), f.checkROM.Checked);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error opening file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        provMem = new Be.Windows.Forms.DynamicByteProvider(EmulatedSystem.memory.getArray());
                        hexMemory.ByteProvider = provMem;
                        updateRegisterDisplay();
                    }
                }
            }
        }

        private void frmDebug_FormClosing(object sender, FormClosingEventArgs e)
        {
            EmulatedSystem.cpu.running = false;
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
            EmulatedSystem.cpu.registers.a = Convert.ToByte(txtRegA.Text, 16);
            EmulatedSystem.cpu.registers.b = Convert.ToByte(txtRegB.Text, 16);
            EmulatedSystem.cpu.registers.c = Convert.ToByte(txtRegC.Text, 16);
            EmulatedSystem.cpu.registers.d = Convert.ToByte(txtRegD.Text, 16);
            EmulatedSystem.cpu.registers.e = Convert.ToByte(txtRegE.Text, 16);
            EmulatedSystem.cpu.registers.f = Convert.ToByte(txtRegF.Text, 16);
            EmulatedSystem.cpu.registers.h = Convert.ToByte(txtRegH.Text, 16);
            EmulatedSystem.cpu.registers.l = Convert.ToByte(txtRegL.Text, 16);
            EmulatedSystem.cpu.registers.pc = Convert.ToUInt16(txtRegPC.Text, 16);
            EmulatedSystem.cpu.registers.sp = Convert.ToUInt16(txtRegSP.Text, 16);
            updateRegisterDisplay();
        }

        private void memoryMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(EmulatedSystem.memory.getMap(), "Memory Map");
        }

        private void sIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sIOToolStripMenuItem.Checked = true;
            diskJockeyToolStripMenuItem.Checked = false;
            noneToolStripMenuItem.Checked = false;
            formConsole.setConsolePort(frmConsole.consolePort.sio);
        }

        private void diskJockeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sIOToolStripMenuItem.Checked = false;
            diskJockeyToolStripMenuItem.Checked = true;
            noneToolStripMenuItem.Checked = false;
            formConsole.setConsolePort(frmConsole.consolePort.dj);
        }

        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sIOToolStripMenuItem.Checked = false;
            diskJockeyToolStripMenuItem.Checked = false;
            noneToolStripMenuItem.Checked = true;
            formConsole.setConsolePort(frmConsole.consolePort.none);
        }

        private void trackBarCycleDelay_ValueChanged(object sender, EventArgs e)
        {
            if (EmulatedSystem.cpu.running && trackBarCycleDelay.Value == 0) lblInstruction.Text = "(running)";
        }
    }
}
