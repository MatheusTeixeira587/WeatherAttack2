using System.Collections.Generic;
using weatherattack2.src.Domain.EntityValidation;

namespace weatherattack2.src.Domain.Entities
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

        public void Validate()
        {
            EntityValidator.Validate(this);
        }
    }
}