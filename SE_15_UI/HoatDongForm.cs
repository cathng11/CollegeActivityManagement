using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SE_15_BLL;
using SE_15_DTO;

namespace SE_15_UI
{
    public partial class HoatDongForm : Form
    {
        public delegate void MyDel();
        private MyDel _D;

        public MyDel D { get => _D; set => _D = value; }

        private string _ID_HD;
        public string ID_HD { get => _ID_HD; set => _ID_HD = value; }

        private string _TypeUser;
        public string TypeUser { get => _TypeUser; set => _TypeUser = value; }

        public HoatDongForm(string id_HD, string typeUser)
        {
            ID_HD = id_HD;
            TypeUser = typeUser;
            InitializeComponent();
            LoadCBB();
            ShowData_HD();

            if(TypeUser=="UserKhoa")
            {
                cbbPheDuyet.Enabled = false;
                cbbDangKy.Enabled = false;
                DashboardForm dashboardForm = (DashboardForm)Application.OpenForms["DashboardForm"];
                Khoa khoa = Khoa_BLL.Instance.Get_ByTaiKhoan_BLL(dashboardForm.ID_TK);
                cbbTenKhoa.Text = khoa.TenKhoa;
                cbbTenKhoa.Enabled = false;

                if (ID_HD != "")
                {
                    if (HoatDong_BLL.Instance.Get_ByID_BLL(ID_HD).TrangThaiPheDuyet == "Đã duyệt")
                        cbbDangKy.Enabled = true;
                }
            }
            else
            {
                cbbPheDuyet.SelectedIndex = 0;
                cbbDangKy.SelectedIndex = 0;
            }
        }

        public void VisibleButtonSave()
        {
            btnSave.Visible = false;
            tableLayoutPanel3.Enabled = false;
            tableLayoutPanel4.Enabled = false;
            tableLayoutPanel5.Enabled = false;
        }

        private void LoadCBB()
        {
            cbbPheDuyet.Items.Add("Đã duyệt");
            cbbPheDuyet.Items.Add("Không duyệt");
            cbbDangKy.Items.Add("Mở đăng ký");
            cbbDangKy.Items.Add("Đóng đăng ký");

            HoatDong hd = HoatDong_BLL.Instance.Get_ByID_BLL(ID_HD);
            if (hd != null)
            {
                foreach (LoaiHoatDong_DTO item in LoaiHoatDong_BLL.Instance.GetAll_DAL())
                {
                    cbbLoaiHD.Items.Add(item);
                    if (hd.IDLoaiHoatDong == item.IDLoaiHoatDong)
                        cbbLoaiHD.Text = item.LoaiHoatDong;
                }

                Khoa k = Khoa_BLL.Instance.Get_ByID_BLL(hd.IDKhoa.Value);
                foreach (Khoa_DTO item in Khoa_BLL.Instance.GetAll_BLL())
                {
                    cbbTenKhoa.Items.Add(item);
                    if (k != null && k.IDKhoa == item.IDKhoa)
                        cbbTenKhoa.Text = item.TenKhoa;
                }

                cbbLoaiHD.Text = hd.LoaiHoatDong.LoaiHoatDong1;
                cbbTenKhoa.Text = hd.Khoa.TenKhoa;
                cbbPheDuyet.SelectedItem = hd.TrangThaiPheDuyet;
                cbbDangKy.SelectedItem = hd.TrangThaiDangKy;
                txtIDHoatDong.ReadOnly = true;
            }
            else
            {
                foreach (LoaiHoatDong_DTO item in LoaiHoatDong_BLL.Instance.GetAll_DAL())
                {
                    cbbLoaiHD.Items.Add(item);
                }
                foreach (Khoa_DTO item in Khoa_BLL.Instance.GetAll_BLL())
                {
                    cbbTenKhoa.Items.Add(item);
                }
            }
        }

