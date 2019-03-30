using Models.DAO;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class NewsController : BaseController
    {
        // GET: Admin/News
        public ActionResult Index(int page=1,int pagesize=3)
        {
          
            TinTucDao tDao = new TinTucDao();
            return View(tDao.listNews(page, pagesize));
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult CreateNews(TinTuc tt,HttpPostedFileBase linkanh)
        {
            try
            {
              
                // lấy tên của hình ảnh
                var tenfile = Path.GetFileName(linkanh.FileName);
                // tạo đường dẫn
                var duongdan = Path.Combine(Server.MapPath("/Photo"), tenfile);
                if (System.IO.File.Exists(duongdan))
                {
                    tt.linkanh = linkanh.FileName;
                    ViewBag.loi = "Hình ảnh đã tồn tại";
                }
                else
                {
                    linkanh.SaveAs(duongdan);
                    tt.linkanh = linkanh.FileName;
                }

            }
            catch (Exception)
            {
                ViewBag.loianh = "Chọn hình ảnh";
                return View("Create");

            }
            if (ModelState.IsValid)
            {
                TinTucDao tDao = new TinTucDao();
                tDao.Create(tt);
                return Redirect("Index");
            }

            return View("Create");
        }
        public ActionResult Edit(int matintuc)
        {
            TinTucDao tDao = new TinTucDao();
            return View(tDao.search(matintuc));
        }
        public ActionResult EditNews(TinTuc tt,HttpPostedFileBase linkanh)
        {
            TinTucDao ttDao = new TinTucDao();
            try
            {
                var tenfile = Path.GetFileName(linkanh.FileName);
                var duongdan = Path.Combine(Server.MapPath("/Photo"), tenfile);
                if (System.IO.File.Exists(duongdan))
                {
                    tt.linkanh = linkanh.FileName;
                }
                else
                {
                    linkanh.SaveAs(duongdan);
                    tt.linkanh = linkanh.FileName;
                }
            }
            catch (Exception)
            {
             
                tt.linkanh = ttDao.search(tt.ma).linkanh;
                
            }
            if (ModelState.IsValid)
            {
                ttDao.Edit(tt);
                return Redirect("Index");
            }
            else
            {
                return View("Edit", ttDao.search(tt.ma));
            }
          
        }
       
        public ActionResult Delete(int matintuc)
        {
            TinTucDao tDao = new TinTucDao();
            tDao.Delete(matintuc);
            return RedirectToAction("Index");
        }
    }
}