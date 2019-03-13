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
    public class TypesController : Controller
    {
        private ClothesLine_FN_Context db = new ClothesLine_FN_Context();
        bool status;
        // GET: Types
        public ActionResult Index()
        {
            var types = db.Types.Where(c=>c.Category.MasterCategory.Id==8);
            return View(types.ToList());
        }
        public ActionResult FoodTypeIndex()
        {
            var types = db.Types.Where(c => c.Category.MasterCategory.Id == 9);
            return View(types.ToList());
        }
        public ActionResult MoreTypeIndex()
        {
            var types = db.Types.Where(c => c.Category.MasterCategory.Id == 13);
            return View(types.ToList());
        }
        // GET: Types/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Type type = db.Types.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            return View(type);
        }

        // GET: Types/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 8), "Id", "Name");
            return View();
        }
        public ActionResult FoodTypeCreate()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 9), "Id", "Name");
            return View();
        }
        public ActionResult MoreTypeCreate()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 13), "Id", "Name");
            return View();
        }
        // POST: Types/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CategoryId")] Models.Type type)
        {
            if (ModelState.IsValid)
            {
                db.Types.Add(type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 8), "Id", "Name", type.CategoryId);
            return View(type);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FoodTypeCreate([Bind(Include = "Id,Name,CategoryId")] Models.Type type)
        {
            if (ModelState.IsValid)
            {
                db.Types.Add(type);
                db.SaveChanges();
                return RedirectToAction("FoodTypeIndex");
            }

            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 9), "Id", "Name", type.CategoryId);
            return View(type);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MoreTypeCreate([Bind(Include = "Id,Name,CategoryId")] Models.Type type)
        {
            if (ModelState.IsValid)
            {
                db.Types.Add(type);
                db.SaveChanges();
                return RedirectToAction("MoreTypeIndex");
            }

            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 13), "Id", "Name", type.CategoryId);
            return View(type);
        }

        // GET: Types/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Type type = db.Types.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 8), "Id", "Name", type.CategoryId);
            return View(type);
        }
        public ActionResult FoodTypeEdit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Type type = db.Types.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 9), "Id", "Name", type.CategoryId);
            return View(type);
        }
        public ActionResult MoreTypeEdit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Type type = db.Types.Find(id);
            if (type == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 13), "Id", "Name", type.CategoryId);
            return View(type);
        }

        // POST: Types/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CategoryId")] Models.Type type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 8), "Id", "Name", type.CategoryId);
            return View(type);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FoodTypeEdit([Bind(Include = "Id,Name,CategoryId")] Models.Type type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("FoodTypeIndex");
            }
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 9), "Id", "Name", type.CategoryId);
            return View(type);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MoreTypeEdit([Bind(Include = "Id,Name,CategoryId")] Models.Type type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MoreTypeIndex");
            }
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 13), "Id", "Name", type.CategoryId);
            return View(type);
        }

        // GET: Types/Delete/5
        public JsonResult Delete(int id)
        {
            var TypeById = db.Types.Where(m => m.Id == id).FirstOrDefault();

            if (TypeById != null)
            {
                db.Entry(TypeById).State = EntityState.Deleted;
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
