using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sharester.Models;

namespace Sharester.Services
{
    public class Notifications
    {
        public Notifications()
        {

        }

        public int UserId { get; set; }
        public List<NotificationModel> UserNotifications { get; set; }

        public int UnreadNotifications
        {
            get
            {
                return UserNotifications.Select(x => x.State == "UnRead").Count();
            }
        }

        public static List<NotificationModel> GetNotification(Guid userId)
        {
            return new List<NotificationModel>()
            {
                new NotificationModel
                {
                    SenderName = "Pankaj",
                    ItemName = "Table",
                    CreatedOn = DateTime.Now,
                    Content = "I am interested in this item. Would you message me.",
                    State = "UnRead"
                },
                new NotificationModel
                {
                    SenderName = "Pankaj",
                    ItemName = "Bed",
                    CreatedOn = DateTime.Parse("7/28/2014"),
                    Content = "I am interested in this item. Would you message me.",
                    State = "Read"
                },
                new NotificationModel
                {
                    SenderName = "Pankaj",
                    ItemName = "Bed",
                    CreatedOn = DateTime.Parse("7/27/2014"),
                    Content = "I am interested in this item. Would you message me.",
                    State = "UnRead"
                },
                new NotificationModel
                {
                    SenderName = "Pankaj",
                    ItemName = "Bed",
                    CreatedOn = DateTime.Parse("7/27/2014"),
                    Content = "I am interested in this item. Would you message me.",
                    State = "UnRead"
                },
                new NotificationModel
                {
                    SenderName = "Pankaj",
                    ItemName = "Bed",
                    CreatedOn = DateTime.Parse("7/27/2014"),
                    Content = "I am interested in this item. Would you message me.",
                    State = "Read"
                },
                new NotificationModel
                {
                    SenderName = "Pankaj",
                    ItemName = "Bed",
                    CreatedOn = DateTime.Parse("7/26/2014"),
                    Content = "I am interested in this item. Would you message me.",
                    State = "UnRead"
                },
            };
        }
    }
}