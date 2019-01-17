namespace Exercise8
{
    partial class frmSave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSave));
            this.lblGrpName = new System.Windows.Forms.Label();
            this.txtSaveName = new System.Windows.Forms.TextBox();
            this.cmbxExtension = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGrpName
            // 
            this.lblGrpName.AutoSize = true;
            this.lblGrpName.BackColor = System.Drawing.Color.Transparent;
            this.lblGrpName.Location = new System.Drawing.Point(20, 32);
            this.lblGrpName.Name = "lblGrpName";
            this.lblGrpName.Size = new System.Drawing.Size(96, 13);
            this.lblGrpName.TabIndex = 0;
            this.lblGrpName.Text = "Nombre del Grupo ";
            // 
            // txtSaveName
            // 
            this.txtSaveName.Location = new System.Drawing.Point(23, 59);
            this.txtSaveName.Name = "txtSaveName";
            this.txtSaveName.Size = new System.Drawing.Size(120, 20);
            this.txtSaveName.TabIndex = 1;
            // 
            // cmbxExtension
            // 
            this.cmbxExtension.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxExtension.FormattingEnabled = true;
            this.cmbxExtension.Items.AddRange(new object[] {
            ".gru"});
            this.cmbxExtension.Location = new System.Drawing.Point(149, 59);
            this.cmbxExtension.Name = "cmbxExtension";
            this.cmbxExtension.Size = new System.Drawing.Size(63, 21);
            this.cmbxExtension.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(85, 96);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(238, 137);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbxExtension);
            this.Controls.Add(this.txtSaveName);
            this.Controls.Add(this.lblGrpName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSave";
            this.Text = "Guardar Grupo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGrpName;
        private System.Windows.Forms.TextBox txtSaveName;
        private System.Windows.Forms.ComboBox cmbxExtension;
        private System.Windows.Forms.Button btnSave;
    }
}