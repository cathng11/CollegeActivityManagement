using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SE_15_DTO;

namespace SE_15_BLL
{
    public class LoaiTaiKhoan_BLL
    {
        private static LoaiTaiKhoan_BLL _Instance;

        public static LoaiTaiKhoan_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LoaiTaiKhoan_BLL();
                }
                return _Instance;
            }
            private set => _Instance = value;
        }

        private LoaiTaiKhoan_BLL()
        {

        }
        public List<LoaiTaiKhoan_DTO> GetAll_BLL()
        {
            SE_15Entities sE_15Entities = new SE_15Entities();
            return sE_15Entities.LoaiTaiKhoans.Select(tk => new LoaiTaiKhoan_DTO
            {
                IDLoaiTaiKhoan = tk.IDLoaiTaiKhoan,
                TenLoai = tk.TenLoai
            }).ToList();
        }
    }
}
