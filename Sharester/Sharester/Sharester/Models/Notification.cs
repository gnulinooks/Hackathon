using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sharester.Models
{
    public class NotificationModel
    {
        public int Id { get; set; }
        public Guid Sender { get; set; }
        public string SenderName { get; set; }
        public Guid Receiver { get; set; }
        public Guid PostId { get; set; }
        public Guid ItemId { get; set; }
        public string ItemName { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public string State { get; set; }
    }
}