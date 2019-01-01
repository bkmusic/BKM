using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BKM.Models;
using BKM.dal;
using System.IO;


namespace BKM.Controllers
{
    public class NhacCaNhanController : Controller
    {
        private BKMContext db = new BKMContext();
        // GET: NhacCaNhan
        public bool ChkDangNhap()
        {
            var ChkDangNhap = Session["nguoiDung"];
            if(ChkDangNhap == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public ActionResult Index()
        {           
            if(ChkDangNhap()==false)
            {
                return View();
            }
            NguoiDung nguoiDung = (NguoiDung)Session["nguoiDung"];
            //var nhacCaNhan = db.NhacCaNhans.Include(n => n.BaiHat).Include(n => n.NguoiDung);
            ViewBag.NhacCaNhan = db.NhacCaNhans.Where(x => x.MaNguoiDung == nguoiDung.MaNguoiDung).ToList();
            return View(nguoiDung); 
        }


        public ActionResult AddBaiHat(int? id)
        {           
            
            if(id == null)
            {
                return HttpNotFound();
            }
            if (ChkDangNhap() == false)
            {
                return RedirectToAction("DangNhap", "NguoiDung");
            }
            NguoiDung nguoiDung = (NguoiDung)Session["nguoiDung"];
            NhacCaNhan nhacCaNhan = db.NhacCaNhans.SingleOrDefault(x => x.MaBaiHat == id && x.MaNguoiDung == nguoiDung.MaNguoiDung);
            if(nhacCaNhan == null)
            {
                nhacCaNhan = new NhacCaNhan();
                nhacCaNhan.MaBaiHat = (int)id;
                nhacCaNhan.MaNguoiDung = nguoiDung.MaNguoiDung;
                db.NhacCaNhans.Add(nhacCaNhan);
                db.SaveChanges();
                return RedirectToAction("Index", "NhacCaNhan");
            }
            
            return RedirectToAction("Index", "NhacCaNhan");
        }

        public ActionResult DelBaiHat(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguoiDung nguoiDung = (NguoiDung)Session["nguoiDung"];
            NhacCaNhan nhacCaNhan = db.NhacCaNhans.Single(x => x.MaBaiHat == id && x.MaNguoiDung == nguoiDung.MaNguoiDung);
            db.NhacCaNhans.Remove(nhacCaNhan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: NhacCaNhan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhacCaNhan nhacCaNhan = db.NhacCaNhans.Find(id);
            if (nhacCaNhan == null)
            {
                return HttpNotFound();
            }
            return View(nhacCaNhan);
        }

        // GET: NhacCaNhan/Create
        public ActionResult Create()
        {
            ViewBag.MaBaiHat = new SelectList(db.BaiHats, "MaBaiHat", "TenBaiHat");
            ViewBag.MaNguoiDung = new SelectList(db.NguoiDungs, "MaNguoiDung", "TenHienThi");
            return View();
        }

        // POST: NhacCaNhan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MaBaiHat,MaNguoiDung")] NhacCaNhan nhacCaNhan)
        {
            if (ModelState.IsValid)
            {
                db.NhacCaNhans.Add(nhacCaNhan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaBaiHat = new SelectList(db.BaiHats, "MaBaiHat", "TenBaiHat", nhacCaNhan.MaBaiHat);
            ViewBag.MaNguoiDung = new SelectList(db.NguoiDungs, "MaNguoiDung", "TenHienThi", nhacCaNhan.MaNguoiDung);
            return View(nhacCaNhan);
        }

        // GET: NhacCaNhan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhacCaNhan nhacCaNhan = db.NhacCaNhans.Find(id);
            if (nhacCaNhan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaBaiHat = new SelectList(db.BaiHats, "MaBaiHat", "TenBaiHat", nhacCaNhan.MaBaiHat);
            ViewBag.MaNguoiDung = new SelectList(db.NguoiDungs, "MaNguoiDung", "TenHienThi", nhacCaNhan.MaNguoiDung);
            return View(nhacCaNhan);
        }

        // POST: NhacCaNhan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MaBaiHat,MaNguoiDung")] NhacCaNhan nhacCaNhan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhacCaNhan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaBaiHat = new SelectList(db.BaiHats, "MaBaiHat", "TenBaiHat", nhacCaNhan.MaBaiHat);
            ViewBag.MaNguoiDung = new SelectList(db.NguoiDungs, "MaNguoiDung", "TenHienThi", nhacCaNhan.MaNguoiDung);
            return View(nhacCaNhan);
        }

        // GET: NhacCaNhan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhacCaNhan nhacCaNhan = db.NhacCaNhans.Find(id);
            if (nhacCaNhan == null)
            {
                return HttpNotFound();
            }
            return View(nhacCaNhan);
        }

        // POST: NhacCaNhan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhacCaNhan nhacCaNhan = db.NhacCaNhans.Find(id);
            db.NhacCaNhans.Remove(nhacCaNhan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Upload()
        {
            //var fname = fileNhac.FileName.ToString();
            //var name = fname.Substring(0, fname.Length - 4);
            //BaiHat baiHats = new BaiHat { TenBaiHat = name, MaTheLoai = 1, MaKhuVuc = 1, MaCaSi = 1, File = fname, HinhAnh = "181668.png" };
            //if (Request.Files.Count > 0)
            //{
            //    fileNhac = Request.Files[0];

            //    if (fileNhac.ContentLength > 0)
            //    {
            //        var fileName = Path.GetFileName(fileNhac.FileName);
            //        string path = Path.Combine(
            //            Server.MapPath("~/SONG/"), fileName);
            //        fileNhac.SaveAs(path);
            //    }
            //}
            //db.BaiHats.Add(baiHats);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
