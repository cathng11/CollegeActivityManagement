using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE_15_UI
{
    public partial class DashboardForm : Form
    {
        public DashboardForm(string typeUser)
        {
            InitializeComponent();
            //SetView_Khoa();
            //SetView_SV();
            if (typeUser == "UserKhoa")
                SetView_Khoa();
            if (typeUser == "UserSinhVien")
                SetView_SV();
        }

        private void SetView_Khoa()
        {
            btnDuyetYC.Visible = false;
            btnQLKhoa.Visible = false;
            lbUser.Text = "(Khoa)";

            //panelButton.SetRow(btnQLHD, 2);
            //panelButton.SetRow(btnQLDiemHD, 3);
            //panelButton.SetRow(btnQLTKhoan, 4);
            //panelButton.SetRow(btnThongKe, 5);
        }

        private void SetView_SV()
        {
            btnDuyetYC.Visible = false;
            btnQLKhoa.Visible = false;
            btnQLSV.Visible = false;
            btnThongKe.Visible = false;
            lbUser.Text = "(Sinh viên)";

            //panelButton.SetRow(btnQLHD, 1);
            //panelButton.SetRow(btnQLTKhoan, 2);
            //panelButton.SetRow(btnQLDiemHD, 3);
        }

        private Form childForm = null;
        public void openForm(Form child)
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
            SelectedButton((Button)sender);
            openForm(new DuyetYCForm());
        }

        private void btnQLKhoa_Click(object sender, EventArgs e)
        {
            lbButton.Text = "Quản lý khoa";
            if (childForm != null) childForm.Close();
            SelectedButton((Button)sender);
            openForm(new QLKhoaForm());
        }

        private void btnQLHD_Click(object sender, EventArgs e)
        {
            //tableLayoutPanel1.GetCellPosition(panelChildForm)
            lbButton.Text = "Quản lý hoạt động";
            SelectedButton((Button)sender);
            openForm(new QLHDForm());
        }


        private void btnQLTKhoan_Click(object sender, EventArgs e)
        {
            lbButton.Text = "Quản lý tài khoản";
            SelectedButton((Button)sender);
            openForm(new QLTKForm());
        }

        private void btnQLSV_Click(object sender, EventArgs e)
        {
            lbButton.Text = "Quản lý sinh viên";
            if (childForm != null) childForm.Close();

            SelectedButton((Button)sender);
            openForm(new QLSVForm());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            lbButton.Text = "Báo cáo thống kê";
            SelectedButton((Button)sender);
            openForm(new ThongKeForm());
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
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }




        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToString("hh:mm:ss");

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
        }


    }
}
