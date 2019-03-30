using Models.DAO;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ProductManagementController : BaseController
    {
        DanhMucSanPhamDao dmDao = new DanhMucSanPhamDao();
        LoaiSPDao loaiSPDao = new LoaiSPDao();
        // GET: Admin/ProductManagement
        public ActionResult Index(int pagenumber=1,int pagesize=5)
        {
            SanPhamDao spDao = new SanPhamDao();
            return View(spDao.listProduct(pagenumber,pagesize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.danhmucsanpham = dmDao.li();
            ViewBag.loaisanpham = loaiSPDao.dsLoaiSP();
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(SanPham sp, HttpPostedFileBase linkanh)
        {
            ViewBag.danhmucsanpham = dmDao.li();
            ViewBag.loaisanpham = loaiSPDao.dsLoaiSP();
            try
            {
                // lấy tên của hình ảnh
                var tenfile = Path.GetFileName(linkanh.FileName);
                // tạo đường dẫn
                var duongdan = Path.Combine(Server.MapPath("/Photo"), tenfile);
                if (System.IO.File.Exists(duongdan))
                {
                    sp.linkanh = linkanh.FileName;
                    ViewBag.loi = "Hình ảnh đã tồn tại";
                }
                else
                {
                    linkanh.SaveAs(duongdan);
                    sp.linkanh = linkanh.FileName;
                }
              
            }
            catch (Exception)
            {
                ViewBag.loianh = "Chọn hình ảnh"; 
                return View("Create");

            }
            if (ModelState.IsValid)
            {
                SanPhamDao spDao = new SanPhamDao();

                spDao.Create(sp);
                return Redirect("Index");
            }

            return View("Create");
        }
        [HttpGet]
        public ActionResult Edit(int masanpham)
        {
            ViewBag.danhmucsanpham = dmDao.li();
            ViewBag.loaisanpham = loaiSPDao.dsLoaiSP();
            SanPhamDao spDao = new SanPhamDao();
            return View(spDao.searchProduct(masanpham));
        }
        [HttpPost]
        public ActionResult EditProduct(SanPham sp, HttpPostedFileBase linkanh)
        {
            ViewBag.danhmucsanpham = dmDao.li();
            ViewBag.loaisanpham = loaiSPDao.dsLoaiSP();
            try
            {
                // lấy tên của hình ảnh
                var tenfile = Path.GetFileName(linkanh.FileName);
                // tạo đường dẫn
                var duongdan = Path.Combine(Server.MapPath("/Photo"), tenfile);
                if (System.IO.File.Exists(duongdan))
                {
                    sp.linkanh = linkanh.FileName;
                    ViewBag.loi = "Hình ảnh đã tồn tại";
                }
                else
                {
                    linkanh.SaveAs(duongdan);
                    sp.linkanh = linkanh.FileName;
                }
            }
            catch (Exception)
            {
                SanPhamDao spDao = new SanPhamDao();
                sp.linkanh = spDao.searchProduct(sp.masanpham).linkanh;
            }
            if (ModelState.IsValid)
            {
                SanPhamDao spDao = new SanPhamDao();
                spDao.Edit(sp);
                return Redirect("Index");
            }
            else
            {
                return View("Edit", sp);
            }

        }

        public ActionResult Delete(int masanpham)
        {
            try
            {
                SanPhamDao spDao = new SanPhamDao();
                spDao.Delete(masanpham);
            }
            catch (Exception)
            {

               
            }
            return RedirectToAction("Index");
        }
        public ActionResult TimKiem(string timkiem)
        {
            SanPhamDao spDao = new SanPhamDao();
            return View("TimKiem",spDao.timkiem(timkiem,0));
        }
    }
}