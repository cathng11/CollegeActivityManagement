using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SE_15_DTO;

namespace SE_15_BLL
{
    public class TaiKhoan_BLL
    {
        private static TaiKhoan_BLL _Instance;

        public static TaiKhoan_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new TaiKhoan_BLL();
                }
                return _Instance;
            }
            private set => _Instance = value;
        }

        private TaiKhoan_BLL()
        {

        }

        public TaiKhoan Get_ByUsername_BLL(string username)
        {
            SE_15Entities sE_15Entities = new SE_15Entities();
            try
            {
                return sE_15Entities.TaiKhoans.Where(tk => tk.TenDangNhap == username).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<TaiKhoan_DTO> GetAll_BLL()
        {
            try
            {
                SE_15Entities sE_15Entities = new SE_15Entities();
                return sE_15Entities.TaiKhoans.Select(tk => new TaiKhoan_DTO
                {
                    IDTaiKhoan = tk.IDTaiKhoan,
                    TenDangNhap = tk.TenDangNhap,
                    LoaiTaiKhoan = tk.LoaiTaiKhoan.TenLoai
                }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<TaiKhoan_DTO> Get_ByLoaiTaiKhoan_DAL(string userType)
        {
            try
            {
                SE_15Entities sE_15Entities = new SE_15Entities();
                return sE_15Entities.TaiKhoans.Where(tk => tk.IDLoaiTaiKhoan == userType).Select(tk => new TaiKhoan_DTO
                {
                    IDTaiKhoan = tk.IDTaiKhoan,
                    TenDangNhap = tk.TenDangNhap,
                    LoaiTaiKhoan = tk.LoaiTaiKhoan.TenLoai
                }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public TaiKhoan Get_ByIDTaiKhoan_BLL(string idTaiKhoan)
        {
            try
            {
                SE_15Entities sE_15Entities = new SE_15Entities();
                return sE_15Entities.TaiKhoans.Where(tk => tk.IDTaiKhoan == idTaiKhoan).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Add_BLL(TaiKhoan tk)
        {
            Random rand = new Random();
            string password = "";
            for (int i = 0; i < 8; i++)
            {
                char c = Convert.ToChar(rand.Next(97, 122));
                password += c;
            }

            tk.MatKhau = EncodePasswordToBase64(password);
            try
            {
                SE_15Entities sE_15Entities = new SE_15Entities();
                sE_15Entities.TaiKhoans.Add(tk);
                sE_15Entities.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        public string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        public void Edit_BLL(string oldTK, TaiKhoan newTK)
        {
            try
            {
                SE_15Entities sE_15Entities = new SE_15Entities();
                TaiKhoan tk = sE_15Entities.TaiKhoans.Where(t => t.IDTaiKhoan == oldTK).FirstOrDefault();
                tk.TenDangNhap = newTK.TenDangNhap;
                sE_15Entities.SaveChanges();
            }
            catch (Exception)
            {
                return;
            }
        }

        public void Delete_BLL(string id_TK)
        {
            try
            {
                SE_15Entities sE_15Entities = new SE_15Entities();
                sE_15Entities.TaiKhoans.Remove(sE_15Entities.TaiKhoans.Where(tk => tk.IDTaiKhoan == id_TK).FirstOrDefault());
                sE_15Entities.SaveChanges();
            }
            catch (Exception)
            {
                return;
            }
        }

        public List<TaiKhoan_DTO> GetTK_Khoa_ByKhoa_BLL(int id_Khoa)
        {
            try
            {
                SE_15Entities sE_15Entities = new SE_15Entities();
                Khoa kh = sE_15Entities.Khoas.Where(k => k.IDKhoa == id_Khoa).FirstOrDefault();
                return sE_15Entities.TaiKhoans.Where(tk => tk.IDTaiKhoan == kh.IDTaiKhoan).Select(tk => new TaiKhoan_DTO
                {
                    IDTaiKhoan = tk.IDTaiKhoan,
                    TenDangNhap = tk.TenDangNhap,
                    LoaiTaiKhoan = tk.LoaiTaiKhoan.TenLoai
                }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<TaiKhoan_DTO> GetTK_SinhVien_ByKhoa_BLL(int id_Khoa)
        {
            try
            {
                SE_15Entities sE_15Entities = new SE_15Entities();
                List<SinhVien> sinhViens = sE_15Entities.SinhViens.Where(sv => sv.IDKhoa == id_Khoa).ToList();
                List<TaiKhoan> list_return = new List<TaiKhoan>();
                foreach (SinhVien item in sinhViens)
                {
                    list_return.Add(sE_15Entities.TaiKhoans.Where(tk => tk.IDTaiKhoan == item.IDTaiKhoan).FirstOrDefault());
                }
                return list_return.Select(tk => new TaiKhoan_DTO
                {
                    IDTaiKhoan = tk.IDTaiKhoan,
                    TenDangNhap = tk.TenDangNhap,
                    LoaiTaiKhoan = tk.LoaiTaiKhoan.TenLoai
                }).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<TaiKhoan_DTO> GetTK_Khoa_SinhVien_ByKhoa_BLL(int id_Khoa)
        {
            List<TaiKhoan_DTO> return_list = new List<TaiKhoan_DTO>();
            return_list.AddRange(GetTK_Khoa_ByKhoa_BLL(id_Khoa));
            return_list.AddRange(GetTK_SinhVien_ByKhoa_BLL(id_Khoa));
            return return_list;
        }

        public void ChangPass_BLL(TaiKhoan tk, string newPass)
        {
            try
            {
                SE_15Entities sE_15Entities = new SE_15Entities();
                TaiKhoan t = sE_15Entities.TaiKhoans.Where(u => u.IDTaiKhoan == tk.IDTaiKhoan).FirstOrDefault();
                t.MatKhau = EncodePasswordToBase64(newPass);
                sE_15Entities.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        public List<TaiKhoan_DTO> ShowSV_BLL(string id)
        {
            SE_15Entities db = new SE_15Entities();
            return db.TaiKhoans.Where(tk => tk.IDTaiKhoan == id).Select(tk => new TaiKhoan_DTO
            {
                IDTaiKhoan = tk.IDTaiKhoan,
                TenDangNhap = tk.TenDangNhap,
                LoaiTaiKhoan = tk.LoaiTaiKhoan.TenLoai
            }).ToList();
        }
    }
}
