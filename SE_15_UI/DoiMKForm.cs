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
    public partial class DoiMKForm : Form
    {
        public delegate void MyDel(Form form);
        private MyDel _D;
        public MyDel D { get => _D; set => _D = value; }

        private string _IDTaiKhoan;
        public string IDTaiKhoan { get => _IDTaiKhoan; set => _IDTaiKhoan = value; }

        public DoiMKForm(string id)
        {
            IDTaiKhoan = id;
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckNewPass()
        {
            if (txtMKMoi.Text.Length < 8) return false;
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = TaiKhoan_BLL.Instance.Get_ByIDTaiKhoan_BLL(IDTaiKhoan);
            if (txtMKCu.Text != DecodeFrom64(tk.MatKhau))
            {
                lblOld.Visible = true;
            }
            else if(txtMKMoi2.Text != txtMKMoi.Text)
            {
                lblNew.Visible = true;
            }
            else
            {
                if (CheckNewPass())
                {
                    TaiKhoan_BLL.Instance.ChangPass_BLL(tk, txtMKMoi2.Text);
                    this.Close();
                }
                else
                    MessageBox.Show("Mật khẩu phải tối thiểu 8 ký tự!", "Mật khẩu mới không hợp lệ!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
