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
    public partial class TaiKhoanForm : Form
    {
        public delegate void MyDel();
        private MyDel _D;
        public MyDel D { get => _D; set => _D = value; }

        private string _ID_TK;
        public string ID_TK { get => _ID_TK; set => _ID_TK = value; }

        public TaiKhoanForm(string id_TK)
        {
            ID_TK = id_TK;
            InitializeComponent();
            LoadCBB();
            ShowData_TK();
        }

        public void VisibleButtonSave()
        {
            btnSave.Visible = false;
            foreach (Control i in this.tableLayoutPanel1.Controls)
            {
                i.Enabled = true;
            }
            dtgvLichSuDN.Enabled = true;
        }

        private void ShowData_TK()
        {
            if (ID_TK != "")
            {
                TaiKhoan tk = TaiKhoan_BLL.Instance.Get_ByIDTaiKhoan_BLL(ID_TK);
                txtIDTaiKhoan.Text = tk.IDTaiKhoan;
                txtTenDangNhap.Text = tk.TenDangNhap;
                dtgvLichSuDN.DataSource = LichSuDangNhap_BLL.Instance.Get_ByIDTaiKhoan_BLL(tk.IDTaiKhoan);
                
                
                //txtIDTaiKhoan.ReadOnly = true;
            }
            else
            {
                
            }
        }

        private void LoadCBB()
        {
            foreach (LoaiTaiKhoan_DTO item in LoaiTaiKhoan_BLL.Instance.GetAll_BLL())
            {
                cbbLoaiTK.Items.Add(item);
            }
            //cbbLoaiTK.DisplayMember = "TenLoai";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckInfo()
        {
            if (txtIDTaiKhoan.Text == "") return false;
            if (txtTenDangNhap.Text == "") return false;
            if (cbbLoaiTK.SelectedIndex < 0) return false;
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Thêm
            TaiKhoan tk = TaiKhoan_BLL.Instance.Get_ByIDTaiKhoan_BLL(txtIDTaiKhoan.Text);
            if (tk == null)
            {

                if (CheckInfo())
                {
                    TaiKhoan newTK = new TaiKhoan
                    {
                        IDTaiKhoan = txtIDTaiKhoan.Text,
                        TenDangNhap = txtTenDangNhap.Text,
                        IDLoaiTaiKhoan = ((LoaiTaiKhoan_DTO)cbbLoaiTK.SelectedItem).IDLoaiTaiKhoan,
                        MatKhau = ""
                    };
                    TaiKhoan_BLL.Instance.Add_BLL(newTK);

                    QLTKForm qLTKForm = (QLTKForm)Application.OpenForms["QLTKForm"];
                    D += qLTKForm.ShowTaiKhoan;
                    if (D != null) D();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thông tin không hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //Edit
            else
            {
                if (CheckInfo())
                {
                    TaiKhoan newTK = new TaiKhoan
                    {
                        IDTaiKhoan = tk.IDTaiKhoan,
                        TenDangNhap = txtTenDangNhap.Text,
                        IDLoaiTaiKhoan = ((LoaiTaiKhoan_DTO)cbbLoaiTK.SelectedItem).IDLoaiTaiKhoan,
                        MatKhau = tk.MatKhau
                    };
                    TaiKhoan_BLL.Instance.Edit_BLL(tk.IDTaiKhoan, newTK);

                    QLTKForm qLTKForm = (QLTKForm)Application.OpenForms["QLTKForm"];
                    D += qLTKForm.ShowTaiKhoan;
                    if (D != null) D();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thông tin không hợp lệ!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbbLoaiTK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ID_TK == "")
            {
                string ID_loaiTK = ((LoaiTaiKhoan_DTO)cbbLoaiTK.SelectedItem).IDLoaiTaiKhoan;
                string name = ((LoaiTaiKhoan_DTO)cbbLoaiTK.SelectedItem).TenLoai;
                int count = TaiKhoan_BLL.Instance.Get_ByLoaiTaiKhoan_DAL(ID_loaiTK).Count;
                txtIDTaiKhoan.Text = ID_loaiTK + (count + 1).ToString();
                txtTenDangNhap.Text = name;
            }
        }
    }
}
