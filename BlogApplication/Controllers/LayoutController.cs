using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogApplication.Models;

namespace BlogApplication.Controllers
{
    public class LayoutController : Controller
    {
        BlogDbContext db = new BlogDbContext();

        public ActionResult Categories()
        {
            var categories = db.Categories.ToList();
            return View(categories);
        }

    }
}
