using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var numberofProducts = context.Products.Count().ToString();
            ViewBag.NumberofProducts = numberofProducts;
            var numberofChefs = context.Chefs.Count();
            ViewBag.NumberofChefs = numberofChefs;
            var numberofEvents = context.Events.Count();
            ViewBag.NumberofEvents = numberofEvents;
            var numberofTestimonial = context.Testimonials.Count();
            ViewBag.NumberofTestimonial = numberofTestimonial;
            return View();
        }

        public PartialViewResult DefaultFeature()
        {
            var values = context.Features.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultAbout()
        {
            var values = context.Abouts.ToList();   
            return PartialView(values);
        }

        public PartialViewResult DefaultService()
        {
            var values = context.Services.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultProduct() 
        {
            var values = context.Categories.ToList(); 
            return PartialView(values);
        }


        public PartialViewResult DefaultTestimonial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultEvent()
        {
            var values = context.Events.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultChef() 
        {
            var values = context.Chefs.OrderByDescending(x=>x.ChefId).ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultBooking()
        {
            return PartialView();
        }

        [HttpPost]
        public string DefaultAddBooking(Booking booking)
        {
            context.Bookings.Add(booking);
            context.SaveChanges();
            return "Başarıyla tamamlandı";
        }

        public PartialViewResult DefaultPhotoGallery()
        {
            var values = context.PhotoGalleries.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultMessage()
        {
            return PartialView();
        }

        public ActionResult DefaultSendMessage(Message message)
        {
            context.Messages.Add(message);
            context.SaveChanges();
            return View("Index");
        }

        public PartialViewResult DefaultContact() 
        {
            var values = context.ContactInfos.ToList();
            return PartialView(values);
        }
    }
}