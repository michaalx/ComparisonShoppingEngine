using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSE
{
    class User
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

        /*public User(string email,string password)
        {
            Email = email;
            Password = password;
        }*/
    }
}
