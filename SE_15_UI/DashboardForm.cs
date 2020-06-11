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
    public partial class DashboardForm : Form
    {
        private string typeUser;
        public string TypeUser { get => typeUser; set => typeUser = value; }

        private string _ID_TK;
        public string ID_TK { get => _ID_TK; set => _ID_TK = value; }

        public DashboardForm(string typeUser, string id_TK)
        {
            TypeUser = typeUser;
            ID_TK = id_TK;
            InitializeComponent();
            if (typeUser == "UserAdmin")
                SetView_Admin();
            if (typeUser == "UserKhoa")
                SetView_Khoa();
            if (typeUser == "UserSinhVien")
                SetView_SV();
        }
        
        private void SetView_Admin()
        {
            lbUser.Text = "(Admin)";
            Admin ad = Admin_BLL.Instance.Get_ByTaiKhoan_BLL(ID_TK);
            lbNameUser.Text = ad.TenAdmin;
        }

        private void SetView_Khoa()
        {
            btnDuyetYC.Visible = false;
            btnQLKhoa.Visible = false;
            lbUser.Text = "(Khoa)";
            Khoa khoa = Khoa_BLL.Instance.Get_ByTaiKhoan_BLL(ID_TK);
            lbNameUser.Text = khoa.TenKhoa;
        }

        private void SetView_SV()
        {
            btnDuyetYC.Visible = false;
            btnQLKhoa.Visible = false;
            btnThongKe.Visible = false;
            lbUser.Text = "(Sinh viên)";
            SinhVien sv = SinhVien_BLL.Instance.Get_ByTaiKhoan_BLL(ID_TK);
            lbNameUser.Text = sv.TenSinhVien;
        }

        public Form childForm = null;
        private Form thaotacForm = null;

        public void openForm(Form child)
        {
            if (childForm == null)
            {
                childForm = child;
                child.TopLevel = false;
                child.FormBorderStyle = FormBorderStyle.None;
                panelChildForm.Controls.Add(child);
                child.Dock = DockStyle.Fill;
                panelChildForm.Tag = child;
                child.BringToFront();
                child.Show();
            }
            else
            {
                thaotacForm = child;
                child.TopLevel = false;
                child.FormBorderStyle = FormBorderStyle.None;
                panelChildForm.Controls.Add(child);
                child.Dock = DockStyle.Fill;
                panelChildForm.Tag = child;
                child.BringToFront();
                child.Show();
            }
        }

        private void CloseAllForms()
        {
            if (childForm != null)
            {
                childForm.Close();
                childForm = null;
            }
            if (thaotacForm != null)
            {
                thaotacForm.Close();
                thaotacForm = null;
            }
        }

        private void SelectedButton(Button b)
        {
            foreach (Button btn in this.panelButton.Controls.OfType<Button>())
            {
                if (btn.BackColor == Color.FromArgb(151, 130, 171))
                    btn.BackColor = Color.FromArgb(79, 58, 101);
            }
            b.BackColor = Color.FromArgb(151, 130, 171);
        }

        private void btnDuyetYC_Click(object sender, EventArgs e)
        {
            lbButton.Text = "Duyệt yêu cầu phê duyệt hoạt động";
            CloseAllForms();
            SelectedButton((Button)sender);
            openForm(new DuyetYCForm());
        }

        private void btnQLKhoa_Click(object sender, EventArgs e)
        {
            lbButton.Text = "Quản lý khoa";
            CloseAllForms();
            SelectedButton((Button)sender);
            openForm(new QLKhoaForm());
        }

        private void btnQLHD_Click(object sender, EventArgs e)
        {
            lbButton.Text = "Quản lý hoạt động";
            CloseAllForms(); 
            SelectedButton((Button)sender);
            if (TypeUser == "UserSinhVien")
            {
                int idsv = SinhVien_BLL.Instance.Get_ByTaiKhoan_BLL(ID_TK).IDSinhVien;
                openForm(new QLHDForm(TypeUser, idsv));
            } 
            else openForm(new QLHDForm(TypeUser, null));
        }

        private void btnQLTKhoan_Click(object sender, EventArgs e)
        {
            lbButton.Text = "Quản lý tài khoản";
            CloseAllForms();
            SelectedButton((Button)sender);
            openForm(new QLTKForm(TypeUser));
        }

        private void btnQLSV_Click(object sender, EventArgs e)
        {
            lbButton.Text = "Quản lý sinh viên";
            CloseAllForms();
            SelectedButton((Button)sender);
            if (TypeUser == "UserSinhVien")
            {
                SinhVienForm sv = new SinhVienForm(SinhVien_BLL.Instance.Get_ByTaiKhoan_BLL(ID_TK).IDSinhVien, TypeUser);               
                openForm(sv);
            }
                
            else if(TypeUser == "UserKhoa") openForm(new QLSVForm("UserKhoa",ID_TK));
            else openForm(new QLSVForm("",ID_TK));
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            lbButton.Text = "Báo cáo thống kê";
            CloseAllForms();

            SelectedButton((Button)sender);
            openForm(new ThongKeForm(TypeUser));
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            LogoutForm logout = new LogoutForm();
            Form activeform = null;
            if (activeform != null) activeform.Close();
            activeform = logout;
            logout.ShowDialog();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            int wid = Screen.PrimaryScreen.Bounds.Width * 80 / 100;
            int hei = Screen.PrimaryScreen.Bounds.Height * 80 / 100;

            this.Width = wid;
            this.Height = hei;

            timer1.Start();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            CloseAllForms();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void DashboardForm_Shown(object sender, EventArgs e)
        {
            if (typeUser == "UserAdmin")
            {
                int count = DuyetYC_BLL.Instance.GetListYC_BLL().Count;
                MessageBox.Show("Có " + count + " yêu cầu cần phê duyệt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
