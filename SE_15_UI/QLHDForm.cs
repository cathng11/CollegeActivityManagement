using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.SqlServer;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SE_15_DTO;
using SE_15_BLL;

namespace SE_15_UI
{
    public partial class QLHDForm : Form
    {
        public delegate void MyDel(Form form);
        private MyDel _D;
        public MyDel D { get => _D; set => _D = value; }

        private string typeUser;
        public string TypeUser { get => typeUser; set => typeUser = value; }

        private Nullable<int> _IDSinhVien;
        public Nullable<int> IDSinhVien { get => _IDSinhVien; set => _IDSinhVien = value; }

        public QLHDForm(string typeUser, Nullable<int> idsv)
        {
            TypeUser = typeUser;
            IDSinhVien = idsv;
            InitializeComponent();
            if (TypeUser == "UserSinhVien")
            {
                SetView_SV();
            }
            SetCBBKhoa();
            ShowHoatDongs();

        }
        private void SetView_SV()
        {
            btnSua.Visible = false;
            layoutButton.RowCount = 3;
            btnTao.Text = "Đăng ký";
            btnHuy.Text = "Hủy đăng ký";
            layoutButton.SetRow(btnTao, 1);
            
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
            else
            { 
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
            else
            {

            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dtgvHoatDong.SelectedRows;
            if (r.Count == 0) return;
            DashboardForm df = (DashboardForm)Application.OpenForms["DashboardForm"];
            this.D = new MyDel(df.openForm);
            HoatDongForm hd = new HoatDongForm(r[0].Cells[0].Value.ToString(), typeUser);
            hd.VisibleButtonSave();
            this.D(hd);
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            DashboardForm df = (DashboardForm)Application.OpenForms["DashboardForm"];
            this.D = new MyDel(df.openForm);
            HoatDongForm hd = new HoatDongForm("", typeUser);
            this.D(hd);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ConfirmForm cf = new ConfirmForm();
            cf.ShowDialog();
            if (cf.ConfirmSuccess)
            {
                DataGridViewSelectedRowCollection r = dtgvHoatDong.SelectedRows;
                HoatDong_BLL.Instance.Del_BLL(r[0].Cells["Column1"].Value.ToString());
                ShowHoatDongs();
                MessageBox.Show("Xoa/Huy thanh cong");
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dtgvHoatDong.SelectedRows;
            if (r.Count == 0) return;

            DashboardForm df = (DashboardForm)Application.OpenForms["DashboardForm"];
            this.D = new MyDel(df.openForm);
            HoatDongForm hd = new HoatDongForm(r[0].Cells[0].Value.ToString(), typeUser);
            this.D(hd);
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbKhoa.SelectedIndex == 0)
                {
                    try
                    {
                        dtgvHoatDong.DataSource = HoatDong_BLL.Instance.Get_ConstainName_BLL(txtTimKiem.Text, 0);
                    }
                    catch (Exception)
                    {
                        ShowHoatDongs();
                    }
                }
                else
                {
                    int id_Khoa = ((Khoa_DTO)cbbKhoa.SelectedItem).IDKhoa;
                    try
                    {
                        dtgvHoatDong.DataSource = HoatDong_BLL.Instance.Get_ConstainName_BLL(txtTimKiem.Text, id_Khoa);
                    }
                    catch (Exception)
                    {
                        dtgvHoatDong.DataSource = HoatDong_BLL.Instance.Get_ByKhoa_BLL(id_Khoa);
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private void QLHD1_SizeChanged(object sender, EventArgs e)
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
