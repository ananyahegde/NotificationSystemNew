using NotificationSystem.Models;
using NotificationSystem.Repositories;

namespace NotificationSystem.Services
{
    internal class UserService
    {
        private UserRepository _repo = new UserRepository();

        public void UserMenu()
        {
            while (true)
            {
                Console.WriteLine("\n\n Please enter what you wish to do.");
                Console.WriteLine("\n1. Add User");
                Console.WriteLine("2. Get User");
                Console.WriteLine("3. Get All Users");
                Console.WriteLine("4. Update User");
                Console.WriteLine("5. Delete User");
                Console.WriteLine("6. Go Back");
                int.TryParse(Console.ReadLine(), out int choice);

                switch (choice)
                {
                    case 1: CreateUser(); break;
                    case 2: ReadUser(); break;
                    case 3: ReadAllUsers(); break;
                    case 4: UpdateUser(); break;
                    case 5: DeleteUser(); break;
                    case 6: return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        public void CreateUser()
        {
            User user = new User();

            Console.WriteLine("Please enter your name.");
            user.Name = Console.ReadLine() ?? "";

            Console.WriteLine("Please enter your email.");
            user.Email = Console.ReadLine() ?? "";

            Console.WriteLine("Please enter your phone number.");
            user.Phone = Console.ReadLine() ?? "";

            User createdUser = _repo.Create(user);
            Console.WriteLine($"User Created.\nUserId: {createdUser.UserId}\nName: {createdUser.Name}\nEmail: {createdUser.Email}\nPhone: {createdUser.Phone}");
        }

        public List<User>? ReadAllUsers()
        {
            List<User>? users = _repo.ReadAll();
            if (users == null)
            {
                Console.WriteLine("No users found.");
                return null;
            }
            foreach (var u in users)
                Console.WriteLine($"UserId: {u.UserId}\nName: {u.Name}\nEmail: {u.Email}\nPhone: {u.Phone}\n");
            return users;
        }

        public void ReadUser()
        {
            Console.WriteLine("Enter the UserId: ");
            string userId = Console.ReadLine();
            User? user = _repo.Read(userId);

            if (user == null)
            {
                Console.WriteLine("User Not Found");
            }
            else
            {
                Console.WriteLine($"\nUserId: {user.UserId}\nName: {user.Name}\nEmail: {user.Email}\nPhone: {user.Phone}");
            }
        }

        public void UpdateUser()
        {
            User user = new User();

            Console.WriteLine("Please enter the Id of the user you want to modify.");
            user.UserId = Console.ReadLine() ?? "";

            Console.WriteLine("Please enter updated name.");
            user.Name = Console.ReadLine() ?? "";

            Console.WriteLine("Please enter updated email.");
            user.Email = Console.ReadLine() ?? "";

            Console.WriteLine("Please enter updated phone number.");
            user.Phone = Console.ReadLine() ?? "";

            User? updatedUser = _repo.Update(user, user.UserId);
            Console.WriteLine($"User Updated.\nUserId: {updatedUser.UserId}\nName: {updatedUser.Name}\nEmail: {updatedUser.Email}\nPhone: {updatedUser.Phone}");
        }

        public void DeleteUser()
        {
            Console.WriteLine("Please Enter the UserId for the user you want to delete.");
            string userId = Console.ReadLine();
            User? deletedUser = _repo.Delete(userId);
            Console.WriteLine($"User Deleted.\nUserId: {deletedUser.UserId}\nName: {deletedUser.Name}\nEmail: {deletedUser.Email}\nPhone: {deletedUser.Phone}");
        }
    }
}
