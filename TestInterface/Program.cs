using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestInterface
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm loginform = new LoginForm();
            Application.Run(loginform);

            if (loginform.SuccessLogin)
            {
                Application.Run(new AdminForm());
            }
            //Application.Run(new QLSV());
        }
           
    }
}
