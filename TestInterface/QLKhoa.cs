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
    public partial class QLKhoa : Form
    {
        public delegate void MyDel(Form form);
        private MyDel _D;

        public MyDel D { get => _D; set => _D = value; }

        public QLKhoa()
        {
            InitializeComponent();
            SetView();
        }

        private void QLKhoa_SizeChanged(object sender, EventArgs e)
        {
            SetView();
            SetPicture();
        }

        private void SetView()
        {
            panel1.Height = this.Height * 15 / 100;
            panelButton.Width = this.Width * 20 / 100;
            btnXem.Height = panelButton.Height * 33 / 100;
            btnThem.Height = panelButton.Height * 33 / 100;
            btnSua.Height = panelButton.Height * 34 / 100;
            foreach (Button b in this.panelButton.Controls.OfType<Button>())
            {
                b.Height = panelButton.Height * 34 / 100;
                b.ImageAlign = ContentAlignment.MiddleCenter;
                b.TextAlign = ContentAlignment.BottomCenter;
                b.TextImageRelation = TextImageRelation.ImageAboveText;
            }
        }

        private void SetPicture()
        {
            if (this.Width > (Screen.PrimaryScreen.Bounds.Width * 70 / 100))
            {
                btnXem.Image = new Bitmap("Resource\\Read64.png");
                btnThem.Image = new Bitmap("Resource\\Add64.png");
                btnSua.Image = new Bitmap("Resource\\Edit64.png");
            }
            else
            {
                btnXem.Image = new Bitmap("Resource\\Read32.png");
                btnThem.Image = new Bitmap("Resource\\Add32.png");
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
            //openChildForm(new Khoa());

            AdminForm admin = (AdminForm)Application.OpenForms["AdminForm"];
            this.D = new MyDel(admin.openForm);
            this.D(new Khoa());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //openChildForm(new Khoa());

            AdminForm admin = (AdminForm)Application.OpenForms["AdminForm"];
            this.D = new MyDel(admin.openForm);
            this.D(new Khoa());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //openChildForm(new Khoa());

            AdminForm admin = (AdminForm)Application.OpenForms["AdminForm"];
            this.D = new MyDel(admin.openChildForm);
            this.D(new Khoa());
        }
    }
}
