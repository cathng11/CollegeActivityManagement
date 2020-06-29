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
    public partial class LoginForm : Form
    {
        private bool _SuccessLogin;
        public bool SuccessLogin { get => _SuccessLogin; private set => _SuccessLogin = value; }

        private string _TypeUser;
        public string TypeUser { get => _TypeUser; set => _TypeUser = value; }

        private string _ID_TK;
        public string ID_TK { get => _ID_TK; set => _ID_TK = value; }

        public LoginForm()
        {
            InitializeComponent();
            lblErrorUsername.Visible = false;
            lblErrorPassword.Visible = false;

        }
        private void btn_X_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                lblErrorUsername.Visible = true;
            }
            else
            {
                TaiKhoan tk = TaiKhoan_BLL.Instance.Get_ByUsername_BLL(txtUsername.Text);
                try
                {
                    switch (tk.LoaiTaiKhoan.TenLoai)
                    {
                        case "Admin":
                            {
                                TypeUser = "UserAdmin";
                                break;
                            }
                        case "Khoa":
                            {
                                TypeUser = "UserKhoa";
                                break;
                            }
                        case "Sinh viên":
                            {
                                TypeUser = "UserSinhVien";
                                break;
                            }
                    }

                    if (txtPassword.Text == DecodeFrom64(tk.MatKhau))
                    {
                        LichSuDangNhap lichSu = new LichSuDangNhap
                        {
                            IDLichSu = 0,
                            IDTaiKhoan = tk.IDTaiKhoan,
                            ThoiGianDangNhap = DateTime.Now
                        };
                        LichSuDangNhap_BLL.Instance.Add_BLL(lichSu);
                        ID_TK = tk.IDTaiKhoan;
                        SuccessLogin = true;
                        this.Close();
                    }
                    else
                    {
                        lblErrorPassword.Visible = true;
                    }
                }
                catch (Exception)
                {
                    lblErrorPassword.Visible = true;
                }
            }
        }

        public string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            lblErrorUsername.Visible = false;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            lblErrorPassword.Visible = false;
        }
    }
}
