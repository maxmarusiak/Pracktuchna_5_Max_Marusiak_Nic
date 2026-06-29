using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentGroupSystem.Models
{
    public class StudentGroup
    {
        public List<Student> Students { get; set; } = new List<Student>();

        public void AddStudent(Student s)
        {
            Students.Add(s);
        }

        public void RemoveStudent(Guid id)
        {
            Students.RemoveAll(s => s.Id == id);
        }

        public string SearchByNameFragment(string fragment)
        {
            fragment = fragment.ToLower();

            var matches = Students
                .Where(s => s.FullName.ToLower().Contains(fragment))
                .ToList();

            if (!matches.Any())
                return "Нічого не знайдено.";

            var sb = new StringBuilder();
            foreach (var s in matches)
                sb.AppendLine(s.GetFormattedInfo());

            return sb.ToString();
        }

        public string ExportToCsv()
        {
            var sb = new StringBuilder();
            sb.AppendLine("FullName;Id;Grades;Notes");

            foreach (var s in Students)
            {
                sb.AppendLine($"{s.FullName};{s.Id};{string.Join(",", s.LabGrades)};{s.Notes}");
            }

            return sb.ToString();
        }

        public void ImportStudentsFromText(string rawText)
        {
            var lines = rawText.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines)
            {
                var parts = line.Split(';', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length < 1)
                    continue;

                var student = new Student(parts[0]);

                if (parts.Length >= 2)
                    student.Notes = parts[1];

                AddStudent(student);
            }
        }

        public static StudentGroup operator +(StudentGroup a, StudentGroup b)
        {
            var merged = new StudentGroup();
            merged.Students.AddRange(a.Students);
            merged.Students.AddRange(b.Students);
            return merged;
        }

        public Student this[string id]
            => Students.FirstOrDefault(s => s.Id.ToString() == id);

        public Student BestStudent()
        {
            if (Students.Count == 0) return null;

            Student best = Students[0];
            foreach (var s in Students)
                if (s > best)
                    best = s;

            return best;
        }   

        public StudentGroup MergeGroups(StudentGroup other) => this + other;


    }
}
