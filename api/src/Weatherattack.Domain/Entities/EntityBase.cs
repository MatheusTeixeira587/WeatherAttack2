using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations.Schema;
using WeatherAttack.Domain.Notifications;

namespace WeatherAttack.Domain.Entities
{
    public abstract class EntityBase
    {
        public EntityBase() { }

        public EntityBase(long id) => Id = id;

        public long Id { get; protected set; }

        public bool IsNew => Id == 0;

        public bool IsValid => Validate();

        public List<Notification> Notifications { get; private set; } = new List<Notification>();

        public void AddNotification(string code)
            => AddNotification(WeatherAttackNotifications.Get(code));

        public void AddNotification(ImmutableArray<string> codeArray)
            => AddNotification(WeatherAttackNotifications.Get(codeArray));

        public void AddNotification(List<Notification> notifications)
            => notifications.ForEach(n => AddNotification(n));

        public void AddNotification(Notification notification)
        {
            if(!Notifications.Contains(notification))
                Notifications.Add(notification);
        }

        public bool HasNotification()
            => Notifications.Count > 0;

        protected virtual bool Validate()
            => !HasNotification();
    }
}