namespace NotificationSystem.Models
{
    internal class SMSNotification : Notification
    {
        public SMSNotification()
        {
            notifType = NotifType.SMSNotification;
        }
    }
}
