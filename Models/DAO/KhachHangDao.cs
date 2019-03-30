using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
using PagedList.Mvc;
using Models.DTO;

namespace Models.DAO
{
    public class KhachHangDao
    {
        OnlineShopDbContext db = null;
        public KhachHangDao()
        {
            db = new OnlineShopDbContext();
        }
        public int ThemKhachHang(KhachHang kh)
        {
            try
            {
                db.KhachHangs.Add(kh);
                db.SaveChanges();
                return kh.makhachhang;
            }
            catch (Exception)
            {

                return -1;
            }
        }
        public IPagedList<KhachDatHangDTO> DanhSachKhachMuaHang(int page, int pagesize)
        {
            var select = from a in db.KhachHangs
                         join b in db.GioHangs
                         on a.makhachhang equals b.makhachhang
                         select new KhachDatHangDTO { makhachhang = a.makhachhang, tenkhachhang = a.tenkhachhang, sodienthoai = a.sodienthoai, email= a.email, diachi=a.diachi, ngaydathang=b.ngaydathang,tongtien= b.tongtien,magiohang=b.magiohang };
            return select.OrderByDescending(p => p.ngaydathang).ToPagedList(page, pagesize);
        }
    }
}
