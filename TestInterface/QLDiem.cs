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
    public partial class QLDiem : Form
    {
        public QLDiem()
        {
            InitializeComponent();
            SetView();
        }

        private void QLDiem_SizeChanged(object sender, EventArgs e)
        {
            SetView(); 
            SetPicture();
        }

        private void SetView()
        {
            panel1.Height = this.Height * 15 / 100;
            panelButton.Width = this.Width * 20 / 100;
            foreach (Button b in this.panelButton.Controls.OfType<Button>())
            {
                b.Height = panelButton.Height * 34 / 100;
                b.ImageAlign = ContentAlignment.MiddleCenter;
                b.TextAlign = ContentAlignment.BottomCenter;
                b.TextImageRelation = TextImageRelation.ImageAboveText;

            }
        }

        private void SetPicture()
        {
            if (this.Width > (Screen.PrimaryScreen.Bounds.Width * 70 / 100))
            {
                btnXem.Image = new Bitmap("Resource\\Read64.png");
                btnGiam.Image = new Bitmap("Resource\\Decrease64.png");
                btnTang.Image = new Bitmap("Resource\\Increase64.png");
            }
            else
            {
                btnXem.Image = new Bitmap("Resource\\Read32.png");
                btnGiam.Image = new Bitmap("Resource\\Decrease32.png");
                btnTang.Image = new Bitmap("Resource\\Increase32.png");
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {

        }
    }
}
