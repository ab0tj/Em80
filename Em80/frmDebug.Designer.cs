namespace Em80
{
    partial class frmDebug
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDebug));
            this.groupRegisters = new System.Windows.Forms.GroupBox();
            this.lblFlagC = new System.Windows.Forms.Label();
            this.lblFlagP = new System.Windows.Forms.Label();
            this.lblFlagA = new System.Windows.Forms.Label();
            this.lblFlagI = new System.Windows.Forms.Label();
            this.lblFlagZ = new System.Windows.Forms.Label();
            this.lblFlagS = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRegPC = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRegSP = new System.Windows.Forms.TextBox();
            this.txtRegL = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRegH = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRegE = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRegD = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRegF = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRegC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRegB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRegA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupMemory = new System.Windows.Forms.GroupBox();
            this.hexMemory = new Be.Windows.Forms.HexBox();
            this.btnStep = new System.Windows.Forms.Button();
            this.btnRunStop = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.trackBarCycleDelay = new System.Windows.Forms.TrackBar();
            this.lblCycleDelay = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memoryClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.memoryMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drive0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ejectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drive1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ejectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.drive2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ejectToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.drive3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.ejectToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblInstruction = new System.Windows.Forms.Label();
            this.timerIPS = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBreakpoint = new System.Windows.Forms.TextBox();
            this.checkBreakpoint = new System.Windows.Forms.CheckBox();
            this.sourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.port1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.port2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.port3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.port4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.port1ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.port2ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.port3ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.port4ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.iMSAIPortAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iMSAIPortBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altairSIOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diskJockeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rubeCronUSBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iMSAISIOPortAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iMSAISIOPortBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altairSIOToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.diskJockeyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rubeCronUSBToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.noneToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.iMSAISIOPortAToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.iMSAISIOPortBToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.altairSIOToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.diskJockeyToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.rubeCronUSBToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.noneToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.iMSAISIOPortAToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.iMSAISIOPortBToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.altairSIOToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.diskJockeyToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.rubeCronUSBToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.noneToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.attachDiskJockeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.e000ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.f800ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupRegisters.SuspendLayout();
            this.groupMemory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCycleDelay)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupRegisters
            // 
            this.groupRegisters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupRegisters.Controls.Add(this.lblFlagC);
            this.groupRegisters.Controls.Add(this.lblFlagP);
            this.groupRegisters.Controls.Add(this.lblFlagA);
            this.groupRegisters.Controls.Add(this.lblFlagI);
            this.groupRegisters.Controls.Add(this.lblFlagZ);
            this.groupRegisters.Controls.Add(this.lblFlagS);
            this.groupRegisters.Controls.Add(this.label11);
            this.groupRegisters.Controls.Add(this.label10);
            this.groupRegisters.Controls.Add(this.txtRegPC);
            this.groupRegisters.Controls.Add(this.label9);
            this.groupRegisters.Controls.Add(this.txtRegSP);
            this.groupRegisters.Controls.Add(this.txtRegL);
            this.groupRegisters.Controls.Add(this.label8);
            this.groupRegisters.Controls.Add(this.txtRegH);
            this.groupRegisters.Controls.Add(this.label7);
            this.groupRegisters.Controls.Add(this.txtRegE);
            this.groupRegisters.Controls.Add(this.label6);
            this.groupRegisters.Controls.Add(this.txtRegD);
            this.groupRegisters.Controls.Add(this.label5);
            this.groupRegisters.Controls.Add(this.txtRegF);
            this.groupRegisters.Controls.Add(this.label4);
            this.groupRegisters.Controls.Add(this.txtRegC);
            this.groupRegisters.Controls.Add(this.label3);
            this.groupRegisters.Controls.Add(this.txtRegB);
            this.groupRegisters.Controls.Add(this.label2);
            this.groupRegisters.Controls.Add(this.txtRegA);
            this.groupRegisters.Controls.Add(this.label1);
            this.groupRegisters.Location = new System.Drawing.Point(667, 27);
            this.groupRegisters.Name = "groupRegisters";
            this.groupRegisters.Size = new System.Drawing.Size(149, 223);
            this.groupRegisters.TabIndex = 0;
            this.groupRegisters.TabStop = false;
            this.groupRegisters.Text = "Registers";
            // 
            // lblFlagC
            // 
            this.lblFlagC.AutoSize = true;
            this.lblFlagC.Location = new System.Drawing.Point(115, 198);
            this.lblFlagC.Name = "lblFlagC";
            this.lblFlagC.Size = new System.Drawing.Size(14, 13);
            this.lblFlagC.TabIndex = 26;
            this.lblFlagC.Text = "C";
            // 
            // lblFlagP
            // 
            this.lblFlagP.AutoSize = true;
            this.lblFlagP.Location = new System.Drawing.Point(95, 198);
            this.lblFlagP.Name = "lblFlagP";
            this.lblFlagP.Size = new System.Drawing.Size(14, 13);
            this.lblFlagP.TabIndex = 25;
            this.lblFlagP.Text = "P";
            // 
            // lblFlagA
            // 
            this.lblFlagA.AutoSize = true;
            this.lblFlagA.Location = new System.Drawing.Point(74, 198);
            this.lblFlagA.Name = "lblFlagA";
            this.lblFlagA.Size = new System.Drawing.Size(14, 13);
            this.lblFlagA.TabIndex = 24;
            this.lblFlagA.Text = "A";
            // 
            // lblFlagI
            // 
            this.lblFlagI.AutoSize = true;
            this.lblFlagI.Location = new System.Drawing.Point(58, 198);
            this.lblFlagI.Name = "lblFlagI";
            this.lblFlagI.Size = new System.Drawing.Size(10, 13);
            this.lblFlagI.TabIndex = 23;
            this.lblFlagI.Text = "I";
            // 
            // lblFlagZ
            // 
            this.lblFlagZ.AutoSize = true;
            this.lblFlagZ.Location = new System.Drawing.Point(38, 198);
            this.lblFlagZ.Name = "lblFlagZ";
            this.lblFlagZ.Size = new System.Drawing.Size(14, 13);
            this.lblFlagZ.TabIndex = 22;
            this.lblFlagZ.Text = "Z";
            // 
            // lblFlagS
            // 
            this.lblFlagS.AutoSize = true;
            this.lblFlagS.Location = new System.Drawing.Point(18, 198);
            this.lblFlagS.Name = "lblFlagS";
            this.lblFlagS.Size = new System.Drawing.Size(14, 13);
            this.lblFlagS.TabIndex = 21;
            this.lblFlagS.Text = "S";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(57, 182);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Flags";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "PC";
            // 
            // txtRegPC
            // 
            this.txtRegPC.Location = new System.Drawing.Point(37, 150);
            this.txtRegPC.MaxLength = 4;
            this.txtRegPC.Name = "txtRegPC";
            this.txtRegPC.Size = new System.Drawing.Size(92, 20);
            this.txtRegPC.TabIndex = 10;
            this.txtRegPC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRegPC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateHexInput);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "SP";
            // 
            // txtRegSP
            // 
            this.txtRegSP.Location = new System.Drawing.Point(37, 124);
            this.txtRegSP.MaxLength = 4;
            this.txtRegSP.Name = "txtRegSP";
            this.txtRegSP.Size = new System.Drawing.Size(92, 20);
            this.txtRegSP.TabIndex = 9;
            this.txtRegSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRegSP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateHexInput);
            // 
            // txtRegL
            // 
            this.txtRegL.Location = new System.Drawing.Point(99, 98);
            this.txtRegL.MaxLength = 2;
            this.txtRegL.Name = "txtRegL";
            this.txtRegL.Size = new System.Drawing.Size(30, 20);
            this.txtRegL.TabIndex = 8;
            this.txtRegL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRegL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateHexInput);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(80, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "L";
            // 
            // txtRegH
            // 
            this.txtRegH.Location = new System.Drawing.Point(37, 98);
            this.txtRegH.MaxLength = 2;
            this.txtRegH.Name = "txtRegH";
            this.txtRegH.Size = new System.Drawing.Size(30, 20);
            this.txtRegH.TabIndex = 7;
            this.txtRegH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRegH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateHexInput);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "H";
            // 
            // txtRegE
            // 
            this.txtRegE.Location = new System.Drawing.Point(99, 72);
            this.txtRegE.MaxLength = 2;
            this.txtRegE.Name = "txtRegE";
            this.txtRegE.Size = new System.Drawing.Size(30, 20);
            this.txtRegE.TabIndex = 6;
            this.txtRegE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRegE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateHexInput);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(79, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "E";
            // 
            // txtRegD
            // 
            this.txtRegD.Location = new System.Drawing.Point(37, 72);
            this.txtRegD.MaxLength = 2;
            this.txtRegD.Name = "txtRegD";
            this.txtRegD.Size = new System.Drawing.Size(30, 20);
            this.txtRegD.TabIndex = 5;
            this.txtRegD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRegD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateHexInput);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "D";
            // 
            // txtRegF
            // 
            this.txtRegF.Location = new System.Drawing.Point(99, 19);
            this.txtRegF.MaxLength = 2;
            this.txtRegF.Name = "txtRegF";
            this.txtRegF.Size = new System.Drawing.Size(30, 20);
            this.txtRegF.TabIndex = 2;
            this.txtRegF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRegF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateHexInput);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "F";
            // 
            // txtRegC
            // 
            this.txtRegC.Location = new System.Drawing.Point(99, 45);
            this.txtRegC.MaxLength = 2;
            this.txtRegC.Name = "txtRegC";
            this.txtRegC.Size = new System.Drawing.Size(30, 20);
            this.txtRegC.TabIndex = 4;
            this.txtRegC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRegC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateHexInput);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "C";
            // 
            // txtRegB
            // 
            this.txtRegB.Location = new System.Drawing.Point(37, 45);
            this.txtRegB.MaxLength = 2;
            this.txtRegB.Name = "txtRegB";
            this.txtRegB.Size = new System.Drawing.Size(30, 20);
            this.txtRegB.TabIndex = 3;
            this.txtRegB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRegB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateHexInput);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "B";
            // 
            // txtRegA
            // 
            this.txtRegA.Location = new System.Drawing.Point(37, 19);
            this.txtRegA.MaxLength = 2;
            this.txtRegA.Name = "txtRegA";
            this.txtRegA.Size = new System.Drawing.Size(30, 20);
            this.txtRegA.TabIndex = 1;
            this.txtRegA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRegA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateHexInput);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "A";
            // 
            // groupMemory
            // 
            this.groupMemory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupMemory.Controls.Add(this.hexMemory);
            this.groupMemory.Location = new System.Drawing.Point(12, 27);
            this.groupMemory.Name = "groupMemory";
            this.groupMemory.Size = new System.Drawing.Size(649, 422);
            this.groupMemory.TabIndex = 1;
            this.groupMemory.TabStop = false;
            this.groupMemory.Text = "Memory";
            // 
            // hexMemory
            // 
            this.hexMemory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hexMemory.ColumnInfoVisible = true;
            this.hexMemory.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.hexMemory.LineInfoVisible = true;
            this.hexMemory.Location = new System.Drawing.Point(6, 19);
            this.hexMemory.Name = "hexMemory";
            this.hexMemory.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexMemory.Size = new System.Drawing.Size(637, 397);
            this.hexMemory.StringViewVisible = true;
            this.hexMemory.TabIndex = 0;
            this.hexMemory.UseFixedBytesPerLine = true;
            this.hexMemory.VScrollBarVisible = true;
            // 
            // btnStep
            // 
            this.btnStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStep.Location = new System.Drawing.Point(667, 397);
            this.btnStep.Name = "btnStep";
            this.btnStep.Size = new System.Drawing.Size(75, 23);
            this.btnStep.TabIndex = 12;
            this.btnStep.Text = "&Step";
            this.btnStep.UseVisualStyleBackColor = true;
            this.btnStep.Click += new System.EventHandler(this.btnStep_Click);
            // 
            // btnRunStop
            // 
            this.btnRunStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunStop.Location = new System.Drawing.Point(744, 397);
            this.btnRunStop.Name = "btnRunStop";
            this.btnRunStop.Size = new System.Drawing.Size(75, 23);
            this.btnRunStop.TabIndex = 13;
            this.btnRunStop.Text = "&Run";
            this.btnRunStop.UseVisualStyleBackColor = true;
            this.btnRunStop.Click += new System.EventHandler(this.btnRunStop_Click);
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(667, 426);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 14;
            this.btnReset.Text = "R&eset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(744, 426);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "&Clr Mem";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // trackBarCycleDelay
            // 
            this.trackBarCycleDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarCycleDelay.Location = new System.Drawing.Point(672, 346);
            this.trackBarCycleDelay.Maximum = 1000;
            this.trackBarCycleDelay.Name = "trackBarCycleDelay";
            this.trackBarCycleDelay.Size = new System.Drawing.Size(144, 45);
            this.trackBarCycleDelay.TabIndex = 11;
            this.trackBarCycleDelay.TickFrequency = 100;
            this.trackBarCycleDelay.Scroll += new System.EventHandler(this.trackBarCycleDelay_Scroll);
            this.trackBarCycleDelay.ValueChanged += new System.EventHandler(this.trackBarCycleDelay_ValueChanged);
            // 
            // lblCycleDelay
            // 
            this.lblCycleDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCycleDelay.AutoSize = true;
            this.lblCycleDelay.Location = new System.Drawing.Point(701, 378);
            this.lblCycleDelay.Name = "lblCycleDelay";
            this.lblCycleDelay.Size = new System.Drawing.Size(88, 13);
            this.lblCycleDelay.TabIndex = 9;
            this.lblCycleDelay.Text = "Cycle Delay: 0ms";
            this.lblCycleDelay.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.consoleToolStripMenuItem,
            this.serialToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.diskToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(828, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.loadToolStripMenuItem.Text = "&Load...";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // consoleToolStripMenuItem
            // 
            this.consoleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.sourceToolStripMenuItem});
            this.consoleToolStripMenuItem.Name = "consoleToolStripMenuItem";
            this.consoleToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.consoleToolStripMenuItem.Text = "&Console";
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.showToolStripMenuItem.Text = "&Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clearToolStripMenuItem.Text = "&Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.memoryClearToolStripMenuItem,
            this.memoryMapToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.toolsToolStripMenuItem.Text = "&Memory";
            // 
            // memoryClearToolStripMenuItem
            // 
            this.memoryClearToolStripMenuItem.Name = "memoryClearToolStripMenuItem";
            this.memoryClearToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.memoryClearToolStripMenuItem.Text = "&Clear";
            this.memoryClearToolStripMenuItem.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.memoryClearToolStripMenuItem.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // memoryMapToolStripMenuItem
            // 
            this.memoryMapToolStripMenuItem.Name = "memoryMapToolStripMenuItem";
            this.memoryMapToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.memoryMapToolStripMenuItem.Text = "&Map";
            this.memoryMapToolStripMenuItem.Click += new System.EventHandler(this.memoryMapToolStripMenuItem_Click);
            // 
            // diskToolStripMenuItem
            // 
            this.diskToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.attachDiskJockeyToolStripMenuItem,
            this.drive0ToolStripMenuItem,
            this.drive1ToolStripMenuItem,
            this.drive2ToolStripMenuItem,
            this.drive3ToolStripMenuItem});
            this.diskToolStripMenuItem.Name = "diskToolStripMenuItem";
            this.diskToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.diskToolStripMenuItem.Text = "&Disk";
            // 
            // drive0ToolStripMenuItem
            // 
            this.drive0ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem1,
            this.ejectToolStripMenuItem});
            this.drive0ToolStripMenuItem.Enabled = false;
            this.drive0ToolStripMenuItem.Name = "drive0ToolStripMenuItem";
            this.drive0ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.drive0ToolStripMenuItem.Text = "Drive &0";
            // 
            // loadToolStripMenuItem1
            // 
            this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
            this.loadToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem1.Text = "&Load";
            this.loadToolStripMenuItem1.Click += new System.EventHandler(this.loadToolStripMenuItem1_Click);
            // 
            // ejectToolStripMenuItem
            // 
            this.ejectToolStripMenuItem.Name = "ejectToolStripMenuItem";
            this.ejectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ejectToolStripMenuItem.Text = "&Eject";
            // 
            // drive1ToolStripMenuItem
            // 
            this.drive1ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem2,
            this.ejectToolStripMenuItem1});
            this.drive1ToolStripMenuItem.Enabled = false;
            this.drive1ToolStripMenuItem.Name = "drive1ToolStripMenuItem";
            this.drive1ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.drive1ToolStripMenuItem.Text = "Drive &1";
            // 
            // loadToolStripMenuItem2
            // 
            this.loadToolStripMenuItem2.Name = "loadToolStripMenuItem2";
            this.loadToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem2.Text = "&Load";
            this.loadToolStripMenuItem2.Click += new System.EventHandler(this.loadToolStripMenuItem2_Click);
            // 
            // ejectToolStripMenuItem1
            // 
            this.ejectToolStripMenuItem1.Name = "ejectToolStripMenuItem1";
            this.ejectToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.ejectToolStripMenuItem1.Text = "&Eject";
            // 
            // drive2ToolStripMenuItem
            // 
            this.drive2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem3,
            this.ejectToolStripMenuItem2});
            this.drive2ToolStripMenuItem.Enabled = false;
            this.drive2ToolStripMenuItem.Name = "drive2ToolStripMenuItem";
            this.drive2ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.drive2ToolStripMenuItem.Text = "Drive &2";
            // 
            // loadToolStripMenuItem3
            // 
            this.loadToolStripMenuItem3.Name = "loadToolStripMenuItem3";
            this.loadToolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem3.Text = "&Load";
            this.loadToolStripMenuItem3.Click += new System.EventHandler(this.loadToolStripMenuItem3_Click);
            // 
            // ejectToolStripMenuItem2
            // 
            this.ejectToolStripMenuItem2.Name = "ejectToolStripMenuItem2";
            this.ejectToolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.ejectToolStripMenuItem2.Text = "&Eject";
            // 
            // drive3ToolStripMenuItem
            // 
            this.drive3ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem4,
            this.ejectToolStripMenuItem3});
            this.drive3ToolStripMenuItem.Enabled = false;
            this.drive3ToolStripMenuItem.Name = "drive3ToolStripMenuItem";
            this.drive3ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.drive3ToolStripMenuItem.Text = "Drive &3";
            // 
            // loadToolStripMenuItem4
            // 
            this.loadToolStripMenuItem4.Name = "loadToolStripMenuItem4";
            this.loadToolStripMenuItem4.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem4.Text = "&Load";
            this.loadToolStripMenuItem4.Click += new System.EventHandler(this.loadToolStripMenuItem4_Click);
            // 
            // ejectToolStripMenuItem3
            // 
            this.ejectToolStripMenuItem3.Name = "ejectToolStripMenuItem3";
            this.ejectToolStripMenuItem3.Size = new System.Drawing.Size(152, 22);
            this.ejectToolStripMenuItem3.Text = "&Eject";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Memory Image (*.hex, *.bin)|*.hex;*.bin|All Files|*.*";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblInstruction);
            this.groupBox1.Location = new System.Drawing.Point(667, 256);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(149, 35);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Current Instruction";
            // 
            // lblInstruction
            // 
            this.lblInstruction.AutoSize = true;
            this.lblInstruction.Location = new System.Drawing.Point(6, 16);
            this.lblInstruction.Name = "lblInstruction";
            this.lblInstruction.Size = new System.Drawing.Size(30, 13);
            this.lblInstruction.TabIndex = 0;
            this.lblInstruction.Text = "NOP";
            // 
            // timerIPS
            // 
            this.timerIPS.Interval = 1000;
            this.timerIPS.Tick += new System.EventHandler(this.timerIPS_Tick);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = "ImageDisk Image (*.IMD)|*.imd|All Files (*.*)|*.*";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtBreakpoint);
            this.groupBox2.Controls.Add(this.checkBreakpoint);
            this.groupBox2.Location = new System.Drawing.Point(667, 297);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(149, 43);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Breakpoint";
            // 
            // txtBreakpoint
            // 
            this.txtBreakpoint.Location = new System.Drawing.Point(37, 17);
            this.txtBreakpoint.MaxLength = 4;
            this.txtBreakpoint.Name = "txtBreakpoint";
            this.txtBreakpoint.Size = new System.Drawing.Size(92, 20);
            this.txtBreakpoint.TabIndex = 1;
            this.txtBreakpoint.Text = "0000";
            this.txtBreakpoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBreakpoint.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateHexInput);
            // 
            // checkBreakpoint
            // 
            this.checkBreakpoint.AutoSize = true;
            this.checkBreakpoint.Location = new System.Drawing.Point(13, 20);
            this.checkBreakpoint.Name = "checkBreakpoint";
            this.checkBreakpoint.Size = new System.Drawing.Size(15, 14);
            this.checkBreakpoint.TabIndex = 0;
            this.checkBreakpoint.UseVisualStyleBackColor = true;
            // 
            // sourceToolStripMenuItem
            // 
            this.sourceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.port1ToolStripMenuItem,
            this.port2ToolStripMenuItem,
            this.port3ToolStripMenuItem,
            this.port4ToolStripMenuItem});
            this.sourceToolStripMenuItem.Name = "sourceToolStripMenuItem";
            this.sourceToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sourceToolStripMenuItem.Text = "S&ource";
            // 
            // port1ToolStripMenuItem
            // 
            this.port1ToolStripMenuItem.Checked = true;
            this.port1ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.port1ToolStripMenuItem.Name = "port1ToolStripMenuItem";
            this.port1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.port1ToolStripMenuItem.Text = "Port &1";
            this.port1ToolStripMenuItem.Click += new System.EventHandler(this.port1ToolStripMenuItem_Click);
            // 
            // port2ToolStripMenuItem
            // 
            this.port2ToolStripMenuItem.Name = "port2ToolStripMenuItem";
            this.port2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.port2ToolStripMenuItem.Text = "Port &2";
            this.port2ToolStripMenuItem.Click += new System.EventHandler(this.port2ToolStripMenuItem_Click);
            // 
            // port3ToolStripMenuItem
            // 
            this.port3ToolStripMenuItem.Name = "port3ToolStripMenuItem";
            this.port3ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.port3ToolStripMenuItem.Text = "Port &3";
            this.port3ToolStripMenuItem.Click += new System.EventHandler(this.port3ToolStripMenuItem_Click);
            // 
            // port4ToolStripMenuItem
            // 
            this.port4ToolStripMenuItem.Name = "port4ToolStripMenuItem";
            this.port4ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.port4ToolStripMenuItem.Text = "Port &4";
            this.port4ToolStripMenuItem.Click += new System.EventHandler(this.port4ToolStripMenuItem_Click);
            // 
            // serialToolStripMenuItem
            // 
            this.serialToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.port1ToolStripMenuItem1,
            this.port2ToolStripMenuItem1,
            this.port3ToolStripMenuItem1,
            this.port4ToolStripMenuItem1});
            this.serialToolStripMenuItem.Name = "serialToolStripMenuItem";
            this.serialToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.serialToolStripMenuItem.Text = "&Serial";
            // 
            // port1ToolStripMenuItem1
            // 
            this.port1ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noneToolStripMenuItem,
            this.iMSAIPortAToolStripMenuItem,
            this.iMSAIPortBToolStripMenuItem,
            this.altairSIOToolStripMenuItem,
            this.diskJockeyToolStripMenuItem,
            this.rubeCronUSBToolStripMenuItem});
            this.port1ToolStripMenuItem1.Name = "port1ToolStripMenuItem1";
            this.port1ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.port1ToolStripMenuItem1.Text = "Port &1";
            // 
            // port2ToolStripMenuItem1
            // 
            this.port2ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noneToolStripMenuItem1,
            this.iMSAISIOPortAToolStripMenuItem,
            this.iMSAISIOPortBToolStripMenuItem,
            this.altairSIOToolStripMenuItem1,
            this.diskJockeyToolStripMenuItem1,
            this.rubeCronUSBToolStripMenuItem1});
            this.port2ToolStripMenuItem1.Name = "port2ToolStripMenuItem1";
            this.port2ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.port2ToolStripMenuItem1.Text = "Port &2";
            // 
            // port3ToolStripMenuItem1
            // 
            this.port3ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noneToolStripMenuItem2,
            this.iMSAISIOPortAToolStripMenuItem1,
            this.iMSAISIOPortBToolStripMenuItem1,
            this.altairSIOToolStripMenuItem2,
            this.diskJockeyToolStripMenuItem2,
            this.rubeCronUSBToolStripMenuItem2});
            this.port3ToolStripMenuItem1.Name = "port3ToolStripMenuItem1";
            this.port3ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.port3ToolStripMenuItem1.Text = "Port &3";
            // 
            // port4ToolStripMenuItem1
            // 
            this.port4ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noneToolStripMenuItem3,
            this.iMSAISIOPortAToolStripMenuItem2,
            this.iMSAISIOPortBToolStripMenuItem2,
            this.altairSIOToolStripMenuItem3,
            this.diskJockeyToolStripMenuItem3,
            this.rubeCronUSBToolStripMenuItem3});
            this.port4ToolStripMenuItem1.Name = "port4ToolStripMenuItem1";
            this.port4ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.port4ToolStripMenuItem1.Text = "Port &4";
            // 
            // iMSAIPortAToolStripMenuItem
            // 
            this.iMSAIPortAToolStripMenuItem.Name = "iMSAIPortAToolStripMenuItem";
            this.iMSAIPortAToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.iMSAIPortAToolStripMenuItem.Text = "&IMSAI SIO Port A";
            this.iMSAIPortAToolStripMenuItem.Click += new System.EventHandler(this.iMSAIPortAToolStripMenuItem_Click);
            // 
            // iMSAIPortBToolStripMenuItem
            // 
            this.iMSAIPortBToolStripMenuItem.Name = "iMSAIPortBToolStripMenuItem";
            this.iMSAIPortBToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.iMSAIPortBToolStripMenuItem.Text = "I&MSAI SIO Port B";
            this.iMSAIPortBToolStripMenuItem.Click += new System.EventHandler(this.iMSAIPortBToolStripMenuItem_Click);
            // 
            // altairSIOToolStripMenuItem
            // 
            this.altairSIOToolStripMenuItem.Name = "altairSIOToolStripMenuItem";
            this.altairSIOToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.altairSIOToolStripMenuItem.Text = "&Altair SIO";
            this.altairSIOToolStripMenuItem.Click += new System.EventHandler(this.altairSIOToolStripMenuItem_Click);
            // 
            // diskJockeyToolStripMenuItem
            // 
            this.diskJockeyToolStripMenuItem.Name = "diskJockeyToolStripMenuItem";
            this.diskJockeyToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.diskJockeyToolStripMenuItem.Text = "&Disk Jockey";
            this.diskJockeyToolStripMenuItem.Click += new System.EventHandler(this.diskJockeyToolStripMenuItem_Click);
            // 
            // rubeCronUSBToolStripMenuItem
            // 
            this.rubeCronUSBToolStripMenuItem.Name = "rubeCronUSBToolStripMenuItem";
            this.rubeCronUSBToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.rubeCronUSBToolStripMenuItem.Text = "&RubeCron USB";
            this.rubeCronUSBToolStripMenuItem.Click += new System.EventHandler(this.rubeCronUSBToolStripMenuItem_Click);
            // 
            // noneToolStripMenuItem
            // 
            this.noneToolStripMenuItem.Checked = true;
            this.noneToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.noneToolStripMenuItem.Name = "noneToolStripMenuItem";
            this.noneToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.noneToolStripMenuItem.Text = "&None";
            this.noneToolStripMenuItem.Click += new System.EventHandler(this.noneToolStripMenuItem_Click);
            // 
            // iMSAISIOPortAToolStripMenuItem
            // 
            this.iMSAISIOPortAToolStripMenuItem.Name = "iMSAISIOPortAToolStripMenuItem";
            this.iMSAISIOPortAToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.iMSAISIOPortAToolStripMenuItem.Text = "&IMSAI SIO Port A";
            this.iMSAISIOPortAToolStripMenuItem.Click += new System.EventHandler(this.iMSAISIOPortAToolStripMenuItem_Click);
            // 
            // iMSAISIOPortBToolStripMenuItem
            // 
            this.iMSAISIOPortBToolStripMenuItem.Name = "iMSAISIOPortBToolStripMenuItem";
            this.iMSAISIOPortBToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.iMSAISIOPortBToolStripMenuItem.Text = "I&MSAI SIO Port B";
            this.iMSAISIOPortBToolStripMenuItem.Click += new System.EventHandler(this.iMSAISIOPortBToolStripMenuItem_Click);
            // 
            // altairSIOToolStripMenuItem1
            // 
            this.altairSIOToolStripMenuItem1.Name = "altairSIOToolStripMenuItem1";
            this.altairSIOToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.altairSIOToolStripMenuItem1.Text = "&Altair SIO";
            this.altairSIOToolStripMenuItem1.Click += new System.EventHandler(this.altairSIOToolStripMenuItem1_Click);
            // 
            // diskJockeyToolStripMenuItem1
            // 
            this.diskJockeyToolStripMenuItem1.Name = "diskJockeyToolStripMenuItem1";
            this.diskJockeyToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.diskJockeyToolStripMenuItem1.Text = "&Disk Jockey";
            this.diskJockeyToolStripMenuItem1.Click += new System.EventHandler(this.diskJockeyToolStripMenuItem1_Click);
            // 
            // rubeCronUSBToolStripMenuItem1
            // 
            this.rubeCronUSBToolStripMenuItem1.Name = "rubeCronUSBToolStripMenuItem1";
            this.rubeCronUSBToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.rubeCronUSBToolStripMenuItem1.Text = "&RubeCron USB";
            this.rubeCronUSBToolStripMenuItem1.Click += new System.EventHandler(this.rubeCronUSBToolStripMenuItem1_Click);
            // 
            // noneToolStripMenuItem1
            // 
            this.noneToolStripMenuItem1.Checked = true;
            this.noneToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.noneToolStripMenuItem1.Name = "noneToolStripMenuItem1";
            this.noneToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.noneToolStripMenuItem1.Text = "&None";
            this.noneToolStripMenuItem1.Click += new System.EventHandler(this.noneToolStripMenuItem1_Click);
            // 
            // iMSAISIOPortAToolStripMenuItem1
            // 
            this.iMSAISIOPortAToolStripMenuItem1.Name = "iMSAISIOPortAToolStripMenuItem1";
            this.iMSAISIOPortAToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.iMSAISIOPortAToolStripMenuItem1.Text = "&IMSAI SIO Port A";
            this.iMSAISIOPortAToolStripMenuItem1.Click += new System.EventHandler(this.iMSAISIOPortAToolStripMenuItem1_Click);
            // 
            // iMSAISIOPortBToolStripMenuItem1
            // 
            this.iMSAISIOPortBToolStripMenuItem1.Name = "iMSAISIOPortBToolStripMenuItem1";
            this.iMSAISIOPortBToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.iMSAISIOPortBToolStripMenuItem1.Text = "I&MSAI SIO Port B";
            this.iMSAISIOPortBToolStripMenuItem1.Click += new System.EventHandler(this.iMSAISIOPortBToolStripMenuItem1_Click);
            // 
            // altairSIOToolStripMenuItem2
            // 
            this.altairSIOToolStripMenuItem2.Name = "altairSIOToolStripMenuItem2";
            this.altairSIOToolStripMenuItem2.Size = new System.Drawing.Size(162, 22);
            this.altairSIOToolStripMenuItem2.Text = "&Altair SIO";
            this.altairSIOToolStripMenuItem2.Click += new System.EventHandler(this.altairSIOToolStripMenuItem2_Click);
            // 
            // diskJockeyToolStripMenuItem2
            // 
            this.diskJockeyToolStripMenuItem2.Name = "diskJockeyToolStripMenuItem2";
            this.diskJockeyToolStripMenuItem2.Size = new System.Drawing.Size(162, 22);
            this.diskJockeyToolStripMenuItem2.Text = "&Disk Jockey";
            this.diskJockeyToolStripMenuItem2.Click += new System.EventHandler(this.diskJockeyToolStripMenuItem2_Click);
            // 
            // rubeCronUSBToolStripMenuItem2
            // 
            this.rubeCronUSBToolStripMenuItem2.Name = "rubeCronUSBToolStripMenuItem2";
            this.rubeCronUSBToolStripMenuItem2.Size = new System.Drawing.Size(162, 22);
            this.rubeCronUSBToolStripMenuItem2.Text = "&RubeCron USB";
            this.rubeCronUSBToolStripMenuItem2.Click += new System.EventHandler(this.rubeCronUSBToolStripMenuItem2_Click);
            // 
            // noneToolStripMenuItem2
            // 
            this.noneToolStripMenuItem2.Checked = true;
            this.noneToolStripMenuItem2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.noneToolStripMenuItem2.Name = "noneToolStripMenuItem2";
            this.noneToolStripMenuItem2.Size = new System.Drawing.Size(162, 22);
            this.noneToolStripMenuItem2.Text = "&None";
            this.noneToolStripMenuItem2.Click += new System.EventHandler(this.noneToolStripMenuItem2_Click);
            // 
            // iMSAISIOPortAToolStripMenuItem2
            // 
            this.iMSAISIOPortAToolStripMenuItem2.Name = "iMSAISIOPortAToolStripMenuItem2";
            this.iMSAISIOPortAToolStripMenuItem2.Size = new System.Drawing.Size(162, 22);
            this.iMSAISIOPortAToolStripMenuItem2.Text = "&IMSAI SIO Port A";
            this.iMSAISIOPortAToolStripMenuItem2.Click += new System.EventHandler(this.iMSAISIOPortAToolStripMenuItem2_Click);
            // 
            // iMSAISIOPortBToolStripMenuItem2
            // 
            this.iMSAISIOPortBToolStripMenuItem2.Name = "iMSAISIOPortBToolStripMenuItem2";
            this.iMSAISIOPortBToolStripMenuItem2.Size = new System.Drawing.Size(162, 22);
            this.iMSAISIOPortBToolStripMenuItem2.Text = "I&MSAI SIO Port B";
            this.iMSAISIOPortBToolStripMenuItem2.Click += new System.EventHandler(this.iMSAISIOPortBToolStripMenuItem2_Click);
            // 
            // altairSIOToolStripMenuItem3
            // 
            this.altairSIOToolStripMenuItem3.Name = "altairSIOToolStripMenuItem3";
            this.altairSIOToolStripMenuItem3.Size = new System.Drawing.Size(162, 22);
            this.altairSIOToolStripMenuItem3.Text = "&Altair SIO";
            this.altairSIOToolStripMenuItem3.Click += new System.EventHandler(this.altairSIOToolStripMenuItem3_Click);
            // 
            // diskJockeyToolStripMenuItem3
            // 
            this.diskJockeyToolStripMenuItem3.Name = "diskJockeyToolStripMenuItem3";
            this.diskJockeyToolStripMenuItem3.Size = new System.Drawing.Size(162, 22);
            this.diskJockeyToolStripMenuItem3.Text = "&Disk Jockey";
            this.diskJockeyToolStripMenuItem3.Click += new System.EventHandler(this.diskJockeyToolStripMenuItem3_Click);
            // 
            // rubeCronUSBToolStripMenuItem3
            // 
            this.rubeCronUSBToolStripMenuItem3.Name = "rubeCronUSBToolStripMenuItem3";
            this.rubeCronUSBToolStripMenuItem3.Size = new System.Drawing.Size(162, 22);
            this.rubeCronUSBToolStripMenuItem3.Text = "&RubeCron USB";
            this.rubeCronUSBToolStripMenuItem3.Click += new System.EventHandler(this.rubeCronUSBToolStripMenuItem3_Click);
            // 
            // noneToolStripMenuItem3
            // 
            this.noneToolStripMenuItem3.Checked = true;
            this.noneToolStripMenuItem3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.noneToolStripMenuItem3.Name = "noneToolStripMenuItem3";
            this.noneToolStripMenuItem3.Size = new System.Drawing.Size(162, 22);
            this.noneToolStripMenuItem3.Text = "&None";
            this.noneToolStripMenuItem3.Click += new System.EventHandler(this.noneToolStripMenuItem3_Click);
            // 
            // attachDiskJockeyToolStripMenuItem
            // 
            this.attachDiskJockeyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.e000ToolStripMenuItem,
            this.f800ToolStripMenuItem});
            this.attachDiskJockeyToolStripMenuItem.Name = "attachDiskJockeyToolStripMenuItem";
            this.attachDiskJockeyToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.attachDiskJockeyToolStripMenuItem.Text = "&Attach Disk Jockey";
            // 
            // e000ToolStripMenuItem
            // 
            this.e000ToolStripMenuItem.Name = "e000ToolStripMenuItem";
            this.e000ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.e000ToolStripMenuItem.Text = "&E000";
            this.e000ToolStripMenuItem.Click += new System.EventHandler(this.e000ToolStripMenuItem_Click);
            // 
            // f800ToolStripMenuItem
            // 
            this.f800ToolStripMenuItem.Name = "f800ToolStripMenuItem";
            this.f800ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.f800ToolStripMenuItem.Text = "&F800";
            this.f800ToolStripMenuItem.Click += new System.EventHandler(this.f800ToolStripMenuItem_Click);
            // 
            // frmDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 461);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblCycleDelay);
            this.Controls.Add(this.trackBarCycleDelay);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnRunStop);
            this.Controls.Add(this.btnStep);
            this.Controls.Add(this.groupMemory);
            this.Controls.Add(this.groupRegisters);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmDebug";
            this.Text = "em80";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDebug_FormClosing);
            this.Load += new System.EventHandler(this.frmDebug_Load);
            this.groupRegisters.ResumeLayout(false);
            this.groupRegisters.PerformLayout();
            this.groupMemory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCycleDelay)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupRegisters;
        private System.Windows.Forms.TextBox txtRegB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRegA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFlagC;
        private System.Windows.Forms.Label lblFlagP;
        private System.Windows.Forms.Label lblFlagA;
        private System.Windows.Forms.Label lblFlagI;
        private System.Windows.Forms.Label lblFlagZ;
        private System.Windows.Forms.Label lblFlagS;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRegPC;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRegSP;
        private System.Windows.Forms.TextBox txtRegL;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRegH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRegE;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRegD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRegF;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRegC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupMemory;
        private System.Windows.Forms.Button btnStep;
        private System.Windows.Forms.Button btnRunStop;
        private Be.Windows.Forms.HexBox hexMemory;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TrackBar trackBarCycleDelay;
        private System.Windows.Forms.Label lblCycleDelay;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem memoryMapToolStripMenuItem;
        private System.Windows.Forms.Timer timerIPS;
        private System.Windows.Forms.ToolStripMenuItem diskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drive0ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ejectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drive1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ejectToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem drive2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem ejectToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem drive3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem ejectToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem memoryClearToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtBreakpoint;
        private System.Windows.Forms.CheckBox checkBreakpoint;
        private System.Windows.Forms.ToolStripMenuItem sourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem port1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem port2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem port3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem port4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem port1ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem iMSAIPortAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iMSAIPortBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altairSIOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diskJockeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rubeCronUSBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem port2ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem port3ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem port4ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem iMSAISIOPortAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iMSAISIOPortBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altairSIOToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem diskJockeyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rubeCronUSBToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem iMSAISIOPortAToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem iMSAISIOPortBToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem altairSIOToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem diskJockeyToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem rubeCronUSBToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem iMSAISIOPortAToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem iMSAISIOPortBToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem altairSIOToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem diskJockeyToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem rubeCronUSBToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem noneToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem attachDiskJockeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem e000ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem f800ToolStripMenuItem;
    }
}

