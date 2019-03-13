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
    public class ProductsController : Controller
    {
        private ClothesLine_FN_Context db = new ClothesLine_FN_Context();
        Common common = new Common();
        bool status;

        //public PartialViewResult ProductPartialDetailFromCategory(int id)
        //{
        //    Product product = db.Products.Where(c => c.Id == id).FirstOrDefault();
        //    return PartialView("~/Views/Shared/Products/_PartialProductDetailFromCategory.cshtml", product);
        //}
        public PartialViewResult ProductPartialDetail(int id)
        {
            Product product = db.Products.Where(c => c.Id == id).FirstOrDefault();
            return PartialView("~/Views/Shared/Products/ProductPartialDetail.cshtml", product);
        }
        public PartialViewResult FoodPartialDetail(int id)
        {
            Product product = db.Products.Where(c => c.Id == id).FirstOrDefault();
            return PartialView("~/Views/Shared/Products/_PartialFoodDetails.cshtml", product);
        }
        public PartialViewResult MoreProductPartialDetail(int id)
        {
            Product product = db.Products.Where(c => c.Id == id).FirstOrDefault();
            return PartialView("~/Views/Shared/Products/_PartialMoreProductDetail.cshtml", product);
        }
        
        public PartialViewResult ProductsByCategoriy(int id)
        {
            List<Product> products = db.Products.Where(c => c.Brand.Category.Id == id).ToList();
            return PartialView("~/Views/Shared/Products/_PartialProductsByCategoriy.cshtml", products);
        }
        public PartialViewResult FoodsByCategoriy(int id)
        {
            List<Product> products = db.Products.Where(c => c.Brand.Category.Id == id).ToList();
            return PartialView("~/Views/Shared/Products/_PartialFoodList.cshtml", products);
        }
        public PartialViewResult ProductsByBrand(int id)
        {
            List<Product> products = db.Products.Where(c => c.Brand.Id == id).ToList();
            return PartialView("~/Views/Shared/Products/_PartialProductsByCategoriy.cshtml", products);
        }
        public PartialViewResult FoodsByBrand(int id)
        {
            List<Product> products = db.Products.Where(c => c.Brand.Id == id).ToList();
            return PartialView("~/Views/Shared/Products/_PartialFoodList.cshtml", products);
        }

        public PartialViewResult ProductsByType(int id)
        {
            List<Product> products = db.Products.Where(c => c.Type.Id == id).ToList();
            return PartialView("~/Views/Shared/Products/_PartialProductsByCategoriy.cshtml", products);
        }
        public PartialViewResult FoodsByType(int id)
        {
            List<Product> products = db.Products.Where(c => c.Type.Id == id).ToList();
            return PartialView("~/Views/Shared/Products/_PartialFoodList.cshtml", products);
        }

        public PartialViewResult MoreProductsByCategoriy(int id)
        {
            List<Product> products = db.Products.Where(c => c.Brand.Category.Id == id).ToList();
            return PartialView("~/Views/Shared/Products/_PartialMoreProductList.cshtml", products);
        }
        public PartialViewResult MoreProductsByBrand(int id)
        {
            List<Product> products = db.Products.Where(c => c.Brand.Id == id).ToList();
            return PartialView("~/Views/Shared/Products/_PartialMoreProductList.cshtml", products);
        }
        public PartialViewResult MoreProductsByType(int id)
        {
            List<Product> products = db.Products.Where(c => c.Type.Id == id).ToList();
            return PartialView("~/Views/Shared/Products/_PartialMoreProductList.cshtml", products);
        }


        public PartialViewResult ProductsByPrice(int id)
        {
            Price price = db.Prices.Where(c => c.Id == id).FirstOrDefault();
            List<Product> products = db.Products.Where(c => c.Price <=price.PriceAmount&&c.Brand.Category.MasterCategory.Id==price.MasterCategory.Id).ToList();
            return PartialView("~/Views/Shared/Products/_PartialProductsByCategoriy.cshtml", products);
        }
        public PartialViewResult FoodsByPrice(int id)
        {
            Price price = db.Prices.Where(c => c.Id == id).FirstOrDefault();
            List<Product> products = db.Products.Where(c => c.Price <= price.PriceAmount && c.Brand.Category.MasterCategory.Id == price.MasterCategory.Id).ToList();
            return PartialView("~/Views/Shared/Products/_PartialFoodList.cshtml", products);
        }

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Where(c=>c.Brand.Category.MasterCategory.Id==8).ToList();
            return View(products.ToList());
        }
        public ActionResult IndexFood()
        {
            var products = db.Products.Where(c=>c.Brand.Category.MasterCategory.Id==9).ToList();
            return View(products.ToList());
        }
        public ActionResult IndexMore()
        {
            var products = db.Products.Where(c => c.Brand.Category.MasterCategory.Id == 13).ToList();
            return View(products.ToList());
        }
        // GET: Products/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        public ActionResult DetailsFood(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        public ActionResult DetailsMore(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.BrandId = new SelectList(db.Brands.Where(c=>c.Category.MasterCategory.Id== 8).ToList(), "Id", "Name");
            ViewBag.TypeId = new SelectList(db.Types.Where(c => c.Category.MasterCategory.Id == 8).ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Image,Price,Description,Feature,BrandId,TypeId")] Product product, HttpPostedFileBase ImageFile)
        {
            if (ImageFile == null)
            {
                ModelState.AddModelError("Image", "Please upload an image");
                ViewBag.BrandId = new SelectList(db.Brands.Where(c => c.Category.MasterCategory.Id == 8).ToList(), "Id", "Name", product.BrandId);
                ViewBag.TypeId = new SelectList(db.Types.Where(c => c.Category.MasterCategory.Id == 8).ToList(), "Id", "Name", product.TypeId);
                return View(product);
            }

            bool IsValidFormat = common.ImageValidation(ImageFile);


            if (IsValidFormat == false)
            {
                ModelState.AddModelError("Image", "Only jpg, png, jpeg formates are allowed ");
                ViewBag.BrandId = new SelectList(db.Brands.Where(c => c.Category.MasterCategory.Id == 8).ToList(), "Id", "Name", product.BrandId);
                ViewBag.TypeId = new SelectList(db.Types.Where(c => c.Category.MasterCategory.Id == 8).ToList(), "Id", "Name", product.TypeId);
                return View(product);
            }
            byte[] convertedImage = common.ConvertImage(ImageFile);
            product.Image = convertedImage;

            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandId = new SelectList(db.Brands.Where(c => c.Category.MasterCategory.Id == 8).ToList(), "Id", "Name", product.BrandId);
            ViewBag.TypeId = new SelectList(db.Types.Where(c => c.Category.MasterCategory.Id == 8).ToList(), "Id", "Name", product.TypeId);
            return View(product);
        }

        public ActionResult CreateFood()
        {
            ViewBag.BrandId = new SelectList(db.Brands.Where(c =>c.Category.MasterCategory.Id == 9).ToList(), "Id", "Name");
            ViewBag.TypeId = new SelectList(db.Types.Where(c =>c.Category.MasterCategory.Id == 9).ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateFood([Bind(Include = "Id,Name,Image,Price,Description,Feature,BrandId,TypeId")] Product product, HttpPostedFileBase ImageFile)
        {
            if (ImageFile == null)
            {
                ModelState.AddModelError("Image", "Please upload an image");
                ViewBag.BrandId = new SelectList(db.Brands.Where(c => c.Category.MasterCategory.Id == 9).ToList(), "Id", "Name", product.BrandId);
                ViewBag.TypeId = new SelectList(db.Types.Where(c => c.Category.MasterCategory.Id == 9).ToList(), "Id", "Name", product.TypeId);
                return View(product);
            }

            bool IsValidFormat = common.ImageValidation(ImageFile);


            if (IsValidFormat == false)
            {
                ModelState.AddModelError("Image", "Only jpg, png, jpeg formates are allowed ");
                ViewBag.BrandId = new SelectList(db.Brands.Where(c =>c.Category.MasterCategory.Id == 9).ToList(), "Id", "Name", product.BrandId);
                ViewBag.TypeId = new SelectList(db.Types.Where(c =>c.Category.MasterCategory.Id == 9).ToList(), "Id", "Name", product.TypeId);
                return View(product);
            }
            byte[] convertedImage = common.ConvertImage(ImageFile);
            product.Image = convertedImage;

            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("IndexFood");
            }

            ViewBag.BrandId = new SelectList(db.Brands.Where(c =>c.Category.MasterCategory.Id == 9).ToList(), "Id", "Name", product.BrandId);
            ViewBag.TypeId = new SelectList(db.Types.Where(c =>c.Category.MasterCategory.Id == 9).ToList(), "Id", "Name", product.TypeId);
            return View(product);
        }

        public ActionResult CreateMore()
        {
            ViewBag.BrandId = new SelectList(db.Brands.Where(c => c.Category.MasterCategory.Id == 13).ToList(), "Id", "Name");
            ViewBag.TypeId = new SelectList(db.Types.Where(c => c.Category.MasterCategory.Id == 13).ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMore([Bind(Include = "Id,Name,Image,Price,Description,Feature,BrandId,TypeId")] Product product, HttpPostedFileBase ImageFile)
        {
            if (ImageFile == null)
            {
                ModelState.AddModelError("Image", "Please upload an image");
                ViewBag.BrandId = new SelectList(db.Brands.Where(c => c.Category.MasterCategory.Id == 13).ToList(), "Id", "Name", product.BrandId);
                ViewBag.TypeId = new SelectList(db.Types.Where(c => c.Category.MasterCategory.Id == 13).ToList(), "Id", "Name", product.TypeId);
                return View(product);
            }

            bool IsValidFormat = common.ImageValidation(ImageFile);


            if (IsValidFormat == false)
            {
                ModelState.AddModelError("Image", "Only jpg, png, jpeg formates are allowed ");
                ViewBag.BrandId = new SelectList(db.Brands.Where(c => c.Category.MasterCategory.Id == 13).ToList(), "Id", "Name", product.BrandId);
                ViewBag.TypeId = new SelectList(db.Types.Where(c => c.Category.MasterCategory.Id == 13).ToList(), "Id", "Name", product.TypeId);
                return View(product);
            }
            byte[] convertedImage = common.ConvertImage(ImageFile);
            product.Image = convertedImage;

            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("IndexMore");
            }

            ViewBag.BrandId = new SelectList(db.Brands.Where(c => c.Category.MasterCategory.Id == 13).ToList(), "Id", "Name", product.BrandId);
            ViewBag.TypeId = new SelectList(db.Types.Where(c => c.Category.MasterCategory.Id == 13).ToList(), "Id", "Name", product.TypeId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(db.Brands.Where(c => c.Category.MasterCategory.Id == 8).ToList(), "Id", "Name", product.BrandId);
            ViewBag.TypeId = new SelectList(db.Types.Where(c => c.Category.MasterCategory.Id == 8).ToList(), "Id", "Name", product.TypeId);
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Image,Price,Description,Feature,BrandId,TypeId")] Product product, HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null)
            {
                bool IsValidFormate = common.ImageValidation(ImageFile);
                if (IsValidFormate == false)
                {
                    ModelState.AddModelError("Image", "Only jpg, png, jpeg formates are allowed ");
                    ViewBag.BrandId = new SelectList(db.Brands.Where(c => c.Category.MasterCategory.Id == 8).ToList(), "Id", "Name", product.BrandId);
                    ViewBag.TypeId = new SelectList(db.Types.Where(c => c.Category.MasterCategory.Id == 8).ToList(), "Id", "Name", product.TypeId);
                    return View(product);
                }
                byte[] CurrentImage = common.ConvertImage(ImageFile);
                product.Image = CurrentImage;
            }
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandId = new SelectList(db.Brands.Where(c => c.Category.MasterCategory.Id == 8).ToList(), "Id", "Name", product.BrandId);
            ViewBag.TypeId = new SelectList(db.Types.Where(c => c.Category.MasterCategory.Id == 8).ToList(), "Id", "Name", product.TypeId);
            return View(product);
        }

        public ActionResult EditFood(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(db.Brands.Where(c =>c.Category.MasterCategory.Id == 9).ToList(), "Id", "Name", product.BrandId);
            ViewBag.TypeId = new SelectList(db.Types.Where(c =>c.Category.MasterCategory.Id == 9).ToList(), "Id", "Name", product.TypeId);
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFood([Bind(Include = "Id,Name,Image,Price,Description,Feature,BrandId,TypeId")] Product product, HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null)
            {
                bool IsValidFormate = common.ImageValidation(ImageFile);
                if (IsValidFormate == false)
                {
                    ModelState.AddModelError("Image", "Only jpg, png, jpeg formates are allowed ");
                    ViewBag.BrandId = new SelectList(db.Brands.Where(c =>c.Category.MasterCategory.Id == 9).ToList(), "Id", "Name", product.BrandId);
                    ViewBag.TypeId = new SelectList(db.Types.Where(c =>c.Category.MasterCategory.Id == 9).ToList(), "Id", "Name", product.TypeId);
                    return View(product);
                }
                byte[] CurrentImage = common.ConvertImage(ImageFile);
                product.Image = CurrentImage;
            }
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexFood");
            }
            ViewBag.BrandId = new SelectList(db.Brands.Where(c =>c.Category.MasterCategory.Id == 9).ToList(), "Id", "Name", product.BrandId);
            ViewBag.TypeId = new SelectList(db.Types.Where(c =>c.Category.MasterCategory.Id == 9).ToList(), "Id", "Name", product.TypeId);
            return View(product);
        }

        public ActionResult EditMore(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(db.Brands.Where(c => c.Category.MasterCategory.Id == 13).ToList(), "Id", "Name", product.BrandId);
            ViewBag.TypeId = new SelectList(db.Types.Where(c => c.Category.MasterCategory.Id == 13).ToList(), "Id", "Name", product.TypeId);
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMore([Bind(Include = "Id,Name,Image,Price,Description,Feature,BrandId,TypeId")] Product product, HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null)
            {
                bool IsValidFormate = common.ImageValidation(ImageFile);
                if (IsValidFormate == false)
                {
                    ModelState.AddModelError("Image", "Only jpg, png, jpeg formates are allowed ");
                    ViewBag.BrandId = new SelectList(db.Brands.Where(c => c.Category.MasterCategory.Id == 13).ToList(), "Id", "Name", product.BrandId);
                    ViewBag.TypeId = new SelectList(db.Types.Where(c => c.Category.MasterCategory.Id == 13).ToList(), "Id", "Name", product.TypeId);
                    return View(product);
                }
                byte[] CurrentImage = common.ConvertImage(ImageFile);
                product.Image = CurrentImage;
            }
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexMore");
            }
            ViewBag.BrandId = new SelectList(db.Brands.Where(c => c.Category.MasterCategory.Id == 13).ToList(), "Id", "Name", product.BrandId);
            ViewBag.TypeId = new SelectList(db.Types.Where(c => c.Category.MasterCategory.Id == 13).ToList(), "Id", "Name", product.TypeId);
            return View(product);
        }

        // GET: Products/Delete/5
        public JsonResult Delete(int id)
        {
            var ProductById = db.Products.Where(m => m.Id == id).FirstOrDefault();

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
