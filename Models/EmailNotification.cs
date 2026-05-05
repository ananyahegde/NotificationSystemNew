namespace NotificationSystem.Models
{
    internal class EmailNotification : Notification
    {
        public EmailNotification()
        {
            notifType = NotifType.EmailNotification;
        }
    }
}
