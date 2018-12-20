using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using WeatherAttack.Domain.Notifications;

namespace WeatherAttack.Domain.Entities
{
    public class EntityBase
    {
        public long Id { get; private set; }

        [NotMapped]
        public List<Notification> Notifications { get; private set; } = new List<Notification>();

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