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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupRegisters.SuspendLayout();
            this.groupMemory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCycleDelay)).BeginInit();
            this.menuStrip1.SuspendLayout();
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
            this.groupMemory.Size = new System.Drawing.Size(649, 336);
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
            this.hexMemory.Size = new System.Drawing.Size(637, 311);
            this.hexMemory.StringViewVisible = true;
            this.hexMemory.TabIndex = 0;
            this.hexMemory.UseFixedBytesPerLine = true;
            this.hexMemory.VScrollBarVisible = true;
            // 
            // btnStep
            // 
            this.btnStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStep.Location = new System.Drawing.Point(667, 307);
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
            this.btnRunStop.Location = new System.Drawing.Point(744, 307);
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
            this.btnReset.Location = new System.Drawing.Point(667, 336);
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
            this.btnClear.Location = new System.Drawing.Point(744, 336);
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
            this.trackBarCycleDelay.Location = new System.Drawing.Point(672, 256);
            this.trackBarCycleDelay.Maximum = 1000;
            this.trackBarCycleDelay.Name = "trackBarCycleDelay";
            this.trackBarCycleDelay.Size = new System.Drawing.Size(144, 45);
            this.trackBarCycleDelay.TabIndex = 11;
            this.trackBarCycleDelay.TickFrequency = 100;
            this.trackBarCycleDelay.Scroll += new System.EventHandler(this.trackBarCycleDelay_Scroll);
            // 
            // lblCycleDelay
            // 
            this.lblCycleDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCycleDelay.AutoSize = true;
            this.lblCycleDelay.Location = new System.Drawing.Point(701, 288);
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
            this.consoleToolStripMenuItem});
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
            this.clearToolStripMenuItem});
            this.consoleToolStripMenuItem.Name = "consoleToolStripMenuItem";
            this.consoleToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.consoleToolStripMenuItem.Text = "&Console";
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.showToolStripMenuItem.Text = "&Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.clearToolStripMenuItem.Text = "&Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Memory Image (*.hex, *.bin)|*.hex;*.bin|All Files|*.*";
            // 
            // frmDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 375);
            this.Controls.Add(this.lblCycleDelay);
            this.Controls.Add(this.trackBarCycleDelay);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnRunStop);
            this.Controls.Add(this.btnStep);
            this.Controls.Add(this.groupMemory);
            this.Controls.Add(this.groupRegisters);
            this.Controls.Add(this.menuStrip1);
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
    }
}

