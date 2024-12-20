using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;

namespace YummyProject.Controllers
{
    public class UILayoutController : Controller
    {
        YummyContext context = new YummyContext();  
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult UILayoutFooter()
        {
            var value = context.ContactInfos.ToList();
            return PartialView(value);
        }

        public PartialViewResult UILayoutFooterSocial()
        {
            var value = context.RestaurantSocials.ToList();
            return PartialView(value);
        }
    }
}