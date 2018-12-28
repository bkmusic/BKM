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
    public class TheLoaiController : Controller
    {
        private BKMContext db = new BKMContext();

        // GET: TheLoai
        public ActionResult Index()
        {
            return View(db.TheLoais.ToList());
        }

        // GET: TheLoai/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheLoai TheLoai = db.TheLoais.Find(id);
            if (TheLoai == null)
            {
                return HttpNotFound();
            }
            return View(TheLoai);
        }

        // GET: TheLoai/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TheLoai/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTheLoai,TenTheLoai")] TheLoai TheLoai)
        {
            if (ModelState.IsValid)
            {
                db.TheLoais.Add(TheLoai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(TheLoai);
        }

        // GET: TheLoai/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheLoai TheLoai = db.TheLoais.Find(id);
            if (TheLoai == null)
            {
                return HttpNotFound();
            }
            return View(TheLoai);
        }

        // POST: TheLoai/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTheLoai,TenTheLoai")] TheLoai TheLoai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(TheLoai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(TheLoai);
        }

        // GET: TheLoai/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TheLoai TheLoai = db.TheLoais.Find(id);
            if (TheLoai == null)
            {
                return HttpNotFound();
            }
            return View(TheLoai);
        }

        // POST: TheLoai/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TheLoai TheLoai = db.TheLoais.Find(id);
            db.TheLoais.Remove(TheLoai);
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
