using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClothesLine_FN.Models;
using ClothesLine_FN.Models.Context;

namespace ClothesLine_FN.Controllers
{
    public class SizesController : Controller
    {
        bool status = false;
        private ClothesLine_FN_Context db = new ClothesLine_FN_Context();

        // GET: Sizes
        public ActionResult Index()
        {
            var sizes = db.Sizes.Where(c => c.MasterCategory.Id == 10);
            return View(sizes.ToList());
        }
        public ActionResult WomanSizeIndex()
        {
            var sizes = db.Sizes.Where(c => c.MasterCategory.Id == 11);
            return View(sizes.ToList());
        }
        // GET: Sizes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Size size = db.Sizes.Find(id);
            if (size == null)
            {
                return HttpNotFound();
            }
            return View(size);
        }

        // GET: Sizes/Create
        public ActionResult Create()
        {
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c=>c.Id==10), "Id", "Name");
            return View();
        }
        public ActionResult WomanSizeCreate()
        {
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 11), "Id", "Name");
            return View();
        }
        // POST: Sizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SizeTitle,SizeNumber,MasterCategoryId")] Size size)
        {
            if (ModelState.IsValid)
            {
                db.Sizes.Add(size);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 10), "Id", "Name", size.MasterCategoryId);
            return View(size);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WomanSizeCreate([Bind(Include = "Id,SizeTitle,SizeNumber,MasterCategoryId")] Size size)
        {
            if (ModelState.IsValid)
            {
                db.Sizes.Add(size);
                db.SaveChanges();
                return RedirectToAction("WomanSizeIndex");
            }

            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 11), "Id", "Name", size.MasterCategoryId);
            return View(size);
        }

        // GET: Sizes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Size size = db.Sizes.Find(id);
            if (size == null)
            {
                return HttpNotFound();
            }
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 10), "Id", "Name", size.MasterCategoryId);
            return View(size);
        }
        public ActionResult WomanSizeEdit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Size size = db.Sizes.Find(id);
            if (size == null)
            {
                return HttpNotFound();
            }
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 11), "Id", "Name", size.MasterCategoryId);
            return View(size);
        }

        // POST: Sizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SizeTitle,SizeNumber,MasterCategoryId")] Size size)
        {
            if (ModelState.IsValid)
            {
                db.Entry(size).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 10), "Id", "Name", size.MasterCategoryId);
            return View(size);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WomanSizeEdit([Bind(Include = "Id,SizeTitle,SizeNumber,MasterCategoryId")] Size size)
        {
            if (ModelState.IsValid)
            {
                db.Entry(size).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("WomanSizeIndex");
            }
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 11), "Id", "Name", size.MasterCategoryId);
            return View(size);
        }

        // GET: Sizes/Delete/5
        public JsonResult Delete(int id)
        {
            var SizeById = db.Sizes.Where(m => m.Id == id).FirstOrDefault();

            if (SizeById != null)
            {
                db.Entry(SizeById).State = EntityState.Deleted;
                int affectedRow = db.SaveChanges();

                if (affectedRow > 0)
                {
                    status = true;
                }
            }
            if (status == true)
            {
                return Json(1);
            }
            return Json(0);
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
