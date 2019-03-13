using ClothesLine_FN.Bll;
using ClothesLine_FN.Models.ViewModel;
using ClothesLine_FN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothesLine_FN.Models.Context;
using System.Data.Entity;

namespace ClothesLine_FN.Controllers
{
    public class AccountsController : Controller
    {
        ClothesLine_FN_Context Db = new ClothesLine_FN_Context();
        Common common = new Common();
        bool status=false;
        bool isExist = false;
        // GET: Accounts
        //public ActionResult Index()
        //{
        //    return View();
        //}
        // GET: Accounts/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LoginVm loginVm)
        {
            if (ModelState.IsValid)
            {
                var account = Db.Accounts.Where(c => c.EmailOrPhone == loginVm.EmailOrPhone && c.Password == loginVm.Pass).FirstOrDefault();
                if (account != null)
                {           
                        return RedirectToAction("Index", "Home");             
                }
                else
                {
                    ViewBag.Message = "Sorry your email or password is incorrect";
                }
            }
            return View(loginVm);
        }
        //// GET: Accounts/Registration
        //public ActionResult Registration()
        //{
        //    return View();
        //}
        //// POST: Accounts/Registration
        //[HttpPost]
        //public ActionResult Registration(RegistrationVm registrationVm)
        //{
        //    if (registrationVm.Pass!=registrationVm.RePass)
        //    {
        //        ModelState.AddModelError("RePass", "পাসওয়ার্ডটি আনুরুপ হয়নি");
        //        return View(registrationVm);
        //    }

        //    if (ModelState.IsValid)
        //    {

        //        isExist = accountBll.CheckExistance(registrationVm);
        //        if(isExist==false)
        //        {
        //            account = accountBll.Registration(registrationVm);
        //            if (account!=null)
        //            {
        //                if (registrationVm.Occupation == "কৃষি কর্মকর্তা")
        //                {
        //                    Session["AccountId"] = account.AccountId;
        //                    return RedirectToAction("Create", "CropCategories");
        //                }
        //                if (registrationVm.Occupation == "কৃষক")
        //                {
        //                    Session["AccountId"] = account.AccountId;
        //                    return RedirectToAction("ListFarmer", "Diseases");
        //                }
        //            }
        //            else
        //            {
        //                ViewBag.Message = "দুঃখিত আপনার একাউন্টটি রেজিসট্রেসন হয়নি";
        //            }
        //        }
        //        else
        //        {
        //            ViewBag.Message = "দুঃখিত! অনুরূপ ইমেইল অথবা ফোন নম্বরের একাউন্ট রয়েছে";
        //        }
        //    }
        //    return View(registrationVm);
        //}

        public ActionResult List()
        {
            List<Account> Accounts = Db.Accounts.ToList();
            return View(Accounts);
        }

        //// GET: Crops/Details/5
        ////public ActionResult Details(int id)
        ////{
        ////    return View();
        ////}

        // GET: Crops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Crops/Create
        [HttpPost]
        public ActionResult Create(Account account, HttpPostedFileBase ImageFile)
        {
            if (ImageFile == null)
            {
                ModelState.AddModelError("Image", "Please upload and image");
                return View(account);
            }

            bool IsValidFormat = common.ImageValidation(ImageFile);


            if (IsValidFormat == false)
            {
                ModelState.AddModelError("Image", "Only jpg ,png,joeg file is suported");
                return View(account);
            }
            byte[] convertedImage = common.ConvertImage(ImageFile);
            account.Image = convertedImage;

            if (ModelState.IsValid)
            {
                // status =Db.Accounts.
                Db.Accounts.Add(account);
                int affectedRow= Db.SaveChanges();
                if (affectedRow>0)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    ViewBag.Message = "Sorry information is not added";
                }
            }

            return View(account);
        }

        // GET: Crops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error", "Home");
            }
            Account account =Db.Accounts.Where(c=>c.AccountId==id).FirstOrDefault();
            if (account == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(account);
        }

        // POST: Crops/Edit/5
        [HttpPost]
        public ActionResult Edit(Account account, HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null)
            {
                bool IsValidFormate = common.ImageValidation(ImageFile);
                if (IsValidFormate == false)
                {
                    ModelState.AddModelError("Image", "Only jpg, png, jpeg formate is suported");
                    return View(account);
                }
                byte[] CurrentImage = common.ConvertImage(ImageFile);
                account.Image = CurrentImage;
            }
            if (ModelState.IsValid)
            {
                    Db.Entry(account).State = EntityState.Modified;
                    Db.SaveChanges();
                    return RedirectToAction("List");
            }
            return View(account);
        }

        // GET: Crops/Delete/5
        public JsonResult Delete(int id)
        {
            Account account = Db.Accounts.Where(c => c.AccountId == id).FirstOrDefault();

            if (account != null)
            {
                Db.Entry(account).State = EntityState.Deleted;
                int affectedRow = Db.SaveChanges();

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
    }
}
