using NotificationSystem.Interfaces;
using NotificationSystem.Models;
using NotificationSystem.Repositories;
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
            List<User> users = new UserService().ReadAllUsers();

            if (users == null)
            {
                Console.WriteLine("No users found.");
                return;
            }

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



        // ----------------------
        // CRUD Operations
        // ----------------------
        // Note: As it is an extension of already existing project, I did not modify existing code. 
        // Everything above this line remains untouched.

        public void CreateNotification()
        {
            Notification notification = TakeNotificationDetails();
            Notification createdNotification = _repo.Create(notification);
            Console.WriteLine($"Notification Created.\nNotificationId: {createdNotification.MessageId}\nMessage: {createdNotification.message}\nDate: {createdNotification.sentDate}\nType: {createdNotification.notifType}");
        }

        private NotificationRepository _repo = new NotificationRepository();

        public void NotificationMenu()
        {
            while (true)
            {
                Console.WriteLine("\n\n Please enter what you wish to do.");
                Console.WriteLine("1. Create Notification (This does not send the notification to any user)");
                Console.WriteLine("2. Get Notification");
                Console.WriteLine("3. Get All Notifications");
                Console.WriteLine("4. Update Notification");
                Console.WriteLine("5. Delete Notification");
                Console.WriteLine("6. Go Back");
                Console.WriteLine("\n\n");
                int.TryParse(Console.ReadLine(), out int choice);
                switch (choice)
                {
                    case 1: CreateNotification(); break;
                    case 2: ReadNotification(); break;
                    case 3: ReadAllNotifications(); break;
                    case 4: UpdateNotification(); break;
                    case 5: DeleteNotification(); break;
                    case 6: return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }
        public void ReadAllNotifications()
        {
            List<Notification>? notifications = _repo.ReadAll();
            if (notifications == null)
            {
                Console.WriteLine("No notifications found.");
                return;
            }
            foreach (var n in notifications)
                Console.WriteLine($"NotificationId: {n.MessageId}\nMessage: {n.message}\nDate: {n.sentDate}\nType: {n.notifType}\n");
        }

        public void ReadNotification()
        {
            Console.WriteLine("Enter the NotificationId: ");
            string id = Console.ReadLine() ?? "";
            Notification? notification = _repo.Read(id);
            if (notification == null)
            {
                Console.WriteLine("Notification not found.");
                return;
            }
            Console.WriteLine($"NotificationId: {notification.MessageId}\nMessage: {notification.message}\nDate: {notification.sentDate}\nType: {notification.notifType}");
        }

        public void UpdateNotification()
        {
            Console.WriteLine("Enter the NotificationId to update: ");
            string id = Console.ReadLine() ?? "";
            Notification notification = TakeNotificationDetails();
            Notification? updatedNotification = _repo.Update(notification, id);
            if (updatedNotification == null)
            {
                Console.WriteLine("Notification not found.");
                return;
            }
            Console.WriteLine($"Notification Updated.\nNotificationId: {updatedNotification.MessageId}\nMessage: {updatedNotification.message}\nDate: {updatedNotification.sentDate}\nType: {updatedNotification.notifType}");
        }

        public void DeleteNotification()
        {
            Console.WriteLine("Enter the NotificationId to delete: ");
            string id = Console.ReadLine() ?? "";
            Notification? deletedNotification = _repo.Delete(id);
            if (deletedNotification == null)
            {
                Console.WriteLine("Notification not found.");
                return;
            }
            Console.WriteLine($"Notification Deleted.\nNotificationId: {deletedNotification.MessageId}\nMessage: {deletedNotification.message}\nDate: {deletedNotification.sentDate}\nType: {deletedNotification.notifType}");
        }
    }
}
