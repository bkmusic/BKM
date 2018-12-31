using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BKM.Models;
using BKM.dal;

namespace BKM.Controllers
{
    public class TimKiemController : Controller
    {
        BKMContext db = new BKMContext();
        // GET: TimKiem
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TimKiem(FormCollection f)
        {
            
            string sch = f.Get("search").ToString();
            if (sch != null && sch != "")
            {
                var baiHat = db.BaiHats.Take(20).Where(x => x.TenBaiHat.ToUpper().Contains(sch.ToUpper())).ToList();
                ViewBag.SchCaSi = db.CaSies.Where(x => x.TenCaSi.ToUpper().Contains(sch.ToUpper())).ToList();
                return View(baiHat);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }
    }
}