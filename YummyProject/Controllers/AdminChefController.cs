using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class AdminChefController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var chefs = context.Chefs.ToList();
            return View(chefs);
        }

        public ActionResult DeleteChef(int id)
        {
            var value = context.Chefs.Find(id);
            context.Chefs.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateChef(int id)
        {
            var value = context.Chefs.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateChef(Chef chef)
        {
            var oldChef = context.Chefs.Find(chef.ChefId);
            oldChef.ImageUrl = chef.ImageUrl;
            oldChef.NameSurname = chef.NameSurname;
            oldChef.Title = chef.Title;
            oldChef.Description = chef.Description;
            oldChef.ChefSocials = chef.ChefSocials;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddChef()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddChef(Chef newChef)
        {
            context.Chefs.Add(newChef);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}