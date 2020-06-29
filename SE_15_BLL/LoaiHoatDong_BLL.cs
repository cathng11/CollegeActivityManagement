using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SE_15_DTO;

namespace SE_15_BLL
{
    public class LoaiHoatDong_BLL
    {
        private static LoaiHoatDong_BLL _Instance;

        public static LoaiHoatDong_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new LoaiHoatDong_BLL();
                }
                return _Instance;
            }
            private set => _Instance = value;
        }

        private LoaiHoatDong_BLL()
        {

        }

        public List<LoaiHoatDong_DTO> GetAll_DAL()
        {
            try
            {
                SE_15Entities sE_15Entities = new SE_15Entities();
                return sE_15Entities.LoaiHoatDongs.Select(lhd => new LoaiHoatDong_DTO()
                {
                    IDLoaiHoatDong = lhd.IDLoaiHoatDong,
                    LoaiHoatDong = lhd.LoaiHoatDong1
                }).ToList();

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
