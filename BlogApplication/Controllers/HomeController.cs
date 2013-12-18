using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogApplication.Models;
using BlogApplication.ViewModel;
using System.Web.Caching;

namespace BlogApplication.Controllers
{
    public class HomeController : Controller
    {
        private BlogDbContext db = new BlogDbContext();

        public ActionResult Index()
        {
            List<Article> articleList = new List<Article>();
            if (HttpRuntime.Cache["Articles"]!=null)
            {
                var articles = HttpRuntime.Cache["Articles"] as List<Article>;
                return View(articles);
            }
            else
            {
                var articles = from a in db.Articles
                               orderby a.PostDate descending
                               select a;
                foreach (var item in articles)
                {
                    if (item.Content.Length > 250)
                    {
                        item.Content = item.Content.Substring(0, 250) + " ...";
                    }
                    else
                    {
                        item.Content = item.Content;
                    }
            }
                articleList = articles.ToList();
                HttpRuntime.Cache.Insert("Articles", articleList, null, DateTime.Now.AddMinutes(30), Cache.NoSlidingExpiration);
                return View(articleList);
            }
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
        public ActionResult ReturnProjects()
        {
            return PartialView("ReturnProjects");
        }
    }
}
