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
    public class WomansProductsController : Controller
    {
        private ClothesLine_FN_Context db = new ClothesLine_FN_Context();
        Common common = new Common();
        bool status = false;
        // GET: WomansProducts
        public PartialViewResult WomansProductPartialDetail(int id)
        {
            WomansProduct product = db.WomansProducts.Where(c => c.Id == id).FirstOrDefault();
            return PartialView("~/Views/Shared/WomansProduct/WomansProductPartialDetail.cshtml", product);
        }
        public PartialViewResult WomansProductByCategoriy(int id)
        {
            List<WomansProduct> products = db.WomansProducts.Where(c => c.Brand.Category.Id == id).ToList();
            return PartialView("~/Views/Shared/WomansProduct/_FilteredWomansProductList.cshtml", products);
        }
        public PartialViewResult WomansProductByBrand(int id)
        {
            List<WomansProduct> products = db.WomansProducts.Where(c => c.Brand.Id == id).ToList();
            return PartialView("~/Views/Shared/WomansProduct/_FilteredWomansProductList.cshtml", products);
        }

        public PartialViewResult WomansProductByPrice(int id)
        {
            Price price = db.Prices.Where(c => c.Id == id).FirstOrDefault();
            List<WomansProduct> products = db.WomansProducts.Where(c => c.Price <= price.PriceAmount && c.Brand.Category.MasterCategory.Id == price.MasterCategory.Id).ToList();
            return PartialView("~/Views/Shared/WomansProduct/_FilteredWomansProductList.cshtml", products);
        }
        public PartialViewResult WomansProductBySize(int id)
        {
            List<WomansProduct> products = db.WomansProducts.Where(c => c.Size.Id == id).ToList();
            return PartialView("~/Views/Shared/WomansProduct/_FilteredWomansProductList.cshtml", products);
        }
        public PartialViewResult WomansProductByColour(int id)
        {
            List<WomansProduct> products = db.WomansProducts.Where(c => c.Colour.Id==id).ToList();
            return PartialView("~/Views/Shared/WomansProduct/_FilteredWomansProductList.cshtml", products);
        }

        public ActionResult Index()
        {
            var womansProducts = db.WomansProducts.Include(w => w.Brand).Include(w => w.Colour).Include(w => w.Size);
            return View(womansProducts.ToList());
        }

        // GET: WomansProducts/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WomansProduct womansProduct = db.WomansProducts.Find(id);
            if (womansProduct == null)
            {
                return HttpNotFound();
            }
            return View(womansProduct);
        }

        // GET: WomansProducts/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.Brands.Where(c=>c.Category.MasterCategory.Id==11).ToList(), "Id", "Name");
            ViewBag.ColourId = new SelectList(db.Colours.Where(c=>c.MasterCategory.Id==11).ToList(), "Id", "ColourName");
            ViewBag.SizeId = new SelectList(db.Sizes.Where(c => c.MasterCategory.Id == 11).ToList(), "Id", "SizeTitle");
            return View();
        }

        // POST: WomansProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BrandId,SizeId,ColourId,Name,Image,Price,Description")] WomansProduct womansProduct,HttpPostedFileBase ImageFile)
        {
            if (ImageFile == null)
            {
                ModelState.AddModelError("Image", "Please upload an image");
                ViewBag.BrandId = new SelectList(db.Brands.Where(c => c.Category.MasterCategory.Id == 11).ToList(), "Id", "Name", womansProduct.BrandId);
                ViewBag.ColourId = new SelectList(db.Colours.Where(c => c.MasterCategory.Id == 11).ToList(), "Id", "ColourName", womansProduct.ColourId);
                ViewBag.SizeId = new SelectList(db.Sizes.Where(c => c.MasterCategory.Id == 11).ToList(), "Id", "SizeTitle", womansProduct.SizeId);
                return View(womansProduct);
            }
            bool IsValidFormat = common.ImageValidation(ImageFile);
            if (IsValidFormat == false)
            {
                ModelState.AddModelError("Image", "Only jpg, png, jpeg formates are allowed ");
                ViewBag.BrandId = new SelectList(db.Brands.Where(c => c.Category.MasterCategory.Id == 11).ToList(), "Id", "Name", womansProduct.BrandId);
                ViewBag.ColourId = new SelectList(db.Colours.Where(c => c.MasterCategory.Id == 11).ToList(), "Id", "ColourName", womansProduct.ColourId);
                ViewBag.SizeId = new SelectList(db.Sizes.Where(c => c.MasterCategory.Id == 11).ToList(), "Id", "SizeTitle", womansProduct.SizeId);
                return View(womansProduct);
            }
            byte[] convertedImage = common.ConvertImage(ImageFile);
            womansProduct.Image = convertedImage;
            if (ModelState.IsValid)
            {
                db.WomansProducts.Add(womansProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandId = new SelectList(db.Brands.Where(c => c.Category.MasterCategory.Id == 11).ToList(), "Id", "Name", womansProduct.BrandId);
            ViewBag.ColourId = new SelectList(db.Colours.Where(c => c.MasterCategory.Id == 11).ToList(), "Id", "ColourName", womansProduct.ColourId);
            ViewBag.SizeId = new SelectList(db.Sizes.Where(c => c.MasterCategory.Id == 11).ToList(), "Id", "SizeTitle", womansProduct.SizeId);
            return View(womansProduct);
        }

        // GET: WomansProducts/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WomansProduct womansProduct = db.WomansProducts.Find(id);
            if (womansProduct == null)
            {
                return HttpNotFound();
            }

            ViewBag.BrandId = new SelectList(db.Brands.Where(c => c.Category.MasterCategory.Id == 11).ToList(), "Id", "Name", womansProduct.BrandId);
            ViewBag.ColourId = new SelectList(db.Colours.Where(c => c.MasterCategory.Id == 11).ToList(), "Id", "ColourName", womansProduct.ColourId);
            ViewBag.SizeId = new SelectList(db.Sizes.Where(c => c.MasterCategory.Id == 11).ToList(), "Id", "SizeTitle", womansProduct.SizeId);

            return View(womansProduct);
        }

        // POST: WomansProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BrandId,SizeId,ColourId,Name,Image,Price,Description")] WomansProduct womansProduct,HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null)
            {
                bool IsValidFormate = common.ImageValidation(ImageFile);
                if (IsValidFormate == false)
                {
                    ModelState.AddModelError("Image", "Only jpg, png, jpeg formates are allowed ");
                    ViewBag.BrandId = new SelectList(db.Brands.Where(c => c.Category.MasterCategory.Id == 11).ToList(), "Id", "Name", womansProduct.BrandId);
                    ViewBag.ColourId = new SelectList(db.Colours.Where(c => c.MasterCategory.Id == 11).ToList(), "Id", "ColourName", womansProduct.ColourId);
                    ViewBag.SizeId = new SelectList(db.Sizes.Where(c => c.MasterCategory.Id == 11).ToList(), "Id", "SizeTitle", womansProduct.SizeId);
                    return View(womansProduct);
                }
                byte[] CurrentImage = common.ConvertImage(ImageFile);
                womansProduct.Image = CurrentImage;
            }
            if (ModelState.IsValid)
            {
                db.Entry(womansProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandId = new SelectList(db.Brands.Where(c => c.Category.MasterCategory.Id == 11).ToList(), "Id", "Name", womansProduct.BrandId);
            ViewBag.ColourId = new SelectList(db.Colours.Where(c => c.MasterCategory.Id == 11).ToList(), "Id", "ColourName", womansProduct.ColourId);
            ViewBag.SizeId = new SelectList(db.Sizes.Where(c => c.MasterCategory.Id == 11).ToList(), "Id", "SizeTitle", womansProduct.SizeId);

            return View(womansProduct);
        }

        // GET: WomansProducts/Delete/5
        public JsonResult Delete(int id)
        {
            var ProductById = db.WomansProducts.Where(m => m.Id == id).FirstOrDefault();

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
