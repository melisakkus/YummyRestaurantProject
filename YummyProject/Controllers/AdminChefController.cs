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
            if(chef.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "Pictures\\Chefs\\";
                var fileName = Path.Combine(saveLocation + chef.ImageFile.FileName);
                chef.ImageFile.SaveAs(fileName);
                chef.ImageUrl = "/Pictures/Chefs/" + chef.ImageFile.FileName;
            }
            else
            {
                chef.ImageUrl = oldChef.ImageUrl;
            }
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
            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var saveLocation = currentDirectory + "Pictures\\Chefs\\";
            var fileName = Path.Combine(saveLocation+newChef.ImageFile.FileName);
            newChef.ImageFile.SaveAs(fileName);
            newChef.ImageUrl = "/Pictures/Chefs/" + newChef.ImageFile.FileName;
            context.Chefs.Add(newChef);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}