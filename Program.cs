using NotificationSystem.Interfaces;
using NotificationSystem.Services;

namespace NotificationSystem
{
    internal class Program
    {
        INotificationInteract notificationInteract;
        public Program()
        {
            notificationInteract = new NotificationService();
        }

        internal void DoCrudOperations()
        {
            UserService userService = new UserService();
            NotificationService notificationService = new NotificationService();

            while (true)
            {
                Console.WriteLine("Please enter what you wish to do.");
                Console.WriteLine("\n1. User Management");
                Console.WriteLine("2. Notification Management");
                Console.WriteLine("3. Exit");

                int.TryParse(Console.ReadLine(), out int choice);

                switch (choice)
                {
                    case 1:
                        userService.UserMenu();
                        break;
                    case 2:
                        notificationService.NotificationMenu();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        internal void SendNotification()
        {
            UserService userService = new UserService();

            while (true)
            {
                Console.WriteLine("1. Send Notification");
                Console.WriteLine("2. Do Crud Operations");
                Console.WriteLine("3. Exit");

                int.TryParse(Console.ReadLine(), out int choice);

                switch (choice)
                {
                    case 1:
                        notificationInteract.SendNotification();
                        break;
                    case 2:
                        DoCrudOperations();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            new Program().SendNotification();
        }
    }
}
