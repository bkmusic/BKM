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
    public class BaiHatController : Controller
    {
        private BKMContext db = new BKMContext();

        // GET: BaiHat
        public ActionResult Index()
        {
            return View(db.BaiHats.ToList());
        }

        // GET: BaiHat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiHat BaiHat = db.BaiHats.Find(id);
            if (BaiHat == null)
            {
                return HttpNotFound();
            }
            return View(BaiHat);
        }

        // GET: BaiHat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BaiHat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBaiHat,TenBaiHat,MaTheLoai,MaKhuVuc,MoTa,HinhAnh,File")] BaiHat BaiHat)
        {
            if (ModelState.IsValid)
            {
                db.BaiHats.Add(BaiHat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(BaiHat);
        }

        // GET: BaiHat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiHat BaiHat = db.BaiHats.Find(id);
            if (BaiHat == null)
            {
                return HttpNotFound();
            }
            return View(BaiHat);
        }

        // POST: BaiHat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBaiHat,TenBaiHat,MaTheLoai,MaKhuVuc,MoTa,HinhAnh,File")] BaiHat BaiHat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(BaiHat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(BaiHat);
        }

        // GET: BaiHat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BaiHat BaiHat = db.BaiHats.Find(id);
            if (BaiHat == null)
            {
                return HttpNotFound();
            }
            return View(BaiHat);
        }

        // POST: BaiHat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BaiHat BaiHat = db.BaiHats.Find(id);
            db.BaiHats.Remove(BaiHat);
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
