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
    public partial class ThongKeForm_Chart : Form
    {
        public ThongKeForm_Chart()
        {
            InitializeComponent();
            LoadChart();
        }

        private void LoadChart()
        {
            foreach (var item in Khoa_BLL.Instance.GetAll_BLL())
            {
                chartSoLuongSV.Series["Số lượng sinh viên"].Points.AddXY(item.TenKhoa, item.SoLuongSV);
                chartSoluongHD.Series["Số lượng hoạt động"].Points.AddXY(item.TenKhoa, HoatDong_BLL.Instance.Get_ByKhoa_BLL(item.IDKhoa).Count);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
