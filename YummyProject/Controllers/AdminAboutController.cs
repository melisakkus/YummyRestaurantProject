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
    public class AdminAboutController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var abouts = context.Abouts.ToList();
            return View(abouts);
        }

        public ActionResult DeleteAbout(int id)
        {
            var about = context.Abouts.Find(id);
            context.Abouts.Remove(about);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About newAbout)
        {

            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var saveLocation = currentDirectory + "Pictures\\Abouts\\";
            var fileName = Path.Combine(saveLocation + newAbout.ImageFile.FileName);
            newAbout.ImageFile.SaveAs(fileName);
            newAbout.ImageUrl = "/Pictures/Abouts/" + newAbout.ImageFile.FileName;

            var fileName2 = Path.Combine(saveLocation + newAbout.ImageFile2.FileName);
            newAbout.ImageFile2.SaveAs(fileName2);
            newAbout.ImageUrl2 = "/Pictures/Abouts/" + newAbout.ImageFile2.FileName;

            context.Abouts.Add(newAbout);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var values = context.Abouts.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateAbout(About newAbout)
        {
            var about = context.Abouts.Find(newAbout.AboutId);
            if (newAbout.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "Pictures\\Abouts\\";
                var fileName = Path.Combine(saveLocation + newAbout.ImageFile.FileName);
                newAbout.ImageFile.SaveAs(fileName);
                newAbout.ImageUrl = "/Pictures/Abouts/" + newAbout.ImageFile.FileName;
                about.ImageUrl = newAbout.ImageUrl;
            }

            if (newAbout.ImageFile2 != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "Pictures\\Abouts\\";
                var fileName = Path.Combine(saveLocation + newAbout.ImageFile2.FileName);
                newAbout.ImageFile2.SaveAs(fileName);
                newAbout.ImageUrl2 = "/Pictures/Abouts/" + newAbout.ImageFile2.FileName;
                about.ImageUrl2 = newAbout.ImageUrl2;

            }
            about.Item1 = newAbout.Item1;
            about.Item2 = newAbout.Item2;
            about.Item3 = newAbout.Item3;
            about.Description = newAbout.Description;
            about.VideoUrl = newAbout.VideoUrl;
            about.PhoneNumber = newAbout.PhoneNumber;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}