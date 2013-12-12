using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogApplication.Models;

namespace BlogApplication.Controllers
{
    public class HomeController : Controller
    {
        private BlogDbContext db = new BlogDbContext();

        public ActionResult Index()
        {
            var articles = from a in db.Articles
                           orderby a.PostDate descending
                           select a;

            return View("Index",articles.ToList());
        }
        public ActionResult Edit(int id)
        {
            var dbArticle = db.Articles.Find(id);
            var dbComments = from a in db.Comments
                             where a.ArticleId == dbArticle.Id
                             select a;
            ViewBag.Comments = dbComments;
            return View(dbArticle);
        }
        public ActionResult AddComment(string jsonData,string id,string commentOwner)
        {
            var comment = new Comment
            {
                ArticleId =int.Parse(id),
                Comments = jsonData,
                CommentDate = DateTime.Now,
                CommentOwner = commentOwner
            };
            db.Comments.Add(comment);
            db.SaveChanges();

            return RedirectToAction("Edit", new { id = id });
        }
        public ActionResult ArticleCategory(int id)
        {
            var categoryArticles = from a in db.Articles
                                   where a.CategoryId == id
                                   orderby a.PostDate descending
                                   select a;

            return PartialView("CategoryById", categoryArticles.ToList());
        }
    }
}
