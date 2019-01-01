using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BKM.dal;
using BKM.Models;

namespace BKM.Controllers
{
    public class NguoiDungController : Controller
    {
        BKMContext db = new BKMContext();
        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]

        public ActionResult DangKy(NguoiDung User)
        {
            if (ModelState.IsValid)
            {
                NguoiDung chkEmail = db.NguoiDungs.SingleOrDefault(x => x.Email == User.Email);
                if (chkEmail == null)
                {
                    db.NguoiDungs.Add(User);
                    db.SaveChanges();
                    return RedirectToAction("DangNhap");
                }
                ViewBag.ThongBao = "Email "+chkEmail.Email+" đã tồn tại,bạn vui lòng đăng ký lại!" ;
                return View();
            }
            ViewBag.ThongBao = "Bạn vui lòng nhập đúng yêu cầu!";
            return View();
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string TK = f.Get("email").ToString();
            string MK = f.Get("pwd").ToString();
            NguoiDung user = db.NguoiDungs.SingleOrDefault(x => x.Email == TK && x.MatKhau == MK);
            if (user != null)
            {
                ViewBag.ThongBao = "Chúc mừng bạn đã đăng nhập thành công";
                Session["nguoiDung"] = user;               
                return RedirectToAction("Index","Home");
            }
            ViewBag.ThongBao = "Sai tên đăng nhập hoặc tài khoản";
            return View();
        }

        public ActionResult DangXuat()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

    }
}