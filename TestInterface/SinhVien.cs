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
    public partial class SinhVien : Form
    {
        public delegate void MyDel(Form form);
        private MyDel _D;

        public MyDel D { get => _D; set => _D = value; }

        public SinhVien()
        {
            InitializeComponent();
        }

        public void VisibleButtonSave(bool success)
        {
            if (success) btnSave.Visible = false;
            else btnSave.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //query

        }
        private void openChildForm(Form form)
        {
            form.TopLevel = false;
            AdminForm admin = (AdminForm)Application.OpenForms["AdminForm"];
            Panel panel = (Panel)admin.Controls["panelChildForm"];
            form.Parent = admin;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel.Tag = form;
            form.BringToFront();
            panel.Controls.Add(form);
            Close();
            form.Width = this.Width;
            form.Height = this.Height;
            form.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            //AdminForm admin = (AdminForm)Application.OpenForms["AdminForm"];
            //this.D = new MyDel(admin.openChildForm);
            //this.D(new QLSV());
        }

        private void SinhVien_SizeChanged(object sender, EventArgs e)
        {
           // SetView();
        }

        private void SetView()
        {
            table1.Height = this.Height * 70 / 100;
            table1.Width = this.Width * 45 / 100;
            table1.Location = new Point(this.Width * 5 / 100, this.Height * 5 / 100);
            table2.Height = this.Height * 70 / 100;
            table2.Width = this.Width * 45 / 100;
            table2.Location = new Point(this.Width * 50 / 100, table1.Location.Y);
            if (btnSave.Visible == true)
            {
                btnThoat.Location = new Point(this.Width / 2, table1.Location.Y + table1.Height + 50);
            }
            else
            {
                btnThoat.Location = new Point(this.Width * 65 / 100, table1.Location.Y + table1.Height + 50);
                btnSave.Location = new Point(this.Width * 35 / 100, table1.Location.Y + table1.Height + 50);
            }
        }
    }
}
