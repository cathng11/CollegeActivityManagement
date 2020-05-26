using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
namespace TestInterface
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            SetView();
            panelSelect.Visible = false;
        }

        public void SetView()
        {
            int wid = Screen.PrimaryScreen.Bounds.Width * 70 / 100;
            int hei = Screen.PrimaryScreen.Bounds.Height * 70 / 100;

            this.Width = wid;
            this.Height = hei;

            panelLeft.Width = wid * 25 / 100;
            panelButton.Width = panelLeft.Width;

            foreach (Button b in this.panelButton.Controls.OfType<Button>())
                b.Padding = new Padding(panelButton.Width * 10 / 100, 0, 0, 0);

            btnDangXuat.Padding = new Padding(panelButton.Width * 10 / 100, 0, 0, 0);

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
                if (btn.BackColor == Color.FromArgb(203, 188, 6)) btn.BackColor = Color.FromArgb(222, 239, 90);
            }
            b.BackColor = Color.FromArgb(203, 188, 6);
        }

        private void btnQLSV_Click(object sender, EventArgs e)
        {
            if (childForm != null) childForm.Close();

            SelectedButton((Button)sender);
            openForm(new QLSV());
        }

        private void btnQLKhoa_Click(object sender, EventArgs e)
        {
            if (childForm != null) childForm.Close();
            SelectedButton((Button)sender);
            openForm(new QLKhoa());
        }

        private void btnQLHD_Click(object sender, EventArgs e)
        {
            if (childForm != null) childForm.Close();
            SelectedButton((Button)sender);
            openForm(new QLHD());
        }

        private void btnQLDiemHD_Click(object sender, EventArgs e)
        {
            if (childForm != null) childForm.Close();
            SelectedButton((Button)sender);
            openForm(new QLDiem());
        }
        private void btnQLTKhoan_Click(object sender, EventArgs e)
        {
            if (childForm != null) childForm.Close();
            SelectedButton((Button)sender);
            openForm(new QLTK());

        }
        private void btnDuyetYC_Click_1(object sender, EventArgs e)
        {
            if (childForm != null) childForm.Close();
            SelectedButton((Button)sender);
            openForm(new DuyetYeuCau());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (childForm != null) childForm.Close();
            SelectedButton((Button)sender);
            openForm(new ThongKe());
        }


        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            LogoutForm logout = new LogoutForm();
            Form activeform = null;
            if (activeform != null) activeform.Close();
            activeform = logout;
            logout.ShowDialog();

        }

        int mov;
        int movX; int movY;
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
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
                SetView();
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;

                int wid = this.Width;
                int hei = this.Height;
                panelLeft.Width = wid * 20 / 100;
                panelChildForm.Size = new Size(wid * 75 / 10, hei * 75 / 100);
                panelButton.Width = wid * 20 / 100;
                foreach (Button b in this.panelButton.Controls.OfType<Button>())
                    b.Padding = new Padding(panelButton.Width * 10 / 100, 0, 0, 0);
                btnDangXuat.Padding = new Padding(panelButton.Width * 15 / 100, 0, 0, 0);

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
