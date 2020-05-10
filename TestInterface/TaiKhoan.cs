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
    public partial class TaiKhoan : Form
    {
        public delegate void MyDel(Form form);
        private MyDel _D;

        public MyDel D { get => _D; set => _D = value; }

        public TaiKhoan()
        {
            InitializeComponent();
        }

        private void TaiKhoan_SizeChanged(object sender, EventArgs e)
        {
            SetView();
        }

        private void SetView()
        {
            tableLayoutPanel1.Height = this.Height * 70 / 100;
            tableLayoutPanel1.Width = this.Width * 50 / 100;
            tableLayoutPanel1.Location = new Point(this.Width * 25 / 100, this.Height * 10 / 100);

            btnSave.Location = new Point(this.Width * 25 / 100, this.Height * 85 / 100);
            btnThoat.Location = new Point(btnSave.Location.X + btnSave.Width + this.Width * 10 / 100, this.Height * 85 / 100);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminForm admin = (AdminForm)Application.OpenForms["AdminForm"];
            this.D = new MyDel(admin.openChildForm);
            this.D(new QLTK());
        }
    }
}
