using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SE_15_DTO;

namespace SE_15_BLL
{
    public class DuyetYC_BLL
    {
        private static DuyetYC_BLL _Instance;

        public static DuyetYC_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DuyetYC_BLL();
                }
                return _Instance;
            }
            private set => _Instance = value;
        }

        private DuyetYC_BLL()
        {

        }
        public List<DuyetYC_DTO> GetListYC_BLL()
        {
            SE_15Entities db = new SE_15Entities();
            var list = db.HoatDongs.Select(yc => new DuyetYC_DTO
            {
                IDHoatDong = yc.IDHoatDong,
                LoaiHoatDong = yc.LoaiHoatDong.LoaiHoatDong1,
                TenKhoa = yc.Khoa.TenKhoa,
                TenHoatDong = yc.TenHoatDong,
                TrangThaiPheDuyet = yc.TrangThaiPheDuyet,
                TrangThaiDangKy = yc.TrangThaiDangKy

            }).ToList();
            list.RemoveAll(r => r.TrangThaiPheDuyet == "Đã duyệt" || r.TrangThaiPheDuyet == "Không duyệt");
            return list;
        }

        public List<DuyetYC_DTO> GetListYC_ByKhoa_BLL(int id)
        {
            SE_15Entities db = new SE_15Entities();
            var list = db.HoatDongs.Where(yc => yc.IDKhoa == id).Select(yc => new DuyetYC_DTO
            {
                IDHoatDong = yc.IDHoatDong,
                LoaiHoatDong = yc.LoaiHoatDong.LoaiHoatDong1,
                TenKhoa = yc.Khoa.TenKhoa,
                TenHoatDong = yc.TenHoatDong,
                TrangThaiPheDuyet = yc.TrangThaiPheDuyet,
                TrangThaiDangKy = yc.TrangThaiDangKy

            }).ToList();
            list.RemoveAll(r => r.TrangThaiPheDuyet == "Đã duyệt" || r.TrangThaiPheDuyet == "Không duyệt");
            return list;
        }
    }
}
