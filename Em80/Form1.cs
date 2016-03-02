using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace em80
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

            hexMemory.Select(emulatedSystem.cpu.registers.pc,1);
        }

        Be.Windows.Forms.DynamicByteProvider provMem;

        private void updateMemoryFromHex()
        {
            emulatedSystem.memory.bytes = provMem.Bytes.ToArray();
        }

        private void resetSystem()
        {
            emulatedSystem.cpu.reset();
            updateRegisterDisplay();
        }

        private void frmPanel_Load(object sender, EventArgs e)
        {
            resetSystem();
            emulatedSystem.memory.init();
            provMem = new Be.Windows.Forms.DynamicByteProvider(emulatedSystem.memory.bytes);
            hexMemory.ByteProvider = provMem;
        }

        private void btnStep_Click(object sender, EventArgs e)
        {
            if (emulatedSystem.cpu.running)
            {
                emulatedSystem.cpu.running = false;
                return;
            }

            if (provMem.HasChanges())
            {
                emulatedSystem.memory.bytes = provMem.Bytes.ToArray();
                provMem.ApplyChanges();
            }

            emulatedSystem.cpu.cycle();

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

            emulatedSystem.cpu.running = true;
            btnRunStop.Enabled = false;
            btnStep.Text = "&Stop";

            while (emulatedSystem.cpu.running)
            {
                emulatedSystem.cpu.cycle();
                Application.DoEvents();
            }

            provMem = new Be.Windows.Forms.DynamicByteProvider(emulatedSystem.memory.bytes);
            hexMemory.ByteProvider = provMem;
            updateRegisterDisplay();

            btnRunStop.Enabled = true;
            btnStep.Text = "&Step";
        }
    }
}
