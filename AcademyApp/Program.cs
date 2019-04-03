using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace AcademyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Subject> subjects = new List<Subject>()
            {
                new Subject("C#"),
                new Subject("C#Advanced"),
                new Subject("JavaScript"),
                new Subject("JavaScript Advanced")


            };

            Dictionary<Subject, int> subjectGrades = new Dictionary<Subject, int>()
            {
                [subjects[0]] = 4,
                [subjects[1]] = 3,

            };
            Dictionary<Subject, int> subjectGrades1 = new Dictionary<Subject, int>()
            {
                [subjects[2]] = 2,
                [subjects[3]] = 3,

            };
            Dictionary<Subject, int> subjectGrades2 = new Dictionary<Subject, int>()
            {
                [subjects[2]] = 5,
                [subjects[0]] = 1,

            };



            List<Person> users = new List<Person>()
            {
                new Admin("Monika", "Gjorgjieska", "Monika", "111"),
                new Admin("Jhon", "Johanson", "Jhon", "123"),
                new Trainer("Trajan","Stevkovski", "Trajan", "333"),
                new Trainer("Dragan","Gelevski", "Dragan", "444"),
                new Trainer("Maraja","Markoska", "Maraja", "777"),
                new Student("Dejan", "Angeloski", "Dejan", "222", subjects[0], subjectGrades ),
                new Student("Natasa", "Andonova", "Natasa", "000", subjects[0], subjectGrades1 ),
                new Student("Alex", "Markov", "Alex", "767", subjects[0], subjectGrades2 )
            };

            while (true)
            {
                #region Login

                Person User;
                while (true)
                {
                    Console.WriteLine("Enter username");
                    string inputUsername = Console.ReadLine();
                    User = users.Where(x => x.Username == inputUsername).FirstOrDefault();
                    if (User == null)
                    {
                        Console.WriteLine("Try again");
                        continue;
                    }
                    Console.WriteLine("Enter Password");
                    string inputPassword = Console.ReadLine();
                    if (User.ValidPassword(inputPassword))
                    {
                        Console.WriteLine("Correct password");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Login again!");
                        continue;
                    }
                }

                #endregion


                #region Admin
                

                if (User.Role == Role.Admin)
                {
                    Console.WriteLine("1.Add; 2.Remove");
                    string adminOption = Console.ReadLine();

                    if (adminOption == "1")
                    {
                        Console.WriteLine("1.Add trainer; 2.Add admin; 3.Add student");
                        string addOption = Console.ReadLine();
                        if (addOption == "1")
                        {

                            Console.WriteLine("Enter trainer first name:");
                            string trainerName = Console.ReadLine();
                            Console.WriteLine("Enter trainer last name:");
                            string trainerLastName = Console.ReadLine();
                            Console.WriteLine("Enter trainer username:");
                            string trainerUsername = Console.ReadLine();
                            Console.WriteLine("Enter trainer password:");
                            string trainerPassword = Console.ReadLine();
                            users.Add(new Trainer(trainerName, trainerLastName, trainerUsername, trainerPassword));

                        }
                        else if (addOption == "2")
                        {

                            Console.WriteLine("Enter admin first name:");
                            string adminName = Console.ReadLine();
                            Console.WriteLine("Enter admin last name:");
                            string adminLastName = Console.ReadLine();
                            Console.WriteLine("Enter admin username:");
                            string adminUsername = Console.ReadLine();
                            Console.WriteLine("Enter admin password:");
                            string adminPassword = Console.ReadLine();
                            users.Add(new Admin(adminName, adminLastName, adminUsername, adminPassword));


                        }
                        else if (addOption == "3")
                        {
                            Console.WriteLine("Enter student first name:");
                            string studentName = Console.ReadLine();
                            Console.WriteLine("Enter student last name:");
                            string studentLastName = Console.ReadLine();
                            Console.WriteLine("Enter student username:");
                            string studentUsername = Console.ReadLine();
                            Console.WriteLine("Enter student password:");
                            string studentPassword = Console.ReadLine();

                            Console.WriteLine($"Choose current subject: ");
                            foreach (var subject in subjects)
                            {
                                Console.WriteLine(subject.Name);
                            }

                            string studentCurrentSubject = Console.ReadLine();
                            Subject studentCurrentSubject1 = new Subject(studentCurrentSubject);
                            if (studentCurrentSubject == "C#")
                            {
                                studentCurrentSubject1 = subjects[0];
                            }
                            else if (studentCurrentSubject == "C#Advanced")
                            {
                                studentCurrentSubject1 = subjects[1];
                            }
                            else if (studentCurrentSubject == "JavaScript")
                            {
                                studentCurrentSubject1 = subjects[2];
                            }
                            else if (studentCurrentSubject == "JavaScript Advanced")
                            {
                                studentCurrentSubject1 = subjects[3];
                            }



                            Console.WriteLine("Add passed subject");


                            foreach (var subject in subjects)
                            {
                                Console.WriteLine(subject.Name);
                            }

                            string studentPassedSubject = Console.ReadLine();
                            Console.WriteLine("Add grade");
                            int studentPassedSubjectGrade = int.Parse(Console.ReadLine());
                            Dictionary<Subject, int> NewSubjectGrades1 = new Dictionary<Subject, int>();
                            if (studentPassedSubject == "C#")
                            {
                                Dictionary<Subject, int> NewSubjectGrades = new Dictionary<Subject, int>()
                                {
                                    [subjects[0]] = studentPassedSubjectGrade,
                                };
                                NewSubjectGrades1 = NewSubjectGrades;
                            }
                            else if (studentPassedSubject == "C#Advanced")
                            {
                                Dictionary<Subject, int> NewSubjectGrades = new Dictionary<Subject, int>()
                                {
                                    [subjects[1]] = studentPassedSubjectGrade,
                                };
                                NewSubjectGrades1 = NewSubjectGrades;
                            }
                            else if (studentPassedSubject == "JavaScript")
                            {
                                Dictionary<Subject, int> NewSubjectGrades = new Dictionary<Subject, int>()
                                {
                                    [subjects[2]] = studentPassedSubjectGrade,
                                };
                                NewSubjectGrades1 = NewSubjectGrades;
                            }
                            else if (studentPassedSubject == "JavaScript Advanced")
                            {
                                Dictionary<Subject, int> NewSubjectGrades = new Dictionary<Subject, int>()
                                {
                                    [subjects[3]] = studentPassedSubjectGrade,
                                };
                                NewSubjectGrades1 = NewSubjectGrades;
                            }
                            else { Console.WriteLine("Try again!"); }
                            users.Add(new Student(studentName, studentLastName, studentUsername, studentPassword, studentCurrentSubject1, NewSubjectGrades1));
                        }
                    }
                    else if (adminOption == "2")
                    {
                        Console.WriteLine("1.Remove trainer; 2.Remove admin; 3.Remove student");
                        string removeOption = Console.ReadLine();

                        if (removeOption == "1")
                        {
                            foreach (var user in users.Where(x => x.Role == Role.Trainer))
                            {
                                Console.WriteLine($"Trainer first name: {user.FirstName} , trainer last name: {user.LastName}, trainer username:" +
                                    $"{user.Username}");
                            }
                            Console.WriteLine("Enter trainers username");
                            string TrainerUsername = Console.ReadLine();
                            Person trainerToRemove = users.Where(x => x.Username == TrainerUsername).FirstOrDefault();
                            if (trainerToRemove != null)
                            {
                                users.Remove(trainerToRemove);
                                Console.WriteLine($"Trainer {trainerToRemove.FirstName} has been removed!");
                            }
                            else
                            {
                                Console.WriteLine("There was no such user!");
                            }


                        }
                        else if (removeOption == "2")
                        {
                            foreach (var user in users.Where(x => x.Role == Role.Admin))
                            {
                                Console.WriteLine($"Admin first name: {user.FirstName} , admin last name: {user.LastName}, admin username:" +
                                    $"{user.Username}");
                            }
                            Console.WriteLine("Enter admin username");
                            string AdminUsername = Console.ReadLine();
                            Person adminToRemove = users.Where(x => x.Username == AdminUsername).FirstOrDefault();
                            if (adminToRemove != null && adminToRemove != User)
                            {
                                users.Remove(adminToRemove);
                                Console.WriteLine($"Admin {adminToRemove.FirstName} has been removed!");
                            }
                            else
                            {
                                Console.WriteLine("There was no such user!");
                            }
                        }
                        else if (removeOption == "3")
                        {
                            foreach (var user in users.Where(x => x.Role == Role.Student))
                            {
                                Console.WriteLine($"Student first name: {user.FirstName} , student last name: {user.LastName}, student username:" +
                                    $"{user.Username}");
                            }
                            Console.WriteLine("Enter student username");
                            string StudentUsername = Console.ReadLine();
                            Person studentToRemove = users.Where(x => x.Username == StudentUsername).FirstOrDefault();
                            if (studentToRemove != null)
                            {
                                users.Remove(studentToRemove);
                                Console.WriteLine($"Student {studentToRemove.FirstName} has been removed!");
                            }
                            else
                            {
                                Console.WriteLine("There was no such user!");
                            }

                        }
                        else Console.WriteLine("Please try again!");
                    }
                }
               
                #endregion



                #region Trainer

                    if (User.Role == Role.Trainer)
                    {
                        Console.WriteLine("1.Show all students; 2.Print grades; 3.Show current subjects");
                        string trainerOption = Console.ReadLine();

                        if (trainerOption == "1")
                        {
                            Console.WriteLine("Name of students");
                            foreach (var student in users)
                            {
                                if (student.Role == Role.Student)
                                {

                                    Console.WriteLine(student.FirstName + " " + student.LastName);
                                }
                            }
                        }
                        else if (trainerOption == "2")
                        {
                            Console.WriteLine("Enter student name.");
                            string studentName = Console.ReadLine();
                            foreach (var student in users)
                            {
                                if (student.Role == Role.Student && (student.FirstName.Contains(studentName)))
                                {
                                    Student stu = (Student)student;
                                    Console.WriteLine(stu.GetInfo());
                                    break;
                                }
                                else if (student.Role != Role.Student && (student.FirstName.Contains(studentName)))
                                {
                                    Console.WriteLine("Try again.");
                                    continue;
                                }
                            }
                        }
                        else if (trainerOption == "3")
                        {
                            foreach (var subject in subjects)
                            {
                                int studentsOfSubject = 0;
                                foreach (var user in users.Where(u => u.Role == Role.Student))
                                {
                                    Student currentStudent = (Student)user;
                                    if (subject == currentStudent.CurrentSubject)
                                    {
                                        studentsOfSubject += 1;
                                    }
                                }
                                Console.WriteLine($"Name of the subject: {subject.Name} ({studentsOfSubject}).");
                            }
                        }
                    }

                    #endregion

                #region Student

                    if (User.Role == Role.Student)
                    {
                        Student student = (Student)User;
                        Console.WriteLine("1.Enroll; 2.List all grades");
                        string option = Console.ReadLine();

                        if (option == "1")
                        {
                            foreach (var subject in subjects)
                            {
                                if (!student.Subjects.ContainsKey(subject))
                                {
                                    Console.WriteLine(subject.Name);
                                }
                            }
                            while (true)
                            {
                                string chosenSubject = Console.ReadLine();
                                Subject sub = subjects.FirstOrDefault(x => x.Name == chosenSubject);

                                if (sub == null)
                                {
                                    continue;
                                }

                                student.Enrol(sub);
                                break;

                            }
                        }
                        else if (option == "2")
                        {
                            Console.WriteLine(student.GetInfo());
                        }
                        else
                        {
                            Console.WriteLine("Error");
                        }
                    }

                    #endregion

                Console.WriteLine("If you want to exit program enter Y, else enter N!");
                string ExitProgram = Console.ReadLine();
                if (ExitProgram == "Y") break;
                else if (ExitProgram == "N") continue;
                else break;
                }

            }
        }
    }

