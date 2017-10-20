namespace CSE
{
    public class User
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(string name, string lastName, string email, string password)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
        }
    }
}
