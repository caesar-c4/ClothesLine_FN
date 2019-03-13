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
    public class MansProductsController : Controller
    {
        bool status = false;
        private ClothesLine_FN_Context db = new ClothesLine_FN_Context();
        Common common = new Common();

        public PartialViewResult MansProductPartialDetail(int id)
        {
            MansProduct product = db.MansProducts.Where(c => c.Id == id).FirstOrDefault();
            return PartialView("~/Views/Shared/MansProduct/MansProductPartialDetail.cshtml", product);
        }
        public PartialViewResult MansProductByCategoriy(int id)
        {
            List<MansProduct> products = db.MansProducts.Where(c => c.Brand.Category.Id == id).ToList();
            return PartialView("~/Views/Shared/MansProduct/_FilteredMansProductList.cshtml", products);
        }
        public PartialViewResult MansProductByBrand(int id)
        {
            List<MansProduct> products = db.MansProducts.Where(c => c.Brand.Id == id).ToList();
            return PartialView("~/Views/Shared/MansProduct/_FilteredMansProductList.cshtml", products);
        }

        public PartialViewResult MansProductByPrice(int id)
        {
            Price price = db.Prices.Where(c => c.Id == id).FirstOrDefault();
            List<MansProduct> products = db.MansProducts.Where(c => c.Price <= price.PriceAmount && c.Brand.Category.MasterCategory.Id == price.MasterCategory.Id).ToList();
            return PartialView("~/Views/Shared/MansProduct/_FilteredMansProductList.cshtml", products);
        }
        public PartialViewResult MansProductBySize(int id)
        {
            List<MansProduct> products = db.MansProducts.Where(c => c.Size.Id == id).ToList();
            return PartialView("~/Views/Shared/MansProduct/_FilteredMansProductList.cshtml", products);
        }
        public PartialViewResult MansProductByColour(int id)
        {
            List<MansProduct> products = db.MansProducts.Where(c => c.Colour.Id == id).ToList();
            return PartialView("~/Views/Shared/MansProduct/_FilteredMansProductList.cshtml", products);
        }


        // GET: MansProducts
        public ActionResult Index()
        {
            var mansProducts = db.MansProducts.Include(m => m.Brand).Include(m => m.Colour).Include(m => m.Size);
            return View(mansProducts.ToList());
        }

        // GET: MansProducts/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MansProduct mansProduct = db.MansProducts.Find(id);
            if (mansProduct == null)
            {
                return HttpNotFound();
            }
            return View(mansProduct);
        }

        // GET: MansProducts/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.Brands.Where(c=>c.Category.MasterCategory.Id== 10), "Id", "Name");
            ViewBag.ColourId = new SelectList(db.Colours.Where(c=>c.MasterCategory.Id==10), "Id", "ColourName");
            ViewBag.SizeId = new SelectList(db.Sizes.Where(c => c.MasterCategory.Id == 10), "Id", "SizeTitle");
            return View();
        }

        // POST: MansProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BrandId,SizeId,ColourId,Name,Image,Price,Description")] MansProduct mansProduct,HttpPostedFileBase ImageFile)
        {
            if (ImageFile == null)
            {
                ModelState.AddModelError("Image", "Please upload an image");
                ViewBag.BrandId = new SelectList(db.Brands.Where(c => c.Category.MasterCategory.Id == 10), "Id", "Name", mansProduct.BrandId);
                ViewBag.ColourId = new SelectList(db.Colours.Where(c => c.MasterCategory.Id == 10), "Id", "ColourName", mansProduct.ColourId);
                ViewBag.SizeId = new SelectList(db.Sizes.Where(c => c.MasterCategory.Id == 10), "Id", "SizeTitle", mansProduct.SizeId);
                return View(mansProduct);
            }
            bool IsValidFormat = common.ImageValidation(ImageFile);
            if (IsValidFormat == false)
            {
                ModelState.AddModelError("Image", "Only jpg, png, jpeg formates are allowed ");
                ViewBag.BrandId = new SelectList(db.Brands.Where(c => c.Category.MasterCategory.Id == 10), "Id", "Name", mansProduct.BrandId);
                ViewBag.ColourId = new SelectList(db.Colours.Where(c => c.MasterCategory.Id == 10), "Id", "ColourName", mansProduct.ColourId);
                ViewBag.SizeId = new SelectList(db.Sizes.Where(c => c.MasterCategory.Id == 10), "Id", "SizeTitle", mansProduct.SizeId);
                return View(mansProduct);
            }
            byte[] convertedImage = common.ConvertImage(ImageFile);
            mansProduct.Image = convertedImage;

            if (ModelState.IsValid)
            {
                db.MansProducts.Add(mansProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandId = new SelectList(db.Brands.Where(c => c.Category.MasterCategory.Id == 10), "Id", "Name", mansProduct.BrandId);
            ViewBag.ColourId = new SelectList(db.Colours.Where(c => c.MasterCategory.Id == 10), "Id", "ColourName", mansProduct.ColourId);
            ViewBag.SizeId = new SelectList(db.Sizes.Where(c => c.MasterCategory.Id == 10), "Id", "SizeTitle", mansProduct.SizeId);
            return View(mansProduct);
        }

        // GET: MansProducts/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MansProduct mansProduct = db.MansProducts.Find(id);
            if (mansProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(db.Brands.Where(c => c.Category.MasterCategory.Id == 10), "Id", "Name", mansProduct.BrandId);
            ViewBag.ColourId = new SelectList(db.Colours.Where(c => c.MasterCategory.Id == 10), "Id", "ColourName", mansProduct.ColourId);
            ViewBag.SizeId = new SelectList(db.Sizes.Where(c => c.MasterCategory.Id == 10), "Id", "SizeTitle", mansProduct.SizeId);
            return View(mansProduct);
        }

        // POST: MansProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BrandId,SizeId,ColourId,Name,Image,Price,Description")] MansProduct mansProduct,HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null)
            {
                bool IsValidFormate = common.ImageValidation(ImageFile);
                if (IsValidFormate == false)
                {
                    ModelState.AddModelError("Image", "Only jpg, png, jpeg formates are allowed ");
                    ViewBag.BrandId = new SelectList(db.Brands.Where(c => c.Category.MasterCategory.Id == 10), "Id", "Name", mansProduct.BrandId);
                    ViewBag.ColourId = new SelectList(db.Colours.Where(c => c.MasterCategory.Id == 10), "Id", "ColourName", mansProduct.ColourId);
                    ViewBag.SizeId = new SelectList(db.Sizes.Where(c => c.MasterCategory.Id == 10), "Id", "SizeTitle", mansProduct.SizeId);
                    return View(mansProduct);
                }
                byte[] CurrentImage = common.ConvertImage(ImageFile);
                mansProduct.Image = CurrentImage;
            }
            if (ModelState.IsValid)
            {
                db.Entry(mansProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandId = new SelectList(db.Brands.Where(c => c.Category.MasterCategory.Id == 10), "Id", "Name", mansProduct.BrandId);
            ViewBag.ColourId = new SelectList(db.Colours.Where(c => c.MasterCategory.Id == 10), "Id", "ColourName", mansProduct.ColourId);
            ViewBag.SizeId = new SelectList(db.Sizes.Where(c => c.MasterCategory.Id == 10), "Id", "SizeTitle", mansProduct.SizeId);
            return View(mansProduct);
        }

        // GET: MansProducts/Delete/5
        public JsonResult Delete(int id)
        {
            var ProductById = db.MansProducts.Where(m => m.Id == id).FirstOrDefault();

            if (ProductById != null)
            {
                db.Entry(ProductById).State = EntityState.Deleted;
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
