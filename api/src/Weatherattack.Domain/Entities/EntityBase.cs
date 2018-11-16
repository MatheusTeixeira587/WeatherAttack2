using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace weatherattack2.src.Domain.Entities
{
    public class EntityBase
    {
        public long Id { get; private set; }

        public List<Notification> Notifications { get; private set; }

        public bool isValid => Notifications.Count == 0;

        public void AddNotification(Notification notification)
        {
            Notifications.Add(notification);
        }
    }
}