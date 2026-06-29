using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentGroupSystem.Models
{
    public class Student
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        private string _fullName;
        public string FullName
        {
            get => _fullName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("ПІБ не може бути порожнім.");

                var parts = value.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 3)
                    throw new ArgumentException("ПІБ має містити мінімум три слова.");

                _fullName = value.Trim();
            }
        }

        public byte[] LabGrades { get; set; } = new byte[10];
        public string Notes { get; set; } = "";

        // ПР №4
        public int CourseProgress { get; set; } = 0;
        public List<GradePoint> Grades { get; set; } = new();

        public double AverageGrade =>
            Grades.Count == 0 ? 0 : Grades.Average(g => (double)g);

        public Student(string fullName)
        {
            FullName = fullName;
        }

        public bool ContainsKeyword(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return false;

            keyword = keyword.ToLower();
            return FullName.ToLower().Contains(keyword)
                || Notes.ToLower().Contains(keyword);
        }

        public string GetFormattedInfo(bool detailed = false)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"ПІБ: {FullName}");
            sb.AppendLine($"ID: {Id}");

            if (detailed)
            {
                sb.AppendLine($"Оцінки (лаби): {string.Join(", ", LabGrades)}");
                sb.AppendLine($"Оцінки (GradePoint): {string.Join(", ", Grades)}");
                sb.AppendLine($"Прогрес: {CourseProgress}%");
                sb.AppendLine($"Нотатки: {Notes}");
            }

            return sb.ToString();
        }

        // -----------------------------
        // REFAC: спільний метод порівняння
        // -----------------------------
        private static int CompareByPerformance(Student a, Student b)
        {
            int gradeCompare = a.AverageGrade.CompareTo(b.AverageGrade);
            if (gradeCompare != 0)
                return gradeCompare;

            return a.CourseProgress.CompareTo(b.CourseProgress);
        }

        public static bool operator >(Student a, Student b) => CompareByPerformance(a, b) > 0;
        public static bool operator <(Student a, Student b) => CompareByPerformance(a, b) < 0;
        public static bool operator >=(Student a, Student b) => CompareByPerformance(a, b) >= 0;
        public static bool operator <=(Student a, Student b) => CompareByPerformance(a, b) <= 0;

        public static bool operator ==(Student a, Student b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;

            return CompareByPerformance(a, b) == 0;
        }

        public static bool operator !=(Student a, Student b) => !(a == b);

        // -----------------------------
        // REFAC: оператор +
        // -----------------------------
        public static Student operator +(Student a, Student b)
        {
            var team = new Student($"{a.FullName} & {b.FullName}")
            {
                CourseProgress = (a.CourseProgress + b.CourseProgress) / 2,
                Notes = $"{a.Notes}; {b.Notes}"
            };

            team.Grades.AddRange(a.Grades);
            team.Grades.AddRange(b.Grades);

            return team;
        }

        public override bool Equals(object obj)
        {
            if (obj is Student s)
                return this == s;
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FullName, AverageGrade, CourseProgress);
        }
    }
}
