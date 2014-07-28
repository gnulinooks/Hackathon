using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Newtonsoft.Json;
using Sharester.Constants;

namespace Sharester.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Reference { get; set; }
        public List<string> Images { get; set; }

        public double Cost { get; set; }

        public ItemAvailability Availability { get; set; }
        public bool Negotiable { get; set; }
        public bool Bidding { get; set; }
        public string Category { get; set; }
        public Guid PostId { get; set; }
        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }
        public DateTime SoldOn { get; set; }
        public int SoldTo { get; set; }

        public static Item Parse(string body)
        {
            try
            {
                return JsonConvert.DeserializeObject<Item>(body);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string StringifyItem(Item item)
        {
            try
            {
                return JsonConvert.SerializeObject(item);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}