using NotificationSystem.Interfaces;
using NotificationSystem.Models;

namespace NotificationSystem.Services
{
    internal class NotificationService : INotificationInteract
    {
        static List<Notification> notifications = new List<Notification>();

        public void SendNotification()
        {
            Notification notification = TakeNotificationDetails();
            SendNotificationToUser(notification);
        }

        private Notification TakeNotificationDetails()
        {
            int typeChoice;
            Console.WriteLine("Please select the type of notification. 1 for Email, 2 for SMS.");
            while (!int.TryParse(Console.ReadLine(), out typeChoice) || typeChoice < 1 || typeChoice > 2)
                Console.WriteLine("Invalid entry. Please try again.");
            Notification notification = typeChoice == 1 ? new EmailNotification() : new SMSNotification();

            Console.WriteLine("Please enter the message.");
            notification.message = Console.ReadLine() ?? "";

            notification.sentDate = DateTime.Today;

            return notification;
        }

        private void SendNotificationToUser(Notification notification)
        {
            Console.WriteLine("Enter the name of the user to send to.");
            string name = Console.ReadLine() ?? "";

            List<User> users = new UserService().GetUsers();
            User? user = null;

            foreach (var u in users)
            {
                if (u.Name == name)
                {
                    user = u;
                    break;
                }
            }

            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Name: {user.Name}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine($"Phone: {user.Phone}");
            Console.WriteLine($"Message: {notification.message}");
            Console.WriteLine($"Sent Date: {notification.sentDate}");
            Console.WriteLine($"Sent Via: {notification.notifType}");
            Console.WriteLine("-----------------------------");
        }

    }
}
