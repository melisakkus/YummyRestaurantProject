using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class AdminRestaurantSocialController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var socials = context.RestaurantSocials.ToList();
            return View(socials);
        }

        public ActionResult DeleteSocial(int id)
        {
            var value = context.RestaurantSocials.Find(id);
            context.RestaurantSocials.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSocial(int id)
        {
            var value = context.RestaurantSocials.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSocial(RestaurantSocial newSocial)
        {
            var social = context.RestaurantSocials.Find(newSocial.RestaurantSocialId);
            social.Url = newSocial.Url;
            social.SocialMediaName = newSocial.SocialMediaName;
            social.Icon = newSocial.Icon;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddSocial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSocial(RestaurantSocial newSocial)
        {
            context.RestaurantSocials.Add(newSocial);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}