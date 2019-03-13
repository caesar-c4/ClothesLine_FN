using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClothesLine_FN.Bll;
using ClothesLine_FN.Models;
using ClothesLine_FN.Models.Context;

namespace ClothesLine_FN.Controllers
{
    public class TourPackegesController : Controller
    {
        private ClothesLine_FN_Context db = new ClothesLine_FN_Context();
        Common common = new Common();
        bool status = false;

        public PartialViewResult TourPackegesPartialDetail(int id)
        {
            TourPackege tourPackege = db.TourPackeges.Where(c => c.Id == id).FirstOrDefault();
            return PartialView("~/Views/Shared/TourPackeges/_PartialTourPackegeDetail.cshtml", tourPackege);
        }
        public PartialViewResult TourPackegesByCategory(int id)
        {
            List<TourPackege> tourPackeges = db.TourPackeges.Where(c => c.Category.Id == id).ToList();
            return PartialView("~/Views/Shared/TourPackeges/_PartialTourPackegesList.cshtml", tourPackeges);
        }
        public PartialViewResult TourPackegesByDes(int id)
        {
            List<TourPackege> tourPackeges = db.TourPackeges.Where(c => c.DestinationPlace.Id == id).ToList();
            return PartialView("~/Views/Shared/TourPackeges/_PartialTourPackegesList.cshtml", tourPackeges);
        }
        // GET: TourPackeges
        public ActionResult Index()
        {
            var tourPackeges = db.TourPackeges.Include(t => t.Category).Include(t => t.DestinationPlace);
            return View(tourPackeges.ToList());
        }

        // GET: TourPackeges/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourPackege tourPackege = db.TourPackeges.Find(id);
            if (tourPackege == null)
            {
                return HttpNotFound();
            }
            return View(tourPackege);
        }

        // GET: TourPackeges/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c=>c.MasterCategory.Id== 12), "Id", "Name");
            ViewBag.DestinationPlaceId = new SelectList(db.DestinationPlaces.Where(c => c.MasterCategory.Id == 12), "Id", "Name");
            return View();
        }

        // POST: TourPackeges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CategoryId,DestinationPlaceId,Name,HotelName,Cost")] TourPackege tourPackege, HttpPostedFileBase ImageFile)
        {
            if (ImageFile == null)
            {
                ModelState.AddModelError("Image", "Please upload an image");
                ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 12), "Id", "Name", tourPackege.CategoryId);
                ViewBag.DestinationPlaceId = new SelectList(db.DestinationPlaces.Where(c => c.MasterCategory.Id == 12), "Id", "Name", tourPackege.DestinationPlaceId);
                return View(tourPackege);
            }

            bool IsValidFormat = common.ImageValidation(ImageFile);


            if (IsValidFormat == false)
            {
                ModelState.AddModelError("Image", "Only jpg, png, jpeg formates are allowed ");
                ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 12), "Id", "Name", tourPackege.CategoryId);
                ViewBag.DestinationPlaceId = new SelectList(db.DestinationPlaces.Where(c => c.MasterCategory.Id == 12), "Id", "Name", tourPackege.DestinationPlaceId);
                return View(tourPackege);
            }
            byte[] convertedImage = common.ConvertImage(ImageFile);
            tourPackege.Image = convertedImage;

            if (ModelState.IsValid)
            {
                db.TourPackeges.Add(tourPackege);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 12), "Id", "Name", tourPackege.CategoryId);
            ViewBag.DestinationPlaceId = new SelectList(db.DestinationPlaces.Where(c => c.MasterCategory.Id == 12), "Id", "Name", tourPackege.DestinationPlaceId);
            return View(tourPackege);
        }

        // GET: TourPackeges/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourPackege tourPackege = db.TourPackeges.Find(id);
            if (tourPackege == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 12), "Id", "Name", tourPackege.CategoryId);
            ViewBag.DestinationPlaceId = new SelectList(db.DestinationPlaces.Where(c => c.MasterCategory.Id == 12), "Id", "Name", tourPackege.DestinationPlaceId);
            return View(tourPackege);
        }

        // POST: TourPackeges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CategoryId,DestinationPlaceId,Name,HotelName,Cost")] TourPackege tourPackege, HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null)
            {
                bool IsValidFormate = common.ImageValidation(ImageFile);
                if (IsValidFormate == false)
                {
                    ModelState.AddModelError("Image", "Only jpg, png, jpeg formates are allowed ");
                    ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 12), "Id", "Name", tourPackege.CategoryId);
                    ViewBag.DestinationPlaceId = new SelectList(db.DestinationPlaces.Where(c => c.MasterCategory.Id == 12), "Id", "Name", tourPackege.DestinationPlaceId);
                    return View(tourPackege);
                }
                byte[] CurrentImage = common.ConvertImage(ImageFile);
                tourPackege.Image = CurrentImage;
            }
            if (ModelState.IsValid)
            {
                db.Entry(tourPackege).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories.Where(c => c.MasterCategory.Id == 12), "Id", "Name", tourPackege.CategoryId);
            ViewBag.DestinationPlaceId = new SelectList(db.DestinationPlaces.Where(c => c.MasterCategory.Id == 12), "Id", "Name", tourPackege.DestinationPlaceId);
            return View(tourPackege);
        }

        // GET: TourPackeges/Delete/5
        public JsonResult Delete(int id)
        {
            var TourPackegeById = db.TourPackeges.Where(m => m.Id == id).FirstOrDefault();

            if (TourPackegeById != null)
            {
                db.Entry(TourPackegeById).State = EntityState.Deleted;
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