        private void ShowData_HD()
        {
            if (ID_HD != "")
            {
                HoatDong hd = HoatDong_BLL.Instance.Get_ByID_BLL(ID_HD);
                txtIDHoatDong.Text = hd.IDHoatDong.Trim();
                txtTenHD.Text = hd.TenHoatDong;
                txtSoLuongSV.Value = hd.SoLuongThamGia.Value;
                txtChiPhi.Value = hd.ChiPhi.Value;
                txtMoTa.Text = hd.MoTa;
                txtDiaDiem.Text = hd.DiaDiem;
                txtYeuCauSV.Text = hd.YeuCau;
                txtDiemHD.Value = hd.DiemHD.Value;
                dtpThoiGian.Value = Convert.ToDateTime(hd.ThoiGian.ToString());
            }
            else
            {
                cbbPheDuyet.Text = "";
                cbbDangKy.Text = "";
                int count = HoatDong_BLL.Instance.GetALL_BLL().Count;
                txtIDHoatDong.Text = "HD" + (count + 1).ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckInfo()
        {
            if (txtIDHoatDong.Text == "") return false;
            if (txtTenHD.Text == "") return false;
            if (txtChiPhi.Text == "") return false;
            if (txtDiaDiem.Text == "") return false;
            if (cbbLoaiHD.SelectedIndex < 0) return false;
            if (cbbTenKhoa.SelectedIndex < 0) return false;
            return true;
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            HoatDong hd = HoatDong_BLL.Instance.Get_ByID_BLL(txtIDHoatDong.Text);
            if (hd == null)
            {
                //Add
                if (CheckInfo())
                {
                    HoatDong hoatDong = new HoatDong
                    {
                        IDHoatDong = txtIDHoatDong.Text,
                        IDLoaiHoatDong = ((LoaiHoatDong_DTO)cbbLoaiHD.SelectedItem).IDLoaiHoatDong,
                        IDKhoa = ((Khoa_DTO)cbbTenKhoa.SelectedItem).IDKhoa,
                        TenHoatDong = txtTenHD.Text,
                        SoLuongThamGia = Convert.ToInt32(txtSoLuongSV.Value),
                        ThoiGian = Convert.ToDateTime(dtpThoiGian.Value.ToString()),
                        DiaDiem = txtDiaDiem.Text,
                        ChiPhi = Convert.ToInt32(txtChiPhi.Value),
                        MoTa = txtMoTa.Text,
                        YeuCau = txtYeuCauSV.Text,
                        DiemHD = Convert.ToInt32(txtDiemHD.Value)
                    };

                    if(cbbDangKy.Text != "" && cbbPheDuyet.Text != "")
                    {
                        hoatDong.TrangThaiPheDuyet = cbbPheDuyet.SelectedItem.ToString();
                        hoatDong.TrangThaiDangKy = cbbDangKy.SelectedItem.ToString();
                    }
                    else
                    {
                        hoatDong.TrangThaiPheDuyet = null;
                        hoatDong.TrangThaiDangKy = null;
                    }
                    HoatDong_BLL.Instance.Add_BLL(hoatDong);

                    QLHDForm qLHDForm = (QLHDForm)Application.OpenForms["QLHDForm"];
                    D += qLHDForm.ShowHoatDongs;
                    if (D != null) D();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thông tin không hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                //Edit
                if (CheckInfo())
                {
                    HoatDong newHD = new HoatDong
                    {
                        IDHoatDong = hd.IDHoatDong,
                        IDLoaiHoatDong = ((LoaiHoatDong_DTO)cbbLoaiHD.SelectedItem).IDLoaiHoatDong,
                        IDKhoa = ((Khoa_DTO)cbbTenKhoa.SelectedItem).IDKhoa,
                        TenHoatDong = txtTenHD.Text,
                        SoLuongThamGia = Convert.ToInt32(txtSoLuongSV.Value),
                        ThoiGian = Convert.ToDateTime(dtpThoiGian.Value.ToString()),
                        DiaDiem = txtDiaDiem.Text,
                        ChiPhi = Convert.ToInt32(txtChiPhi.Value),
                        MoTa = txtMoTa.Text,
                        YeuCau = txtYeuCauSV.Text,
                        DiemHD = Convert.ToInt32(txtDiemHD.Value),
                        TrangThaiPheDuyet = cbbPheDuyet.SelectedItem.ToString(),
                        TrangThaiDangKy = cbbDangKy.SelectedItem.ToString()
                    };
                    HoatDong_BLL.Instance.Edit_BLL(newHD);

                    try
                    {
                        DuyetYCForm duyet = (DuyetYCForm)Application.OpenForms["DuyetYCForm"];
                        D += duyet.ShowYeuCau;
                    }
                    catch (Exception)
                    {
                        QLHDForm qLHDForm = (QLHDForm)Application.OpenForms["QLHDForm"];
                        D += qLHDForm.ShowHoatDongs;
                    }

                    if (D != null) D();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Thông tin không hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
