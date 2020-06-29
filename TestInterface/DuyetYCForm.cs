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
    public partial class DuyetYCForm : Form
    {
        public delegate void MyDel(Form form);
        private MyDel _D;

        public MyDel D { get => _D; set => _D = value; }
        public DuyetYCForm()
        {
            InitializeComponent();
        }
        private void SetPicture()
        {   
            if (this.Width > (Screen.PrimaryScreen.Bounds.Width * 70 / 100))
                btnXem.Image = new Bitmap("Resource\\Read64.png");
            else
                btnXem.Image = new Bitmap("Resource\\Read32.png");
        }

        private void btnXem_SizeChanged(object sender, EventArgs e)
        {
            SetPicture();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DashboardForm df = (DashboardForm)Application.OpenForms["DashboardForm"];
            this.D = new MyDel(df.openForm);
            this.D(new HoatDongForm());
        }
    }
}
