using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sharester.Models
{
    public class History
    {
        public Guid ItemId { get; set; }
        public Guid PostId { get; set; }
        public Guid OnwerId { get; set; }
        public Guid BuyerId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string ItemAvailability { get; set; }
    }
}