﻿using System;
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

        int instructions;

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
            resetCPU();
            EmulatedSystem.memory.clear();

            updateMemDisplay();
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

        private void updateMemDisplay()
        {
            provMem = new Be.Windows.Forms.DynamicByteProvider(EmulatedSystem.memory.getArray());
            hexMemory.ByteProvider = provMem;
        }

        private void Step()
        {
            EmulatedSystem.cpu.exec();

            updateMemDisplay();
            updateRegisterDisplay();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            resetCPU();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            EmulatedSystem.memory.clear();
            updateMemDisplay();
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

            ushort breakpoint = Convert.ToUInt16(txtBreakpoint.Text, 16);

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
            txtBreakpoint.ReadOnly = true;
            hexMemory.ReadOnly = true;
            btnRunStop.Enabled = false;
            btnStep.Text = "&Stop";
            lblInstruction.Text = "(running)";
            timerIPS.Enabled = true;

            while (EmulatedSystem.cpu.running)
            {
                if (trackBarCycleDelay.Value == 0)
                {
                    if (checkBreakpoint.Checked && EmulatedSystem.cpu.registers.pc == breakpoint) break;
                    EmulatedSystem.cpu.exec();
                    instructions++;
                    Application.DoEvents();
                }
                else
                {
                    Step();
                    instructions++;
                    System.Threading.Thread.Sleep(trackBarCycleDelay.Value);
                    Application.DoEvents();
                }
            }

            try {
                EmulatedSystem.cpu.running = false;
                timerIPS.Enabled = false;
                Text = "em80";
                updateMemDisplay();
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
                txtBreakpoint.ReadOnly = false;
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

                        updateMemDisplay();
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
            if ((e.KeyChar > 47 && e.KeyChar < 58) || (e.KeyChar > 64 && e.KeyChar < 71) || e.KeyChar == 8)   // 0-9, A-F, backspace
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

        private void UncheckAllChildMenuItems (ToolStripMenuItem parentMenuItem)
        {
            foreach (ToolStripMenuItem item in parentMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
        }

        private void trackBarCycleDelay_ValueChanged(object sender, EventArgs e)
        {
            if (EmulatedSystem.cpu.running && trackBarCycleDelay.Value == 0) lblInstruction.Text = "(running)";
        }

        private void timerIPS_Tick(object sender, EventArgs e)
        {
            Text = "em80 " + instructions.ToString() + "ips";
            instructions = 0;
        }

        private void loadDiskImage(int drive)
        {
            openFileDialog2.ShowDialog();

            try
            {
                EmulatedSystem.DiskJockey.insertDisk(drive, openFileDialog2.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading image");
            }
        }

        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            loadDiskImage(0);
        }

        private void loadToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            loadDiskImage(1);
        }

        private void loadToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            loadDiskImage(2);
        }

        private void loadToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            loadDiskImage(3);
        }

        private void port1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UncheckAllChildMenuItems(sourceToolStripMenuItem);
            port1ToolStripMenuItem.Checked = true;
            formConsole.setConsolePort(0);
        }

        private void port2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UncheckAllChildMenuItems(sourceToolStripMenuItem);
            port2ToolStripMenuItem.Checked = true;
            formConsole.setConsolePort(1);
        }

        private void port3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UncheckAllChildMenuItems(sourceToolStripMenuItem);
            port3ToolStripMenuItem.Checked = true;
            formConsole.setConsolePort(2);
        }

        private void port4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UncheckAllChildMenuItems(sourceToolStripMenuItem);
            port3ToolStripMenuItem.Checked = true;
            formConsole.setConsolePort(3);
        }

        private void iMSAIPortAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UncheckAllChildMenuItems(port1ToolStripMenuItem1);
            iMSAIPortAToolStripMenuItem.Checked = true;
            EmulatedSystem.sioPorts[0].setType(EmulatedSystem.sio.sioType.IMSAI_A);
        }

        private void iMSAIPortBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UncheckAllChildMenuItems(port1ToolStripMenuItem1);
            iMSAIPortBToolStripMenuItem.Checked = true;
            EmulatedSystem.sioPorts[0].setType(EmulatedSystem.sio.sioType.IMSAI_B);
        }

        private void altairSIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UncheckAllChildMenuItems(port1ToolStripMenuItem1);
            altairSIOToolStripMenuItem.Checked = true;
            EmulatedSystem.sioPorts[0].setType(EmulatedSystem.sio.sioType.Altair);
        }

        private void diskJockeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UncheckAllChildMenuItems(port1ToolStripMenuItem1);
            diskJockeyToolStripMenuItem.Checked = true;
            EmulatedSystem.sioPorts[0].setType(EmulatedSystem.sio.sioType.DiskJockey);
        }

        private void rubeCronUSBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UncheckAllChildMenuItems(port1ToolStripMenuItem1);
            rubeCronUSBToolStripMenuItem.Checked = true;
            EmulatedSystem.sioPorts[0].setType(EmulatedSystem.sio.sioType.RubeCronUSB);
        }

        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UncheckAllChildMenuItems(port1ToolStripMenuItem1);
            noneToolStripMenuItem.Checked = true;
            EmulatedSystem.sioPorts[0].setType(EmulatedSystem.sio.sioType.None);
        }

        private void e000ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmulatedSystem.DiskJockey.Init(0xe000);
            attachDiskJockeyToolStripMenuItem.Enabled = false;
            drive0ToolStripMenuItem.Enabled = true;
            drive1ToolStripMenuItem.Enabled = true;
            drive2ToolStripMenuItem.Enabled = true;
            drive3ToolStripMenuItem.Enabled = true;
            updateMemDisplay();
        }

        private void f800ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmulatedSystem.DiskJockey.Init(0xf800);
            attachDiskJockeyToolStripMenuItem.Enabled = false;
            drive0ToolStripMenuItem.Enabled = true;
            drive1ToolStripMenuItem.Enabled = true;
            drive2ToolStripMenuItem.Enabled = true;
            drive3ToolStripMenuItem.Enabled = true;
            updateMemDisplay();
        }

        private void noneToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UncheckAllChildMenuItems(port2ToolStripMenuItem1);
            noneToolStripMenuItem1.Checked = true;
            EmulatedSystem.sioPorts[1].setType(EmulatedSystem.sio.sioType.None);
        }

        private void iMSAISIOPortAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UncheckAllChildMenuItems(port2ToolStripMenuItem1);
            iMSAISIOPortAToolStripMenuItem.Checked = true;
            EmulatedSystem.sioPorts[1].setType(EmulatedSystem.sio.sioType.IMSAI_A);
        }

        private void iMSAISIOPortBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UncheckAllChildMenuItems(port2ToolStripMenuItem1);
            iMSAISIOPortBToolStripMenuItem.Checked = true;
            EmulatedSystem.sioPorts[1].setType(EmulatedSystem.sio.sioType.IMSAI_B);
        }

        private void altairSIOToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UncheckAllChildMenuItems(port2ToolStripMenuItem1);
            altairSIOToolStripMenuItem1.Checked = true;
            EmulatedSystem.sioPorts[1].setType(EmulatedSystem.sio.sioType.Altair);
        }

        private void diskJockeyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UncheckAllChildMenuItems(port2ToolStripMenuItem1);
            diskJockeyToolStripMenuItem1.Checked= true;
            EmulatedSystem.sioPorts[1].setType(EmulatedSystem.sio.sioType.DiskJockey);
        }

        private void rubeCronUSBToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UncheckAllChildMenuItems(port2ToolStripMenuItem1);
            rubeCronUSBToolStripMenuItem1.Checked = true;
            EmulatedSystem.sioPorts[1].setType(EmulatedSystem.sio.sioType.RubeCronUSB);
        }

        private void noneToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            UncheckAllChildMenuItems(port3ToolStripMenuItem1);
            noneToolStripMenuItem2.Checked = true;
            EmulatedSystem.sioPorts[2].setType(EmulatedSystem.sio.sioType.None);
        }

        private void iMSAISIOPortAToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UncheckAllChildMenuItems(port3ToolStripMenuItem1);
            iMSAISIOPortAToolStripMenuItem1.Checked = true;
            EmulatedSystem.sioPorts[2].setType(EmulatedSystem.sio.sioType.IMSAI_A);
        }

        private void iMSAISIOPortBToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UncheckAllChildMenuItems(port3ToolStripMenuItem1);
            iMSAISIOPortBToolStripMenuItem1.Checked = true;
            EmulatedSystem.sioPorts[2].setType(EmulatedSystem.sio.sioType.IMSAI_B);
        }

        private void altairSIOToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            UncheckAllChildMenuItems(port3ToolStripMenuItem1);
            altairSIOToolStripMenuItem2.Checked = true;
            EmulatedSystem.sioPorts[2].setType(EmulatedSystem.sio.sioType.Altair);
        }

        private void diskJockeyToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            UncheckAllChildMenuItems(port3ToolStripMenuItem1);
            diskJockeyToolStripMenuItem2.Checked = true;
            EmulatedSystem.sioPorts[2].setType(EmulatedSystem.sio.sioType.DiskJockey);
        }

        private void rubeCronUSBToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            UncheckAllChildMenuItems(port3ToolStripMenuItem1);
            rubeCronUSBToolStripMenuItem2.Checked = true;
            EmulatedSystem.sioPorts[2].setType(EmulatedSystem.sio.sioType.RubeCronUSB);
        }

        private void noneToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            UncheckAllChildMenuItems(port4ToolStripMenuItem1);
            noneToolStripMenuItem3.Checked = true;
            EmulatedSystem.sioPorts[3].setType(EmulatedSystem.sio.sioType.None);
        }

        private void iMSAISIOPortAToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            UncheckAllChildMenuItems(port4ToolStripMenuItem1);
            iMSAISIOPortAToolStripMenuItem2.Checked = true;
            EmulatedSystem.sioPorts[3].setType(EmulatedSystem.sio.sioType.IMSAI_A);
        }

        private void iMSAISIOPortBToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            UncheckAllChildMenuItems(port4ToolStripMenuItem1);
            iMSAISIOPortBToolStripMenuItem2.Checked = true;
            EmulatedSystem.sioPorts[3].setType(EmulatedSystem.sio.sioType.IMSAI_B);
        }

        private void altairSIOToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            UncheckAllChildMenuItems(port4ToolStripMenuItem1);
            altairSIOToolStripMenuItem3.Checked = true;
            EmulatedSystem.sioPorts[3].setType(EmulatedSystem.sio.sioType.Altair);
        }

        private void diskJockeyToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            UncheckAllChildMenuItems(port4ToolStripMenuItem1);
            diskJockeyToolStripMenuItem3.Checked = true;
            EmulatedSystem.sioPorts[3].setType(EmulatedSystem.sio.sioType.DiskJockey);
        }

        private void rubeCronUSBToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            UncheckAllChildMenuItems(port4ToolStripMenuItem1);
            rubeCronUSBToolStripMenuItem3.Checked = true;
            EmulatedSystem.sioPorts[3].setType(EmulatedSystem.sio.sioType.RubeCronUSB);
        }
    }
}
