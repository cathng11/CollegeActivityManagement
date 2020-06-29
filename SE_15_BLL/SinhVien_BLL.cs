using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SE_15_DTO;


namespace SE_15_BLL
{
    public class SinhVien_BLL
    {
        private static SinhVien_BLL _Instance;

        public static SinhVien_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SinhVien_BLL();
                }
                return _Instance;
            }
            private set => _Instance = value;
        }

        private SinhVien_BLL()
        {

        }

        public SinhVien Get_ByTaiKhoan_BLL(string id_TK)
        {
            try
            {
                SE_15Entities sE_15Entities = new SE_15Entities();
                return sE_15Entities.SinhViens.Where(sv => sv.IDTaiKhoan == id_TK).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<SinhVien_DTO> GetListSV_BLL()
        {
            SE_15Entities db = new SE_15Entities();
            var list = db.SinhViens.Select(p => new SinhVien_DTO()
            {
                IDSinhVien = p.IDSinhVien,
                TenSinhVien = p.TenSinhVien,
                TenKhoa = p.Khoa.TenKhoa,
                TenDangNhap = p.TaiKhoan.TenDangNhap,
                GioiTinh = (p.GioiTinh.Value) ? "Nam" : "Nữ",
                Email = p.Email,
                SoDienThoai = p.SoDienThoai,
                QueQuan = p.QueQuan,
                NgaySinh = p.NgaySinh,
                DiaChi = p.DiaChi,
                TongDiemHoatDong = p.TongDiemHoatDong
            }).ToList();
            return list;
        }

        public bool AddSV_BLL(SinhVien sv)
        {
            try
            {
                SE_15Entities db = new SE_15Entities();
                db.SinhViens.Add(sv);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DelSV_BLL(SinhVien sv)
        {
            try
            {
                SE_15Entities db = new SE_15Entities();
                SinhVien list = db.SinhViens.Where(p => p.IDSinhVien == sv.IDSinhVien).FirstOrDefault();
                db.SinhViens.Remove(list);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateSV_BLL(SinhVien sv)
        {
            try
            {
                SE_15Entities db = new SE_15Entities();
                db.SinhViens.Attach(sv);
                db.Entry(sv).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public SinhVien ShowSV_BLL(int id)
        {

            SE_15Entities db = new SE_15Entities();
            var list = db.SinhViens.Where(p => p.IDSinhVien == id).FirstOrDefault();
            return list;
        }

        public List<SinhVien_DTO> GetListSV_Where_BLL(int id)
        {
            SE_15Entities db = new SE_15Entities();
            var list = db.SinhViens.Where(p=>p.IDKhoa==id).Select(p => new SinhVien_DTO()
            {
                IDSinhVien = p.IDSinhVien,
                TenSinhVien = p.TenSinhVien,
                TenKhoa = p.Khoa.TenKhoa,
                TenDangNhap = p.TaiKhoan.TenDangNhap,
                GioiTinh = (p.GioiTinh.Value) ? "Nam" : "Nữ",
                Email = p.Email,
                SoDienThoai = p.SoDienThoai,
                QueQuan = p.QueQuan,
                NgaySinh = p.NgaySinh,
                DiaChi = p.DiaChi,
                TongDiemHoatDong = p.TongDiemHoatDong
            }).ToList();
            return list;

        }
        public List<SinhVien_DTO> GetListSV_ByTenSV_BLL(int searchkhoa, string searchten)
        {
            SE_15Entities db = new SE_15Entities();
            if (searchkhoa == 0)
            {
                var list = db.SinhViens.Where(p => p.TenSinhVien.Contains(searchten))
                    .Select(p => new SinhVien_DTO()
                    {
                        IDSinhVien = p.IDSinhVien,
                        TenSinhVien = p.TenSinhVien,
                        TenKhoa = p.Khoa.TenKhoa,
                        TenDangNhap = p.TaiKhoan.TenDangNhap,
                        GioiTinh = (p.GioiTinh.Value) ? "Nam" : "Nữ",
                        Email = p.Email,
                        SoDienThoai = p.SoDienThoai,
                        QueQuan = p.QueQuan,
                        NgaySinh = p.NgaySinh,
                        DiaChi = p.DiaChi,
                        TongDiemHoatDong = p.TongDiemHoatDong
                    }).ToList();
                return list;

            }
            else
            {
                var list = db.SinhViens.Where(p => p.TenSinhVien.Contains(searchten))
                    .Where(p => p.Khoa.IDKhoa == searchkhoa)
                    .Select(p => new SinhVien_DTO()
                    {
                        IDSinhVien = p.IDSinhVien,
                        TenSinhVien = p.TenSinhVien,
                        TenKhoa = p.Khoa.TenKhoa,
                        TenDangNhap = p.TaiKhoan.TenDangNhap,
                        GioiTinh = (p.GioiTinh.Value) ? "Nam" : "Nữ",
                        Email = p.Email,
                        SoDienThoai = p.SoDienThoai,
                        QueQuan = p.QueQuan,
                        NgaySinh = p.NgaySinh,
                        DiaChi = p.DiaChi,
                        TongDiemHoatDong = p.TongDiemHoatDong
                    }).ToList();
                return list;
            }
        }

        public SinhVien FindUsername_BLL(string nametk)
        {
            try
            {
                SE_15Entities db = new SE_15Entities();
                return db.SinhViens.Where(p => p.TaiKhoan.TenDangNhap == nametk).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<SinhVien_DTO> GetSV_ByKhoa_BLL(string idtk)
        {
            SE_15Entities db = new SE_15Entities();
            int idkhoa = Khoa_BLL.Instance.Get_ByTaiKhoan_BLL(idtk).IDKhoa;
            return db.SinhViens.Where(p => p.IDKhoa == idkhoa).Select(p => new SinhVien_DTO()
            {
                IDSinhVien = p.IDSinhVien,
                TenSinhVien = p.TenSinhVien,
                TenKhoa = p.Khoa.TenKhoa,
                TenDangNhap = p.TaiKhoan.TenDangNhap,
                GioiTinh = (p.GioiTinh.Value) ? "Nam" : "Nữ",
                Email = p.Email,
                SoDienThoai = p.SoDienThoai,
                QueQuan = p.QueQuan,
                NgaySinh = p.NgaySinh,
                DiaChi = p.DiaChi,
                TongDiemHoatDong = p.TongDiemHoatDong
            }).ToList();
        }

        public List<SinhVien_DTO> Get_ThamGiaHD_BLL(string id_HD)
        {
            try
            {
                SE_15Entities sE_15Entities = new SE_15Entities();
                return (from sv in sE_15Entities.SinhViens
                        join dk in sE_15Entities.DangKies
                        on sv.IDSinhVien equals dk.IDSinhVien.Value into final
                        from dk in final.DefaultIfEmpty()
                        where dk.IDHoatDong == id_HD && dk.TrangThai == "Đã đăng ký"
                        select new SinhVien_DTO
                        {
                            IDSinhVien = sv.IDSinhVien,
                            TenSinhVien = sv.TenSinhVien,
                            TenKhoa = sv.Khoa.TenKhoa,
                            TenDangNhap = sv.TaiKhoan.TenDangNhap,
                            GioiTinh = (sv.GioiTinh.Value) ? "Nam" : "Nữ",
                            Email = sv.Email,
                            SoDienThoai = sv.SoDienThoai,
                            QueQuan = sv.QueQuan,
                            NgaySinh = sv.NgaySinh,
                            DiaChi = sv.DiaChi,
                            TongDiemHoatDong = sv.TongDiemHoatDong
                        }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
