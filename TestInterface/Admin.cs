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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            //SetView_Khoa();
            SetView_SV();
        }

        private void SetView_Khoa()
        {
            btnDuyetYC.Visible = false;
            btnQLKhoa.Visible = false;
            panelButton.SetRow(btnQLHD, 2);
            panelButton.SetRow(btnQLDiemHD, 3);
            panelButton.SetRow(btnQLTKhoan, 4);
            panelButton.SetRow(btnThongKe, 5);
        }

        private void SetView_SV()
        {
            btnDuyetYC.Visible = false;
            btnQLKhoa.Visible = false;
            btnQLSV.Visible = false;
            btnThongKe.Visible = false;
            panelButton.SetRow(btnQLHD, 1);
            panelButton.SetRow(btnQLTKhoan, 2);
            panelButton.SetRow(btnQLDiemHD, 3);
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

        private void btnDuyetYC_Click(object sender, EventArgs e)
        {
            SelectedButton((Button)sender);
            openForm(new DuyetYeuCau());
        }

        private void btnQLKhoa_Click(object sender, EventArgs e)
        {
            if (childForm != null) childForm.Close();
            SelectedButton((Button)sender);
            openForm(new QLKhoa());
        }

        private void btnQLHD_Click(object sender, EventArgs e)
        {
            //tableLayoutPanel1.GetCellPosition(panelChildForm)
            
            SelectedButton((Button)sender);
            openForm(new QLHD());
        }

        private void btnQLDiemHD_Click(object sender, EventArgs e)
        {
            SelectedButton((Button)sender);
            openForm(new QLDiem());
        }

        private void btnQLTKhoan_Click(object sender, EventArgs e)
        {
            SelectedButton((Button)sender);
            openForm(new QLTK());
        }

        private void btnQLSV_Click(object sender, EventArgs e)
        {
            if (childForm != null) childForm.Close();

            SelectedButton((Button)sender);
            openForm(new QLSV());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            int wid = Screen.PrimaryScreen.Bounds.Width * 80 / 100;
            int hei = Screen.PrimaryScreen.Bounds.Height * 80 / 100;

            this.Width = wid;
            this.Height = hei;
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(74, 74, 74));
            if (e.Column == 0 && e.Row == 0)
                e.Graphics.FillRectangle(solidBrush, e.CellBounds);
            if (e.Column == 0 && e.Row == 2)
                e.Graphics.FillRectangle(solidBrush, e.CellBounds);
            if (e.Column == 1 && e.Row == 1)
                e.Graphics.FillRectangle(solidBrush, e.CellBounds);
        }
    }
}
