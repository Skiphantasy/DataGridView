/*
 * EXERCISE............: Exercise 8.
 * NAME AND LASTNAME...: Tania López Martín 
 * CURSE AND GROUP.....: 2º Interface Development 
 * PROJECT.............: Forms II. Components
 * DATE................: 21 Jan 2019
 */


namespace Exercise8
{
    partial class frmCreate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreate));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblSubjects = new System.Windows.Forms.Label();
            this.cmbxSubjects = new System.Windows.Forms.ComboBox();
            this.lblSubject1 = new System.Windows.Forms.Label();
            this.lblSubject2 = new System.Windows.Forms.Label();
            this.lblSubject3 = new System.Windows.Forms.Label();
            this.lblSubject4 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.flowLayoutPanel1.Controls.Add(this.lblName);
            this.flowLayoutPanel1.Controls.Add(this.txtName);
            this.flowLayoutPanel1.Controls.Add(this.lblSubjects);
            this.flowLayoutPanel1.Controls.Add(this.cmbxSubjects);
            this.flowLayoutPanel1.Controls.Add(this.lblSubject1);
            this.flowLayoutPanel1.Controls.Add(this.lblSubject2);
            this.flowLayoutPanel1.Controls.Add(this.lblSubject3);
            this.flowLayoutPanel1.Controls.Add(this.lblSubject4);
            this.flowLayoutPanel1.Controls.Add(this.btnAccept);
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(276, 127);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(13, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(93, 23);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Nombre";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(112, 13);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(148, 20);
            this.txtName.TabIndex = 1;
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            this.txtName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyUp_1);
            // 
            // lblSubjects
            // 
            this.lblSubjects.Location = new System.Drawing.Point(13, 36);
            this.lblSubjects.Name = "lblSubjects";
            this.lblSubjects.Size = new System.Drawing.Size(93, 23);
            this.lblSubjects.TabIndex = 6;
            this.lblSubjects.Text = "Asignaturas";
            this.lblSubjects.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbxSubjects
            // 
            this.cmbxSubjects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxSubjects.FormattingEnabled = true;
            this.cmbxSubjects.Items.AddRange(new object[] {
            "BADA",
            "PROG",
            "SIIN",
            "LEMA",
            "ENDE",
            "ACDA",
            "SIGE",
            "PRSP",
            "PMDM",
            "DEIN",
            "FOL",
            "EIE"});
            this.cmbxSubjects.Location = new System.Drawing.Point(112, 39);
            this.cmbxSubjects.Name = "cmbxSubjects";
            this.cmbxSubjects.Size = new System.Drawing.Size(148, 21);
            this.cmbxSubjects.TabIndex = 6;
            this.cmbxSubjects.SelectedIndexChanged += new System.EventHandler(this.cmbxSubjects_SelectedIndexChanged);
            // 
            // lblSubject1
            // 
            this.lblSubject1.Location = new System.Drawing.Point(13, 63);
            this.lblSubject1.Name = "lblSubject1";
            this.lblSubject1.Size = new System.Drawing.Size(57, 24);
            this.lblSubject1.TabIndex = 12;
            this.lblSubject1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubject2
            // 
            this.lblSubject2.Location = new System.Drawing.Point(76, 63);
            this.lblSubject2.Name = "lblSubject2";
            this.lblSubject2.Size = new System.Drawing.Size(51, 24);
            this.lblSubject2.TabIndex = 13;
            this.lblSubject2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubject3
            // 
            this.lblSubject3.Location = new System.Drawing.Point(133, 63);
            this.lblSubject3.Name = "lblSubject3";
            this.lblSubject3.Size = new System.Drawing.Size(60, 24);
            this.lblSubject3.TabIndex = 14;
            this.lblSubject3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubject4
            // 
            this.lblSubject4.Location = new System.Drawing.Point(199, 63);
            this.lblSubject4.Name = "lblSubject4";
            this.lblSubject4.Size = new System.Drawing.Size(63, 24);
            this.lblSubject4.TabIndex = 15;
            this.lblSubject4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAccept
            // 
            this.btnAccept.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAccept.Enabled = false;
            this.btnAccept.Location = new System.Drawing.Point(13, 90);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(120, 23);
            this.btnAccept.TabIndex = 10;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCancel.Location = new System.Drawing.Point(139, 90);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(121, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmCreate
            // 
            this.ClientSize = new System.Drawing.Size(301, 152);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCreate";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblSubjects;
        private System.Windows.Forms.ComboBox cmbxSubjects;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblSubject1;
        private System.Windows.Forms.Label lblSubject2;
        private System.Windows.Forms.Label lblSubject3;
        private System.Windows.Forms.Label lblSubject4;
    }
}