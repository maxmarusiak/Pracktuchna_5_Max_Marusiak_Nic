using StudentGroupSystem.Models;

namespace StudentGroupSystem.Models.Students
{
    public class HonorsStudent : Student
    {
        public double Bonus { get; set; }

        public HonorsStudent(int id, string name, GradePoint grade, double bonus)
            : base(id, name, grade)
        {
            Bonus = bonus;
        }

        public override string GetRole()
        {
            return "Honors Student";
        }

        public override string GetInfo()
        {
            double boosted = AverageGrade.Value + Bonus;
            return $"{base.GetInfo()}, Bonus: {Bonus}, Boosted Grade: {boosted}";
        }
    }
}
