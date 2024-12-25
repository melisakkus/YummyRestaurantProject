using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    [Authorize]
    public class AdminFeatureController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var values = context.Features.ToList();
            return View(values);
        }

        public ActionResult AddFeature()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFeature(Feature feature)
        {
            if (!ModelState.IsValid)
            { 
                return View(feature);
            }

            context.Features.Add(feature);
            int result = context.SaveChanges();
            if (result == 0)
            {
                ViewBag.Error = "Değerler kaydedilirken bir hata ile karşılaşıldı.";
                return View(feature);
            }

            return RedirectToAction("Index");
        }

        public ActionResult DeleteFeature(int id)
        {
            var value = context.Features.Find(id);
            context.Features.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var feature = context.Features.Find(id);
            return View(feature);
        }

        [HttpPost]
        public ActionResult UpdateFeature(Feature newFeature)
        {
            if (!ModelState.IsValid)
            {
                return View(newFeature);
            }

            var feature = context.Features.Find(newFeature.FeatureId);
            feature.ImageUrl = newFeature.ImageUrl;
            feature.Title = newFeature.Title;
            feature.Description = newFeature.Description;
            feature.VideoUrl = newFeature.VideoUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}