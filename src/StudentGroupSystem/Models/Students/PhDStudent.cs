using StudentGroupSystem.Models;

namespace StudentGroupSystem.Models.Students
{
    public class PhDStudent : Student
    {
        public PhDStudent(int id, string name, GradePoint grade)
            : base(id, name, grade)
        {
        }

        public override string ToString()
        {
            return $"[PhD] {base.ToString()}";
        }
    }
}
