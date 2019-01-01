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
using System.Data.Entity.Migrations;

namespace BKM.Controllers
{
    public class BaiHatController : Controller
    {
        private BKMContext db = new BKMContext();

        // GET: BaiHat
        public ActionResult Index()
        {
            var baiHats = db.BaiHats.Include(b => b.KhuVuc).Include(b => b.TheLoai);
            return View(baiHats.ToList());
        }

        // GET: BaiHat/Details/5
        public ActionResult Details(int? id)
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

        // GET: BaiHat/Create
        public ActionResult Create()
        {
            ViewBag.MaKhuVuc = new SelectList(db.KhuVucs, "MaKhuVuc", "TenKhuVuc");
            ViewBag.MaTheLoai = new SelectList(db.TheLoais, "MaTheLoai", "TenTheLoai");
            ViewBag.MaCaSi = new SelectList(db.CaSies, "MaCaSi", "TenCaSi");
            return View();
        }

        // POST: BaiHat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BaiHat baiHat)
        {          
            if (ModelState.IsValid)
            {
                baiHat.HinhAnh = "images.png";
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase fileNhac = Request.Files[0];

                    if (fileNhac.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(fileNhac.FileName);
                        baiHat.File = fileNhac.FileName;
                        string path = Path.Combine(
                            Server.MapPath("~/SONG"), fileName);
                        fileNhac.SaveAs(path);
                    }
                }
                db.BaiHats.Add(baiHat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKhuVuc = new SelectList(db.KhuVucs, "MaKhuVuc", "TenKhuVuc", baiHat.MaKhuVuc);
            ViewBag.MaTheLoai = new SelectList(db.TheLoais, "MaTheLoai", "TenTheLoai", baiHat.MaTheLoai);
            ViewBag.MaCaSi = new SelectList(db.CaSies, "MaCaSi", "TenCaSi",baiHat.MaCaSi);
            return View(baiHat);
        }

        // GET: BaiHat/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.MaKhuVuc = new SelectList(db.KhuVucs, "MaKhuVuc", "TenKhuVuc", baiHat.MaKhuVuc);
            ViewBag.MaTheLoai = new SelectList(db.TheLoais, "MaTheLoai", "TenTheLoai", baiHat.MaTheLoai);
            ViewBag.MaCaSi = new SelectList(db.CaSies, "MaCaSi", "TenCaSi", baiHat.MaCaSi);
            return View(baiHat);
        }

        // POST: BaiHat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BaiHat baiHat)
        {
            if (ModelState.IsValid)
            {
                baiHat.HinhAnh = "images.png";
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase fileNhac = Request.Files[0];

                    if (fileNhac.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(fileNhac.FileName);
                        baiHat.File = fileNhac.FileName;
                        string path = Path.Combine(
                            Server.MapPath("~/SONG"), fileName);
                        fileNhac.SaveAs(path);
                    }
                }
                db.Entry(baiHat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhuVuc = new SelectList(db.KhuVucs, "MaKhuVuc", "TenKhuVuc", baiHat.MaKhuVuc);
            ViewBag.MaTheLoai = new SelectList(db.TheLoais, "MaTheLoai", "TenTheLoai", baiHat.MaTheLoai);
            ViewBag.MaCaSi = new SelectList(db.CaSies, "MaCaSi", "TenCaSi", baiHat.MaCaSi);
            return View(baiHat);
        }

        public ActionResult EditImage(int? id)
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

        // POST: BaiHat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditImage(BaiHat baiHat)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase fileAnh = Request.Files[0];

                    if (fileAnh.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(fileAnh.FileName);
                        baiHat.File = fileAnh.FileName;
                        string path = Path.Combine(
                            Server.MapPath("~/IMAGE"), fileName);
                        fileAnh.SaveAs(path);
                    }
                }
                db.Entry(baiHat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKhuVuc = new SelectList(db.KhuVucs, "MaKhuVuc", "TenKhuVuc", baiHat.MaKhuVuc);
            ViewBag.MaTheLoai = new SelectList(db.TheLoais, "MaTheLoai", "TenTheLoai", baiHat.MaTheLoai);
            ViewBag.MaCaSi = new SelectList(db.CaSies, "MaCaSi", "TenCaSi", baiHat.MaCaSi);
            return View(baiHat);
        }

        // GET: BaiHat/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: BaiHat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaiHat baiHat = db.BaiHats.Find(id);
            db.BaiHats.Remove(baiHat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: BaiHatVietNam
        public ActionResult BaiHatVN()
        {
            var baiHatVN = db.BaiHats.Where(x => x.MaKhuVuc == 1).ToList();
            return View(baiHatVN);
        }

        //GET: BaiHatAuMy
        public ActionResult BaiHatUS()
        {
            var baiHatUS = db.BaiHats.Where(x => x.MaKhuVuc == 2).ToList();
            return View(baiHatUS);
        }

        //GET: BaiHatKP
        public ActionResult BaiHatKP()
        {
            var baiHatKP = db.BaiHats.Where(x => x.MaKhuVuc == 2).ToList();
            return View(baiHatKP);
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