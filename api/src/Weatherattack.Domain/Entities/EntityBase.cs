using System.Collections.Generic;
using System.Linq;
using Weatherattack.Domain.Notifications;

namespace WeatherAttack.Domain.Entities
{
    public class EntityBase
    {
        public long Id { get; private set; }

        public List<Notification> Notifications { get; private set; }

        public bool isValid => Notifications.Count == 0;

        public void AddNotification(Notification notification)
        {
            if(!Notifications.Contains(notification))
                Notifications.Add(notification);
        }

        public void AddNotification(List<Notification> notifications)
        {
            if(notifications.Count > 0)
                notifications.ForEach(n => AddNotification(n));
        }
    }
}