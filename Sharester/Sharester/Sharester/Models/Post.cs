using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sharester.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public bool Alive { get; set; }
        public int NoOfItems { get; set; }
        public List<Item> Items { get; set; }

        public int NoOfSoldItems { get; set; }

        public DateTime CreateOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}