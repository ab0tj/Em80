namespace Em80
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textComment = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblSectorInfo = new System.Windows.Forms.Label();
            this.numHead = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numSector = new System.Windows.Forms.NumericUpDown();
            this.numCylinder = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.hexBox1 = new Be.Windows.Forms.HexBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCylinder)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "&Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textComment);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblHeader);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(636, 110);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image Info";
            // 
            // textComment
            // 
            this.textComment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textComment.Location = new System.Drawing.Point(77, 32);
            this.textComment.Multiline = true;
            this.textComment.Name = "textComment";
            this.textComment.ReadOnly = true;
            this.textComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textComment.Size = new System.Drawing.Size(552, 72);
            this.textComment.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Comment:";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Location = new System.Drawing.Point(74, 16);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(52, 13);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "lblHeader";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Header:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblSectorInfo);
            this.groupBox2.Controls.Add(this.numHead);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.numSector);
            this.groupBox2.Controls.Add(this.numCylinder);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.hexBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 157);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(636, 234);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sectors";
            // 
            // lblSectorInfo
            // 
            this.lblSectorInfo.AutoSize = true;
            this.lblSectorInfo.Location = new System.Drawing.Point(6, 217);
            this.lblSectorInfo.Name = "lblSectorInfo";
            this.lblSectorInfo.Size = new System.Drawing.Size(66, 13);
            this.lblSectorInfo.TabIndex = 7;
            this.lblSectorInfo.Text = "lblSectorInfo";
            // 
            // numHead
            // 
            this.numHead.Location = new System.Drawing.Point(314, 14);
            this.numHead.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numHead.Name = "numHead";
            this.numHead.Size = new System.Drawing.Size(55, 20);
            this.numHead.TabIndex = 6;
            this.numHead.ValueChanged += new System.EventHandler(this.numHead_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(275, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Head";
            // 
            // numSector
            // 
            this.numSector.Location = new System.Drawing.Point(429, 14);
            this.numSector.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSector.Name = "numSector";
            this.numSector.Size = new System.Drawing.Size(55, 20);
            this.numSector.TabIndex = 4;
            this.numSector.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSector.ValueChanged += new System.EventHandler(this.numSector_ValueChanged);
            // 
            // numCylinder
            // 
            this.numCylinder.Location = new System.Drawing.Point(202, 14);
            this.numCylinder.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numCylinder.Name = "numCylinder";
            this.numCylinder.Size = new System.Drawing.Size(55, 20);
            this.numCylinder.TabIndex = 3;
            this.numCylinder.ValueChanged += new System.EventHandler(this.numCylinder_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(385, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Sector";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Cylinder";
            // 
            // hexBox1
            // 
            this.hexBox1.ColumnInfoVisible = true;
            this.hexBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.hexBox1.LineInfoVisible = true;
            this.hexBox1.Location = new System.Drawing.Point(6, 40);
            this.hexBox1.Name = "hexBox1";
            this.hexBox1.ReadOnly = true;
            this.hexBox1.ShadowSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(60)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.hexBox1.Size = new System.Drawing.Size(623, 174);
            this.hexBox1.StringViewVisible = true;
            this.hexBox1.TabIndex = 0;
            this.hexBox1.UseFixedBytesPerLine = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "ImageDisk Files (*.IMD)|*.imd|All Files (*.*)|*.*";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 403);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "IMDTest";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCylinder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox textComment;
        private System.Windows.Forms.NumericUpDown numHead;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numSector;
        private System.Windows.Forms.NumericUpDown numCylinder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Be.Windows.Forms.HexBox hexBox1;
        private System.Windows.Forms.Label lblSectorInfo;
    }
}

