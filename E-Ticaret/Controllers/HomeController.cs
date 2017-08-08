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
    }
}