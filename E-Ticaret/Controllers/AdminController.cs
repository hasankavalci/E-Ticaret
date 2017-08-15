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
            UserNameSurname ToEdit = new UserNameSurname();
            ToEdit.ID = Convert.ToInt32(Session["UserID"]);
            var ToEditFromDB = _db.Users.Where(x => x.BaseUserID == ToEdit.ID).Select(x => new { x.Name, x.SurName }).FirstOrDefault();
            ToEdit.Name = ToEditFromDB.Name;
            ToEdit.SurName = ToEditFromDB.SurName;
            return View(ToEdit);
          
        }
       
        
    }
}