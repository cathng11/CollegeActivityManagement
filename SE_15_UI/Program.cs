using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE_15_UI
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
                if (loginform.TypeUser == "UserAdmin")
                    Application.Run(new DashboardForm(loginform.TypeUser));
                if (loginform.TypeUser == "UserSinhVien")
                    Application.Run(new DashboardForm(loginform.TypeUser));
                if (loginform.TypeUser == "UserKhoa")
                    Application.Run(new DashboardForm(loginform.TypeUser));
            }
        }
           
    }
}
