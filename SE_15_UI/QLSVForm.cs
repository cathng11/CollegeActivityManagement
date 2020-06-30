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
    public partial class QLSVForm : Form
    {
        public delegate void MyDel(Form form);
        private MyDel _D;
        public MyDel D { get => _D; set => _D = value; }

        private string _ID_TK;
        public string ID_TK { get => _ID_TK; set => _ID_TK = value; }

        private string _TypeUser;
        public string TypeUser { get => _TypeUser; set => _TypeUser = value; }

        public QLSVForm(string typeUser, string idtk)
        {
            ID_TK = idtk;
            TypeUser = typeUser;
            InitializeComponent();
            ShowSinhVien();
            if (typeUser == "UserKhoa") SetView_Khoa();
            SetCBB();
        }

        private void SetView_Khoa()
        {
            layoutButton.RowCount = 2;
            layoutButton.SetRow(btnSua, 1);
            btnThem.Visible = false;
            btnXoa.Visible = false;
            string tenKhoa = Khoa_BLL.Instance.Get_ByTaiKhoan_BLL(ID_TK).TenKhoa.ToString();
            cbbKhoa.Text = tenKhoa;
            cbbKhoa.Enabled = true;
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

        public void ShowSinhVien()
        {
            if (TypeUser == "UserKhoa") dtgvSinhVien.DataSource = SinhVien_BLL.Instance.GetSV_ByKhoa_BLL(ID_TK);
            else dtgvSinhVien.DataSource = SinhVien_BLL.Instance.GetListSV_BLL().ToList();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dtgvSinhVien.SelectedRows;
            if (r.Count <= 0) MessageBox.Show("Chưa chọn sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                SinhVienForm sv = new SinhVienForm(Convert.ToInt32(r[0].Cells["Column1"].Value), TypeUser);
                sv.VisibleButtonSave();
                DashboardForm df = (DashboardForm)Application.OpenForms["DashboardForm"];
                this.D = new MyDel(df.openForm);
                this.D(sv);
            }

        }
        private void btnXoa_Click(object sender, EventArgs e)
        {

            ConfirmForm cf = new ConfirmForm();
            cf.ShowDialog();
            if (cf.ConfirmSuccess)
            {
                DataGridViewSelectedRowCollection r = dtgvSinhVien.SelectedRows;
                if (r.Count != 1) MessageBox.Show("Chọn 1 sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    SinhVien sv = new SinhVien();
                    sv.IDSinhVien = Convert.ToInt32(Convert.ToInt32(r[0].Cells["Column1"].Value));
                    SinhVien_BLL.Instance.DelSV_BLL(sv);
                    MessageBox.Show("Xóa thành công!");
                }
            }
            dtgvSinhVien.DataSource = SinhVien_BLL.Instance.GetListSV_BLL().ToList();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DashboardForm df = (DashboardForm)Application.OpenForms["DashboardForm"];
            this.D = new MyDel(df.openForm);
            SinhVienForm sv = new SinhVienForm(null, TypeUser);
            this.D(sv);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DashboardForm df = (DashboardForm)Application.OpenForms["DashboardForm"];
            this.D = new MyDel(df.openForm);

            DataGridViewSelectedRowCollection r = dtgvSinhVien.SelectedRows;
            if (r.Count != 1) MessageBox.Show("Chọn 1 sinh viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                SinhVienForm sv = new SinhVienForm(Convert.ToInt32(r[0].Cells["Column1"].Value), TypeUser);
                this.D(sv);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tenKhoa = cbbKhoa.SelectedItem.ToString();
            int searchKhoa;
            if (tenKhoa == "All") searchKhoa = 0;
            else searchKhoa = Khoa_BLL.Instance.GetIDKhoa_BLL(tenKhoa);
            string searchTen = txtTimKiem.Text;
            dtgvSinhVien.DataSource = SinhVien_BLL.Instance.GetListSV_ByTenSV_BLL(searchKhoa, searchTen);

        }

        private void QLSVForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width > (Screen.PrimaryScreen.Bounds.Width * 70 / 100))
            {
                btnXem.Image = SE_15_UI.Properties.Resources.Read64;
                btnXoa.Image = SE_15_UI.Properties.Resources.Delete64;
                btnThem.Image = SE_15_UI.Properties.Resources.Create64;
                btnSua.Image = SE_15_UI.Properties.Resources.Edit64;
            }
            else
            {
                btnXem.Image = SE_15_UI.Properties.Resources.Read32;
                btnXoa.Image = SE_15_UI.Properties.Resources.Delete32;
                btnThem.Image = SE_15_UI.Properties.Resources.Create32;
                btnSua.Image = SE_15_UI.Properties.Resources.Edit32;
            }
        }

        private void cbbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbKhoa.SelectedIndex == 0)
            {
                ShowSinhVien();
            }
            else
            {
                dtgvSinhVien.DataSource = SinhVien_BLL.Instance.GetListSV_Where_BLL(((Khoa_DTO)cbbKhoa.SelectedItem).IDKhoa);
 
            }
        }
    }
}
