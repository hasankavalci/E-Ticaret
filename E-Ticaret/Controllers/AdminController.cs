﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Ticaret.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult GirisDenetle(ControllerContext controllerContext,ViewResult viewResult)
        {
            if ((string)Session["Authority"] != "Admin" && (string)Session["Authority"] != "Master")
            {
                return RedirectToAction("Index", "Home");
            }
            return viewResult;

        }

        // GET: Admin
        public ActionResult Index()
        {
            GirisDenetle(ControllerContext,View()).ExecuteResult(ControllerContext);
            return View();
        }

        
    }
}