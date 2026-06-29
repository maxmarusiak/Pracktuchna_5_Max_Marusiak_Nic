using System;

namespace StudentGroupSystem.Models
{
    public class Vector : BaseEntity
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector(int id, double x, double y)
            : base(id)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, Vector({X}, {Y})";
        }

        public static Vector operator +(Vector a, Vector b)
            => new Vector(0, a.X + b.X, a.Y + b.Y);

        public static Vector operator -(Vector a, Vector b)
            => new Vector(0, a.X - b.X, a.Y - b.Y);

        public static Vector operator *(Vector a, double k)
            => new Vector(0, a.X * k, a.Y * k);

        public static bool operator ==(Vector a, Vector b)
            => a.X == b.X && a.Y == b.Y;

        public static bool operator !=(Vector a, Vector b)
            => !(a == b);

        public static implicit operator double(Vector v)
            => Math.Sqrt(v.X * v.X + v.Y * v.Y);
    }
}
