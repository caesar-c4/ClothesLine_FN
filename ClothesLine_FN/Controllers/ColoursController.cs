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
    public class ColoursController : Controller
    {
        bool status = false;
        private ClothesLine_FN_Context db = new ClothesLine_FN_Context();

        // GET: Colours
        public ActionResult Index()
        {
            var colours = db.Colours.Where(c => c.MasterCategory.Id == 10);
            return View(colours.ToList());
        }
        public ActionResult WomanColourIndex()
        {
            var colours = db.Colours.Where(c => c.MasterCategory.Id == 11);
            return View(colours.ToList());
        }
        // GET: Colours/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colour colour = db.Colours.Find(id);
            if (colour == null)
            {
                return HttpNotFound();
            }
            return View(colour);
        }

        // GET: Colours/Create
        public ActionResult Create()
        {
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 10), "Id", "Name");
            return View();
        }
        public ActionResult WomanColourCreate()
        {
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 11), "Id", "Name");
            return View();
        }
        // POST: Colours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ColourName,MasterCategoryId")] Colour colour)
        {
            if (ModelState.IsValid)
            {
                db.Colours.Add(colour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 10), "Id", "Name", colour.MasterCategoryId);
            return View(colour);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WomanColourCreate([Bind(Include = "Id,ColourName,MasterCategoryId")] Colour colour)
        {
            if (ModelState.IsValid)
            {
                db.Colours.Add(colour);
                db.SaveChanges();
                return RedirectToAction("WomanColourIndex");
            }

            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 11), "Id", "Name", colour.MasterCategoryId);
            return View(colour);
        }

        // GET: Colours/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colour colour = db.Colours.Find(id);
            if (colour == null)
            {
                return HttpNotFound();
            }
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 10), "Id", "Name", colour.MasterCategoryId);
            return View(colour);
        }
        public ActionResult WomanColourEdit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colour colour = db.Colours.Find(id);
            if (colour == null)
            {
                return HttpNotFound();
            }
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 11), "Id", "Name", colour.MasterCategoryId);
            return View(colour);
        }

        // POST: Colours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ColourName,MasterCategoryId")] Colour colour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 10), "Id", "Name", colour.MasterCategoryId);
            return View(colour);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WomanColourEdit([Bind(Include = "Id,ColourName,MasterCategoryId")] Colour colour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(colour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("WomanColourIndex");
            }
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 11), "Id", "Name", colour.MasterCategoryId);
            return View(colour);
        }

        // GET: Colours/Delete/5
        public JsonResult Delete(int id)
        {
            var ColourById = db.Colours.Where(m => m.Id == id).FirstOrDefault();

            if (ColourById != null)
            {
                db.Entry(ColourById).State = EntityState.Deleted;
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
