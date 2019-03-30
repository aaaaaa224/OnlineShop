using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int page=1,int pagesize=8)
        {
            SanPhamDao spDao = new SanPhamDao();
            LoaiSPDao loaiSpDao = new LoaiSPDao();
            ViewBag.sanphammoi = spDao.dsSanPhamTheoUuTien(3, page,pagesize).Take(4);
            ViewBag.loaisanpham = loaiSpDao.dsLoaiSP();
            ViewBag.danhsachsanpham = spDao.listProduct(page, pagesize);
            return View();
        }
        public ActionResult GioiThieu()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult DanhMucSanPham()
        {
            DanhMucSanPhamDao dao = new DanhMucSanPhamDao();
            return PartialView(dao.li());
            
        }
        [ChildActionOnly]
        public PartialViewResult CatogeryLeft()
        {
            DanhMucSanPhamDao dao = new DanhMucSanPhamDao();

            return PartialView(dao.li());
        }
        public ActionResult TinTuc()
        {
            return View();
        }
        public ActionResult SanPhamTheoUuTien(int id, int page = 1, int pagesize = 4)
        {
            SanPhamDao spDao = new SanPhamDao();
            return View(spDao.dsSanPhamTheoUuTien(id, page, pagesize));
        }
        public ActionResult SanPhamTheoLoai(int id, int page = 1, int pagesize =4)
        {
            SanPhamDao spDao = new SanPhamDao();
            return View(spDao.dsSanPhamTheoLoai(id, page, pagesize));
        }
        public ActionResult SanPhamTheoDanhMuc(int id, int page = 1,int pagesize=16)
        {
            SanPhamDao spDao = new SanPhamDao();
            return View(spDao.dsSanPhamTheoDanhMuc(id,page,pagesize));
        }
        [ChildActionOnly]
        public ActionResult DanhMucTimKiem()
        {
            DanhMucSanPhamDao dao = new DanhMucSanPhamDao();
            return PartialView(dao.li());
        }
        public ActionResult TimKiem(string timkiem,int danhmuc)
        {
            SanPhamDao spDao = new SanPhamDao();

            return View(spDao.timkiem(timkiem,danhmuc));
        }
    }
}