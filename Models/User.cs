namespace NotificationSystem.Models
{
    internal class User
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public User() { }

        public User(string name, string email, string phone)
        {
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
        }

        public override string ToString()
        {
            return $"Name: {Name}" +
                   $"Email: {Email}" +
                   $"Phone: {Phone}";
        }
    }
}

