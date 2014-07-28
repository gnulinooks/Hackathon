using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sharester.Models
{
    public class SearchModels
    {
        [DataType(DataType.Text)]
        [Display(Name = "Search Query")]
        public string SearchQuery { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Category")]
        public string Category { get; set; }
    }
}