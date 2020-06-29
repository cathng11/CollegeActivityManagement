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
    public partial class QLSV : Form
    {
        public delegate void MyDel(Form form);
        private MyDel _D;

        public MyDel D { get => _D; set => _D = value; }
        public QLSV()
        {
            InitializeComponent();
            //SetView_Khoa();
        }

        private void SetView_Khoa()
        {
            layoutButton.RowCount = 2;
            layoutButton.SetRow(btnSua, 1);
            btnThem.Visible = false;
            btnXoa.Visible = false;
        }

        private void SetPicture()
        {
            if (this.Width > (Screen.PrimaryScreen.Bounds.Width * 70 / 100))
            {
                btnXem.Image = new Bitmap("Resource\\Read64.png");
                btnXoa.Image = new Bitmap("Resource\\Delete64.png");
                btnThem.Image = new Bitmap("Resource\\Add64.png");
                btnSua.Image = new Bitmap("Resource\\Edit64.png");
            }
            else
            {
                btnXem.Image = new Bitmap("Resource\\Read32.png");
                btnXoa.Image = new Bitmap("Resource\\Delete32.png");
                btnThem.Image = new Bitmap("Resource\\Add32.png");
                btnSua.Image = new Bitmap("Resource\\Edit32.png");
            }
        }

        private void dataGridView1_SizeChanged(object sender, EventArgs e)
        {
            SetPicture();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            Admin admin = (Admin)Application.OpenForms["Admin"];
            this.D = new MyDel(admin.openForm);
            SinhVien sv = new SinhVien();
            sv.VisibleButtonSave();
            this.D(sv);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Admin admin = (Admin)Application.OpenForms["Admin"];
            this.D = new MyDel(admin.openForm);
            SinhVien sv = new SinhVien();
            this.D(sv);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Admin admin = (Admin)Application.OpenForms["Admin"];
            this.D = new MyDel(admin.openForm);
            SinhVien sv = new SinhVien();
            this.D(sv);
        }
    }
}
