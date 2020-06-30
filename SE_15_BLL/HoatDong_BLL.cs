using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SE_15_DTO;

namespace SE_15_BLL
{
    public class HoatDong_BLL
    {
        private static HoatDong_BLL _Instance;

        public static HoatDong_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new HoatDong_BLL();
                }
                return _Instance;
            }
            private set => _Instance = value;
        }

        private HoatDong_BLL()
        {

        }

        public List<HoatDong_DTO> GetALL_BLL()
        {
            try
            {
                SE_15Entities sE_15Entities = new SE_15Entities();
                return sE_15Entities.HoatDongs.Select(hd => new HoatDong_DTO()
                {
                    IDHoatDong = hd.IDHoatDong,
                    LoaiHoatDong = hd.LoaiHoatDong.LoaiHoatDong1,
                    TenKhoa = hd.Khoa.TenKhoa,
                    TenHoatDong = hd.TenHoatDong,
                    SoLuongThamGia = hd.SoLuongThamGia,
                    //ThoiGian = hd.ThoiGian,
                    //DiaDiem = hd.DiaDiem,
                    //ChiPhi = hd.ChiPhi,
                    //DiemHD = hd.DiemHD,
                    //TrangThaiPheDuyet = hd.TrangThaiPheDuyet,
                    //TrangThaiDangKy = hd.TrangThaiDangKy
                }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public HoatDong Get_ByID_BLL(string id_HD)
        {
            try
            {
                SE_15Entities sE_15Entities = new SE_15Entities();
                return sE_15Entities.HoatDongs.Where(hd => hd.IDHoatDong == id_HD).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<HoatDong_DTO> Get_ByKhoa_BLL(int id_Khoa)
        {
            try
            {
                SE_15Entities sE_15Entities = new SE_15Entities();
                return sE_15Entities.HoatDongs.Where(hd => hd.IDKhoa == id_Khoa).Select(hd => new HoatDong_DTO()
                {
                    IDHoatDong = hd.IDHoatDong,
                    LoaiHoatDong = hd.LoaiHoatDong.LoaiHoatDong1,
                    TenKhoa = hd.Khoa.TenKhoa,
                    TenHoatDong = hd.TenHoatDong,
                    SoLuongThamGia = hd.SoLuongThamGia,
                    //ThoiGian = hd.ThoiGian,
                    //DiaDiem = hd.DiaDiem,
                    //ChiPhi = hd.ChiPhi,
                    //DiemHD = hd.DiemHD,
                    //TrangThaiPheDuyet = hd.TrangThaiPheDuyet,
                    //TrangThaiDangKy = hd.TrangThaiDangKy
                }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<HoatDong_DTO> Get_ConstainName_BLL(string nameHD, int id_Khoa)
        {
            try
            {
                SE_15Entities sE_15Entities = new SE_15Entities();
                if (id_Khoa == 0)
                {
                    return sE_15Entities.HoatDongs.Where(hd => hd.TenHoatDong.Contains(nameHD)).Select(hd => new HoatDong_DTO()
                    {
                        IDHoatDong = hd.IDHoatDong,
                        LoaiHoatDong = hd.LoaiHoatDong.LoaiHoatDong1,
                        TenKhoa = hd.Khoa.TenKhoa,
                        TenHoatDong = hd.TenHoatDong,
                        SoLuongThamGia = hd.SoLuongThamGia,
                        //ThoiGian = hd.ThoiGian,
                        //DiaDiem = hd.DiaDiem,
                        //ChiPhi = hd.ChiPhi,
                        //DiemHD = hd.DiemHD,
                        //TrangThaiPheDuyet = hd.TrangThaiPheDuyet,
                        //TrangThaiDangKy = hd.TrangThaiDangKy
                    }).ToList();
                }
                else
                    return Get_ByKhoa_BLL(id_Khoa).Where(hd => hd.TenHoatDong.Contains(nameHD)).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public void Add_BLL(HoatDong hoatDong)
        {
            try
            {
                SE_15Entities sE_15Entities = new SE_15Entities();
                sE_15Entities.HoatDongs.Add(hoatDong);
                sE_15Entities.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        public void Edit_BLL(HoatDong hd)
        {
            try
            {
                SE_15Entities sE_15Entities = new SE_15Entities();
                sE_15Entities.HoatDongs.Attach(hd);
                sE_15Entities.Entry(hd).State = System.Data.Entity.EntityState.Modified;
                sE_15Entities.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        public void Del_BLL(string hd)
        {
            try
            {
                SE_15Entities db = new SE_15Entities();
                HoatDong list = db.HoatDongs.Where(p => p.IDHoatDong == hd).FirstOrDefault();
                db.HoatDongs.Remove(list);
                db.SaveChanges();
            }
            catch (Exception)
            {

            }
        }
    }
}
