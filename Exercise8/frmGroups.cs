/*
 * EXERCISE.............: Exercise 8.
 * NAME AND LASTNAME...: Tania López Martín 
 * CURSE AND GROUP.....: 2º Interface Development 
 * PROJECT.............: Forms
 * DATE................: 17 Dic 2018
 */


using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Exercise8
{
    public partial class frmGroups : Form
    {
        #region attributes
        static Group group;
        static DataGridView dGridView;
        static string savingFile;
        static bool open = false;
        static bool saveOpen = true;
        bool creating = false;
        #endregion
        #region constructor
        public frmGroups()
        {
            this.WindowState = FormWindowState.Minimized;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Size = new System.Drawing.Size(727, 320);
            this.CenterToScreen();
            this.Size = new System.Drawing.Size(317, 320);
            InitializeComponent();
            ExistingGroups();
            dGridView = gviewStudents;

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\OurSettings", RegistryKeyPermissionCheck.ReadWriteSubTree);

            if (key == null)
            {
                key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\OurSettings", RegistryKeyPermissionCheck.ReadWriteSubTree);
                key.SetValue("Uses", 1);
                key.Close();
            }
            else
            {
                int counter = int.Parse(key.GetValue("Uses").ToString());
                counter++;
                key.SetValue("Uses", counter);
                key.Close();
            }
        }

        private void ExistingGroups()
        {
            DirectoryInfo d = new DirectoryInfo(".");//Assuming Test is your Folder
            FileInfo[] fs = d.GetFiles("*.gru"); 
            foreach (FileInfo f in fs)
            {
                menuGroup.DropDownItems.Add(f.Name);
            }

            for (int i = 0; i < menuGroup.DropDownItems.Count; i++)
            {
                menuGroup.DropDownItems[i].Click += new EventHandler(loadGroup_Click);
            }
        }

        private void ColumnDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                //tb.Leave += new EventHandler(textBox_Leave);
                tb.KeyUp += new KeyEventHandler(textBox_Leave);
            }

        }

        private void ColumnLetter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void nuevoGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = new frmCreate();

            openForm.Show();
            creating = true;

        }
        #endregion

        #region event voids
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != Convert.ToChar(Keys.Tab) && e.KeyChar != Convert.ToChar(Keys.Enter) && !char.IsLetter(e.KeyChar)
                && e.KeyChar != Convert.ToChar(Keys.Back) && e.KeyChar != Convert.ToChar(Keys.Space);
            TextBox textBox = (TextBox)sender;

        }

        private void nfyMessage_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Show();
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form openForm = new frmAboutMe();

            if (open == false)
            {
                openForm.Show();
                open = true;
            }
            else
            {
                openForm = Application.OpenForms[0];
                openForm.BringToFront();
            }
        }

        private void frmSalary_Shown(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.nfyMessage.Visible = true;
            this.nfyMessage.BalloonTipText = "Bienvenido/a al programa";
            this.nfyMessage.ShowBalloonTip(1000);
        }

        private void cmbxState(object sender, KeyPressEventArgs e)
        {
            ComboBox cmbBox = (ComboBox)sender;

            if (e.KeyChar == Convert.ToChar(Keys.Enter) && cmbBox.BackColor == Color.LightGreen)
            {
                SendKeys.Send("{TAB}");
            }
        }

        public static bool Open { get => open; set => open = value; }
        internal static Group CurrentGroup { get => group; set => group = value; }
        public static string SavingFile { get => savingFile; set => savingFile = value; }
        public static bool SaveOpen { get => saveOpen; set => saveOpen = value; }
        public static DataGridView DGridView { get => dGridView; set => dGridView = value; }
        #endregion

        private void frmGroups_Click(object sender, EventArgs e)
        {
            if (creating)
            {
                int index = 0;
                lblGroupName.Text = group.Name;
                gviewStudents.Enabled = true;
                gviewStudents.ReadOnly = false;

                foreach (DataGridViewColumn column in gviewStudents.Columns)
                {
                    if (!column.Equals(gviewStudents.Columns[0]))
                    {
                        column.HeaderText = group.Subjects[index];
                        index++;
                    }
                }
            }
        }

        private void gviewStudents_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnDigit_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnLetter_KeyPress);
            DataGridView dataGrid = (DataGridView)sender;
            TextBox tb = (TextBox)e.Control;

            if (dataGrid.CurrentCell.OwningColumn.HeaderText.Equals("Nombre Alumno"))
            {
                tb.KeyPress += new KeyPressEventHandler(ColumnLetter_KeyPress);
            }
            else
            {
                tb.KeyPress += new KeyPressEventHandler(ColumnDigit_KeyPress);
            }
        }

        private void textBox_Leave(object sender, KeyEventArgs e)
        {
            int number;
            TextBox tb = (TextBox)sender;

            if (int.TryParse(tb.Text, out number))
            {
                if (int.Parse(tb.Text) > 10)
                {
                    tb.Text = "" + 10;
                }
                else if (int.Parse(tb.Text) < 0)
                {
                    tb.Text = "" + 0;
                }
            }
        }

        private void guardarGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form saveForm = new frmSave();
            saveForm.Show();
            /*
            if(!saveOpen)
            {
                using (BinaryWriter bw = new BinaryWriter(File.Open(savingFile, FileMode.Create)))
                {
                    bw.Write(gviewStudents.Columns.Count);
                    bw.Write(gviewStudents.Rows.Count);

                    foreach (DataGridViewRow dgvR in gviewStudents.Rows)
                    {
                        emptyColumns = 0;

                        for (int j = 0; j < gviewStudents.Columns.Count; ++j)
                        {
                            DataGridViewCell val = dgvR.Cells[j];

                            if (val.Value == null)
                            {
                                bw.Write(false);
                                bw.Write(false);
                                emptyColumns++;
                            }
                        }

                        if (emptyColumns == 0)
                        {
                            for (int j = 0; j < gviewStudents.Columns.Count; ++j)
                            {
                                DataGridViewCell val = dgvR.Cells[j];

                                bw.Write(true);
                                bw.Write(val.Value.ToString());
                            }
                        }
                    }
                }

                saveOpen = false;
                     Thread t = new Thread(new ThreadStart(ThreadMethod));
            {

            }
                 t.SetApartmentState(ApartmentState.STA);
                 t.Start();

            }*/
        }

        static void ThreadMethod()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\Users\Tania\source\repos\Exercise8";
            saveFileDialog1.Title = "Save Group Files";
            //saveFileDialog1.CheckFileExists = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.Filter = "Group File|*.gru";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Stream fileStream = saveFileDialog1.OpenFile();
                fileStream.Close();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openGroups_Click(object sender, EventArgs e)
        {

        }

       
        private void loadGroup_Click(object sender, EventArgs e)
        {
            gviewStudents.Rows.Clear();
            ToolStripDropDownItem combo = (ToolStripDropDownItem)sender;
            string file = combo.Text;
            using (BinaryReader bw = new BinaryReader(File.Open(file, FileMode.Open)))
            {

                int n = bw.ReadInt32();
                int m = bw.ReadInt32();

                foreach (DataGridViewColumn dgvC in frmGroups.DGridView.Columns)
                {
                    dgvC.HeaderText = bw.ReadString();
                }

                for (int i = 0; i < m; ++i)
                {
                    gviewStudents.Rows.Add();

                    for (int j = 0; j < n; ++j)
                    {
                        if (bw.ReadBoolean())
                        {     
                            gviewStudents.Rows[i].Cells[j].Value = bw.ReadString();
                        }
                        else bw.ReadBoolean();
                    }
                }
            }
        }

        private void menuGroup_Click(object sender, EventArgs e)
        {
        }
    }
}
