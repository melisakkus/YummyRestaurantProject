using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class AdminChefSocialController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var socials = context.ChefSocials.ToList();
            return View(socials);
        }

        public ActionResult DeleteChefSocial(int id)
        {
            var value = context.ChefSocials.Find(id);
            context.ChefSocials.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateChefSocials(int id)
        {
            var value = context.ChefSocials.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateChefSocials(ChefSocial social)
        {
            var old = context.ChefSocials.Find(social.ChefSocialId);
            old.Url = social.Url;
            old.Icon = social.Icon;
            old.SocialMediaName= social.SocialMediaName;
            //old.ChefId = social.ChefId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddChefSocials()
        {
            List<SelectListItem> şefler = (from i in context.Chefs
                                           select new SelectListItem
                                           {
                                               Text = i.NameSurname,
                                               Value = i.ChefId.ToString()
                                           }).ToList();
            şefler.Insert(0, new SelectListItem
            {
                Text = "Lütfen Şef Seçiniz.",
                Value = "",
                Selected = true,
                Disabled = true
            });
            ViewBag.şefler = şefler;
            return View();
        }
        [HttpPost]
        public ActionResult AddChefSocials(ChefSocial newChefSocial)
        {
            context.ChefSocials.Add(newChefSocial);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}