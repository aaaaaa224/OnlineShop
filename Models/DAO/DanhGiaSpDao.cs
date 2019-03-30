using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class DanhGiaSpDao
    {
        OnlineShopDbContext db = null;
        public DanhGiaSpDao()
        {
            db = new OnlineShopDbContext();
        }
        public void DanhGiaSp(PhanHoi ph)
        {
            try
            {
                db.PhanHois.Add(ph);
                db.SaveChanges();
            }
            catch (Exception)
            {

            }
          
        }
    }
}
