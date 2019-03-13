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
    public class MasterCategoriesController : Controller
    {
        private ClothesLine_FN_Context db = new ClothesLine_FN_Context();
        bool status;
        // GET: MasterCategories
        public ActionResult Index()
        {
            return View(db.MasterCategories.ToList());
        }

        public PartialViewResult GetById(int id)
        {
            MasterCategory masterCategory = db.MasterCategories.Where(c => c.Id == id).FirstOrDefault();
            return PartialView("~/Views/MasterCategories/GetById.cshtml", masterCategory);
        }

        public ActionResult ListByCommonUser()
        {
            List<MasterCategory> masterCategories = db.MasterCategories.ToList();
            return View(masterCategories);
        }

        // GET: MasterCategories/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterCategory masterCategory = db.MasterCategories.Find(id);
            if (masterCategory == null)
            {
                return HttpNotFound();
            }
            return View(masterCategory);
        }

        // GET: MasterCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] MasterCategory masterCategory)
        {
            if (ModelState.IsValid)
            {
                db.MasterCategories.Add(masterCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(masterCategory);
        }

        // GET: MasterCategories/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MasterCategory masterCategory = db.MasterCategories.Find(id);
            if (masterCategory == null)
            {
                return HttpNotFound();
            }
            return View(masterCategory);
        }

        // POST: MasterCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] MasterCategory masterCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(masterCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(masterCategory);
        }

        // GET: MasterCategories/Delete/5
        public JsonResult Delete(int id)
        {
            var MasterCategoryById = db.MasterCategories.Where(m => m.Id == id).FirstOrDefault();

            if (MasterCategoryById != null)
            {
                db.Entry(MasterCategoryById).State = EntityState.Deleted;
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
