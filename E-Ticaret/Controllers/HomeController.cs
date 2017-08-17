using E_Ticaret.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_Ticaret.Models.DataModel;
using E_Ticaret.Models.Helper;
using E_Ticaret.CF;

namespace E_Ticaret.Controllers
{
    public class HomeController : Controller
    {
        Context _db = Connection.Connect();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            if ((string)Session["AdiSoyadi"] != null && (string)Session["AdiSoyadi"] != "")
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection frm)
        {
            try
            {
                string ViewUserMail = frm.Get("Email");
                string ViewUserPassword = frm.Get("Password");
                BaseUser ToLogin = _db.Users.FirstOrDefault(x => x.Email == ViewUserMail && x.Password == ViewUserPassword);
                if (ToLogin != null)
                {
                    Session.Add("AdiSoyadi", (ToLogin.Name + " " + ToLogin.SurName));
                    Session.Add("UserID", ToLogin.BaseUserID);
                    Session.Add("Authority", ToLogin.Authority);
                }
            }
            catch (Exception e)
            {
                ViewBag.Mesaj = e.Message;
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
        public ActionResult LogOut()
        {
            Session.Remove("AdiSoyadi");
            Session.Remove("UserID");
            Session.Remove("Authority");
            return RedirectToAction("Index", "Home");
        }
        public ActionResult SignUp()
        {
            UserSingUp ToSingUp = new UserSingUp();
            return View(ToSingUp);
        }
        [HttpPost]
        public ActionResult SignUp(FormCollection frm)
        {
            UserSingUp ToConfirm = new UserSingUp();
            ToConfirm.TermAndConditions = Convert.ToBoolean(frm.Get("TermAndConditions"));
            string ViewPassword = frm.Get("Password");
            string ViewPasswordAgain = frm.Get("PasswordAgain");
            string ViewName = frm.Get("Name");
            string ViewSurName = frm.Get("SurName");
            string ViewEmail = frm.Get("Email");
            BaseUser ToAdd = new BaseUser();
            ToAdd.Authority = "UnConfirmed";
            ToAdd.Email = ViewEmail;
            ToAdd.Name = ViewName;
            ToAdd.Password = ViewPassword;
            ToAdd.SurName = ViewSurName;
            ToConfirm.Name = ViewName;
            ToConfirm.SurName = ViewSurName;
            ToConfirm.Email = ViewEmail;
            if (ViewPassword != ViewPasswordAgain)
            {
                ViewBag.Mesaj = "Şifreler Uyuşmuyor";
                return View(ToConfirm);
            }
            if (!ToConfirm.TermAndConditions)
            {
                ViewBag.Mesaj = "Sisteme Kayıt Olmak İçin Kullanıcı Sözleşmesini Onaylamanız Gerekir";
                return View(ToConfirm);
            }
            _db.Users.Add(ToAdd);
            if (_db.SaveChanges() > 0)
            {
                return RedirectToAction("SuccessPage", "Home");
            }
            else
            {
                ViewBag.Mesaj = "Veri Tabanı Bağlantısı Sırasında Bir Hata Oluştu";
            }
            return View(ToConfirm);
        }
        public ActionResult SuccessPage()
        {
            return View();
        }
        public ActionResult TermAndConditions()
        {
            return View();
        }
        public ActionResult Help()
        {
            return View();
        }
    }
}