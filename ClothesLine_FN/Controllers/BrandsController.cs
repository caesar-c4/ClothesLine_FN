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
    public class BrandsController : Controller
    {
        private ClothesLine_FN_Context db = new ClothesLine_FN_Context();
        bool status;
        // GET: Brands
        public ActionResult Index()
        {
            var brands = db.Brands.Where(c=>c.Category.MasterCategory.Id==8);
            return View(brands.ToList());
        }
        public ActionResult FoodBrandIndex()
        {
            var brands = db.Brands.Where(c => c.Category.MasterCategory.Id == 9);
            return View(brands.ToList());
        }
        public ActionResult ManBrandIndex()
        {
            var brands = db.Brands.Where(c => c.Category.MasterCategory.Id == 10);
            return View(brands.ToList());
        }
        public ActionResult WomanBrandIndex()
        {
            var brands = db.Brands.Where(c => c.Category.MasterCategory.Id == 11);
            return View(brands.ToList());
        }
        public ActionResult MoreBrandIndex()
        {
            var brands = db.Brands.Where(c => c.Category.MasterCategory.Id == 13);
            return View(brands.ToList());
        }

        // GET: Brands/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // GET: Brands/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c=>c.MasterCategory.Id==8).ToList(), "Id", "Name");
            return View();
        }
        public ActionResult FoodBrandCreate()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 9).ToList(), "Id", "Name");
            return View();
        }
        public ActionResult ManBrandCreate()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 10).ToList(), "Id", "Name");
            return View();
        }
        public ActionResult WomanBrandCreate()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 11).ToList(), "Id", "Name");
            return View();
        }
        public ActionResult MoreBrandCreate()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 13).ToList(), "Id", "Name");
            return View();
        }

        // POST: Brands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CategoryId")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Brands.Add(brand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories.Where(c=>c.MasterCategory.Id==8).ToList(), "Id", "Name", brand.CategoryId);
            return View(brand);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FoodBrandCreate([Bind(Include = "Id,Name,CategoryId")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Brands.Add(brand);
                db.SaveChanges();
                return RedirectToAction("FoodBrandIndex");
            }

            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 9).ToList(), "Id", "Name", brand.CategoryId);
            return View(brand);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManBrandCreate([Bind(Include = "Id,Name,CategoryId")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Brands.Add(brand);
                db.SaveChanges();
                return RedirectToAction("ManBrandIndex");
            }

            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 10).ToList(), "Id", "Name", brand.CategoryId);
            return View(brand);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WomanBrandCreate([Bind(Include = "Id,Name,CategoryId")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Brands.Add(brand);
                db.SaveChanges();
                return RedirectToAction("WomanBrandIndex");
            }

            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 11).ToList(), "Id", "Name", brand.CategoryId);
            return View(brand);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MoreBrandCreate([Bind(Include = "Id,Name,CategoryId")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Brands.Add(brand);
                db.SaveChanges();
                return RedirectToAction("MoreBrandIndex");
            }

            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 13).ToList(), "Id", "Name", brand.CategoryId);
            return View(brand);
        }
        // GET: Brands/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 8).ToList(), "Id", "Name", brand.CategoryId);
            return View(brand);
        }
        public ActionResult FoodBrandEdit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 9).ToList(), "Id", "Name", brand.CategoryId);
            return View(brand);
        }
        public ActionResult ManBrandEdit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 10).ToList(), "Id", "Name", brand.CategoryId);
            return View(brand);
        }
        public ActionResult WomanBrandEdit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 11).ToList(), "Id", "Name", brand.CategoryId);
            return View(brand);
        }
        public ActionResult MoreBrandEdit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 13).ToList(), "Id", "Name", brand.CategoryId);
            return View(brand);
        }

        // POST: Brands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CategoryId")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 8).ToList(), "Id", "Name", brand.CategoryId);
            return View(brand);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FoodBrandEdit([Bind(Include = "Id,Name,CategoryId")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("FoodBrandIndex");
            }
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 9).ToList(), "Id", "Name", brand.CategoryId);
            return View(brand);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManBrandEdit([Bind(Include = "Id,Name,CategoryId")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ManBrandIndex");
            }
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 10).ToList(), "Id", "Name", brand.CategoryId);
            return View(brand);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WomanBrandEdit([Bind(Include = "Id,Name,CategoryId")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("WomanBrandIndex");
            }
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 11).ToList(), "Id", "Name", brand.CategoryId);
            return View(brand);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MoreBrandEdit([Bind(Include = "Id,Name,CategoryId")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MoreBrandIndex");
            }
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 13).ToList(), "Id", "Name", brand.CategoryId);
            return View(brand);
        }


        // GET: Brands/Delete/5
        public JsonResult Delete(int id)
        {
            var BrandById = db.Brands.Where(m => m.Id == id).FirstOrDefault();

            if (BrandById != null)
            {
                db.Entry(BrandById).State = EntityState.Deleted;
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
