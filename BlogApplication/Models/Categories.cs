using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogApplication.Models
{
    public class Categories
    {
        public int Id { get; set; }
        [Display(Name="Category Name"),Required]
        public string CategoryName { get; set; }
        [Display(Name="Category Discription"),DataType(DataType.MultilineText)]
        public string CategoryDiscription { get; set; }
        private DateTime? createDate;
        [DataType(DataType.DateTime),DisplayFormat(DataFormatString="{0:dd/mm/yy}")]
        public DateTime? CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }
    }
}