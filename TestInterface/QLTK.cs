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
        public delegate void MyDel(Form form);
        private MyDel _D;
        public MyDel D { get => _D; set => _D = value; }
        public QLTK()
        {
            InitializeComponent();
            SetView_Khoa_SV();
        }

        private void SetView_Khoa_SV()
        {
            btnXoa.Visible = false;
            btnThem.Visible = false;
            layoutButton.RowCount = 3;
            layoutButton.SetRow(btnSua, 2);
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

        private void QLTK1cs_SizeChanged(object sender, EventArgs e)
        {
            SetPicture();
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            Admin admin = (Admin)Application.OpenForms["Admin"];
            this.D = new MyDel(admin.openForm);
            DoiMK mk = new DoiMK();
            this.D(mk);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            Admin admin = (Admin)Application.OpenForms["Admin"];
            this.D = new MyDel(admin.openForm);
            TaiKhoan tk = new TaiKhoan();
            tk.VisibleButtonSave();
            this.D(tk);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Admin admin = (Admin)Application.OpenForms["Admin"];
            this.D = new MyDel(admin.openForm);
            TaiKhoan tk = new TaiKhoan();
            this.D(tk);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Admin admin = (Admin)Application.OpenForms["Admin"];
            this.D = new MyDel(admin.openForm);
            TaiKhoan tk = new TaiKhoan();
            this.D(tk);
        }
    }
}
