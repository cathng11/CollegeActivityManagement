using SE_15_BLL;
using SE_15_DTO;
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
    public partial class DuyetYCForm : Form
    {
        public delegate void MyDel(Form form);
        private MyDel _D;
        public MyDel D { get => _D; set => _D = value; }

        public DuyetYCForm()
        {
            InitializeComponent();
            SetCBB();
            ShowYeuCau();
        }
        public void SetCBB()
        {
            if (cbbKhoa.Items == null)
            {
                cbbKhoa.Items.Clear();
            }
            cbbKhoa.Items.Add(new Khoa_DTO { IDKhoa = 0, TenKhoa = "All", SoLuongSV = 0, TenDangNhap = "" });
            foreach (Khoa_DTO item in Khoa_BLL.Instance.GetAll_BLL())
            {
                cbbKhoa.Items.Add(item);
            }

            cbbKhoa.SelectedIndex = 0;
        }
        private void SetPicture()
        {
            if (this.Width > (Screen.PrimaryScreen.Bounds.Width * 70 / 100))
                btnXem.Image = new Bitmap("Resource\\Read64.png");
            else
                btnXem.Image = new Bitmap("Resource\\Read32.png");
        }
        public void SetEmptyCells()
        {
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                dataGridView1.Rows[r.Index].Cells["Column5"].Value = "Chưa duyệt";
                dataGridView1.Rows[r.Index].Cells["Column6"].Value = "Đóng đăng ký";
            }
        }
        public void ShowYeuCau()
        {
            dataGridView1.DataSource = DuyetYC_BLL.Instance.GetListYC_BLL();
            SetEmptyCells();
        }
        private void btnXem_SizeChanged(object sender, EventArgs e)
        {
            SetPicture();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dataGridView1.SelectedRows;
            DashboardForm df = (DashboardForm)Application.OpenForms["DashboardForm"];
            this.D = new MyDel(df.openForm);
            if (r.Count <= 0) MessageBox.Show("Chưa chọn yêu cầu cần duyệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                HoatDongForm hd = new HoatDongForm(r[0].Cells[0].Value.ToString(), "UserAdmin");
                hd.D += new HoatDongForm.MyDel(ShowYeuCau);
                this.D(hd);
            }
        }

        private void cbbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbKhoa.SelectedIndex == 0)
            {
                ShowYeuCau();
            }
            else
            {
                dataGridView1.DataSource = DuyetYC_BLL.Instance.GetListYC_ByKhoa_BLL(((Khoa_DTO)cbbKhoa.SelectedItem).IDKhoa);
                SetEmptyCells();
            }
        }
    }
}
