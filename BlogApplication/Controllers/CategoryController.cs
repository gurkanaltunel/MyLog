using BlogApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApplication.Controllers
{
    public class CategoryController : Controller
    {
        BlogDbContext db = new BlogDbContext();

        public ActionResult Index()
        {
            var currentCategories = db.Categories.ToList();
            return View(currentCategories);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Categories category)
        {
            category.CreateDate = DateTime.Now;
            db.Categories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
        public ActionResult Edit(int id)
        {
            var categoryById = db.Categories.Find(id);
            return View(categoryById);
        }
        [HttpPost]
        public ActionResult Edit(Categories category)
        {
            
            var model = db.Categories.Find(category.Id);
            category.CreateDate = model.CreateDate;
            if (model!=null)
            {
                db.Entry(model).CurrentValues.SetValues(category);
            }
            return RedirectToAction("Index", "Category");
        }
        public ActionResult Delete(int id)
        {
            var model = db.Categories.Find(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(Categories category)
        {
            var model = db.Categories.Find(category.Id);
            db.Categories.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
    }
}
