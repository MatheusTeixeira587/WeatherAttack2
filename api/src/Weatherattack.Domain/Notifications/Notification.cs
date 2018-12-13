namespace Weatherattack.Domain.Notifications
{
    public class Notification
    {

        public Notification(string code, string message)
        {
            this.Code = code;
            this.Message = message;
        }

        public string Code { get; private set; }

        public string Message { get; private set; }
    }
}