using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class AdminController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var admins = context.Admins.FirstOrDefault();
            return View(admins);
        }
    }
}