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
            return View(db.DetailBaiHats.ToList());
        }

        // GET: DetailBaiHat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailBaiHat DetailBaiHat = db.DetailBaiHats.Find(id);
            if (DetailBaiHat == null)
            {
                return HttpNotFound();
            }
            return View(DetailBaiHat);
        }

        // GET: DetailBaiHat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetailBaiHat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBaiHat,TenBaiHat,MaTheLoai,MaKhuVuc,MaCaSi,MaNhacSi,NguoiDang,NgayDang,MoTa,HinhAnh")] DetailBaiHat DetailBaiHat)
        {
            if (ModelState.IsValid)
            {
                db.DetailBaiHats.Add(DetailBaiHat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(DetailBaiHat);
        }

        // GET: DetailBaiHat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailBaiHat DetailBaiHat = db.DetailBaiHats.Find(id);
            if (DetailBaiHat == null)
            {
                return HttpNotFound();
            }
            return View(DetailBaiHat);
        }

        // POST: DetailBaiHat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBaiHat,TenBaiHat,MaTheLoai,MaKhuVuc,MaCaSi,MaNhacSi,NguoiDang,NgayDang,MoTa,HinhAnh")] DetailBaiHat DetailBaiHat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(DetailBaiHat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(DetailBaiHat);
        }

        // GET: DetailBaiHat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailBaiHat DetailBaiHat = db.DetailBaiHats.Find(id);
            if (DetailBaiHat == null)
            {
                return HttpNotFound();
            }
            return View(DetailBaiHat);
        }

        // POST: DetailBaiHat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetailBaiHat DetailBaiHat = db.DetailBaiHats.Find(id);
            db.DetailBaiHats.Remove(DetailBaiHat);
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
