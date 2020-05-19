using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestInterface
{
    public partial class DuyetYC : Form
    {
        public DuyetYC()
        {
            InitializeComponent();
            SetView();
        }
        private void openChildForm(Form form)
        {
            form.TopLevel = false;
            AdminForm admin = (AdminForm)Application.OpenForms["AdminForm"];
            Panel panel = (Panel)admin.Controls["panelChildForm"];
            form.Parent = admin;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panel.Tag = form;
            form.BringToFront();
            panel.Controls.Add(form);
            Close();
            form.Width = this.Width;
            form.Height = this.Height;
            form.Show();
        }
        private void SetView()
        {
            this.Height = panelChildForm.Height;
            this.Width = panelChildForm.Width;
            panel1.Height = this.Height * 15 / 100;
            panelButton.Height = this.Height * 85 / 100;
            panelButton.Width = this.Width * 20 / 100;
            btnXem.Height = panelButton.Height;
            btnXem.ImageAlign = ContentAlignment.MiddleCenter;
            btnXem.TextAlign = ContentAlignment.BottomCenter;
            btnXem.TextImageRelation = TextImageRelation.ImageAboveText;

        }

        private void SetPicture()
        {
            if (this.Width > (Screen.PrimaryScreen.Bounds.Width * 70 / 100))
                btnXem.Image = new Bitmap("Resource\\Read64.png");
            else
                btnXem.Image = new Bitmap("Resource\\Read32.png");
        }

        private void dataGridView1_SizeChanged(object sender, EventArgs e)
        {
            SetView();
            SetPicture();
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            openChildForm(new HoatDong());
        }
    }
}
