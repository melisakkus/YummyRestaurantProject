using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class AdminBookingController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var bookings = context.Bookings.ToList();
            return View(bookings);
        }

        public ActionResult IsApproved(int id)
        {
            var booking = context.Bookings.Find(id);
            booking.IsApproved = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteBooking(int id)
        {
            var value = context.Bookings.Find(id);
            context.Bookings.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateBooking(int id)
        {
            var value = context.Bookings.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateBooking(Booking newBooking)
        {
            var oldBooking = context.Bookings.Find(newBooking.BookingId);
            oldBooking.Name = newBooking.Name;
            oldBooking.Email = newBooking.Email;
            oldBooking.PhoneNumber = newBooking.PhoneNumber;
            oldBooking.BookingDate = newBooking.BookingDate;
            oldBooking.PersonCount = newBooking.PersonCount;
            oldBooking.MessageContent = newBooking.MessageContent;
            oldBooking.IsApproved = newBooking.IsApproved;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddBooking()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBooking(Booking newBooking)
        {
            context.Bookings.Add(newBooking);
            context.SaveChanges();
            return View(newBooking);
        }
       

    }
}