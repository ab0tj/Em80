namespace Em80
{
    partial class frmHexOrBin
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
            this.radioHex = new System.Windows.Forms.RadioButton();
            this.radioBin = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textOffset = new System.Windows.Forms.TextBox();
            this.checkClear = new System.Windows.Forms.CheckBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radioHex
            // 
            this.radioHex.AutoSize = true;
            this.radioHex.Location = new System.Drawing.Point(108, 12);
            this.radioHex.Name = "radioHex";
            this.radioHex.Size = new System.Drawing.Size(67, 17);
            this.radioHex.TabIndex = 0;
            this.radioHex.Text = "Intel Hex";
            this.radioHex.UseVisualStyleBackColor = true;
            this.radioHex.CheckedChanged += new System.EventHandler(this.radioHex_CheckedChanged);
            // 
            // radioBin
            // 
            this.radioBin.AutoSize = true;
            this.radioBin.Checked = true;
            this.radioBin.Location = new System.Drawing.Point(48, 12);
            this.radioBin.Name = "radioBin";
            this.radioBin.Size = new System.Drawing.Size(54, 17);
            this.radioBin.TabIndex = 1;
            this.radioBin.TabStop = true;
            this.radioBin.Text = "Binary";
            this.radioBin.UseVisualStyleBackColor = true;
            this.radioBin.CheckedChanged += new System.EventHandler(this.radioBin_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Offset:";
            // 
            // textOffset
            // 
            this.textOffset.Location = new System.Drawing.Point(109, 35);
            this.textOffset.MaxLength = 4;
            this.textOffset.Name = "textOffset";
            this.textOffset.Size = new System.Drawing.Size(48, 20);
            this.textOffset.TabIndex = 3;
            this.textOffset.Text = "0";
            this.textOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textOffset.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateHexInput);
            // 
            // checkClear
            // 
            this.checkClear.AutoSize = true;
            this.checkClear.Location = new System.Drawing.Point(39, 61);
            this.checkClear.Name = "checkClear";
            this.checkClear.Size = new System.Drawing.Size(145, 17);
            this.checkClear.TabIndex = 4;
            this.checkClear.Text = "Clear memory before load";
            this.checkClear.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLoad.Location = new System.Drawing.Point(58, 84);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(50, 23);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "&Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(114, 84);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(50, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmHexOrBin
            // 
            this.AcceptButton = this.btnLoad;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(222, 117);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.checkClear);
            this.Controls.Add(this.textOffset);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioBin);
            this.Controls.Add(this.radioHex);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHexOrBin";
            this.Text = "Load Memory Image";
            this.Load += new System.EventHandler(this.frmHexOrBin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.RadioButton radioHex;
        public System.Windows.Forms.RadioButton radioBin;
        public System.Windows.Forms.TextBox textOffset;
        public System.Windows.Forms.CheckBox checkClear;
    }
}