using Models.DAO;
using Models.Entity;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ShopingCartController : Controller
    {
        // GET: ShopingCart
        public const string shop = "Shopping";
        public ActionResult Index()
        {
            ShopingCart cart = (ShopingCart)Session[shop];
            if (cart != null)
            {
                List<ItemCart> li = new List<ItemCart>();
                li = cart.listItem;
                ViewBag.tongtien = cart.TotalMoney();
                ViewBag.soluong = cart.TotalAmmount();
                return View("Index", li);
            }
            return View("Error");
        }
        public ActionResult AddItem(int id, int soluong = 1)
        {
            SanPhamDao spDao = new SanPhamDao();
            SanPham sp = spDao.searchProduct(id);
            ShopingCart cart = (ShopingCart)Session[shop];
            if (cart == null)
            {
                cart = new ShopingCart();
            }
            cart.AddItem(sp, soluong);
            Session[shop] = cart;
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult Delete(int id)
        {
            SanPhamDao spDAo = new SanPhamDao();
            SanPham sp = spDAo.searchProduct(id);
            ShopingCart cart = (ShopingCart)Session[shop];
            cart.ReMove(sp);
            Session[shop] = cart;
            return Redirect(Request.UrlReferrer.ToString());
        }
        [HttpPost]
        public ActionResult Update(int masanpham, int soluong)
        {
            SanPhamDao spDao = new SanPhamDao();
            SanPham sp = spDao.searchProduct(masanpham);
            ShopingCart cart = (ShopingCart)Session[shop];
            cart.UpdateAmount(sp, soluong);
            Session[shop] = cart;
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult ThanhToan()
        {
            ShopingCart cart = (ShopingCart)Session[shop];
            if (cart != null)
            {
                List<ItemCart> li = new List<ItemCart>();
                li = cart.listItem;
                ViewBag.tongtien = cart.TotalMoney();
                ViewBag.soluong = cart.TotalAmmount();
                return View("ThanhToan", li);
            }
            else
            {
                return View("Error");
            }
        }
        [HttpPost]
        public ActionResult ThanhToan1(Models.KhachHangDTO kh)
        {
            ShopingCart cart = (ShopingCart)Session[shop];
            List<ItemCart> li = new List<ItemCart>();
            li = cart.listItem;
            ViewBag.tongtien = cart.TotalMoney();
            ViewBag.soluong = cart.TotalAmmount();
            if (ModelState.IsValid)
            {
                KhachHang kh1 = new KhachHang();
                kh1.tenkhachhang = kh.tenkhachhang;
                kh1.diachi = kh.diachi;
                kh1.email = kh.email;
                kh1.sodienthoai = kh.sodienthoai;
                KhachHangDao khDAo = new KhachHangDao();
                int makhachhang1= khDAo.ThemKhachHang(kh1);

                GioHang gh = new GioHang();
                gh.makhachhang = makhachhang1;
                gh.ngaydathang = DateTime.Today;
                gh.tinhtranggiaohang = false;
                gh.tongtien= cart.TotalMoney();
                GioHangDAO ghDao = new GioHangDAO();
                int magiohang=ghDao.ThemGioHang(gh);

                foreach (ItemCart item in li)
                {
                    ChiTietGioHang ct = new ChiTietGioHang()
                    {
                        magiohang = magiohang,
                        masanpham = item.sanpham.masanpham,
                        soluong = item.soluong,
                        thanhtien = item.soluong*(item.sanpham.giaban)
                    };
                    ChiTietGioHangDAO ctDao = new ChiTietGioHangDAO();
                    ctDao.ThemChiTiet(ct);
                }
                Session[shop] = null;
                return View("Success");
            }
            else
            {

                return View("ThanhToan", li);
            }
        }
    }
}