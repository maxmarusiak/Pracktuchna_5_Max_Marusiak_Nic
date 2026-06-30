using System;
using StudentGroupSystem.Models;
using StudentGroupSystem.Models.Students;

namespace StudentGroupSystem.Menu
{
    public class MainMenu
    {
        private StudentGroup _group;

        public MainMenu()
        {
            _group = new StudentGroup(1, "Polymorphism Group");
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== POLYMORPHISM MENU ===");
                Console.WriteLine("1. Add Bachelor");
                Console.WriteLine("2. Add Master");
                Console.WriteLine("3. Add PhD");
                Console.WriteLine("4. Show All Members");
                Console.WriteLine("5. Search by Name");
                Console.WriteLine("6. Show Average Grade");
                Console.WriteLine("7. Exit");
                Console.Write("Choose option: ");

                Console.Write("Choose option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddBachelor();
                        break;

                    case "2":
                        AddMaster();
                        break;

                    case "3":
                        AddPhD();
                        break;

                    case "4":
                        _group.PrintAll();
                        Console.ReadKey();
                        break;

                    case "5":
                        Console.Write("Fragment: ");
                        var f = Console.ReadLine();
                        foreach (var m in _group.Search(f))
                            Console.WriteLine(m.GetInfo());
                        Console.ReadKey();
                        break;

                    case "6":
                        Console.WriteLine($"Average grade: {_group.GetAverageGrade()}");
                        Console.ReadKey();
                        break;

                    case "7":
                        return;

                    default:
                        Console.WriteLine("Invalid option");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void AddBachelor()
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Grade: ");
            double grade = double.Parse(Console.ReadLine());

            var gp = new GradePoint(id + 1000, grade);
            var b = new BachelorStudent(id, name, gp);

            _group.AddMember(b);
        }

        private void AddMaster()
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Grade: ");
            double grade = double.Parse(Console.ReadLine());

            var gp = new GradePoint(id + 2000, grade);
            var m = new MasterStudent(id, name, gp);

            _group.AddMember(m);
        }

        private void AddPhD()
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Grade: ");
            double grade = double.Parse(Console.ReadLine());

            var gp = new GradePoint(id + 3000, grade);
            var p = new PhDStudent(id, name, gp);

            _group.AddMember(p);
        }
    }
}
