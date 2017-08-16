using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.DataModel;
using E_Ticaret.CF;
using E_Ticaret.Models.Helper;

namespace E_Ticaret.Controllers
{
    public class AdminController : Controller
    {
        Context _db = Connection.Connect();
        public bool AuthorityCheck()
        {
            if ((string)Session["Authority"] != "Admin" && (string)Session["Authority"] != "Master")
            {
                return true;
            }
            return false;
        }
        // GET: Admin
        public ActionResult Index()
        {
            if (AuthorityCheck())
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
               
        }
        public ActionResult Settings()
        {
            if (AuthorityCheck())
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult ChangeNameSurName()
        {
            if (AuthorityCheck())
            {
                return RedirectToAction("Index","Home");
            }
            int ID = Convert.ToInt32(Session["UserID"]);
            UserNameSurname ToEdit = Converter.ToUserNameSurName(_db.Users.Where( x => x.BaseUserID ==ID).Select(x => new {x.Name, x.SurName }).FirstOrDefault());          
            return View(ToEdit);         
        }
        [HttpPost]
        public ActionResult ChangeNameSurName(FormCollection frm)
        {
            int ViewID =Convert.ToInt32(Session["UserID"]);
            string ViewName = frm.Get("Name");
            string ViewSurName = frm.Get("SurName");
            BaseUser ToEdit = _db.Users.FirstOrDefault(x => x.BaseUserID == ViewID);
            ToEdit.Name = ViewName;
            ToEdit.SurName = ViewSurName;
            if (_db.SaveChanges() > 0)
            {
                Session["AdiSoyadi"] = ToEdit.Name + " " + ToEdit.SurName;
            }
            return RedirectToAction("SuccessPage", "Admin");
        }
        public ActionResult ChangePassword()
        {
            UserPassword ToEdit = new UserPassword();
            return View(ToEdit);
        }
        [HttpPost]
        public ActionResult ChangePassword(FormCollection frm)
        {
            int UserID = Convert.ToInt32(Session["UserID"]);
            string ViewOldPassword = frm.Get("OldPassword");
            var Query = _db.Users.Where(x => x.BaseUserID == UserID && x.Password == ViewOldPassword);
            if (Query.Count() > 0)
            {
                string ViewNewPassword = frm.Get("NewPassword");
                string ViewNewPasswordAgain = frm.Get("NewPasswordAgain");
                if (ViewNewPassword == ViewNewPasswordAgain)
                {
                    BaseUser ToEdit = _db.Users.FirstOrDefault(x => x.BaseUserID == UserID);
                    ToEdit.Password = ViewNewPassword;
                    if (_db.SaveChanges() > 0)
                    {
                        return RedirectToAction("SuccessPage", "Admin");
                    }
                    else
                    {
                        ViewBag.Mesaj = "Eski Şifreniz Ve Yeni Şifreniz Aynı Olmamalı";
                    }
                }
                else
                {
                    ViewBag.Mesaj = "Yeni Şifreleriniz Uyuşmuyor";
                }
            }
            else
            {
                ViewBag.Mesaj = "Eski Şifreniz Hatalı";
            }
           return View();
        }
        public ActionResult SuccessPage()
        {
            return View();
        }
       
        
    }
}