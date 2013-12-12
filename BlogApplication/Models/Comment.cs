using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private DateTime? commentDate;
        [DataType(DataType.DateTime),DisplayFormat(DataFormatString="{0:dd/mm/yy}")]
        public DateTime ?CommentDate
        {
            get { return commentDate; }
            set { commentDate = value; }
        }
    }
}