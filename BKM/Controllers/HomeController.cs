using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BKM.Models;
using BKM.dal;
namespace BKM.Controllers
{
    public class HomeController : Controller
    {
        BKMContext db = new BKMContext();
        public ActionResult Index()
        {
            var caSi = db.CaSies.Take(8).ToList();
            return View(caSi);
        }

 
        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us at";

            return View();
        }

        public ActionResult GopY()
        {
            return View();
        }

        public ActionResult BeTa()
        {
            return View();
        }
    }
}