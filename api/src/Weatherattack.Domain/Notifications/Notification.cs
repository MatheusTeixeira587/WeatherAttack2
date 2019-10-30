using WeatherAttack.Domain.Notifications.Enums;

namespace WeatherAttack.Domain.Notifications
{
    public sealed class Notification
    {
        public Notification(string code, string message_En_us, string message_Pt_br)
        {
            Code = code;
            Message = new Message { En_us = message_En_us, Pt_br = message_Pt_br };
        }

        public Notification(NotificationType type, string code, Message message)
        {
            Type = type;
            Code = code;
            Message = message;
        }

        public NotificationType Type { get; } = NotificationType.Error;

        public string Code { get; private set; }

        public Message Message { get; private set; }
    }
}