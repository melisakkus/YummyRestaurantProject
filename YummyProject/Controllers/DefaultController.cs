using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;

namespace YummyProject.Controllers
{
    public class DefaultController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
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

        public PartialViewResult DefaultProduct() // eksik
        {
            var values = context.Products.ToList();
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

        public PartialViewResult DefaultChef() // sosyal medya eksik
        {
            var values = context.Chefs.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultBooking()
        {
            return PartialView();
        }

        public PartialViewResult DefaultPhotoGallery() //bazı resimler değişecek
        {
            var values = context.PhotoGalleries.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultMessage()
        {
            return PartialView();
        }

        public PartialViewResult DefaultContact() //item.mapurl çalışmıyor
        {
            var values = context.ContactInfos.ToList();
            return PartialView(values);
        }
    }
}