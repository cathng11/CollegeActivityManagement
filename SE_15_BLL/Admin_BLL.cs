using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SE_15_DTO;

namespace SE_15_BLL
{
    public class Admin_BLL
    {
        private static Admin_BLL _Instance;

        public static Admin_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Admin_BLL();
                }
                return _Instance;
            }
            private set => _Instance = value;
        }

        private Admin_BLL()
        {

        }

        public Admin Get_ByTaiKhoan_BLL(string id_TK)
        {
            try
            {
                SE_15Entities sE_15Entities = new SE_15Entities();
                return sE_15Entities.Admins.Where(ad => ad.IDTaiKhoan == id_TK).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
