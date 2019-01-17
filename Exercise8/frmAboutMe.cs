/*
 * EXERCISE.............: Exercise 7.
 * NAME AND LASTNAME...: Tania López Martín 
 * CURSE AND GROUP.....: 2º Interface Development 
 * PROJECT.............: Forms
 * DATE................: 17 Dic 2018
 */


using Microsoft.Win32;
using System.Windows.Forms;

namespace Exercise8
{
    public partial class frmAboutMe : Form
    {
        #region constructor
        public frmAboutMe()
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\OurSettings");
            InitializeComponent();
            this.CenterToParent();

            if (key != null)
            {
                lblCounter.Text = key.GetValue("Uses").ToString();
                key.Close();
            }
        }
        #endregion
        #region event voids
        private void frmAboutMe_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmGroups.Open = false;
        }
        #endregion
    }
}
