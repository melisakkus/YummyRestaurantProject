using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class AdminEventController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var events = context.Events.ToList();
            return View(events);
        }

        public ActionResult DeleteEvent(int id)
        {
            var value = context.Events.Find(id);
            context.Events.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateEvent(int id)
        {
            var value = context.Events.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateEvent(Event newEvent)
        {
            var oldEvent = context.Events.Find(newEvent.EventId);
            oldEvent.ImageUrl = newEvent.ImageUrl;
            oldEvent.Title = newEvent.Title;
            oldEvent.Description = newEvent.Description;
            oldEvent.Price = newEvent.Price;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddEvent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEvent(Event newEvent)
        {
            context.Events.Add(newEvent);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}