using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

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

        //CategoryProduct categoryProduct = new CategoryProduct();
        //public PartialViewResult DefaultProduct() // eksik
        //{
        //    categoryProduct.ReachProductsC1 = context.Products.Where(x=>x.CategoryId == 1).ToList();
        //    categoryProduct.ReachProductsC2 = context.Products.Where(x => x.CategoryId == 2).ToList();
        //    categoryProduct.ReachProductsC3 = context.Products.Where(x => x.CategoryId == 3).ToList();
        //    categoryProduct.ReachProductsC4 = context.Products.Where(x => x.CategoryId == 4).ToList();

        //    categoryProduct.ReachCategories = context.Categories.ToList();
        //    return PartialView(categoryProduct);
        //}

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

        public PartialViewResult DefaultPhotoGallery()
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