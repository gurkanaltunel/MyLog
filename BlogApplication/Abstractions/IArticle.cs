using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApplication.Models;

namespace BlogApplication.Abstractions
{
    interface IArticle
    {
        void Add(Article article);
        void Delete(int id);
        void Update(int id);
        IQueryable<Article> GetAllArticle();
    }
}
