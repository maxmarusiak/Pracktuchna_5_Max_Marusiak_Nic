using StudentGroupSystem.Models;

namespace StudentGroupSystem.Models.Students
{
    public class MasterStudent : Student
    {
        public MasterStudent(int id, string name, GradePoint grade)
            : base(id, name, grade)
        {
        }

        public override string ToString()
        {
            return $"[Master] {base.ToString()}";
        }
    }
}
