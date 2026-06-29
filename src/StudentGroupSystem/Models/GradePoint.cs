using System;

namespace StudentGroupSystem.Models
{
    public class GradePoint : BaseEntity
    {
        public double Value { get; set; }

        public GradePoint(int id, double value)
            : base(id)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Grade: {Value}";
        }

        public static GradePoint operator +(GradePoint a, GradePoint b)
            => new GradePoint(0, a.Value + b.Value);

        public static GradePoint operator ++(GradePoint g)
        {
            g.Value++;
            return g;
        }

        public static GradePoint operator --(GradePoint g)
        {
            g.Value--;
            return g;
        }

        public static bool operator >(GradePoint a, GradePoint b)
            => a.Value > b.Value;

        public static bool operator <(GradePoint a, GradePoint b)
            => a.Value < b.Value;

        public static explicit operator int(GradePoint g)
            => (int)g.Value;
    }
}
