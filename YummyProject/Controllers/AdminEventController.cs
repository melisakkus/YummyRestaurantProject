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
            if(newEvent.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "Pictures\\Events\\";
                var fileName = Path.Combine(saveLocation + newEvent.ImageFile.FileName);
                newEvent.ImageFile.SaveAs(fileName);
                oldEvent.ImageUrl = "/Pictures/Events/" + newEvent.ImageFile.FileName;
            }

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
            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var saveLocation = currentDirectory + "Pictures\\Events\\";
            var fileName = Path.Combine(saveLocation + newEvent.ImageFile.FileName);
            newEvent.ImageFile.SaveAs(fileName);
            newEvent.ImageUrl = "/Pictures/Events/" + newEvent.ImageFile.FileName;
            context.Events.Add(newEvent);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}