using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE_15_UI
{
    public partial class TaiKhoanForm : Form
    {
        public delegate void MyDel(Form form);
        private MyDel _D;

        public MyDel D { get => _D; set => _D = value; }

        public TaiKhoanForm()
        {
            InitializeComponent();
        }
        public void VisibleButtonSave()
        {
            btnSave.Visible = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
