/*
 * EXERCISE............: Exercise 8.
 * NAME AND LASTNAME...: Tania López Martín 
 * CURSE AND GROUP.....: 2º Interface Development 
 * PROJECT.............: Forms II. Components
 * DATE................: 21 Jan 2019
 */


using System;
using System.Windows.Forms;

namespace Exercise8
{
    static class MainClass
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        /// 
        [STAThread]
        #region main
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmSplashScreen());
        }
        #endregion
    }
}
