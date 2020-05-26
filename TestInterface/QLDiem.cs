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

    public partial class QLDiem : Form
    {
        public delegate void MyDel(Form form);
        private MyDel _D;

        public MyDel D { get => _D; set => _D = value; }
        public QLDiem()
        {
            InitializeComponent();
            SetView_SV();
        }

        private void SetView_SV()
        {
            btnGiam.Visible = false;
            btnTang.Visible = false;
            layoutButton.RowCount = 1;
        }

        private void QLDiem1_SizeChanged(object sender, EventArgs e)
        {
            SetPicture();
        }

        private void SetPicture()
        {
            if (this.Width > (Screen.PrimaryScreen.Bounds.Width * 70 / 100))
            {
                btnXem.Image = new Bitmap("Resource\\Read64.png");
                btnGiam.Image = new Bitmap("Resource\\Decrease64.png");
                btnTang.Image = new Bitmap("Resource\\Increase64.png");
            }
            else
            {
                btnXem.Image = new Bitmap("Resource\\Read32.png");
                btnGiam.Image = new Bitmap("Resource\\Decrease32.png");
                btnTang.Image = new Bitmap("Resource\\Increase32.png");
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            Admin admin = (Admin)Application.OpenForms["Admin"];
            this.D = new MyDel(admin.openForm);
            this.D(new Diem());
        }

        private void btnGiam_Click(object sender, EventArgs e)
        {

        }

        private void btnTang_Click(object sender, EventArgs e)
        {

        }
    }
}
