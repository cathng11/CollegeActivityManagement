using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_15_DTO
{
    public class DangKy_DTO
    {
        public string IDHoatDong { get; set; }
        public string TenHoatDong { get; set; }
        public string TrangThaiPheDuyet { get; set; }
        public string TrangThaiDangKy { get; set; }
        public Nullable<int> IDSinhVien { get; set; }
        public Nullable<DateTime> ThoiGian { get; set; }
        public Nullable<int> IDDangKy { get; set; }
        public string TrangThai { get; set; }
        public Nullable<DateTime> ThoiGianDangKy { get; set; }
        public Nullable<DateTime> ThoiGianHuyDangKy { get; set; }

    }
}
