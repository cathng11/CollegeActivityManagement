using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SE_15_DTO;

namespace SE_15_BLL
{
    public class Khoa_BLL
    {
        private static Khoa_BLL _Instance;

        public static Khoa_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Khoa_BLL();
                }
                return _Instance;

            }

            private set => _Instance = value;
        }

        private Khoa_BLL()
        {

        }

        public List<Khoa_DTO> GetAll_BLL()
        {
            try
            {
                SE_15Entities db = new SE_15Entities();
                return db.Khoas.Select(k => new Khoa_DTO()
                {
                    IDKhoa = k.IDKhoa,
                    TenKhoa = k.TenKhoa,
                    SoLuongSV = k.SoLuongSV,
                    TenDangNhap = k.TaiKhoan.TenDangNhap
                }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Khoa Get_ByID_BLL(int id_K)
        {
            try
            {
                SE_15Entities db = new SE_15Entities();
                return db.Khoas.Where(k => k.IDKhoa == id_K).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Khoa Get_ByTaiKhoan_BLL(string id_TK)
        {
            try
            {
                SE_15Entities db = new SE_15Entities();
                return db.Khoas.Where(k => k.IDTaiKhoan == id_TK).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int GetIDKhoa_BLL(string tenkhoa)
        {
            SE_15Entities db = new SE_15Entities();
            return (db.Khoas.Where(k => k.TenKhoa == tenkhoa).FirstOrDefault()).IDKhoa;
        }
        public List<Khoa> CBBGetListKhoa_BLL()
        {
            SE_15Entities db = new SE_15Entities();
            return db.Khoas.ToList();
        }
        public Khoa ShowKhoa_BLL(Nullable<int> id)
        {
            SE_15Entities db = new SE_15Entities();
            return db.Khoas.Where(k => k.IDKhoa == id).FirstOrDefault();
        }
        public bool AddKhoa_BLL(Khoa khoa)
        {
            try
            {
                SE_15Entities db = new SE_15Entities();
                db.Khoas.Add(khoa);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateKhoa_BLL(Khoa khoa)
        {
            try
            {
                SE_15Entities db = new SE_15Entities();
                db.Khoas.Attach(khoa);
                db.Entry(khoa).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Khoa FindUsername_BLL(string nametk)
        {
            try
            {
                SE_15Entities db = new SE_15Entities();
                var list = db.Khoas.Where(k => k.TaiKhoan.TenDangNhap == nametk).FirstOrDefault();
                return list;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public List<Khoa_DTO> Sort_BLL(string sort)
        {
            if (sort == "id") return GetAll_BLL().OrderByDescending(p => p.IDKhoa).ToList();
            else return GetAll_BLL().OrderBy(p => p.TenKhoa).ToList();
        }

    }

}
