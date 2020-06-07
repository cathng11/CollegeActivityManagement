using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_15_DTO
{
    public class SinhVien_DTO
    {
        public int IDSinhVien { get; set; }
        public string TenSinhVien { get; set; }
        public string GioiTinh { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string QueQuan { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public Nullable<int> TongDiemHoatDong { get; set; }
        public string TenKhoa { get; set; }
        public string TenDangNhap { get; set; }
    }
}
