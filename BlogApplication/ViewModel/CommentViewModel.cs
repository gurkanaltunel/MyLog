using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogApplication.Models;

namespace BlogApplication.ViewModel
{
    public class CommentViewModel
    {
        public Article Article { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}