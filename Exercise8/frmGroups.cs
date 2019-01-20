/*
 * EXERCISE............: Exercise 8.
 * NAME AND LASTNAME...: Tania López Martín 
 * CURSE AND GROUP.....: 2º Interface Development 
 * PROJECT.............: Forms II. Components
 * DATE................: 21 Jan 2019
 */


using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Exercise8
{
    public partial class frmGroups : Form
    {
        #region attributes
        static Student student;
        static List<Student> students;
        static Label groupName;
        static Group group;
        static DataGridView dGridView;
        static CheckBox checkBox;
        static string savingFile;
        static bool open = false;
        static bool saveOpen = true;
        static bool creating = false;
        static ToolStripMenuItem tsmiGroup;
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
            tsmiGroup = tsmiGuardarGrupo;
            ExistingGroups();
            students = new List<Student>();
            groupName = lblGroupName;
            checkBox = chckboxFilter;
            dGridView = gviewStudents;
            DGridView.Enabled = false;
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\P8", RegistryKeyPermissionCheck.ReadWriteSubTree);

            if (key == null)
            {
                key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\P8", RegistryKeyPermissionCheck.ReadWriteSubTree);
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
        #endregion
        #region voids and methods
        private void ExistingGroups()
        {
            menuGroup.DropDownItems.Clear();

            DirectoryInfo d = new DirectoryInfo(".");
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

        public static void AddStudents()
        {
            students = new List<Student>();
            student = null;
            float flt;

            for (int i = 0; i < dGridView.Rows.Count; i++)
            {
                string studentName = "";
                List<float> marks = new List<float>();

                for (int j = 0; j < dGridView.Columns.Count; j++)
                {
                    if (dGridView.Rows[i].Cells[j].Value != null)
                    {
                        string value = dGridView.Rows[i].Cells[j].Value.ToString();

                        if (float.TryParse(value.Replace(".", ","), out flt))
                        {
                            marks.Add(float.Parse(value.Replace(".", ",")));
                        }
                        else if (!float.TryParse(value.Replace(".", ","), out flt)
                            && !value.Replace(".", ",").Any(char.IsDigit))
                        {
                            studentName = value;
                        }
                    }
                }

                if (!studentName.Equals(""))
                {
                    student = new Student(studentName, marks);
                    students.Add(student);
                }
            }
        }

        public static void UpdateMainForm()
        {
            if (creating)
            {
                tsmiGroup.Enabled = true;
                int index = 0;
                groupName.Text = group.Name;
                dGridView.Enabled = true;
                DGridView.Rows.Clear();
                student = null;
                students = new List<Student>();
                AddStudents();
                dGridView.ReadOnly = false;

                foreach (DataGridViewColumn column in dGridView.Columns)
                {
                    if (!column.Equals(dGridView.Columns[0]))
                    {
                        column.HeaderText = group.Subjects[index];
                        index++;
                    }
                }
            }
        }

        private List<Student> CheckPassedStudens()
        {
            List<Student> passStudents = new List<Student>();

            if (students.Count > 0)
            {
                for (int i = 0; i < students.Count; i++)
                {
                    bool pass = true;

                    for (int j = 0; j < students[i].Marks.Count; j++)
                    {
                        if (students[i].Marks[j] < 5f)
                        {
                            pass = false;
                        }
                    }

                    if (pass == true)
                    {
                        passStudents.Add(students[i]);
                    }
                }
            }

            return passStudents;
        }

        public static void LoadData(string fileName)
        {
            int n = 0;
            int m = 0;
            student = null;
            students = new List<Student>();
            dGridView.Rows.Clear();
            tsmiGroup.Enabled = true;
            string file = fileName;
            groupName.Text = file.Replace(".gru", "");
            using (BinaryReader bw = new BinaryReader(File.Open(file, FileMode.Open)))
            {
                try
                {
                    n = bw.ReadInt32();
                    m = bw.ReadInt32();

                    foreach (DataGridViewColumn dgvC in frmGroups.DGridView.Columns)
                    {
                        dgvC.HeaderText = bw.ReadString();
                    }
                }
                catch (EndOfStreamException)
                {
                    DialogResult result = MessageBox.Show("No se pudo leer el archivo.",
                        "Alerta", MessageBoxButtons.OK);
                }

                for (int i = 0; i < m; ++i)
                {
                    dGridView.Rows.Add();

                    for (int j = 0; j < n; ++j)
                    {
                        try
                        {
                            if (bw.ReadBoolean())
                            {
                                dGridView.Rows[i].Cells[j].Value = bw.ReadString();
                            }
                            else bw.ReadBoolean();
                        }
                        catch (EndOfStreamException)
                        {
                        }
                    }
                }

                dGridView.Enabled = true;
                checkBox.Enabled = true;
                AddStudents();
                bw.Close();
                dGridView.CellValueChanged += new DataGridViewCellEventHandler(gviewStudents_CellValueChanged);
            }
        }
        #endregion
        #region events
        private void columnDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.MaxLength = 4;

            if (char.IsLetter(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void columnLetter_KeyPress(object sender, KeyPressEventArgs e)
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

        private void gviewStudents_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(columnDigit_KeyPress);
            e.Control.KeyPress -= new KeyPressEventHandler(columnLetter_KeyPress);
            DataGridView dataGrid = (DataGridView)sender;
            TextBox tb = (TextBox)e.Control;

            if (dataGrid.CurrentCell.OwningColumn.HeaderText.Equals("Nombre Alumno"))
            {
                tb.KeyPress += new KeyPressEventHandler(columnLetter_KeyPress);
            }
            else
            {
                tb.KeyPress += new KeyPressEventHandler(columnDigit_KeyPress);
            }
        }

        private void guardarGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dGridView.EndEdit();
            Form saveForm = new frmSave();            
            saveForm.Show();
        }
      
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openGroups_Click(object sender, EventArgs e)
        {
            ExistingGroups();
        }       

        private void loadGroup_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem combo = (ToolStripDropDownItem)sender;
            LoadData(combo.Text);
        }

        private void chckboxFilter_CheckedChanged(object sender, EventArgs e)
        {
            bool next = false;
            DialogResult result = MessageBox.Show("Perderá todos los cambios que no haya guardado. ¿Desea continuar de todos modos?",
                "Alerta", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                next = true;
            } else
            {
                checkBox.CheckedChanged -= new System.EventHandler(this.chckboxFilter_CheckedChanged);
                checkBox.Checked = !checkBox.Checked;
                checkBox.CheckedChanged += new System.EventHandler(this.chckboxFilter_CheckedChanged);
            }

            if (checkBox.Checked && next)
            {               
                List<Student> passStudents = CheckPassedStudens();
                dGridView.Rows.Clear();

                for (int i = 0; i < passStudents.Count; i++)
                {
                    dGridView.Rows.Add();

                    for (int j = 0; j < passStudents[i].Marks.Count + 1; j++)
                    {
                        if (j == 0)
                        {
                            dGridView.Rows[i].Cells[j].Value = passStudents[i].Name;
                        }
                        else
                        {
                            dGridView.Rows[i].Cells[j].Value = passStudents[i].Marks[j - 1];
                        }
                    }
                }
             }
            else if(!checkBox.Checked && next)
            {
                dGridView.Rows.Clear();

                for (int i = 0; i < students.Count; i++)
                {
                    dGridView.Rows.Add();

                    for (int j = 0; j < students[i].Marks.Count + 1; j++)
                    {
                        if (j == 0)
                        {
                            dGridView.Rows[i].Cells[j].Value = students[i].Name;
                        }
                        else
                        {
                            dGridView.Rows[i].Cells[j].Value = students[i].Marks[j - 1];
                        }
                    }
                }
            }                 
        }

        private static void gviewStudents_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            float number;
            DataGridView dtg = (DataGridView)sender;
            string value;

            if (dtg[e.ColumnIndex, e.RowIndex].Value != null)
            {
                value = dtg[e.ColumnIndex, e.RowIndex].Value.ToString();
                if (float.TryParse(value, out number))
                {
                    if(value.Contains("."))
                    {
                        dtg[e.ColumnIndex, e.RowIndex].Value = value.Replace(".", ",");
                        value = dtg[e.ColumnIndex, e.RowIndex].Value.ToString();
                    }
                    
                    if (float.Parse(value) >= 10)
                    {
                        dtg[e.ColumnIndex, e.RowIndex].Value = string.Format("{0:0.00}", 10);
                    }
                    else if (float.Parse(value) < 0)
                    {
                        dtg[e.ColumnIndex, e.RowIndex].Value = string.Format("{0:0.00}", 0);
                    }
                    else
                    {
                        dtg[e.ColumnIndex, e.RowIndex].Value = string.Format("{0:0.00}", 
                            float.Parse(dtg[e.ColumnIndex, e.RowIndex].Value.ToString()));           
                    }
                }
            }
        }
        #endregion
        #region properties
        public static bool Open { get => open; set => open = value; }
        internal static Group CurrentGroup { get => group; set => group = value; }
        public static string SavingFile { get => savingFile; set => savingFile = value; }
        public static bool SaveOpen { get => saveOpen; set => saveOpen = value; }
        public static DataGridView DGridView { get => dGridView; set => dGridView = value; }
        public static Label GroupName { get => groupName; set => groupName = value; }
        #endregion   
    }
}
