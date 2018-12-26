using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BKM.Models;
namespace BKM.Controllers
{
    public class HomeController : Controller
    {
        bkmusicEntities db = new bkmusicEntities();
        public ActionResult Index()
        {
            return View();
        }

   

        public ActionResult NhacCaNhan()
        {
            ViewBag.Message = "This is your music";
           
            return View();

        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us at";

            return View();
        }
    }
}