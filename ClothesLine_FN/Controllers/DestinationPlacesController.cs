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
    public class DestinationPlacesController : Controller
    {
        private ClothesLine_FN_Context db = new ClothesLine_FN_Context();

        // GET: DestinationPlaces
        public ActionResult Index()
        {
            var destinationPlaces = db.DestinationPlaces.Include(d => d.MasterCategory);
            return View(destinationPlaces.ToList());
        }

        // GET: DestinationPlaces/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DestinationPlace destinationPlace = db.DestinationPlaces.Find(id);
            if (destinationPlace == null)
            {
                return HttpNotFound();
            }
            return View(destinationPlace);
        }

        // GET: DestinationPlaces/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c=>c.MasterCategory.Id== 12).ToList(), "Id", "Name");
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c=>c.Id==12).ToList(), "Id", "Name");
            return View();
        }

        // POST: DestinationPlaces/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CategoryId,MasterCategoryId")] DestinationPlace destinationPlace)
        {
            if (ModelState.IsValid)
            {
                db.DestinationPlaces.Add(destinationPlace);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 12).ToList(), "Id", "Name",destinationPlace.CategoryId);
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 12).ToList(), "Id", "Name", destinationPlace.MasterCategoryId);
            return View(destinationPlace);
        }

        // GET: DestinationPlaces/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DestinationPlace destinationPlace = db.DestinationPlaces.Find(id);
            if (destinationPlace == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 12).ToList(), "Id", "Name", destinationPlace.CategoryId);
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 12).ToList(), "Id", "Name", destinationPlace.MasterCategoryId);
            return View(destinationPlace);
        }

        // POST: DestinationPlaces/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CategoryId,MasterCategoryId")] DestinationPlace destinationPlace)
        {
            if (ModelState.IsValid)
            {
                db.Entry(destinationPlace).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 12).ToList(), "Id", "Name", destinationPlace.CategoryId);
            ViewBag.MasterCategoryId = new SelectList(db.MasterCategories.Where(c => c.Id == 12).ToList(), "Id", "Name", destinationPlace.MasterCategoryId);
            return View(destinationPlace);
        }

        // GET: DestinationPlaces/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DestinationPlace destinationPlace = db.DestinationPlaces.Find(id);
            if (destinationPlace == null)
            {
                return HttpNotFound();
            }
            return View(destinationPlace);
        }

        // POST: DestinationPlaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            DestinationPlace destinationPlace = db.DestinationPlaces.Find(id);
            db.DestinationPlaces.Remove(destinationPlace);
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
