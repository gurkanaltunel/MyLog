using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;

namespace BlogApplication.ViewModel
{
    public class CategoryViewModel
    {
        [Required(ErrorMessage="Title not Empty")]
        public string Title { get; set; }
        [DataType(DataType.MultilineText),Required(ErrorMessage="Content not empty"),Display(Name="Article")]
        public string Content { get; set; }
        [Required(ErrorMessage="Content must have one category")]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories;
    }
}