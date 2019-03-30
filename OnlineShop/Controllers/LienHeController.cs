using Models.DAO;
using Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class LienHeController : Controller
    {
        // GET: LienHe
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PhanHoi(PhanHoi ph)
        {
            
            DanhGiaSpDao dgDao = new DanhGiaSpDao();
            if (ModelState.IsValid)
            {
                dgDao.DanhGiaSp(ph);
                return View("CamOn");
            }
            return View("Index");
        }
        public  ActionResult CamOn()
        {
            return View();
        }
    }
}