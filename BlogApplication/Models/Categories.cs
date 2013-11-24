using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApplication.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDiscription { get; set; }
        private DateTime? createDate;
        public DateTime? CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }
    }
}