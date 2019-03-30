
using Models.DAO;
using OnlineShop.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User ur)
        {
            UserDao uDao = new UserDao();
            if (ModelState.IsValid)
            {
                if (uDao.kiemtraTk(ur.taikhoan, ur.matkhau))
                {
                    User u = new User();
                    u.taikhoan = uDao.GetUser(ur.taikhoan).taikhoan;
                    u.matkhau = uDao.GetUser(ur.taikhoan).matkhau;
                  
                    Session.Add("UserLogin", u);
                  
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ViewBag.err = "Sai tài khoản hoặc mật khẩu";
                    return View("Index");
                }
            }
            else
            {
                return View("Index");
            }
        }
        public ActionResult SingOut()
        {
            
            Session["UserLogin"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}