using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SE_15_DTO;
using SE_15_BLL;

namespace SE_15_UI
{
    public partial class ThongKeForm : Form
    {
        public delegate void MyDel(Form form);
        private MyDel _D;
        public MyDel D { get => _D; set => _D = value; }

        private string typeUser;
        public string TypeUser { get => typeUser; set => typeUser = value; }

        public ThongKeForm(string tUser)
        {
            TypeUser = tUser;
            InitializeComponent();
            SetCBBKhoa();
            ShowHoatDongs();
        }

        private void SetPicture()
        {
            if (this.Width > (Screen.PrimaryScreen.Bounds.Width * 70 / 100))
            {
                btnSVThamGia.Image = SE_15_UI.Properties.Resources.Read64;
                btnSoLuongSV.Image = SE_15_UI.Properties.Resources.Create64;
            }
            else
            {
                btnSVThamGia.Image = SE_15_UI.Properties.Resources.Read32;
                btnSoLuongSV.Image = SE_15_UI.Properties.Resources.Create32;
            }
        }

        private void SetCBBKhoa()
        {
            if (TypeUser == "UserAdmin")
            {
                cbbKhoa.Items.Add(new Khoa_DTO { IDKhoa = 0, TenKhoa = "All", SoLuongSV = 0, TenDangNhap = "" });
                foreach (Khoa_DTO item in Khoa_BLL.Instance.GetAll_BLL())
                {
                    cbbKhoa.Items.Add(item);
                }

                cbbKhoa.SelectedIndex = 0;

            }
            else if (TypeUser == "UserKhoa")
            {
                DashboardForm dashboardForm = (DashboardForm)Application.OpenForms["DashboardForm"];
                Khoa khoa = Khoa_BLL.Instance.Get_ByTaiKhoan_BLL(dashboardForm.ID_TK);
                cbbKhoa.Text = khoa.TenKhoa;
                cbbKhoa.Enabled = false;
            }
        }

        public void ShowHoatDongs()
        {
            if (TypeUser == "UserAdmin")
            {
                dtgvHoatDong.DataSource = HoatDong_BLL.Instance.GetALL_BLL();

            }
            else if (TypeUser == "UserKhoa")
            {
                DashboardForm dashboardForm = (DashboardForm)Application.OpenForms["DashboardForm"];
                Khoa khoa = Khoa_BLL.Instance.Get_ByTaiKhoan_BLL(dashboardForm.ID_TK);
                dtgvHoatDong.DataSource = HoatDong_BLL.Instance.Get_ByKhoa_BLL(khoa.IDKhoa);
            }

        }
        private void btnSVThamGia_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dtgvHoatDong.SelectedRows;
            if (r.Count == 0) return;

            DashboardForm df = (DashboardForm)Application.OpenForms["DashboardForm"];
            this.D = new MyDel(df.openForm);
            this.D(new ThongKeForm_DSSV(r[0].Cells[0].Value.ToString()));
        }

        private void btnSoLuongSV_Click(object sender, EventArgs e)
        {
            DashboardForm df = (DashboardForm)Application.OpenForms["DashboardForm"];
            this.D = new MyDel(df.openForm);
            this.D(new ThongKeForm_Chart());
        }

        private void ThongKeForm_SizeChanged(object sender, EventArgs e)
        {
            SetPicture();
        }

        private void cbbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbKhoa.SelectedIndex == 0)
            {
                ShowHoatDongs();
            }
            else
            {
                dtgvHoatDong.DataSource = HoatDong_BLL.Instance.Get_ByKhoa_BLL(((Khoa_DTO)cbbKhoa.SelectedItem).IDKhoa);
            }
        }
    }
}
