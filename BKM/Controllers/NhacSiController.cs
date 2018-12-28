using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BKM.dal;
using BKM.Models;

namespace BKM.Controllers
{
    public class NhacSiController : Controller
    {
        private BKMContext db = new BKMContext();

        // GET: NhacSi
        public ActionResult Index()
        {
            return View(db.NhacSies.ToList());
        }

        // GET: NhacSi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhacSi NhacSi = db.NhacSies.Find(id);
            if (NhacSi == null)
            {
                return HttpNotFound();
            }
            return View(NhacSi);
        }

        // GET: NhacSi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhacSi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NhacSi NhacSi)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase file = Request.Files[0];
                    if (file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        NhacSi.HinhAnh = file.FileName;
                        string path = Path.Combine(
                            Server.MapPath("~/IMAGE"), fileName);
                        file.SaveAs(path);
                    }
                    db.NhacSies.Add(NhacSi);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(NhacSi);
        }

        // GET: NhacSi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhacSi NhacSi = db.NhacSies.Find(id);
            if (NhacSi == null)
            {
                return HttpNotFound();
            }
            return View(NhacSi);
        }

        // POST: NhacSi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NhacSi NhacSi)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase file = Request.Files[0];
                    if (file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        NhacSi.HinhAnh = file.FileName;
                        string path = Path.Combine(
                            Server.MapPath("~/IMAGE"), fileName);
                        file.SaveAs(path);
                    }
                }
                db.Entry(NhacSi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(NhacSi);
        }

        // GET: NhacSi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhacSi NhacSi = db.NhacSies.Find(id);
            if (NhacSi == null)
            {
                return HttpNotFound();
            }
            return View(NhacSi);
        }

        // POST: NhacSi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhacSi NhacSi = db.NhacSies.Find(id);
            db.NhacSies.Remove(NhacSi);
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
