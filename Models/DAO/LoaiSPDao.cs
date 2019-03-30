using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
   public class LoaiSPDao
    {
        OnlineShopDbContext db = null;
        public LoaiSPDao()
        {
            db = new OnlineShopDbContext();
        }
        public List<LoaiSanPham> dsLoaiSP()
        {
            return db.LoaiSanPhams.Select(p => p).ToList();
        }
    }
}
