using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Role Role { get;  }
        public string Username { get; set; }
        private string Password { get; }

        public Person(string firstName, string lastName, Role role, string username, string pass)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Role = role;
            this.Username = username;
            this.Password = pass;
        }

        public bool ValidPassword(string password)
        {
            return Password == password;
        }
    }
}
