using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_15_DTO
{
    public class HoatDong_DTO
    {
        public string IDHoatDong { get; set; }
        public string LoaiHoatDong { get; set; }
        public string TenKhoa { get; set; }
        public string TenHoatDong { get; set; }
        public Nullable<int> SoLuongThamGia { get; set; }
        public Nullable<System.DateTime> ThoiGian { get; set; }
        public string DiaDiem { get; set; }
        public Nullable<int> ChiPhi { get; set; }
        public Nullable<int> DiemHD { get; set; }
        public string TrangThaiPheDuyet { get; set; }
        public string TrangThaiDangKy { get; set; }
    }
}
