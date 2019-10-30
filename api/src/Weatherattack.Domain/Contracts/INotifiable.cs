using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using WeatherAttack.Domain.Notifications;

namespace WeatherAttack.Domain.Contracts
{
    public interface INotifiable
    {
        void AddNotification(string code);

        void AddNotification(ImmutableArray<string> codeArray);

        public void AddNotification(IEnumerable<Notification> notifications);

        public void AddNotification(Notification notification);

        public bool HasNotification();
    }
}
