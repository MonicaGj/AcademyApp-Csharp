using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Student:Person
    {
        public Subject CurrentSubject { get; set; }
        public Dictionary<Subject, int> Subjects { get; set; }

        public Student(string firstName, string lastName, string username, string pass, Subject currentSubject, Dictionary<Subject, int> subjects)
             : base(firstName, lastName, Role.Student, username, pass)
        {
            this.CurrentSubject = currentSubject;
            this.Subjects = subjects;
        }

        public void Enrol(Subject s)
        {
            CurrentSubject = s;
        }

        public string GetInfo()
        {
            string result = "";
            foreach (var item in Subjects)
            {
                result += $"Subject :{item.Key.Name}: Grade:{item.Value} \n";
            }
            return result;
        }
    }
}
