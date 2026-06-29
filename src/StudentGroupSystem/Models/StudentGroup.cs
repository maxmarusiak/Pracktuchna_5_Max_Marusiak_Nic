using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentGroupSystem.Models
{
    public class StudentGroup : BaseEntity
    {
        public string GroupName { get; set; }

        public List<UniversityMember> Members { get; set; }

        public StudentGroup(int id, string name)
            : base(id)
        {
            GroupName = name;
            Members = new List<UniversityMember>();
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Group: {GroupName}, Members: {Members.Count}";
        }

        public void AddMember(UniversityMember member)
        {
            Members.Add(member);
        }

        public void RemoveMember(int id)
        {
            var m = Members.FirstOrDefault(x => x.Id == id);
            if (m != null)
                Members.Remove(m);
        }

        public IEnumerable<UniversityMember> Search(string fragment)
        {
            return Members.Where(m => m.Name.Contains(fragment, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Student> GetStudents()
        {
            return Members.OfType<Student>();
        }

        public double GetAverageGrade()
        {
            var students = Members.OfType<Student>().ToList();
            if (students.Count == 0) return 0;

            return students.Average(s => s.AverageGrade.Value);
        }

        public void PrintAll()
        {
            foreach (var m in Members)
                Console.WriteLine(m.GetInfo());
        }
    }
}
