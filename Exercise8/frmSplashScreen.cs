/*
 * EXERCISE............: Exercise 8.
 * NAME AND LASTNAME...: Tania López Martín 
 * CURSE AND GROUP.....: 2º Interface Development 
 * PROJECT.............: Forms II. Components 
 * DATE................: 08 Jan 2018
 */
 

using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Exercise8
{
    public partial class frmSplashScreen : Form
    {
        #region attributes
        int time;
        #endregion
        #region constructor
        public frmSplashScreen()
        {            
            InitializeComponent();
            this.BackColor = Color.Black;
            this.TransparencyKey = Color.Black;
            cbarSplash.Value = 10;
            time = 0;
            cbarSplash2.Value = 10;
            this.tmrBar.Start();
        }
        #endregion
        #region voids
        private void OpenMainForm()
        {
            Thread.Sleep(1000);
            Application.Run(new frmGroups());
        }
        #endregion
        #region event voids
        private void tmrBar_Tick(object sender, EventArgs e)
        {
            time++;
            Thread thread;

            if (time < 200)
            {
                this.cbarSplash.StartAngle += 5;
                this.cbarSplash2.StartAngle += 5;
            }   
            else
            {
                Application.Exit();
                thread = new Thread(OpenMainForm);
                thread.Start();                         
            }
        }
        #endregion
    }
}
