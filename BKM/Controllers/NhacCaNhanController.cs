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
    public class NhacCaNhanController : Controller
    {
        private BKMContext db = new BKMContext();
        
        // GET: NhacCaNhan
        public ActionResult Index()
        {
            var nhacCaNhans = db.NhacCaNhans.Include(n => n.BaiHat).Include(n => n.NguoiDung);
            return View(nhacCaNhans.ToList());
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
