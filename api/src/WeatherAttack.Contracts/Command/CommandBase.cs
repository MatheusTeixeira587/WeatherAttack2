using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using WeatherAttack.Domain.Notifications;

namespace WeatherAttack.Contracts.Command
{
    public abstract class CommandBase
    {
        public CommandBase(long id) => Id = id;

        public CommandBase() { }

        public long Id { get; set; }

        public bool IsNew => Id == 0;

        public bool IsValid => Validate();

        private List<Notification> _notifications;

        public List<Notification> Notifications
        {
            get
            {
                if (_notifications is null)
                    _notifications = new List<Notification>();

                return _notifications;
            }

            private set
            {
                _notifications = value;
            }
        }

        public void AddNotification(string code)
            => AddNotification(WeatherAttackNotifications.Get(code));

        public void AddNotification(ImmutableArray<string> codeArray)
            => AddNotification(WeatherAttackNotifications.Get(codeArray));

        public void AddNotification(Notification notification)
        {
            if (!Notifications.Contains(notification))
                Notifications.Add(notification);
        }

        public void AddNotification(List<Notification> notifications)
        {
            if (notifications.Count > 0)
                Notifications.AddRange(notifications.Where(n => !Notifications.Contains(n)));
        }

        protected virtual bool Validate()
            => Notifications.Count == 0;
    }
}
