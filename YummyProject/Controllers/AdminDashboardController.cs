using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;

namespace YummyProject.Controllers
{
    public class AdminDashboardController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            ViewBag.AperatifCount = context.Products.Count(x => x.Category.CategoryName == "Aperatifler");
            ViewBag.MaxPriceProduct = context.Products.OrderByDescending(x=>x.Price).Select(x=>x.ProductName).FirstOrDefault();
            ViewBag.MinPriceProduct = context.Products.OrderBy(x => x.Price).Select(x => x.ProductName).FirstOrDefault();
            ViewBag.AvgPrice = context.Products.Average(x => x.Price);
            return View();
        }
    }
}