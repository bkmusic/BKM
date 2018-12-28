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
    public class KhuVucController : Controller
    {
        private BKMContext db = new BKMContext();

        // GET: KhuVuc
        public ActionResult Index()
        {
            return View(db.KhuVucs.ToList());
        }

        // GET: KhuVuc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhuVuc khuVuc = db.KhuVucs.Find(id);
            if (khuVuc == null)
            {
                return HttpNotFound();
            }
            return View(khuVuc);
        }

        // GET: KhuVuc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KhuVuc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaKhuVuc,TenKhuVuc")] KhuVuc khuVuc)
        {
            if (ModelState.IsValid)
            {
                db.KhuVucs.Add(khuVuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khuVuc);
        }

        // GET: KhuVuc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhuVuc khuVuc = db.KhuVucs.Find(id);
            if (khuVuc == null)
            {
                return HttpNotFound();
            }
            return View(khuVuc);
        }

        // POST: KhuVuc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaKhuVuc,TenKhuVuc")] KhuVuc khuVuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khuVuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khuVuc);
        }

        // GET: KhuVuc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhuVuc khuVuc = db.KhuVucs.Find(id);
            if (khuVuc == null)
            {
                return HttpNotFound();
            }
            return View(khuVuc);
        }

        // POST: KhuVuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KhuVuc khuVuc = db.KhuVucs.Find(id);
            db.KhuVucs.Remove(khuVuc);
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
