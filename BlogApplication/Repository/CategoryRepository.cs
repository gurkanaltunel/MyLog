using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogApplication.Models;
using System.Web.WebPages.Html;

namespace BlogApplication.Repository
{
    public class CategoryRepository
    {
        private static readonly CategoryRepository instance = new CategoryRepository();

        public static CategoryRepository Instance
        {
            get
            {

                return instance;
            }
        }


        public IEnumerable<SelectListItem> Categories()
        {
            List<Categories> categoryList = new List<Categories>();
            BlogDbContext db = new BlogDbContext();
            var category = db.Categories.Select(x => new { Id = x.Id, CategoryName = x.CategoryName });

            foreach (var item in category)
            {
                categoryList.Add(
                    new Categories
                    {
                        Id = item.Id,
                        CategoryName = item.CategoryName
                    }
                    );
            }


            IEnumerable<SelectListItem> viewList = from k in categoryList
                                                select new SelectListItem { Value = k.Id.ToString(), Text = k.CategoryName };
            
            
            return viewList;
        }
        
    }
}