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
    public partial class ThongKeForm : Form
    {
        public ThongKeForm()
        {
            InitializeComponent();
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            this.chart1.Series["Sinh viên"].Points.AddXY("Công nghệ thông tin", 200);
            this.chart1.Series["Sinh viên"].Points.AddXY("Công nghệ thực phẩm", 400);
            this.chart1.Series["Sinh viên"].Points.AddXY("Hoá", 235);
            this.chart1.Series["Sinh viên"].Points.AddXY("Điện", 350);
            this.chart1.Series["Sinh viên"].Points.AddXY("Cơ khí", 600);

            this.chart2.Series["Sinh viên"].Points.AddXY("Trại", 200);
            this.chart2.Series["Sinh viên"].Points.AddXY("Văn nghệ", 60);
            this.chart2.Series["Sinh viên"].Points.AddXY("Esport", 100);

            this.chart3.Series["Hoạt động"].Points.AddXY("Công nghệ thông tin", 10);
            this.chart3.Series["Hoạt động"].Points.AddXY("Công nghệ thực phẩm", 5);
            this.chart3.Series["Hoạt động"].Points.AddXY("Hoá", 6);
            this.chart3.Series["Hoạt động"].Points.AddXY("Điện", 3);
            this.chart3.Series["Hoạt động"].Points.AddXY("Cơ khí", 7);

            this.chart4.Series["Sinh viên"].Points.AddXY("thông tin", 25);
            this.chart4.Series["Sinh viên"].Points.AddXY("thực phẩm", 25);
            this.chart4.Series["Sinh viên"].Points.AddXY("Hoá", 20);
            this.chart4.Series["Sinh viên"].Points.AddXY("Điện", 10);
            this.chart4.Series["Sinh viên"].Points.AddXY("Cơ khí", 20);
        }
    }
}
