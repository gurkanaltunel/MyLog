using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApplication.Models
{
    public class AdminViewModel
    {
        public AdminViewModel()
        {
            ArticleList = new List<Article>();

            CategoryList = new List<Categories>();
        }

        public List<Article> ArticleList { get; set; }

        public List<Categories> CategoryList { get; set; }
    }
}