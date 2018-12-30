using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BKM.Models;
using BKM.dal;
using System.Net;

namespace BKM.Controllers
{
    public class NgheNhacController : Controller
    {
        BKMContext db = new BKMContext();
        // GET: NgheNhac

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NgheNhac(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiHat baiHat = db.BaiHats.Find(id);
            if (baiHat == null)
            {
                return HttpNotFound();
            }
            return View(baiHat);
        }
        public ActionResult tempView()
        {
            return View();
        }
    }
}