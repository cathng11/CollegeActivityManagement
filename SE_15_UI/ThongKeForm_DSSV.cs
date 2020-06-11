using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SE_15_DTO;
using SE_15_BLL;

namespace SE_15_UI
{
    public partial class ThongKeForm_DSSV : Form
    {
        private string _ID_HD;
        public string ID_HD { get => _ID_HD; set => _ID_HD = value; }

        public ThongKeForm_DSSV(string id_HD)
        {
            ID_HD = id_HD;
            InitializeComponent();
            dtgvSVThamGia.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(87, 79, 125);
            dtgvSVThamGia.EnableHeadersVisualStyles = false;
            ShowSinhVien();
        }

        private void ShowSinhVien()
        {
            dtgvSVThamGia.DataSource = SinhVien_BLL.Instance.Get_ThamGiaHD_BLL(ID_HD);
            HoatDong hd = HoatDong_BLL.Instance.Get_ByID_BLL(ID_HD);
            lblTenHD.Text = hd.TenHoatDong;
            lblSoluongSV.Text = "Số lượng tham gia: " + dtgvSVThamGia.Rows.Count.ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
