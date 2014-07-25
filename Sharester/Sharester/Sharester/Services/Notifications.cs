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
        public List<Notification> UserNotifications { get; set; }

        public int UnreadNotifications
        {
            get
            {
                return UserNotifications.Select(x => x.State == "UnRead").Count();
            }
        }


    }
}