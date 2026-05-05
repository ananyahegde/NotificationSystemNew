namespace NotificationSystem.Models
{
    public enum NotifType
    {
        EmailNotification = 1,
        SMSNotification = 2
    }

    internal class Notification : IComparable<Notification>
    {
        public string MessageId { get; set; } = string.Empty;
        public string message { get; set; } = string.Empty;
        public DateTime sentDate { get; set; }
        public NotifType notifType { get; set; }

        public Notification() { }

        public Notification(string messageId, string message, DateTime sentDate)
        {
            this.MessageId = messageId;
            this.message = message;
            this.sentDate = sentDate;
        }

        public override string ToString()
        {
            return $"Message Id: {MessageId}" +
            $"message: {message}" +
            $"sent date: {sentDate}";
        }

        public int CompareTo(Notification? other)
        {
            return this.MessageId.CompareTo(other.MessageId);
        }
    }
}

