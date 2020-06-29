using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_15_DTO
{
    public class Khoa_DTO
    {
        public int IDKhoa { get; set; }
        public string TenKhoa { get; set; }
        public Nullable<int> SoLuongSV { get; set; }
        public string TenDangNhap { get; set; }
        public override string ToString()
        {
            //return base.ToString();
            return this.TenKhoa;
        }
    }
}
