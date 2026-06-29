using System;
using StudentGroupSystem.Models;

namespace StudentGroupSystem.Menu
{
    public class MainMenu
    {
        private StudentGroup _group;

        public MainMenu()
        {
            _group = new StudentGroup(1, "Default Group");
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== MAIN MENU ===");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Remove Student");
                Console.WriteLine("3. Show Group Info");
                Console.WriteLine("4. Exit");
                Console.Write("Choose option: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddStudent();
                        break;

                    case "2":
                        RemoveStudent();
                        break;

                    case "3":
                        ShowGroup();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid option!");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void AddStudent()
        {
            Console.Write("Enter student ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            Console.Write("Enter grade value: ");
            double gradeValue = double.Parse(Console.ReadLine());

            GradePoint gp = new GradePoint(id + 1000, gradeValue);
            Student s = new Student(id, name, gp);

            _group += s;

            Console.WriteLine("Student added!");
            Console.ReadKey();
        }

        private void RemoveStudent()
        {
            Console.Write("Enter student ID to remove: ");
            int id = int.Parse(Console.ReadLine());

            Student toRemove = _group.Students.Find(s => s.Id == id);

            if (toRemove != null)
            {
                _group -= toRemove;
                Console.WriteLine("Student removed!");
            }
            else
            {
                Console.WriteLine("Student not found!");
            }

            Console.ReadKey();
        }

        private void ShowGroup()
        {
            Console.WriteLine(_group.ToString());

            foreach (var s in _group.Students)
            {
                Console.WriteLine(" - " + s.ToString());
            }

            Console.ReadKey();
        }
    }
}
