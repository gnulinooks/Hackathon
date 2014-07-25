using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sharester.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int Sender { get; set; }
        public int Receiver { get; set; }
        public int PostId { get; set; }
        public int ItemId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public string State { get; set; }
    }
}