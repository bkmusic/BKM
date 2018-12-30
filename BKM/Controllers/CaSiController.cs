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
    public class CaSiController : Controller
    {
        private BKMContext db = new BKMContext();

        // GET: CaSi
        public ActionResult Index()
        {
            return View(db.CaSies.ToList());
        }

        // GET: CaSi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaSi caSi = db.CaSies.Find(id);
            if (caSi == null)
            {
                return HttpNotFound();
            }
            return View(caSi);
        }

        // GET: CaSi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CaSi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CaSi CaSi)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase file = Request.Files[0];
                    if (file.ContentLength > 0)
                    {
                        
                        var fileName = Path.GetFileName(file.FileName);
                        
                        CaSi.HinhAnh = file.FileName;
                        string path = Path.Combine(
                            Server.MapPath("~/IMAGE"), fileName);
                        file.SaveAs(path);
                    }
                    db.CaSies.Add(CaSi);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(CaSi);
        }

        // GET: CaSi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaSi caSi = db.CaSies.Find(id);
            if (caSi == null)
            {
                return HttpNotFound();
            }
            return View(caSi);
        }

        // POST: CaSi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CaSi CaSi)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase file = Request.Files[0];
                    if (file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        CaSi.HinhAnh = file.FileName;
                        string path = Path.Combine(
                            Server.MapPath("~/IMAGE"), fileName);
                        file.SaveAs(path);
                    }
                }
                db.Entry(CaSi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(CaSi);
        }

        // GET: CaSi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaSi caSi = db.CaSies.Find(id);
            if (caSi == null)
            {
                return HttpNotFound();
            }
            return View(caSi);
        }

        // POST: CaSi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CaSi caSi = db.CaSies.Find(id);
            db.CaSies.Remove(caSi);
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
