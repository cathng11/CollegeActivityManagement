using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE_15_DTO
{
    public class LoaiHoatDong_DTO
    {
        public int IDLoaiHoatDong { get; set; }
        public string LoaiHoatDong { get; set; }
        public override string ToString()
        {
            return this.LoaiHoatDong;
        }
    }
}
