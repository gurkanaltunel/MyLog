using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogApplication.Models;
using System.Web.WebPages.Html;

namespace BlogApplication.ViewModel
{
    public class EditViewModel
    {
        public Article Article { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}