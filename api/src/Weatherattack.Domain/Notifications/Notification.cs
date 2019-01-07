namespace WeatherAttack.Domain.Notifications
{
    public class Notification
    {
        public Notification(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public string Code { get; private set; }

        public string Message { get; private set; }
    }
}