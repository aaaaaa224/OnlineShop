using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class CustomerController : BaseController
    {
        // GET: Admin/Customer
        public ActionResult Index(int page=1,int pagesize=6)
        {
            KhachHangDao khDao = new KhachHangDao(); 
            return View(khDao.DanhSachKhachMuaHang(page,pagesize));
        }
        public ActionResult ChiTiet(int id)
        {
            GioHangDAO ghDao = new GioHangDAO();
            return View(ghDao.chitietdonhang(id));
        }
    }
}