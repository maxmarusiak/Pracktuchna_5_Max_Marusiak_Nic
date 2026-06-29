using System;

namespace StudentGroupSystem.Models
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public GradePoint AverageGrade { get; set; }

        public Student(int id, string name, GradePoint grade)
            : base(id)
        {
            Name = name;
            AverageGrade = grade;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Name: {Name}, Avg: {AverageGrade}";
        }

        public static bool operator >(Student a, Student b)
            => a.AverageGrade > b.AverageGrade;

        public static bool operator <(Student a, Student b)
            => a.AverageGrade < b.AverageGrade;

        public static bool operator true(Student s)
            => s.AverageGrade.Value > 7;

        public static bool operator false(Student s)
            => s.AverageGrade.Value <= 7;
    }
}
