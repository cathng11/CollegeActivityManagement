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
    public partial class QLKhoaForm : Form
    {
        public delegate void MyDel(Form form);
        private MyDel _D;

        public MyDel D { get => _D; set => _D = value; }
        public QLKhoaForm()
        {
            InitializeComponent();
        }

        private void QLKhoa1_SizeChanged(object sender, EventArgs e)
        {
            SetPicture();
        }
        //
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

        private void btnXem_Click(object sender, EventArgs e)
        {
            DashboardForm df = (DashboardForm)Application.OpenForms["DashboardForm"];
            this.D = new MyDel(df.openForm);
            KhoaForm khoa = new KhoaForm();
            khoa.VisibleButtonSave();
            this.D(khoa);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DashboardForm df = (DashboardForm)Application.OpenForms["DashboardForm"];
            this.D = new MyDel(df.openForm);
            this.D(new KhoaForm());
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DashboardForm df = (DashboardForm)Application.OpenForms["DashboardForm"];
            this.D = new MyDel(df.openForm);
            this.D(new KhoaForm());
        }
    }
}
