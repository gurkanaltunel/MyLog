using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApplication.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string CommentOwner { get; set; }
        public string Comments { get; set; }
        public DateTime ?CommentDate { get; set; }
    }
}