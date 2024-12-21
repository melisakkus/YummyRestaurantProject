 using System;
using System.Collections.Generic;
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
            about.ImageUrl = newAbout.ImageUrl;
            about.ImageUrl2 = newAbout.ImageUrl2;
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