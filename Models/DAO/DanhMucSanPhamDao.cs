using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class DanhMucSanPhamDao
    {
        OnlineShopDbContext db = null;
        public DanhMucSanPhamDao()
        {
            db = new OnlineShopDbContext();
        }
        public List<DanhMucSanPham> li()
        {
            return db.DanhMucSanPhams.Select(p => p).ToList();
        }
    }
}
