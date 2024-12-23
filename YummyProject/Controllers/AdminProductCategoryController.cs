using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class AdminProductCategoryController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var categories = context.Categories.ToList();
            return View(categories);
        }

        public ActionResult DeleteCategory(int id)
        {
            var value = context.Categories.Find(id);
            context.Categories.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = context.Categories.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCategoryt(Category newCategory)
        {
            var old = context.Categories.Find(newCategory.CategoryId);
            old.CategoryName = newCategory.CategoryName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category newCategory)
        {
            context.Categories.Add(newCategory);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}