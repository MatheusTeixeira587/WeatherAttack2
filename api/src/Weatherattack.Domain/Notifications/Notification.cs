using WeatherAttack.Domain.Notifications.Enums;

namespace WeatherAttack.Domain.Notifications
{
    public sealed class Notification
    {
         public Notification(string code, Message message)
        {
            Code = code;
            Message = message;
        }
        public Notification(string code, string message_En_us, string message_Pt_br) : this(code, new Message { En_us = message_En_us, Pt_br = message_Pt_br }) 
        {
            
        }

        public Notification(NotificationType type, string code, Message message) : this(code, message)
        {
            Type = type;
        }

        public NotificationType Type { get; } = NotificationType.Error;

        public string Code { get; private set; }

        public Message Message { get; private set; }
    }
}