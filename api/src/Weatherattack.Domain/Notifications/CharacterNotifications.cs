using System.Collections.Generic;
using System.Linq;

namespace WeatherAttack.Domain.Notifications
{
    public static class CharacterNotifications
    {
        private static readonly IReadOnlyList<Notification> _messages = new List<Notification>
        {
            new Notification("CN-001", "Invalid character.") ,
        };

        public static Notification GetNotification(string cod)
        {
            return _messages.Select(m => m).Where(m => m.Code == cod).FirstOrDefault();
        }
    }
}
