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
    public partial class QLHD : Form
    {
        public delegate void MyDel(Form form);
        private MyDel _D;

        public MyDel D { get => _D; set => _D = value; }

        public QLHD()
        {
            InitializeComponent();
            SetView();
        }

        private void QLHD_SizeChanged(object sender, EventArgs e)
        {
            SetView();
            SetPicture();
        }
        private void SetView()
        {
            panel1.Height = this.Height * 15 / 100;
            panelButton.Width = this.Width * 20 / 100;
            foreach (Button b in this.panelButton.Controls.OfType<Button>())
            {
                b.Height = panelButton.Height * 25 / 100;
                b.ImageAlign = ContentAlignment.MiddleCenter;
                b.TextAlign = ContentAlignment.BottomCenter;
                b.TextImageRelation = TextImageRelation.ImageAboveText;
            }

            lbKhoa.Location = new Point(panel1.Width * 10 / 100, panel1.Height * 30 / 100);
            cbbKhoa.Location = new Point(lbKhoa.Location.X + lbKhoa.Width + 10, lbKhoa.Location.Y);
        }

        private void SetPicture()
        {
            if (this.Width > (Screen.PrimaryScreen.Bounds.Width * 70 / 100))
            {
                btnXem.Image = new Bitmap("Resource\\Read64.png");
                btnHuy.Image = new Bitmap("Resource\\Delete64.png");
                btnTao.Image = new Bitmap("Resource\\Create64.png");
                btnSua.Image = new Bitmap("Resource\\Edit64.png");
            }
            else
            {
                btnXem.Image = new Bitmap("Resource\\Read32.png");
                btnHuy.Image = new Bitmap("Resource\\Delete32.png");
                btnTao.Image = new Bitmap("Resource\\Create32.png");
                btnSua.Image = new Bitmap("Resource\\Edit32.png");
            }
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
        private void btnXem_Click(object sender, EventArgs e)
        {
            //HoatDong hd = new HoatDong();
            //hd.VisibleButtonSave();
            //this.openChildForm(hd);

            AdminForm admin = (AdminForm)Application.OpenForms["AdminForm"];
            this.D = new MyDel(admin.openChildForm);
            HoatDong hd = new HoatDong();
            hd.VisibleButtonSave();
            this.D(hd);
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            //this.openChildForm(new HoatDong());

            AdminForm admin = (AdminForm)Application.OpenForms["AdminForm"];
            this.D = new MyDel(admin.openChildForm);
            HoatDong hd = new HoatDong();
            this.D(hd);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //this.openChildForm(new HoatDong());

            AdminForm admin = (AdminForm)Application.OpenForms["AdminForm"];
            this.D = new MyDel(admin.openChildForm);
            HoatDong hd = new HoatDong();
            this.D(hd);
        }
    }
}
