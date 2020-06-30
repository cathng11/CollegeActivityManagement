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
    public partial class QLTKForm : Form
    {
        public delegate void MyDel(Form form);
        private MyDel _D;
        public MyDel D { get => _D; set => _D = value; }

        private string _TypeUser;
        public string TypeUser { get => _TypeUser; set => _TypeUser = value; }

        public QLTKForm(string typeUser)
        {
            TypeUser = typeUser;
            InitializeComponent();
            if (TypeUser == "UserKhoa" || TypeUser == "UserSinhVien")
                SetView_Khoa_SV();
            SetCBBLoaiTK();
            ShowTaiKhoan();
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
                btnXem.Image = SE_15_UI.Properties.Resources.Read64;
                btnXoa.Image = SE_15_UI.Properties.Resources.Delete64;
                btnThem.Image = SE_15_UI.Properties.Resources.Create64;
                btnSua.Image = SE_15_UI.Properties.Resources.Edit64;
                btnDoiMK.Image = SE_15_UI.Properties.Resources.ChangePW64;
            }
            else
            {
                btnXem.Image = SE_15_UI.Properties.Resources.Read32;
                btnXoa.Image = SE_15_UI.Properties.Resources.Delete32;
                btnThem.Image = SE_15_UI.Properties.Resources.Create32;
                btnSua.Image = SE_15_UI.Properties.Resources.Edit32;
                btnDoiMK.Image = SE_15_UI.Properties.Resources.ChangePW32png;

            }
        }

        private void QLTK1cs_SizeChanged(object sender, EventArgs e)
        {
            SetPicture();
        }

        public void ShowTaiKhoan()
        {
            if (TypeUser == "UserAdmin")
            {
                dtgvTaiKhoan.DataSource = TaiKhoan_BLL.Instance.GetAll_BLL();
            }
            else if (TypeUser == "UserKhoa")
            {
                DashboardForm dashboardForm = (DashboardForm)Application.OpenForms["DashboardForm"];
                Khoa khoa = Khoa_BLL.Instance.Get_ByTaiKhoan_BLL(dashboardForm.ID_TK);
                dtgvTaiKhoan.DataSource = TaiKhoan_BLL.Instance.GetTK_Khoa_SinhVien_ByKhoa_BLL(khoa.IDKhoa);
            }
            else
            {
                DashboardForm dashboardForm = (DashboardForm)Application.OpenForms["DashboardForm"];
                dtgvTaiKhoan.DataSource = TaiKhoan_BLL.Instance.ShowSV_BLL(dashboardForm.ID_TK);
            }
        }

        private void SetCBBLoaiTK()
        {
            if (TypeUser == "UserAdmin")
            {
                cbbLoaiTK.Items.Add(new LoaiTaiKhoan_DTO {IDLoaiTaiKhoan="",TenLoai= "All" });
                foreach (LoaiTaiKhoan_DTO item in LoaiTaiKhoan_BLL.Instance.GetAll_BLL())
                {
                    cbbLoaiTK.Items.Add(item);
                }
            }
            else if (TypeUser == "UserKhoa")
            {
                foreach (LoaiTaiKhoan_DTO item in LoaiTaiKhoan_BLL.Instance.GetAll_BLL())
                {
                    if (item.TenLoai != "Admin") cbbLoaiTK.Items.Add(item);
                }
            }
            else
            {
                cbbLoaiTK.Items.Add("Sinh viên");
                cbbLoaiTK.Enabled = false;
            }
            cbbLoaiTK.SelectedIndex = 0;
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dtgvTaiKhoan.SelectedRows;
            DashboardForm df = (DashboardForm)Application.OpenForms["DashboardForm"];
            this.D = new MyDel(df.openForm);
            DoiMKForm mk = new DoiMKForm(r[0].Cells[0].Value.ToString());
            this.D(mk);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dtgvTaiKhoan.SelectedRows;
            DashboardForm df = (DashboardForm)Application.OpenForms["DashboardForm"];
            this.D = new MyDel(df.openForm);
            TaiKhoanForm tk = new TaiKhoanForm(r[0].Cells[0].Value.ToString());
            tk.VisibleButtonSave();
            this.D(tk);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ConfirmForm cf = new ConfirmForm();
            cf.ShowDialog();
            if (cf.ConfirmSuccess)
            {
                DataGridViewSelectedRowCollection r = dtgvTaiKhoan.SelectedRows;
                TaiKhoan_BLL.Instance.Delete_BLL(r[0].Cells[0].Value.ToString());
                ShowTaiKhoan();

                MessageBox.Show("Xóa tài khoản thành công");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DashboardForm df = (DashboardForm)Application.OpenForms["DashboardForm"];
            this.D = new MyDel(df.openForm);
            TaiKhoanForm tk = new TaiKhoanForm("");
            this.D(tk);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dtgvTaiKhoan.SelectedRows;

            DashboardForm df = (DashboardForm)Application.OpenForms["DashboardForm"];
            this.D = new MyDel(df.openForm);
            TaiKhoanForm tk = new TaiKhoanForm(r[0].Cells[0].Value.ToString());
            this.D(tk);
        }

        private void cbbLoaiTK_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (TypeUser == "UserAdmin")
                {
                    if (cbbLoaiTK.SelectedIndex != 0)
                    {
                        string ID_LoaiTK = ((LoaiTaiKhoan_DTO)cbbLoaiTK.SelectedItem).IDLoaiTaiKhoan;
                        dtgvTaiKhoan.DataSource = TaiKhoan_BLL.Instance.Get_ByLoaiTaiKhoan_DAL(ID_LoaiTK);
                    }
                    else
                    {
                        ShowTaiKhoan();
                    }
                }
                else
                {
                    DashboardForm dashboardForm = (DashboardForm)Application.OpenForms["DashboardForm"];
                    Khoa khoa = Khoa_BLL.Instance.Get_ByTaiKhoan_BLL(dashboardForm.ID_TK);
                    if (cbbLoaiTK.SelectedIndex == 0)
                    {
                        dtgvTaiKhoan.DataSource = TaiKhoan_BLL.Instance.GetTK_Khoa_ByKhoa_BLL(khoa.IDKhoa);
                    }
                    else
                        dtgvTaiKhoan.DataSource = TaiKhoan_BLL.Instance.GetTK_SinhVien_ByKhoa_BLL(khoa.IDKhoa);
                }
            }
            catch (Exception)
            {
                ShowTaiKhoan();
            }
        }
    }
}
