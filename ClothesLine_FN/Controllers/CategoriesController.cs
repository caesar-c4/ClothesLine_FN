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
    public class CategoriesController : Controller
    {
        private ClothesLine_FN_Context db = new ClothesLine_FN_Context();
        bool status;
        // GET: Categories
        public ActionResult Index()
        {
            var categories = db.Categories.Where(c => c.MasterCategory.Id == 8).ToList();
            return View(categories.ToList());
        }
        public ActionResult FoodCategoryIndex()
        {
            var categories = db.Categories.Where(c => c.MasterCategory.Id == 9).ToList();
            return View(categories.ToList());
        }
        public ActionResult ManCategoryIndex()
        {
            var categories = db.Categories.Where(c => c.MasterCategory.Id == 10).ToList();
            return View(categories.ToList());
        }
        public ActionResult WomanCategoryIndex()
        {
            var categories = db.Categories.Where(c => c.MasterCategory.Id == 11).ToList();
            return View(categories.ToList());
        }
        public ActionResult TourCategoryIndex()
        {
            var categories = db.Categories.Where(c => c.MasterCategory.Id == 12).ToList();
            return View(categories.ToList());
        }
        public ActionResult MoreCategoryIndex()
        {
            var categories = db.Categories.Where(c => c.MasterCategory.Id == 13).ToList();
            return View(categories.ToList());
        }


        //----------------------------------------------------------

        public ActionResult CategoryByMaster(int id)
        {
            return View(db.MasterCategories.Where(c => c.Id == id).FirstOrDefault());
        }
        public ActionResult CategoryByElectronics()
        {
            return View(db.MasterCategories.Where(c => c.Id == 8).FirstOrDefault());
        }
        public ActionResult CategoryByFood()
        {
            return View(db.MasterCategories.Where(c => c.Id == 9).FirstOrDefault());
        }
        public ActionResult CategoryByMan()
        {
            return View(db.MasterCategories.Where(c => c.Id == 10).FirstOrDefault());
        }
        public ActionResult CategoryByWoman()
        {
            return View(db.MasterCategories.Where(c => c.Id == 11).FirstOrDefault());
        }
        public ActionResult CategoryByTours()
        {
            return View(db.MasterCategories.Where(c => c.Id == 12).FirstOrDefault());
        }
        public ActionResult CategoryByMore()
        {
            return View(db.MasterCategories.Where(c => c.Id == 13).FirstOrDefault());
        }

     // GET: Categories/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 8).ToList(), "Id", "Name");
            ViewBag.ParentId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 8).ToList(), "Id", "Name");
            return View();
        }
        public ActionResult FoodCategoryCreate()
        {
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c=>c.Id==9).ToList(), "Id", "Name");
            ViewBag.ParentId = new SelectList(db.Categories.Where(c=>c.MasterCategory.Id==9).ToList(), "Id", "Name");
            return View();
        }
        public ActionResult ManCategoryCreate()
        {
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 10).ToList(), "Id", "Name");
            ViewBag.ParentId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 10).ToList(), "Id", "Name");
            return View();
        }
        public ActionResult WomanCategoryCreate()
        {
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 11).ToList(), "Id", "Name");
            ViewBag.ParentId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 11).ToList(), "Id", "Name");
            return View();
        }
        public ActionResult TourCategoryCreate()
        {
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 12).ToList(), "Id", "Name");
            ViewBag.ParentId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 12).ToList(), "Id", "Name");
            return View();
        }
        public ActionResult MoreCategoryCreate()
        {
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 13).ToList(), "Id", "Name");
            ViewBag.ParentId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 13).ToList(), "Id", "Name");
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,MasterCategoryId,ParentId")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 8).ToList(), "Id", "Name", category.MasterCategoryId);
            ViewBag.ParentId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 8).ToList(), "Id", "Name", category.ParentId);
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FoodCategoryCreate([Bind(Include = "Id,Name,MasterCategoryId,ParentId")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("FoodCategoryIndex");
            }

            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 9).ToList(), "Id", "Name", category.MasterCategoryId);
            ViewBag.ParentId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 9).ToList(), "Id", "Name", category.ParentId);
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManCategoryCreate([Bind(Include = "Id,Name,MasterCategoryId,ParentId")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("ManCategoryIndex");
            }

            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 10).ToList(), "Id", "Name", category.MasterCategoryId);
            ViewBag.ParentId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 10).ToList(), "Id", "Name", category.ParentId);
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WomanCategoryCreate([Bind(Include = "Id,Name,MasterCategoryId,ParentId")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("WomanCategoryIndex");
            }

            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 11).ToList(), "Id", "Name", category.MasterCategoryId);
            ViewBag.ParentId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 11).ToList(), "Id", "Name", category.ParentId);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TourCategoryCreate([Bind(Include = "Id,Name,MasterCategoryId,ParentId")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("TourCategoryIndex");
            }

            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 12).ToList(), "Id", "Name", category.MasterCategoryId);
            ViewBag.ParentId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 12).ToList(), "Id", "Name", category.ParentId);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MoreCategoryCreate([Bind(Include = "Id,Name,MasterCategoryId,ParentId")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("MoreCategoryIndex");
            }

            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 13).ToList(), "Id", "Name", category.MasterCategoryId);
            ViewBag.ParentId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 13).ToList(), "Id", "Name", category.ParentId);
            return View(category);
        }
        // GET: Categories/Edit/5

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 8).ToList(), "Id", "Name", category.MasterCategoryId);
            ViewBag.ParentId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 8).ToList(), "Id", "Name", category.ParentId);
            return View(category);
        }
        public ActionResult FoodCategoryEdit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 9).ToList(), "Id", "Name", category.MasterCategoryId);
            ViewBag.ParentId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 9).ToList(), "Id", "Name", category.ParentId);
            return View(category);
        }
        public ActionResult ManCategoryEdit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 10).ToList(), "Id", "Name", category.MasterCategoryId);
            ViewBag.ParentId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 10).ToList(), "Id", "Name", category.ParentId);
            return View(category);
        }
        public ActionResult WomanCategoryEdit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 11).ToList(), "Id", "Name", category.MasterCategoryId);
            ViewBag.ParentId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 11).ToList(), "Id", "Name", category.ParentId);
            return View(category);
        }
        public ActionResult TourCategoryEdit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 12).ToList(), "Id", "Name", category.MasterCategoryId);
            ViewBag.ParentId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 12).ToList(), "Id", "Name", category.ParentId);
            return View(category);
        }
        public ActionResult MoreCategoryEdit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 13).ToList(), "Id", "Name", category.MasterCategoryId);
            ViewBag.ParentId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 13).ToList(), "Id", "Name", category.ParentId);
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,MasterCategoryId,ParentId")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 8).ToList(), "Id", "Name", category.MasterCategoryId);
            ViewBag.ParentId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 8).ToList(), "Id", "Name", category.ParentId);
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FoodCategoryEdit([Bind(Include = "Id,Name,MasterCategoryId,ParentId")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("FoodCategoryIndex");
            }
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 9).ToList(), "Id", "Name", category.MasterCategoryId);
            ViewBag.ParentId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 9).ToList(), "Id", "Name", category.ParentId);
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ManCategoryEdit([Bind(Include = "Id,Name,MasterCategoryId,ParentId")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ManCategoryIndex");
            }
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 10).ToList(), "Id", "Name", category.MasterCategoryId);
            ViewBag.ParentId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 10).ToList(), "Id", "Name", category.ParentId);
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WomanCategoryEdit([Bind(Include = "Id,Name,MasterCategoryId,ParentId")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("WomanCategoryIndex");
            }
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 11).ToList(), "Id", "Name", category.MasterCategoryId);
            ViewBag.ParentId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 11).ToList(), "Id", "Name", category.ParentId);
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TourCategoryEdit([Bind(Include = "Id,Name,MasterCategoryId,ParentId")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("TourCategoryIndex");
            }
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 12).ToList(), "Id", "Name", category.MasterCategoryId);
            ViewBag.ParentId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 12).ToList(), "Id", "Name", category.ParentId);
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MoreCategoryEdit([Bind(Include = "Id,Name,MasterCategoryId,ParentId")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MoreCategoryIndex");
            }
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 13).ToList(), "Id", "Name", category.MasterCategoryId);
            ViewBag.ParentId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 13).ToList(), "Id", "Name", category.ParentId);
            return View(category);
        }

        // GET: Categories/Delete/5
        public JsonResult Delete(int id)
        {
            var CategoryById = db.Categories.Where(m => m.Id == id).FirstOrDefault();

            if (CategoryById != null)
            {
                db.Entry(CategoryById).State = EntityState.Deleted;
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
