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
            List<SelectListItem> khuVuc = new SelectList(db.KhuVucs, "MaKhuVuc", "TenKhuVuc").ToList();
            khuVuc.Insert(0, (new SelectListItem
            {
                Text = "---Chọn Khu Vực---",
                Value = "0.0",
                Selected = true,
            }));
            khuVuc.Insert(1, (new SelectListItem
            {
                Text = "Custom",
                Value = "0",
            }));
            ViewBag.MaKhuVuc = new SelectList(khuVuc, "Value", "Text");
            ViewBag.MaTheLoai = new SelectList(db.TheLoais, "MaTheLoai", "TenTheLoai");
            ViewBag.MaCaSi = new SelectList(db.CaSies, "MaCaSi", "TenCaSi");
            return View();
        }

        public ActionResult Upload()
        {
            List<SelectListItem> khuVuc = new SelectList(db.KhuVucs, "MaKhuVuc", "TenKhuVuc").ToList();
            khuVuc.Insert(0, (new SelectListItem
            {
                Text = "---Chọn Khu Vực---",
                Value = "0.0",
                Selected = true,
                Disabled = true,
            }));
            //khuVuc.Insert(1, (new SelectListItem
            //{
            //    Text = "Custom",
            //    Value = "0",
            //}));
            ViewBag.MaKhuVuc = new SelectList(khuVuc, "Value", "Text");

            List<SelectListItem> theLoai = new SelectList(db.TheLoais, "MaTheLoai", "TenTheLoai").ToList();
            theLoai.Insert(0, (new SelectListItem
            {
                Text = "---Chọn Thể Loại---",
                Value = "0.0",
                Selected = true,
                Disabled = true,
            }));
            //theLoai.Insert(1, (new SelectListItem
            //{
            //    Text = "Custom",
            //    Value = "0",
            //}));
            ViewBag.MaTheLoai = new SelectList(theLoai, "Value", "Text");

            List<SelectListItem> caSi = new SelectList(db.CaSies, "MaCaSi", "TenCaSi").ToList();
            caSi.Insert(0, (new SelectListItem
            {
                Text = "---Chọn Ca Sĩ---",
                Value = "0.0",
                Selected = true,
                Disabled = true,
            }));
            //caSi.Insert(1, (new SelectListItem
            //{
            //    Text = "Custom",
            //    Value = "0",
            //}));
            ViewBag.MaCaSi = new SelectList(caSi, "Value", "Text");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(BaiHat baiHat)
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
                            Server.MapPath("~/SONG/"), fileName);
                        fileNhac.SaveAs(path);
                    }
                }
                db.BaiHats.Add(baiHat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaTheLoai = new SelectList(db.KhuVucs, "MaKhuVuc", "TenKhuVuc", baiHat.MaKhuVuc);
            ViewBag.MaTheLoai = new SelectList(db.TheLoais, "MaTheLoai", "TenTheLoai", baiHat.MaTheLoai);
            ViewBag.MaCaSi = new SelectList(db.CaSies, "MaCaSi", "TenCaSi", baiHat.MaCaSi);
            return View(baiHat);
        }

//public ActionResult Nap(HttpPostedFileBase file)
//{           
//    var fname = file.FileName;
//    var name = fname.Substring(0, fname.Length - 4);
//    BaiHat baiHat = new BaiHat { TenBaiHat = name, File = fname, HinhAnh = "images.png", MaCaSi = 1, MaKhuVuc = 1, MaTheLoai = 1 } ;
//    return View();
//}



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
                            Server.MapPath("~/SONG/"), fileName);
                        fileNhac.SaveAs(path);
                    }
                }
                db.BaiHats.Add(baiHat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            List<SelectListItem> khuVuc = new SelectList(db.KhuVucs, "MaKhuVuc", "TenKhuVuc", baiHat.MaKhuVuc).ToList();
            khuVuc.Insert(0, (new SelectListItem
            {
                Text = "---Chọn Khu Vực---",
                Value = "0.0",
                Selected = true,
            }));
            ViewBag.MaKhuVuc = khuVuc;
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