﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YummyProject.Controllers
{
    public class AdminLayoutController : Controller
    {        
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult AdminLayoutNavbar()
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutSidebar()
        {
            return PartialView();
        }
    }
}