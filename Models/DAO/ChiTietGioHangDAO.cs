using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ChiTietGioHangDAO
    {
        OnlineShopDbContext db = null;
        public ChiTietGioHangDAO()
        {
            db = new OnlineShopDbContext();
        }
        public void ThemChiTiet(ChiTietGioHang ct)
        {
            try
            {
                db.ChiTietGioHangs.Add(ct);
                db.SaveChanges();
            }
            catch (Exception)
            {

            }
         
        }
    }
}
