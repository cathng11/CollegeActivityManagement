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
    public partial class SinhVienForm : Form
    {

        public delegate void MyDel();
        private MyDel _D;
        public MyDel D { get => _D; set => _D = value; }

        private Nullable<int> _IDSinhVien;
        public Nullable<int> IDSinhVien { get => _IDSinhVien; set => _IDSinhVien = value; }

        private string _TypeUser;
        public string TypeUser { get => _TypeUser; set => _TypeUser = value; }

        public SinhVienForm(Nullable<int> id,string typeUser)
        {
            IDSinhVien = id;
            TypeUser = typeUser;
            InitializeComponent();
            SetCBB();
            SetView();

        }
        public void VisibleButtonSave()
        {
            btnSave.Visible = false;
            foreach (Control i in this.tableLayoutPanel2.Controls)
            {
                i.Enabled = false;
            }

        }
        public void SetView()
        {
            if (IDSinhVien == null)
            {
                foreach (TextBox i in this.tableLayoutPanel2.Controls.OfType<TextBox>())
                {
                    i.Text = null;
                }
                dateTimePicker1.Value = DateTime.Today;
                radioButton_Exist.Checked = true;
                radioButton_Nam.Checked = false;
                radioButton_Nu.Checked = false;
                txtDiem.Value = 0;
            }
            else
            {
                if (TypeUser == "UserSinhVien" || TypeUser == "UserKhoa")
                {
                    cbbKhoa.Enabled = false;
                }
                if (TypeUser == "UserSinhVien") txtDiem.ReadOnly = true;
                grBTaiKhoan.Enabled = false;
                SinhVien sv = SinhVien_BLL.Instance.ShowSV_BLL(IDSinhVien.Value);
                txtIDSinhVien.Text = sv.IDSinhVien.ToString();
                txtTaiKhoan.Text = sv.TaiKhoan.TenDangNhap;
                txtTenSV.Text = sv.TenSinhVien;
                txtEmail.Text = sv.Email;
                txtQueQuan.Text = sv.QueQuan;
                txtDiaChi.Text = sv.DiaChi;
                txtSDT.Text = sv.SoDienThoai;
                txtDiem.Value = sv.TongDiemHoatDong.Value;
                cbbKhoa.Text = sv.Khoa.TenKhoa;
                if (sv.GioiTinh == true) radioButton_Nam.Checked = true;
                else radioButton_Nu.Checked = true;
                dateTimePicker1.Value = sv.NgaySinh.Value;
                radioButton_Exist.Checked = true;
            }
        }
        public void SetCBB()
        {
            if (cbbKhoa.Items == null)
            {
                cbbKhoa.Items.Clear();
            }
            foreach (Khoa_DTO item in Khoa_BLL.Instance.GetAll_BLL())
            {
                cbbKhoa.Items.Add(item);
            }
        }
        public bool Check()
        {
            if (txtTenSV.Text == "") return false;
            if (txtEmail.Text.Length < 10) return false;
            if (txtEmail.Text.Substring(txtEmail.Text.Length - 10) != "@gmail.com" && txtEmail.Text.Substring(txtEmail.Text.Length - 10) != "@email.com") 
                return false;
            if (txtDiem.Text == "") return false;
            if (txtSDT.Text.Length < 10) return false;
            try
            {
                Convert.ToInt32(txtSDT.Text);
            }
            catch (Exception)
            {
                return false;
            }
            if (txtQueQuan.Text == "") return false;
            if (txtDiaChi.Text == "") return false;
            if (cbbKhoa.SelectedIndex == -1) return false;
            if (dateTimePicker1.Value == DateTime.Today) return false;
            return true;
        }

        public void SetMessageBox(string m)
        {
            MessageBox.Show(m, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public string CreateTK(string id)
        {
            if (radioButton_AutoCreate.Checked == true)
            {
                int count = SinhVien_BLL.Instance.GetListSV_BLL().Count;
                TaiKhoan tk = new TaiKhoan
                {

                    IDTaiKhoan = "SV" + (count + 1).ToString(),
                    IDLoaiTaiKhoan = "SV",
                    TenDangNhap = (102180100 + count + 1).ToString(),
                    MatKhau = ""
                };
                TaiKhoan_BLL.Instance.Add_BLL(tk);
                id = tk.IDTaiKhoan;
                return id;
            }
            if (radioButton_Exist.Checked == true)
            {
                if (txtTaiKhoan.Text == "") return id;
                TaiKhoan tk = TaiKhoan_BLL.Instance.Get_ByUsername_BLL(txtTaiKhoan.Text);
                id = tk.IDTaiKhoan;
                if (tk != null)
                {
                    if (SinhVien_BLL.Instance.FindUsername_BLL(txtTaiKhoan.Text) != null)
                    {
                        SetMessageBox("Tài khoản đã được sử dụng!");
                    }
                    else
                        return id;
                }
                else
                {
                    SetMessageBox("Tài khoản không tồn tại!");
                }
            }
            return id;
        }

        public void CloseForm()
        {
            QLSVForm qLSVForm = (QLSVForm)Application.OpenForms["QLSVForm"];
            D += qLSVForm.ShowSinhVien;
            if (D != null) D();
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                if (IDSinhVien == null)
                {
                    string idtk = "";
                    SinhVien sv = new SinhVien
                    {
                        TenSinhVien = txtTenSV.Text,
                        IDKhoa = Khoa_BLL.Instance.GetIDKhoa_BLL(cbbKhoa.SelectedItem.ToString()),
                        Email = txtEmail.Text,
                        SoDienThoai = txtSDT.Text,
                        QueQuan = txtQueQuan.Text,
                        NgaySinh = dateTimePicker1.Value,
                        DiaChi = txtDiaChi.Text,
                        TongDiemHoatDong = Convert.ToInt32(txtDiem.Value)
                    };
                    if (radioButton_Nam.Checked == true) sv.GioiTinh = true;
                    else sv.GioiTinh = false;
                    if (CreateTK(idtk) == "")
                        SetMessageBox("Thông tin tài khoản không hợp lệ!");
                    else
                    {
                        sv.IDTaiKhoan = CreateTK(idtk);
                        SinhVien_BLL.Instance.AddSV_BLL(sv);
                        MessageBox.Show("Thêm thành công!");
                        CloseForm();
                    }
                }
                else
                {
                    SinhVien sv = new SinhVien
                    {
                        IDSinhVien = Convert.ToInt32(IDSinhVien),
                        TenSinhVien = txtTenSV.Text,
                        IDKhoa = Khoa_BLL.Instance.GetIDKhoa_BLL(cbbKhoa.SelectedItem.ToString()),
                        IDTaiKhoan = TaiKhoan_BLL.Instance.Get_ByUsername_BLL(txtTaiKhoan.Text).IDTaiKhoan.ToString(),
                        Email = txtEmail.Text,
                        SoDienThoai = txtSDT.Text,
                        QueQuan = txtQueQuan.Text,
                        NgaySinh = dateTimePicker1.Value,
                        DiaChi = txtDiaChi.Text,
                        TongDiemHoatDong = Convert.ToInt32(txtDiem.Value)
                    };
                    if (radioButton_Nam.Checked == true) sv.GioiTinh = true;
                    else sv.GioiTinh = false;
                    SinhVien_BLL.Instance.UpdateSV_BLL(sv);
                    MessageBox.Show("Đã lưu thông tin");
                    if (TypeUser == "UserSinhVien")
                    {
                        DashboardForm dashboardForm = (DashboardForm)Application.OpenForms["DashboardForm"];
                        dashboardForm.lbNameUser.Text = sv.TenSinhVien;
                    }
                    else CloseForm();
                }
            }
            else
            {
                MessageBox.Show("Thông tin không hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton_AutoCreate_CheckedChanged(object sender, EventArgs e)
        {
            txtTaiKhoan.ReadOnly = true;
            txtTaiKhoan.Text = "";
        }

        private void radioButton_Exist_CheckedChanged(object sender, EventArgs e)
        {
            txtTaiKhoan.ReadOnly = false;
        }
    }
}
