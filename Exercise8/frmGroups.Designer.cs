/*
 * EXERCISE.............: Exercise 8.
 * NAME AND LASTNAME...: Tania López Martín 
 * CURSE AND GROUP.....: 2º Interface Development 
 * PROJECT.............: Forms
 * DATE................: 17 Dic 2018
 */
 
 
 namespace Exercise8
{
    partial class frmGroups
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGroups));
            this.ttpInfo = new System.Windows.Forms.ToolTip(this.components);
            this.mnuOptions = new System.Windows.Forms.MenuStrip();
            this.nuevoGrupoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarGrupoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nfyMessage = new System.Windows.Forms.NotifyIcon(this.components);
            this.gviewStudents = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblGroup = new System.Windows.Forms.Label();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.saveGroup = new System.Windows.Forms.SaveFileDialog();
            this.mnuOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gviewStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuOptions
            // 
            this.mnuOptions.BackColor = System.Drawing.SystemColors.Menu;
            this.mnuOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mnuOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoGrupoToolStripMenuItem,
            this.openGroups,
            this.guardarGrupoToolStripMenuItem,
            this.salirToolStripMenuItem,
            this.mnuHelpItem});
            this.mnuOptions.Location = new System.Drawing.Point(10, 10);
            this.mnuOptions.Name = "mnuOptions";
            this.mnuOptions.Size = new System.Drawing.Size(424, 24);
            this.mnuOptions.TabIndex = 1;
            this.mnuOptions.Text = "Opciones";
            // 
            // nuevoGrupoToolStripMenuItem
            // 
            this.nuevoGrupoToolStripMenuItem.Name = "nuevoGrupoToolStripMenuItem";
            this.nuevoGrupoToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.nuevoGrupoToolStripMenuItem.Text = "Nuevo Grupo";
            this.nuevoGrupoToolStripMenuItem.Click += new System.EventHandler(this.nuevoGrupoToolStripMenuItem_Click);
            // 
            // openGroups
            // 
            this.openGroups.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuGroup});
            this.openGroups.Name = "openGroups";
            this.openGroups.Size = new System.Drawing.Size(81, 20);
            this.openGroups.Text = "Abrir Grupo";
            this.openGroups.Click += new System.EventHandler(this.openGroups_Click);
            // 
            // menuGroup
            // 
            this.menuGroup.Name = "menuGroup";
            this.menuGroup.Size = new System.Drawing.Size(180, 22);
            this.menuGroup.Text = "Lista de grupos";
            this.menuGroup.Click += new System.EventHandler(this.menuGroup_Click);
            // 
            // guardarGrupoToolStripMenuItem
            // 
            this.guardarGrupoToolStripMenuItem.Name = "guardarGrupoToolStripMenuItem";
            this.guardarGrupoToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.guardarGrupoToolStripMenuItem.Text = "Guardar Grupo";
            this.guardarGrupoToolStripMenuItem.Click += new System.EventHandler(this.guardarGrupoToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // mnuHelpItem
            // 
            this.mnuHelpItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.mnuHelpItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem});
            this.mnuHelpItem.Name = "mnuHelpItem";
            this.mnuHelpItem.Size = new System.Drawing.Size(53, 20);
            this.mnuHelpItem.Text = "Ayuda";
            this.mnuHelpItem.ToolTipText = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca de...";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // nfyMessage
            // 
            this.nfyMessage.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.nfyMessage.Icon = ((System.Drawing.Icon)(resources.GetObject("nfyMessage.Icon")));
            this.nfyMessage.Text = "Tray Icon";
            this.nfyMessage.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nfyMessage_MouseDoubleClick);
            // 
            // gviewStudents
            // 
            this.gviewStudents.AllowUserToDeleteRows = false;
            this.gviewStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gviewStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.gviewStudents.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gviewStudents.Location = new System.Drawing.Point(28, 86);
            this.gviewStudents.Name = "gviewStudents";
            this.gviewStudents.Size = new System.Drawing.Size(393, 170);
            this.gviewStudents.TabIndex = 2;
            this.gviewStudents.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gviewStudents_EditingControlShowing);
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Nombre Alumno";
            this.Column5.Name = "Column5";
            this.Column5.Width = 150;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.Width = 50;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "";
            this.Column2.Name = "Column2";
            this.Column2.Width = 50;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "";
            this.Column3.Name = "Column3";
            this.Column3.Width = 50;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "";
            this.Column4.Name = "Column4";
            this.Column4.Width = 50;
            // 
            // lblGroup
            // 
            this.lblGroup.BackColor = System.Drawing.Color.Transparent;
            this.lblGroup.Location = new System.Drawing.Point(25, 52);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(80, 13);
            this.lblGroup.TabIndex = 3;
            this.lblGroup.Text = "Grupo actual:";
            // 
            // lblGroupName
            // 
            this.lblGroupName.BackColor = System.Drawing.Color.Transparent;
            this.lblGroupName.Location = new System.Drawing.Point(111, 52);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(204, 13);
            this.lblGroupName.TabIndex = 4;
            this.lblGroupName.Text = "-";
            this.lblGroupName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // saveGroup
            // 
            this.saveGroup.CheckFileExists = true;
            // 
            // frmGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(444, 281);
            this.Controls.Add(this.lblGroupName);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.gviewStudents);
            this.Controls.Add(this.mnuOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuOptions;
            this.MaximizeBox = false;
            this.Name = "frmGroups";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Grupos";
            this.Shown += new System.EventHandler(this.frmSalary_Shown);
            this.Click += new System.EventHandler(this.frmGroups_Click);
            this.mnuOptions.ResumeLayout(false);
            this.mnuOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gviewStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip ttpInfo;
        private System.Windows.Forms.MenuStrip mnuOptions;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon nfyMessage;
        private System.Windows.Forms.ToolStripMenuItem nuevoGrupoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openGroups;
        private System.Windows.Forms.ToolStripMenuItem guardarGrupoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.DataGridView gviewStudents;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblGroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        public System.Windows.Forms.SaveFileDialog saveGroup;
        private System.Windows.Forms.ToolStripMenuItem menuGroup;
    }
}

