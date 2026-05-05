namespace NotificationSystem.Models
{
    public enum NotifType
    {
        EmailNotification = 1,
        SMSNotification = 2
    }

    internal class Notification
    {
        public string message { get; set; } = string.Empty;
        public DateTime sentDate { get; set; }
        public NotifType notifType { get; set; }

        public Notification() { }

        public Notification(string message, DateTime sentDate)
        {
            this.message = message;
            this.sentDate = sentDate;
        }

        public override string ToString()
        {
            return $"message: {message}" +
                   $"sent date: {sentDate}";
        }
    }
}

