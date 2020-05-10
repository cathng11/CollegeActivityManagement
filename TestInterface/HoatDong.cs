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
    public partial class HoatDong : Form
    {
        public delegate void MyDel(Form form);
        private MyDel _D;

        public MyDel D { get => _D; set => _D = value; }

        public HoatDong()
        {
            InitializeComponent();
        }
        public void VisibleButtonSave()
        {
            btnSave.Visible = false;
            btnThoat.Location = new Point(445, 545);
        }
        private void SetView()
        {
            tableLayoutPanel1.Height = this.Height * 70 / 100;
            tableLayoutPanel1.Width = this.Width * 45 / 100;
            tableLayoutPanel2.Height = tableLayoutPanel1.Height * 70 / 100;
            tableLayoutPanel2.Width = this.Width * 45 / 100;
            tableLayoutPanel3.Height = tableLayoutPanel1.Height * 25 / 100; 
            tableLayoutPanel3.Width = this.Width * 45 / 100;

            tableLayoutPanel1.Location = new Point(this.Width * 5 / 100, this.Height * 5 / 100);
            tableLayoutPanel2.Location = new Point(this.Width * 52 / 100, tableLayoutPanel1.Location.Y);
            tableLayoutPanel3.Location = new Point(this.Width * 52 / 100, tableLayoutPanel1.Location.Y + tableLayoutPanel2.Height + tableLayoutPanel1.Height * 5 / 100);

            btnThoat.Location = new Point(this.Width * 65 / 100, tableLayoutPanel1.Location.Y + tableLayoutPanel1.Height + 50);
            btnSave.Location = new Point(this.Width * 35 / 100, tableLayoutPanel1.Location.Y + tableLayoutPanel1.Height + 50);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminForm admin = (AdminForm)Application.OpenForms["AdminForm"];
            this.D = new MyDel(admin.openChildForm);
            this.D(new QLHD());
        }

        private void HoatDong_SizeChanged(object sender, EventArgs e)
        {
            SetView();
        }
    }
}
