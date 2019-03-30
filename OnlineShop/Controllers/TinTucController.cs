using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class TinTucController : Controller
    {
        // GET: TinTuc
        public ActionResult Index(int page=1,int pagesize=3)
        {
            TinTucDao ttDao = new TinTucDao();
            return View(ttDao.listNews(page,pagesize));
        }
        public ActionResult Detail(int id)
        {
            TinTucDao ttDao = new TinTucDao();
            ttDao.Detail(id);
            return View();
        }
    }
}