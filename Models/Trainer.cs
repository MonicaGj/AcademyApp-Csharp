using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Trainer:Person
    {
        public Trainer(string firstName, string lastName, string username, string pass)
             : base(firstName, lastName, Role.Trainer, username, pass)
        {
        }
    }
}
