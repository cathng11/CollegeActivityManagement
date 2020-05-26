using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestInterface
{
    public partial class LoginForm : Form
    {
        private bool successLogin;
        public bool SuccessLogin { get => successLogin; private set => successLogin = value; }

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btn_X_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SuccessLogin = true;
            Close();
        }
    }
}
