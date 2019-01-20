/*
 * EXERCISE.............: Exercise 8.
 * NAME AND LASTNAME...: Tania López Martín 
 * CURSE AND GROUP.....: 2º Interface Development 
 * PROJECT.............: Forms II. Components
 * DATE................: 21 Jan 2019
 */


using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Exercise8
{
    public partial class frmCreate : Form
    {
        #region attributes
        bool enableName;
        bool enableAccept;
        #endregion
        #region constructor
        public frmCreate()
        {
            InitializeComponent();
        }
        #endregion
        #region voids     
        public void EnableObjects(bool state)
        {
            this.txtName.Enabled = state;
            this.cmbxSubjects.Enabled = state;
        }
        #endregion
        #region events
        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            bool correctName;
            TextBox textBox = (TextBox)sender;

            if (this.txtName.TextLength < 3 && txtName.Focused)
            {
                correctName = false;
                this.txtName.BackColor = Color.LightPink;
            }
            else if (this.txtName.TextLength >= 3 && txtName.Focused)
            {
                correctName = true;
                this.txtName.BackColor = Color.LightGreen;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            string info;
            Label label;
            string name = txtName.Text;
            string[] subjects = new string[4];

            for (int i = 0; i < subjects.Length; i++)
            {
                info = "lblSubject" + (i + 1);
                label = this.Controls.Find(info, true).FirstOrDefault() as Label;
                subjects[i] = label.Text;
            }

            frmGroups.CurrentGroup = new Group(subjects, name);
            frmGroups.DGridView.Enabled = true;
            frmGroups.UpdateMainForm();
            this.Close();
        }

        private void cmbxSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            string info;
            enableAccept = true;
            Label label;
            string[] subjects = new string[4];

            for (int i = 0; i < subjects.Length; i++)
            {
                info = "lblSubject" + (i + 1);
                label = this.Controls.Find(info, true).FirstOrDefault() as Label;

                if (label.Text.Equals(""))
                {
                    label.Text = cmbxSubjects.Text;
                    cmbxSubjects.Items.Remove(cmbxSubjects.Text);
                } 
            }

            for (int i = 0; i < subjects.Length; i++)
            {
                info = "lblSubject" + (i + 1);
                label = this.Controls.Find(info, true).FirstOrDefault() as Label;

                if (label.Text.Equals(""))
                {
                   enableAccept = false;
                }
            }

            if (enableAccept && enableName)
            {
                btnAccept.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != Convert.ToChar(Keys.Tab) && e.KeyChar != Convert.ToChar(Keys.Enter) && !char.IsLetter(e.KeyChar)
                && e.KeyChar != Convert.ToChar(Keys.Back) && e.KeyChar != Convert.ToChar(Keys.Space);
            TextBox textBox = (TextBox)sender;
        }

        private void txtName_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (txtName.Text.Replace(" ", "").Equals(""))
            {
                enableName = false;
                txtName.BackColor = Color.Pink;
            }
            else
            {
                enableName = true;
                txtName.BackColor = Color.LightGreen;
            }

            if (enableAccept && enableName)
            {
                btnAccept.Enabled = true;
            } else
            {
                btnAccept.Enabled = false;
            }
        }
        #endregion
    }
}
