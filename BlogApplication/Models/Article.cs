using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;

namespace BlogApplication.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        private DateTime? postDate;
        public DateTime? PostDate
        {
            get { return postDate; }
            set { postDate = value; }
        }
        public int CategoryId { get; set; }
    }
}