using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sharester.Models
{
    public class History
    {
        public int ItemId { get; set; }
        public int PostId { get; set; }
        public int OnwerId { get; set; }
        public int BuyerId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string ItemAvailability { get; set; }
    }
}