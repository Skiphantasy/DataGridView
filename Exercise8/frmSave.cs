/*
 * EXERCISE............: Exercise 8.
 * NAME AND LASTNAME...: Tania López Martín 
 * CURSE AND GROUP.....: 2º Interface Development 
 * PROJECT.............: Forms II. Components
 * DATE................: 21 Jan 2019
 */


using System;
using System.IO;
using System.Windows.Forms;

namespace Exercise8
{
    public partial class frmSave : Form
    {
        #region attributes
        bool enableName = true;
        bool enableExtension;
        #endregion
        #region constructor
        public frmSave()
        {
            InitializeComponent();
            txtSaveName.Text = frmGroups.GroupName.Text;
        }
        #endregion
        #region events
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool existFile = false;
            string savingFile;
            int emptyColumns;
            DirectoryInfo d;
            float flt;
            FileInfo[] fs;
            savingFile = txtSaveName.Text + ".gru";

            d = new DirectoryInfo(".");
            fs = d.GetFiles(savingFile);

            if (fs.Length >= 1)
            {
                DialogResult result1 = MessageBox.Show("Ya existe un grupo con ese nombre. ¿Desea sobreescribirlo?",
                    "Alerta", MessageBoxButtons.YesNo);

                if (result1 == DialogResult.No)
                {
                    fs[0].Delete();
                    existFile = true;
                }
            }

            if (existFile == false)
            { 
                frmGroups.SaveOpen = true;

                using (BinaryWriter bw = new BinaryWriter(File.Open(savingFile, FileMode.Create)))
                {

                    bw.Write(frmGroups.DGridView.Columns.Count);
                    bw.Write(frmGroups.DGridView.Rows.Count);

                    foreach (DataGridViewColumn dgvC in frmGroups.DGridView.Columns)
                    {
                        bw.Write(dgvC.HeaderText);
                    }

                    foreach (DataGridViewRow dgvR in frmGroups.DGridView.Rows)
                    {
                        emptyColumns = 0;
                        bool incorrect = false;

                        for (int j = 0; j < frmGroups.DGridView.Columns.Count; ++j)
                        {
                            DataGridViewCell val = dgvR.Cells[j];
                        
                            if (val.Value == null)
                            {
                                emptyColumns++;
                            }
                            else
                            {
                                if(j > 0 && !float.TryParse(val.Value.ToString().Replace(".", ","), out flt))
                                {                              
                                    incorrect = true;
                                }
                            }
                        }

                        if (emptyColumns == 0 && incorrect == false)
                        {
                            for (int j = 0; j < frmGroups.DGridView.Columns.Count; ++j)
                            {
                                DataGridViewCell val = dgvR.Cells[j];

                                bw.Write(true);
                                bw.Write(val.Value.ToString());
                            }
                        }
                        else if (incorrect == true && emptyColumns == 0)
                        {
                            DialogResult result = MessageBox.Show("No se pudo guardar el alumno/a " + dgvR.Cells[0].Value.ToString()
                                       + " porque una o más de sus notas no tenía(n) un formato válido.",
                                   "Alerta", MessageBoxButtons.OK);
                        }
                    }
                }
            }
            frmGroups.DGridView.Enabled = true;
            frmGroups.LoadData(savingFile);
            this.Close();
        }

        private void txtSaveName_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSaveName.Text.Replace(" ", "").Equals(""))
            {
                enableName = false;
            }
            else
            {
                enableName = true;
            }

            if (enableExtension && enableName)
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }

        private void cmbxExtension_TextChanged(object sender, EventArgs e)
        {
            if (cmbxExtension.Text.Equals(""))
            {
                enableExtension = false;
            }
            else
            {
                enableExtension = true;
            }

            if (enableExtension && enableName)
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }
        #endregion
    }
}
