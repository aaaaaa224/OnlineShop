using Models.DTO;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class GioHangDAO
    {
        OnlineShopDbContext db = null;
        public GioHangDAO()
        {
            db = new OnlineShopDbContext();
        }
        public int ThemGioHang(GioHang gh)
        {
            if (gh == null) return -1;
            else
            {
                db.GioHangs.Add(gh);
                db.SaveChanges();
                return gh.magiohang;
            }
        }
        public IQueryable<ChiTietGioHangDTO> chitietdonhang(int magiohang)
        {
            var li = from a in db.ChiTietGioHangs
                     join b in db.SanPhams on a.masanpham equals b.masanpham
                     where a.magiohang == magiohang
                     select new ChiTietGioHangDTO { masanpham = a.masanpham, soluong = a.soluong, thanhtien = a.thanhtien, tensanpham = b.tensanpham };
            if (li == null) return null;
            else
            {
                return li;
            }
        }
    }
}
