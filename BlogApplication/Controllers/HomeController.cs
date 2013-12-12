using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogApplication.Models;
using BlogApplication.ViewModel;

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

            foreach (var item in articles)
            {
                if (item.Content.Length>250)
                {
                    item.Content = item.Content.Substring(0, 250) + " ...";
                }
                else
                {
                    item.Content = item.Content;
                }
            }

            return View("Index",articles.ToList());
        }
        public ActionResult Edit(int id)
        {
            var dbArticle = db.Articles.Find(id);
            var dbComments = from a in db.Comments
                             where a.ArticleId == dbArticle.Id
                             select a;
            CommentViewModel model = new CommentViewModel
            {
                Article = dbArticle,
                Comments = dbComments.ToList()
            };
            return View(model);
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
