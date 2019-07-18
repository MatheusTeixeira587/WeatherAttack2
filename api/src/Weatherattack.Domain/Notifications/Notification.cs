namespace WeatherAttack.Domain.Notifications
{
    public class Notification
    {
        public Notification(string code, string message_EN_US, string message_PT_BR)
        {
            Code = code;
            Message = new Message() { EN_US = message_EN_US, PT_BR = message_PT_BR };
        }

        public string Code { get; private set; }

        public Message Message { get; private set; }
    }
}