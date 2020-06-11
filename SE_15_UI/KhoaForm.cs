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
    public partial class KhoaForm : Form
    {
        public delegate void MyDel();
        private MyDel _D;
        public MyDel D { get => _D; set => _D = value; }

        private Nullable<int> _IDKhoa;
        public Nullable<int> IDKhoa { get => _IDKhoa; set => _IDKhoa = value; }

        public KhoaForm(Nullable<int> id)
        {
            IDKhoa = id;
            InitializeComponent();
            SetView();
        }

        public void VisibleButtonSave()
        {
            btnSave.Visible = false;
            foreach (Control i in this.table1.Controls.OfType<TextBox>())
            {
                i.Enabled = false;
            }
        }

        public void SetView()
        {
            txtIDKhoa.ReadOnly = true;
            txtSoLuongSV.ReadOnly = true;
            if (IDKhoa == null)
            {
                foreach (Control i in this.Controls.OfType<TextBox>())
                {
                    i.Text = "";
                }
                txtSoLuongSV.Value = 0;
            }
            else
            {
                grBoxTK.Enabled = false;
                Khoa khoa = Khoa_BLL.Instance.ShowKhoa_BLL(IDKhoa);
                txtIDKhoa.Text = IDKhoa.ToString();
                txtTenKhoa.Text = khoa.TenKhoa;
                txtSoLuongSV.Value = khoa.SoLuongSV.Value;
                txtTenTK.Text = khoa.TaiKhoan.TenDangNhap;
                rdBtnAvailable.Checked = true;
            }
        }
        public bool Check()
        {
            if (txtTenKhoa.Text == "") return false;
            if (txtSoLuongSV.Text == "") return false;
            return true;
        }
        public void SetMessageBox(string m)
        {
            MessageBox.Show(m, "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public string CreateTK(string id)
        {
            if (rdBtnAuto.Checked == true)
            {
                int count = Khoa_BLL.Instance.GetAll_BLL().Count;
                TaiKhoan tk = new TaiKhoan
                {

                    IDTaiKhoan = "K" + (count + 1).ToString(),
                    IDLoaiTaiKhoan = "K",
                    TenDangNhap = stripunicode(txtTenKhoa.Text),
                    MatKhau = ""
                };
                TaiKhoan_BLL.Instance.Add_BLL(tk);
                id = tk.IDTaiKhoan;
                return id;
            }
            if (rdBtnAvailable.Checked == true)
            {
                if (txtTenTK.Text == "") return id;
                TaiKhoan tk = TaiKhoan_BLL.Instance.Get_ByUsername_BLL(txtTenTK.Text);
                id = tk.IDTaiKhoan;
                if (tk != null)
                {
                    if (Khoa_BLL.Instance.FindUsername_BLL(txtTenTK.Text) != null)
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

        //StringBuilder: cho phép mở rộng số lượng kí tự của một chuỗi, mở rộng bộ nhớ dể lưu
        //trữ giá trị chuỗi thay thế mới
        //Append: Nối các giá trị được truyền vào cuối của đối tượng StringBuilder hiện tại
        //Replace: Thay thế các ký tự cũ bằng các ký tự mới
        //Normalize: bình thường hóa chuỗi, loại bỏ dấu của chuỗi unicode 
        //ToLower Trả về chuỗi chữ thường
        public string stripunicode(string inputtext)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(inputtext.Normalize(NormalizationForm.FormKD).Where(x => x < 128).ToArray());
            string newstring = stringBuilder.ToString();
            return (newstring.Replace(" ", string.Empty)).ToLower();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                if (IDKhoa == null)
                {
                    string idtk = "";
                    Khoa khoa = new Khoa()
                    {
                        TenKhoa = txtTenKhoa.Text,
                        SoLuongSV = Convert.ToInt32(txtSoLuongSV.Text),
                    };
                    if (CreateTK(idtk) == "")
                        SetMessageBox("Thông tin tài khoản không hợp lệ!");
                    else
                    {
                        khoa.IDTaiKhoan = CreateTK(idtk);
                        Khoa_BLL.Instance.AddKhoa_BLL(khoa);

                        QLKhoaForm qLKhoaForm = (QLKhoaForm)Application.OpenForms["QLKhoaForm"];
                        D += qLKhoaForm.ShowKhoa;
                        if (D != null) D();
                        this.Close();
                    }
                }
                else
                {
                    Khoa khoa = new Khoa()
                    {
                        IDKhoa = IDKhoa.Value,
                        TenKhoa = txtTenKhoa.Text,
                        SoLuongSV = Convert.ToInt32(txtSoLuongSV.Text),
                        IDTaiKhoan = TaiKhoan_BLL.Instance.Get_ByUsername_BLL(txtTenTK.Text).IDTaiKhoan.ToString()
                    };
                    Khoa_BLL.Instance.UpdateKhoa_BLL(khoa);

                    QLKhoaForm qLKhoaForm = (QLKhoaForm)Application.OpenForms["QLKhoaForm"];
                    D += qLKhoaForm.ShowKhoa;
                    if (D != null) D();
                    this.Close();
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

        private void rdBtnAvailable_CheckedChanged(object sender, EventArgs e)
        {
            txtTenTK.ReadOnly = false;
        }

        private void rdBtnAuto_CheckedChanged(object sender, EventArgs e)
        {
            txtTenTK.ReadOnly = true;
            txtTenTK.Text = "";
        }
    }
}
