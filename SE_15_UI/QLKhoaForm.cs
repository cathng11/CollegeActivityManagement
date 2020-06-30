using SE_15_BLL;
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
    public partial class QLKhoaForm : Form
    {
        public delegate void MyDel(Form form);
        private MyDel _D;

        public MyDel D { get => _D; set => _D = value; }

        public QLKhoaForm()
        {
            InitializeComponent();
            ShowKhoa();
            radioBtnNo.Checked = true;
        }

        private void QLKhoa1_SizeChanged(object sender, EventArgs e)
        {
            SetPicture();
        }

        private void SetPicture()
        {
            if (this.Width > (Screen.PrimaryScreen.Bounds.Width * 70 / 100))
            {
                btnXem.Image = SE_15_UI.Properties.Resources.Read64;
                btnThem.Image = SE_15_UI.Properties.Resources.Create64;
                btnSua.Image = SE_15_UI.Properties.Resources.Edit64;
            }
            else
            {
                btnXem.Image = SE_15_UI.Properties.Resources.Read32;
                btnThem.Image = SE_15_UI.Properties.Resources.Create32;
                btnSua.Image = SE_15_UI.Properties.Resources.Edit32;
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dtgvKhoa.SelectedRows;
            KhoaForm khoa = new KhoaForm(Convert.ToInt32(r[0].Cells["Column1"].Value.ToString()));
            khoa.VisibleButtonSave();
            DashboardForm df = (DashboardForm)Application.OpenForms["DashboardForm"];
            this.D = new MyDel(df.openForm);
            this.D(khoa);
        }

        public void ShowKhoa()
        {
            dtgvKhoa.DataSource = Khoa_BLL.Instance.GetAll_BLL().ToList();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DashboardForm df = (DashboardForm)Application.OpenForms["DashboardForm"];
            this.D = new MyDel(df.openForm);
            this.D(new KhoaForm(null));
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = dtgvKhoa.SelectedRows;
            DashboardForm df = (DashboardForm)Application.OpenForms["DashboardForm"];
            this.D = new MyDel(df.openForm);
            this.D(new KhoaForm(Convert.ToInt32(r[0].Cells["Column1"].Value.ToString())));
        }


        private void btnSapXep_Click_1(object sender, EventArgs e)
        {
            if (radioBtnAlpha.Checked == true)
            {
                dtgvKhoa.DataSource = Khoa_BLL.Instance.Sort_BLL("alpha");
            }
            if (radioBtnID.Checked == true)
            {
                dtgvKhoa.DataSource = Khoa_BLL.Instance.Sort_BLL("id");
            }
            if (radioBtnNo.Checked == true)
                dtgvKhoa.DataSource = Khoa_BLL.Instance.GetAll_BLL();
        }
    }
}
