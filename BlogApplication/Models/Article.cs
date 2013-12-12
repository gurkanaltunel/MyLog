using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [DataType(DataType.MultilineText),Display(Name="Article")]
        public string Content { get; set; }
        private DateTime? postDate;
        [DataType(DataType.DateTime),DisplayFormat(DataFormatString="{0:dd/mm/yy}")]
        public DateTime? PostDate
        {
            get { return postDate; }
            set { postDate = value; }
        }
        public int CategoryId { get; set; }
    }
}