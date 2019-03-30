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
    public class SanPhamController : Controller
    {
        // GET: SanPham
        public ActionResult LoaiSanPham(int id)
        {
            return View();
        }
        public ActionResult SanPhamTheoUuTien(int id, int page = 1, int pagesize = 4)
        {
            SanPhamDao spDao = new SanPhamDao();
            return View(spDao.dsSanPhamTheoUuTien(id, page, pagesize));
        }
       
        public ActionResult SanPhamTheoLoai(int id, int page = 1, int pagesize = 4)
        {
            SanPhamDao spDao = new SanPhamDao();
            return View(spDao.dsSanPhamTheoLoai(id, page, pagesize));
        }
        public ActionResult SanPhamTheoDanhMuc(int id, int page = 1, int pagesize = 16)
        {
            SanPhamDao spDao = new SanPhamDao();
            return View(spDao.dsSanPhamTheoDanhMuc(id, page, pagesize));
        }
        public ActionResult ChiTietSp(int masanpham)
        {
            SanPhamDao spDao = new SanPhamDao();
            return View(spDao.searchProduct(masanpham));
        }
        [HttpPost]
        public ActionResult DanhGiaSp(PhanHoi ph,int masanpham)
        {
            SanPhamDao spDao = new SanPhamDao();
            DanhGiaSpDao dgDao = new DanhGiaSpDao();
            if (ModelState.IsValid)
            {
                dgDao.DanhGiaSp(ph);
                
            }
            return View("ChiTietSp",spDao.searchProduct(masanpham));
        }
    }
}