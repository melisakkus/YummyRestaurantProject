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
    public class AdminPhotoGalleryController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var photos = context.PhotoGalleries.ToList();
            return View(photos);
        }

        public ActionResult DeletePhoto(int id)
        {
            var value = context.PhotoGalleries.Find(id);
            context.PhotoGalleries.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdatePhoto(int id)
        {
            var value = context.PhotoGalleries.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdatePhoto(PhotoGallery photo)
        {
            var oldPhoto = context.PhotoGalleries.Find(photo.PhotoGalleryId);
            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var saveLocation = currentDirectory + "Pictures\\PhotoGallery\\";
            var fileName = Path.Combine(saveLocation + photo.ImageFile.FileName);
            photo.ImageFile.SaveAs(fileName);
            oldPhoto.ImageUrl = "/Pictures/PhotoGallery/" + photo.ImageFile.FileName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddPhoto()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPhoto(PhotoGallery photo)
        {
            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var saveLocation = currentDirectory + "Pictures\\Features\\";
            var fileName = Path.Combine(saveLocation + photo.ImageFile.FileName);
            photo.ImageFile.SaveAs(fileName);
            photo.ImageUrl = "/Pictures/Features/" + photo.ImageFile.FileName;
            context.PhotoGalleries.Add(photo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}