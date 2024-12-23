using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class AdminMessageController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var messages = context.Messages.ToList();
            return View(messages);
        }

        public ActionResult DeleteMessage(int id)
        {
            var value = context.Messages.Find(id);
            context.Messages.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateMessage(int id)
        {
            var value = context.Messages.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateMessage(Message newMessage)
        {
            var oldMessage = context.Messages.Find(newMessage.MessageId);
            oldMessage.NameSurname = newMessage.NameSurname;
            oldMessage.Email = newMessage.Email;
            oldMessage.Subject = newMessage.Subject;
            oldMessage.MessageContent = newMessage.MessageContent;
            oldMessage.IsRead = newMessage.IsRead;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult IsRead(int id)
        {
            var message = context.Messages.Find(id);
            message.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMessage(Message newMessage)
        {
            context.Messages.Add(newMessage);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}