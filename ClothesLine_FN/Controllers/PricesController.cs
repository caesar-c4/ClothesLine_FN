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
    public class PricesController : Controller
    {
        bool status = false;
        private ClothesLine_FN_Context db = new ClothesLine_FN_Context();

        // GET: Prices
        public ActionResult Index()
        {
            var prices = db.Prices.Where(c=>c.MasterCategory.Id==8);
            return View(prices.ToList());
        }
        public ActionResult FoodPriceIndex()
        {
            var prices = db.Prices.Where(c => c.MasterCategory.Id == 9);
            return View(prices.ToList());
        }
        public ActionResult ManPriceIndex()
        {
            var prices = db.Prices.Where(c => c.MasterCategory.Id == 10);
            return View(prices.ToList());
        }
        public ActionResult WomanPriceIndex()
        {
            var prices = db.Prices.Where(c => c.MasterCategory.Id == 11);
            return View(prices.ToList());
        }
        // GET: Prices/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Price price = db.Prices.Find(id);
            if (price == null)
            {
                return HttpNotFound();
            }
            return View(price);
        }

        // GET: Prices/Create
        public ActionResult Create()
        {
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 8), "Id", "Name");
            return View();
        }
        public ActionResult FoodPriceCreate()
        {
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 9), "Id", "Name");
            return View();
        }
        public ActionResult ManPriceCreate()
        {
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 10), "Id", "Name");
            return View();
        }
        public ActionResult WomanPriceCreate()
        {
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 11), "Id", "Name");
            return View();
        }

        // POST: Prices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PriceAmount,PriceRangeName,MasterCategoryId")] Price price)
        {
            if (ModelState.IsValid)
            {
                db.Prices.Add(price);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 8), "Id", "Name", price.MasterCategoryId);
            return View(price);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FoodPriceCreate([Bind(Include = "Id,PriceAmount,PriceRangeName,MasterCategoryId")] Price price)
        {
            if (ModelState.IsValid)
            {
                db.Prices.Add(price);
                db.SaveChanges();
                return RedirectToAction("FoodPriceIndex");
            }

            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 9), "Id", "Name", price.MasterCategoryId);
            return View(price);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManPriceCreate([Bind(Include = "Id,PriceAmount,PriceRangeName,MasterCategoryId")] Price price)
        {
            if (ModelState.IsValid)
            {
                db.Prices.Add(price);
                db.SaveChanges();
                return RedirectToAction("ManPriceIndex");
            }

            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 10), "Id", "Name", price.MasterCategoryId);
            return View(price);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WomanPriceCreate([Bind(Include = "Id,PriceAmount,PriceRangeName,MasterCategoryId")] Price price)
        {
            if (ModelState.IsValid)
            {
                db.Prices.Add(price);
                db.SaveChanges();
                return RedirectToAction("WomanPriceIndex");
            }

            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 11), "Id", "Name", price.MasterCategoryId);
            return View(price);
        }

        // GET: Prices/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Price price = db.Prices.Find(id);
            if (price == null)
            {
                return HttpNotFound();
            }
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 8), "Id", "Name", price.MasterCategoryId);
            return View(price);
        }
        public ActionResult FoodPriceEdit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Price price = db.Prices.Find(id);
            if (price == null)
            {
                return HttpNotFound();
            }
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 9), "Id", "Name", price.MasterCategoryId);
            return View(price);
        }
        public ActionResult ManPriceEdit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Price price = db.Prices.Find(id);
            if (price == null)
            {
                return HttpNotFound();
            }
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 10), "Id", "Name", price.MasterCategoryId);
            return View(price);
        }
        public ActionResult WomanPriceEdit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Price price = db.Prices.Find(id);
            if (price == null)
            {
                return HttpNotFound();
            }
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 11), "Id", "Name", price.MasterCategoryId);
            return View(price);
        }

        // POST: Prices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PriceAmount,PriceRangeName,MasterCategoryId")] Price price)
        {
            if (ModelState.IsValid)
            {
                db.Entry(price).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 8), "Id", "Name", price.MasterCategoryId);
            return View(price);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FoodPriceEdit([Bind(Include = "Id,PriceAmount,PriceRangeName,MasterCategoryId")] Price price)
        {
            if (ModelState.IsValid)
            {
                db.Entry(price).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("FoodPriceIndex");
            }
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 9), "Id", "Name", price.MasterCategoryId);
            return View(price);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManPriceEdit([Bind(Include = "Id,PriceAmount,PriceRangeName,MasterCategoryId")] Price price)
        {
            if (ModelState.IsValid)
            {
                db.Entry(price).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ManPriceIndex");
            }
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 10), "Id", "Name", price.MasterCategoryId);
            return View(price);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WomanPriceEdit([Bind(Include = "Id,PriceAmount,PriceRangeName,MasterCategoryId")] Price price)
        {
            if (ModelState.IsValid)
            {
                db.Entry(price).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("WomanPriceIndex");
            }
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 11), "Id", "Name", price.MasterCategoryId);
            return View(price);
        }


        // GET: Prices/Delete/5
        public JsonResult Delete(int id)
        {
            var PriceById = db.Prices.Where(m => m.Id == id).FirstOrDefault();

            if (PriceById != null)
            {
                db.Entry(PriceById).State = EntityState.Deleted;
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
