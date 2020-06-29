using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SE_15_DTO;

namespace SE_15_BLL
{
    public class LichSuDangNhap_BLL
    {
        private static LichSuDangNhap_BLL _Instance;

        public static LichSuDangNhap_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LichSuDangNhap_BLL();
                }
                return _Instance;
            }
            set => _Instance = value;
        }

        private LichSuDangNhap_BLL()
        {

        }

        public List<LichSuDangNhap_DTO> Get_ByIDTaiKhoan_BLL(string id_TK)
        {
            try
            {
                SE_15Entities sE_15Entities = new SE_15Entities();
                return sE_15Entities.LichSuDangNhaps.Where(ls => ls.IDTaiKhoan == id_TK).Select(ls => new LichSuDangNhap_DTO
                {
                    ThoiGianDangNhap = ls.ThoiGianDangNhap
                }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Add_BLL(LichSuDangNhap lichSu)
        {
            try
            {
                SE_15Entities sE_15Entities = new SE_15Entities();
                sE_15Entities.LichSuDangNhaps.Add(lichSu);
                sE_15Entities.SaveChanges();
            }
            catch (Exception)
            {

            }
        }
    }
}
