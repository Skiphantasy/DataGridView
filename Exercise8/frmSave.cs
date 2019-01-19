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
        bool enableName = true;
        bool enableExtension;
        public frmSave()
        {
            InitializeComponent();
            txtSaveName.Text = frmGroups.GroupName.Text;
        }
      

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool existFile = false;
            string savingFile;
            int emptyColumns;
            DirectoryInfo d;
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

                        for (int j = 0; j < frmGroups.DGridView.Columns.Count; ++j)
                        {
                            DataGridViewCell val = dgvR.Cells[j];
                        
                            if (val.Value == null)
                            {
                                emptyColumns++;
                            }
                        }

                        if (emptyColumns == 0)
                        {
                            for (int j = 0; j < frmGroups.DGridView.Columns.Count; ++j)
                            {
                                DataGridViewCell val = dgvR.Cells[j];

                                bw.Write(true);
                                bw.Write(val.Value.ToString());
                            }
                        }
                    }
                }
            }
            frmGroups.DGridView.Enabled = true;
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
    }
}
