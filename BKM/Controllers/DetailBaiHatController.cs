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

namespace BKM.Controllers
{
    public class DetailBaiHatController : Controller
    {
        private BKMContext db = new BKMContext();

        // GET: DetailBaiHat
        public ActionResult Index()
        {
            var detailBaiHats = db.DetailBaiHats.Include(d => d.CaSi).Include(d => d.NhacSi);
            return View(detailBaiHats.ToList());
        }

        // GET: DetailBaiHat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailBaiHat detailBaiHat = db.DetailBaiHats.Find(id);
            if (detailBaiHat == null)
            {
                return HttpNotFound();
            }
            return View(detailBaiHat);
        }

        // GET: DetailBaiHat/Create
        public ActionResult Create()
        {
            ViewBag.MaCaSi = new SelectList(db.CaSies, "MaCaSi", "TenCaSi");
            ViewBag.MaNhacSi = new SelectList(db.NhacSies, "MaNhacSi", "TenNhacSi");
            return View();
        }

        // POST: DetailBaiHat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBaiHat,TenBaiHat,MaTheLoai,MaKhuVuc,MaCaSi,MaNhacSi,NguoiDang,NgayDang,MoTa,HinhAnh")] DetailBaiHat detailBaiHat)
        {
            if (ModelState.IsValid)
            {
                db.DetailBaiHats.Add(detailBaiHat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaCaSi = new SelectList(db.CaSies, "MaCaSi", "TenCaSi", detailBaiHat.MaCaSi);
            ViewBag.MaNhacSi = new SelectList(db.NhacSies, "MaNhacSi", "TenNhacSi", detailBaiHat.MaNhacSi);
            return View(detailBaiHat);
        }

        // GET: DetailBaiHat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailBaiHat detailBaiHat = db.DetailBaiHats.Find(id);
            if (detailBaiHat == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCaSi = new SelectList(db.CaSies, "MaCaSi", "TenCaSi", detailBaiHat.MaCaSi);
            ViewBag.MaNhacSi = new SelectList(db.NhacSies, "MaNhacSi", "TenNhacSi", detailBaiHat.MaNhacSi);
            return View(detailBaiHat);
        }

        // POST: DetailBaiHat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBaiHat,TenBaiHat,MaTheLoai,MaKhuVuc,MaCaSi,MaNhacSi,NguoiDang,NgayDang,MoTa,HinhAnh")] DetailBaiHat detailBaiHat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detailBaiHat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCaSi = new SelectList(db.CaSies, "MaCaSi", "TenCaSi", detailBaiHat.MaCaSi);
            ViewBag.MaNhacSi = new SelectList(db.NhacSies, "MaNhacSi", "TenNhacSi", detailBaiHat.MaNhacSi);
            return View(detailBaiHat);
        }

        // GET: DetailBaiHat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailBaiHat detailBaiHat = db.DetailBaiHats.Find(id);
            if (detailBaiHat == null)
            {
                return HttpNotFound();
            }
            return View(detailBaiHat);
        }

        // POST: DetailBaiHat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetailBaiHat detailBaiHat = db.DetailBaiHats.Find(id);
            db.DetailBaiHats.Remove(detailBaiHat);
            db.SaveChanges();
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
