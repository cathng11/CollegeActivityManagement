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
    public partial class QLHDForm : Form
    {
        public delegate void MyDel(Form form);
        private MyDel _D;

        public MyDel D { get => _D; set => _D = value; }
        public QLHDForm()
        {
            InitializeComponent();
            //SetView_SV();
        }

        private void SetView_SV()
        {
            btnSua.Visible = false;
            layoutButton.RowCount = 3;
            btnTao.Text = "Đăng ký";
            btnHuy.Text = "Hủy đăng ký";
            layoutButton.SetRow(btnTao,2);
            
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

        private void QLHD1_SizeChanged(object sender, EventArgs e)
        {
            SetPicture();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DashboardForm df = (DashboardForm)Application.OpenForms["DashboardForm"];
            this.D = new MyDel(df.openForm);
            HoatDongForm hd = new HoatDongForm();
            hd.VisibleButtonSave();
            this.D(hd);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ConfirmForm cf = new ConfirmForm();
            cf.ShowDialog();
            if (cf.ConfirmSuccess)
            {
                //delete
                MessageBox.Show("Xoa/Huy thanh cong");

            }
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            DashboardForm df = (DashboardForm)Application.OpenForms["DashboardForm"];
            this.D = new MyDel(df.openForm);
            HoatDongForm hd = new HoatDongForm();
            this.D(hd);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DashboardForm df = (DashboardForm)Application.OpenForms["DashboardForm"];
            this.D = new MyDel(df.openForm);
            HoatDongForm hd = new HoatDongForm();
            this.D(hd);
        }
    }
}
