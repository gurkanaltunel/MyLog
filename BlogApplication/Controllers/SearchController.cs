using BlogApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace BlogApplication.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Search(string SearchWord)
        {
            List<Article> articles = null;

            if (HttpRuntime.Cache["Articles"]!=null)
            {
                articles = HttpRuntime.Cache["Articles"] as List<Article>;
            }
            var article = from a in articles
                          //where SqlMethods.Like(a.Title, "%" + SearchWord + "%")
                          where a.Title.Contains(SearchWord)
                          select a;

            return PartialView("Search",article.ToList());
        }
    }
}