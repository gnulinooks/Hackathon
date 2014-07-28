using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Newtonsoft.Json;

namespace Sharester.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public bool Alive { get; set; }
        public int NoOfItems { get; set; }
        public List<Item> Items { get; set; }

        public int NoOfSoldItems { get; set; }

        public DateTime CreateOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public static Post Parser(string body)
        {
            try
            {
                Post post = JsonConvert.DeserializeObject<Post>(body);
                return post;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}