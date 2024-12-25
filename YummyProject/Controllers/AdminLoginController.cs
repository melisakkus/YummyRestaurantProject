using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class AdminLoginController : Controller
    {
        YummyContext context = new YummyContext();
        
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(Admin model, string returnUrl)
        {
            var admin = context.Admins.FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);
            if (admin == null)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifresi hatalı.");
                return View(model);
            }
            FormsAuthentication.SetAuthCookie(admin.UserName, false);
            Session["currentUser"] = admin.UserName;
            if (returnUrl != null)
            {
                return RedirectToAction(returnUrl);
            }
            return RedirectToAction("Index","AdminDashboard");
        }
    }
}