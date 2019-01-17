using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise8
{
    public partial class frmCreate : Form
    {
        public frmCreate()
        {
            InitializeComponent();
        }
        #region voids     
        public void EnableObjects(bool state)
        {
            this.txtName.Enabled = state;
            this.cmbxSubjects.Enabled = state;
        }
        #endregion

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
            this.Close();
        }

        private void cmbxSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            string info;
            Label label;
            int counter = 0;
            string[] subjects = new string[4];

            for (int i = 0; i < subjects.Length; i++)
            {
                info = "lblSubject" + (i + 1);
                label = this.Controls.Find(info, true).FirstOrDefault() as Label;

                if (label.Text.Equals("") && counter == 0)
                {
                    counter++;
                    label.Text = cmbxSubjects.Text;
                } 
            }

            if(counter == 0)
            {
                btnAccept.Enabled = true;
            }
        }

        private void txtNameAndLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar != Convert.ToChar(Keys.Tab) && e.KeyChar != Convert.ToChar(Keys.Enter) && !char.IsLetter(e.KeyChar)
                && e.KeyChar != Convert.ToChar(Keys.Back) && e.KeyChar != Convert.ToChar(Keys.Space);
            TextBox textBox = (TextBox)sender;

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
    }
}
