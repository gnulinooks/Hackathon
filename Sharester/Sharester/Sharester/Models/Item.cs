using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sharester.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Reference { get; set; }
        public string[] Images { get; set; }

        public double Cost { get; set; }

        public string Availability { get; set; }
        public bool Negotiable { get; set; }
        public bool Bidding { get; set; }
        public string CategoryType { get; set; }
        public int PostId { get; set; }
        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
        public DateTime SoldOn { get; set; }
        public int SoldTo { get; set; }
    }
}