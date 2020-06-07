using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_15_DTO
{
    public class LoaiTaiKhoan_DTO
    {
        public string IDLoaiTaiKhoan { get; set; }
        public string TenLoai { get; set; }
        public override string ToString()
        {
            return this.TenLoai;
        }
    }
}
