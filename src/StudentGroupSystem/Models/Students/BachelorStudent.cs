using StudentGroupSystem.Models;

namespace StudentGroupSystem.Models.Students
{
    public class BachelorStudent : Student
    {
        public BachelorStudent(int id, string name, GradePoint grade)
            : base(id, name, grade)
        {
        }

        public override string ToString()
        {
            return $"[Bachelor] {base.ToString()}";
        }
    }
}
