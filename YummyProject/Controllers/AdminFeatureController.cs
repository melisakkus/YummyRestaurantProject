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
            //if (!ModelState.IsValid)
            //{ 
            //    return View(feature);
            //}

            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var saveLocation = currentDirectory + "Pictures\\Features\\";
            var fileName = Path.Combine(saveLocation + feature.ImageFile.FileName);
            feature.ImageFile.SaveAs(fileName);
            feature.ImageUrl = "/Pictures/Features/" + feature.ImageFile.FileName;
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
            var feature = context.Features.Find(newFeature.FeatureId);

            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var saveLocation = currentDirectory + "Pictures\\Features\\";
            var fileName = Path.Combine(saveLocation + newFeature.ImageFile.FileName);
            newFeature.ImageFile.SaveAs(fileName);
            feature.ImageUrl = "/Pictures/Features/" + newFeature.ImageFile.FileName;
            feature.Title = newFeature.Title;
            feature.Description = newFeature.Description;
            feature.VideoUrl = newFeature.VideoUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}