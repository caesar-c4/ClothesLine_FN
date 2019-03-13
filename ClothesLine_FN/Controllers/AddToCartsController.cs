using ClothesLine_FN.Models;
using ClothesLine_FN.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ClothesLine_FN.Controllers
{
    public class AddToCartsController : Controller
    {
        bool status = false;
        ClothesLine_FN_Context db = new ClothesLine_FN_Context();

        public static List<CartProduct> cartProducts = new List<CartProduct>();
        public JsonResult AddToCart(int id,int qty)
        {
            var ProductById = db.Products.Where(m => m.Id == id).FirstOrDefault();

            CartProduct cartProduct = new CartProduct();
            cartProduct.Id = 0;
            cartProduct.Name = ProductById.Name;
            cartProduct.Qty = qty;
            cartProduct.Image = ProductById.Image;
            cartProduct.Price = ProductById.Price;
            cartProduct.UserInfo = null;
            cartProduct.UserInfoId = 0;

            cartProducts.Add(cartProduct);

            if (cartProducts != null && cartProducts.Count > 0)
            {
                status = true;
            }
            if (status == true)
            {
                return Json(1);
            }
            return Json(0);
        }
        public JsonResult AddToCartManProduct(int id, int qty)
        {
            var ProductById = db.MansProducts.Where(m => m.Id == id).FirstOrDefault();

            CartProduct cartProduct = new CartProduct();
            cartProduct.Id = 0;
            cartProduct.Name = ProductById.Name;
            cartProduct.Qty = qty;
            cartProduct.Image = ProductById.Image;
            cartProduct.Price = ProductById.Price;
            cartProduct.UserInfo = null;
            cartProduct.UserInfoId = 0;

            cartProducts.Add(cartProduct);

            if (cartProducts != null && cartProducts.Count > 0)
            {
                status = true;
            }
            if (status == true)
            {
                return Json(1);
            }
            return Json(0);
        }
        public JsonResult AddToCartWomanProduct(int id, int qty)
        {
            var ProductById = db.WomansProducts.Where(m => m.Id == id).FirstOrDefault();

            CartProduct cartProduct = new CartProduct();
            cartProduct.Id = 0;
            cartProduct.Name = ProductById.Name;
            cartProduct.Qty = qty;
            cartProduct.Image = ProductById.Image;
            cartProduct.Price = ProductById.Price;
            cartProduct.UserInfo = null;
            cartProduct.UserInfoId = 0;

            cartProducts.Add(cartProduct);

            if (cartProducts != null && cartProducts.Count > 0)
            {
                status = true;
            }
            if (status == true)
            {
                return Json(1);
            }
            return Json(0);
        }
        public JsonResult AddToCartTourPackege(int id, int qty)
        {
            var ProductById = db.TourPackeges.Where(m => m.Id == id).FirstOrDefault();

            CartProduct cartProduct = new CartProduct();
            cartProduct.Id = 0;
            cartProduct.Name = ProductById.Name;
            cartProduct.Qty = qty;
            cartProduct.Image = ProductById.Image;
            cartProduct.Price = ProductById.Cost;
            cartProduct.UserInfo = null;
            cartProduct.UserInfoId = 0;

            cartProducts.Add(cartProduct);

            if (cartProducts != null && cartProducts.Count > 0)
            {
                status = true;
            }
            if (status == true)
            {
                return Json(1);
            }
            return Json(0);
        }


        public static List<Product> products = new List<Product>();
        public static List<Product> foodProducts = new List<Product>();
        public static List<Product> moreProducts = new List<Product>();
        public static List<MansProduct> manProducts = new List<MansProduct>();
        public static List<WomansProduct> womanProducts = new List<WomansProduct>();
        public static List<TourPackege> tourPackeges = new List<TourPackege>();

        public JsonResult AddToCompare(int id)
        {
            var ProductById = db.Products.Where(m => m.Id == id).FirstOrDefault();

            if (ProductById.Brand.Category.MasterCategory.Id == 8)
            {
                if (products.Count < 3)
                {
                    products.Add(ProductById);
                    if (products != null && products.Count > 0)
                    {
                        status = true;
                    }
                    if (status == true)
                    {
                        return Json(1);
                    }
                }
            }

            if (ProductById.Brand.Category.MasterCategory.Id == 9)
            {
                if (foodProducts.Count < 3)
                {
                    foodProducts.Add(ProductById);
                    if (foodProducts != null && foodProducts.Count > 0)
                    {
                        status = true;
                    }
                    if (status == true)
                    {
                        return Json(1);
                    }
                }
            }
            if (ProductById.Brand.Category.MasterCategory.Id == 13)
            {
                if (moreProducts.Count < 3)
                {
                    moreProducts.Add(ProductById);
                    if (moreProducts != null && moreProducts.Count > 0)
                    {
                        status = true;
                    }
                    if (status == true)
                    {
                        return Json(1);
                    }
                }
            }
            return Json(0);
        }
        public JsonResult AddToCompareManProduct(int id)
        {
            var ProductById = db.MansProducts.Where(m => m.Id == id).FirstOrDefault();

            if (manProducts.Count < 3)
            {
                manProducts.Add(ProductById);

                if (manProducts != null && manProducts.Count > 0)
                {
                    status = true;
                }
                if (status == true)
                {
                    return Json(1);
                }
            }
            return Json(0);
        }
        public JsonResult AddToCompareWomanProduct(int id)
        {
            var ProductById = db.WomansProducts.Where(m => m.Id == id).FirstOrDefault();

            if (womanProducts.Count < 3)
            {
                womanProducts.Add(ProductById);

                if (womanProducts != null && womanProducts.Count > 0)
                {
                    status = true;
                }
                if (status == true)
                {
                    return Json(1);
                }
            }
            return Json(0);
        }
        public JsonResult AddToCompareTourPackege(int id)
        {
            var ProductById = db.TourPackeges.Where(m => m.Id == id).FirstOrDefault();

            if (tourPackeges.Count < 3)
            {
                tourPackeges.Add(ProductById);

                if (tourPackeges != null && tourPackeges.Count > 0)
                {
                    status = true;
                }
                if (status == true)
                {
                    return Json(1);
                }
            }
            return Json(0);
        }

        

        //--------------------------------------------
        public ActionResult ResetCompareProductList()
        {
            products = new List<Product>();
            return View("~/Views/AddToCarts/CompareProducts.cshtml", products);
        }
        public ActionResult ResetCompareFoodProductList()
        {
            foodProducts = new List<Product>();
            return View("~/Views/AddToCarts/CompareFoodProducts.cshtml", foodProducts);
        }
        public ActionResult ResetCompareManProductList()
        {
            manProducts = new List<MansProduct>();
            return View("~/Views/AddToCarts/CompareManProducts.cshtml", manProducts);

        }
        public ActionResult ResetCompareWomanProductList()
        {
            womanProducts = new List<WomansProduct>();
            return View("~/Views/AddToCarts/CompareWomanProducts.cshtml", womanProducts);
        }
        public ActionResult ResetCompareTourPackegeList()
        {
            tourPackeges = new List<TourPackege>();
            return View("~/Views/AddToCarts/CompareTourPackeges.cshtml", tourPackeges);
        }
        public ActionResult ResetCompareMoreProductList()
        {
            moreProducts = new List<Product>();
            return View("~/Views/AddToCarts/CompareMoreProducts.cshtml", moreProducts);
        }



        //---------------------------------------------
        public ActionResult CompareProducts()
        {
            var productList = products.ToList();    
            return View(productList);
        }
        public ActionResult CompareFoodProducts()
        {
            var productList = foodProducts.ToList();
            return View(productList);
        }
        public ActionResult CompareManProducts()
        {
            var productList = manProducts.ToList();
            return View(productList);
        }
        public ActionResult CompareWomanProducts()
        {
            var productList = womanProducts.ToList();
            return View(productList);
        }
        public ActionResult CompareTourPackeges()
        {
            var productList = tourPackeges.ToList();
            return View(productList);
        }
        public ActionResult CompareMoreProducts()
        {
            var productList = moreProducts.ToList();
            return View(productList);
        }

        public ActionResult ShowCartListAndBuy()
        {
            UserInfo userInfo = new UserInfo();
            userInfo.CartProducts = cartProducts;
            return View(userInfo);
        }
        [HttpPost]
        public ActionResult ShowCartListAndBuy(UserInfo userInfo)
        {
            userInfo.CartProducts = cartProducts;
            if (ModelState.IsValid)
            {
                db.UserInfos.Add(userInfo);
                int affectedRow = db.SaveChanges();
                if (affectedRow > 0)
                {
                    cartProducts = new List<CartProduct>();
                    return RedirectToAction("CartDetails", "AddToCarts", new { id = userInfo.Id });
                }
            }
            return View(userInfo);
        }

        public ActionResult CartDetails(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInfo userInfo = db.UserInfos.Find(id);
            if(userInfo == null)
            {
                return HttpNotFound();
            }
            return View(userInfo);
        }

    }
}