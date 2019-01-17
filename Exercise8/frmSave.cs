using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise8
{
    public partial class frmSave : Form
    {
        public frmSave()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string savingFile;
            int emptyColumns;
            savingFile = txtSaveName.Text + ".gru";
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
                            bw.Write(false);
                            bw.Write(false);
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

            this.Close();
        }
    }
}
