using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogApplication.Models;
using System.Data.Entity;
using BlogApplication.Repository;
using BlogApplication.ViewModel;
using BlogApplication.Exceptions;

namespace BlogApplication.Controllers
{
    public class AdminController : Controller
    {
 
        BlogDbContext db = new BlogDbContext();

        public ActionResult Index(string value)
        {
            const string MyValue = "asdasd198";
            if (value != MyValue)
            {
                return RedirectToAction("/Home/Index");
            }
            List<Article> list = new List<Article>();
            var articles = db.Articles.Select(x => new { Id = x.Id, Title = x.Title });
            foreach (var item in articles)
            {
                list.Add(
        new Article
        {
            Id = item.Id,
            Title = item.Title
        }
        );
            }
            return View(list);
        }

        public ActionResult Create()
        {
            CategoryViewModel model = new CategoryViewModel();
            model.Categories = CategoryRepository.Instance.Categories();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Article article = new Article
                    {
                        Title = model.Title,
                        Content = model.Content,
                        PostDate = DateTime.Now,
                        CategoryId = model.CategoryId
                    };
                    db.Articles.Add(article);
                    db.SaveChanges();
                    return RedirectToAction("Index", new { value = "asdasd198" });
                }
                else
                {
                    return View();
                }
               
            }
            catch (OperationWasFailedException)
            {

                throw new OperationWasFailedException("falan filan");
            }     
        }

        public ActionResult Edit(int id)
        {
            var article = db.Articles.Find(id);
            EditViewModel editModel = new EditViewModel();
            editModel.Article = article;
            editModel.Categories = CategoryRepository.Instance.Categories();
            return View(editModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, Article article)
        {
            try
            {
                //db.Articles.Find(id);
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { value = "asdasd198" });
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var article = db.Articles.Find(id);
            return View(article);
        }

        
        [HttpPost]
        public ActionResult Delete(int id,Article articl)
        {
            try
            {
                var article=db.Articles.Find(id);
                db.Articles.Remove(article);
                db.SaveChanges();
                return RedirectToAction("Index", new { value = "asdasd198" });
            }
            catch
            {
                return View();
            }
        }
    }
}
