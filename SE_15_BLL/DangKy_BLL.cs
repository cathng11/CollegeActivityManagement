using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SE_15_DTO;

namespace SE_15_BLL
{
    public class DangKy_BLL
    {
        private static DangKy_BLL _Instance;

        public static DangKy_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DangKy_BLL();
                }
                return _Instance;
            }
            private set => _Instance = value;
        }

        private DangKy_BLL()
        {

        }

        public List<DangKy_DTO> GetListDK_BLL(int idKhoa,int idsv)
        {
            try
            {
                SE_15Entities db = new SE_15Entities();
                var list = (from hd in db.HoatDongs
                            join dk in db.DangKies
                            on hd.IDHoatDong equals dk.IDHoatDong into final
                            from dk in final.DefaultIfEmpty()
                            where hd.IDKhoa == idKhoa
                            select new DangKy_DTO
                            {
                                IDHoatDong = hd.IDHoatDong,
                                TenHoatDong = hd.TenHoatDong,
                                IDSinhVien = dk.IDSinhVien,
                                ThoiGian = hd.ThoiGian,
                                IDDangKy = dk.IDDangKy,
                                TrangThai = dk != null ? dk.TrangThai : "Chưa đăng ký",
                                ThoiGianDangKy = dk.ThoiGianDangKy,
                                ThoiGianHuyDangKy = dk.ThoiGianHuyDangKy
                            }).ToList();
                list.RemoveAll(sv => sv.IDSinhVien != null && sv.IDSinhVien != idsv);
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public DangKy GetDK_ByID_BLL(int id)
        {
            try
            {
                SE_15Entities db = new SE_15Entities();
                return db.DangKies.Where(dk => dk.IDDangKy == id).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public void AddDK_BLL(DangKy dk)
        {
            try
            {
                SE_15Entities db = new SE_15Entities();
                db.DangKies.Add(dk);
                db.SaveChanges();
            }
            catch (Exception)
            {
            }
        }
        public void CancelDK_BLL(DangKy dk)
        {
            try
            {
                SE_15Entities db = new SE_15Entities();
                db.DangKies.Attach(dk);
                db.Entry(dk).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {

            }
        }
    }
}
