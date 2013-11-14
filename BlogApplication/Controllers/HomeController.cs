﻿using System;
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
            var articles = db.Articles.ToList();
            return View(articles);
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
    }
}
