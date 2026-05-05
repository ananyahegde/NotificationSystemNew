using NotificationSystem.Models;

namespace NotificationSystem.Services
{
    internal class UserService
    {
        static List<User> users = new List<User>();

        public User AddUser()
        {
            User user = new User();

            Console.WriteLine("Please enter your name.");
            user.Name = Console.ReadLine() ?? "";

            Console.WriteLine("Please enter your email.");
            user.Email = Console.ReadLine() ?? "";

            Console.WriteLine("Please enter your phone number.");
            user.Phone = Console.ReadLine() ?? "";

            users.Add(user);
            return user;
        }

        public List<User> GetUsers()
        {
            return users;
        }
    }
}
