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
    public partial class QLTK : Form
    {
        public QLTK()
        {
            InitializeComponent();
            SetView();
        }


        private void SetView()
        {
            panel1.Height = this.Height * 15 / 100;
            panelButton.Width = this.Width * 20 / 100;

            foreach(Button b in this.panelButton.Controls.OfType<Button>())
            {
                b.Height = panelButton.Height * 20 / 100;
                b.ImageAlign = ContentAlignment.MiddleCenter;
                b.TextAlign = ContentAlignment.BottomCenter;
                b.TextImageRelation = TextImageRelation.ImageAboveText;

            }
            lbLoaiTK.Location = new Point(panel1.Location.X + panel1.Width * 10 / 100, panel1.Location.Y + panel1.Height * 30 / 100);
            cbbLoaiTK.Location = new Point(lbLoaiTK.Location.X + lbLoaiTK.Width + 10, lbLoaiTK.Location.Y);
        }

        private void SetPicture()
        {
            if (this.Width > (Screen.PrimaryScreen.Bounds.Width * 70 / 100))
            {
                btnXem.Image = new Bitmap("Resource\\Read64.png");
                btnXoa.Image = new Bitmap("Resource\\Delete64.png");
                btnThem.Image = new Bitmap("Resource\\Create64.png");
                btnSua.Image = new Bitmap("Resource\\Edit64.png");
                btnDoiMK.Image = new Bitmap("Resource\\ChangePW64.png");
            }
            else
            {
                btnXem.Image = new Bitmap("Resource\\Read32.png");
                btnXoa.Image = new Bitmap("Resource\\Delete32.png");
                btnThem.Image = new Bitmap("Resource\\Create32.png");
                btnSua.Image = new Bitmap("Resource\\Edit32.png");
                btnDoiMK.Image = new Bitmap("Resource\\ChangePW32.png");

            }
        }

        private void QLTK_SizeChanged(object sender, EventArgs e)
        {
            SetView();
            SetPicture();
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
            openChildForm(new TaiKhoan());
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            openChildForm(new DoiMK());

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            openChildForm(new TaiKhoan());

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            openChildForm(new TaiKhoan());

        }
    }
}
