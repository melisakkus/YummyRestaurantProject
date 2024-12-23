using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class AdminTestimonialController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var testimonials = context.Testimonials.ToList();
            return View(testimonials);
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var testimonial = context.Testimonials.Find(id);
            context.Testimonials.Remove(testimonial);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var testimonial = context.Testimonials.Find(id);
            return View(testimonial);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial newTestimonial)
        {
            var testimonial = context.Testimonials.Find(newTestimonial.TestimonialId);
            testimonial.ImageUrl = newTestimonial.ImageUrl;
            testimonial.NameSurname = newTestimonial.NameSurname;
            testimonial.Title = newTestimonial.Title;
            testimonial.Comment = newTestimonial.Comment;
            testimonial.Rating = newTestimonial.Rating;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTestimonial(Testimonial newTestimonial)
        {
            context.Testimonials.Add(newTestimonial);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}