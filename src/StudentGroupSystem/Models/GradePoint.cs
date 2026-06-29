public class GradePoint
{
    public double Value { get; private set; }

    public GradePoint(double value)
    {
        if (value < 0 || value > 10)
            throw new ArgumentOutOfRangeException(nameof(value));
        Value = value;
    }

    public static GradePoint operator +(GradePoint a, GradePoint b)
        => new GradePoint(Math.Min(10, a.Value + b.Value));

    public static GradePoint operator ++(GradePoint a)
        => new GradePoint(Math.Min(10, a.Value + 1));

    public static GradePoint operator --(GradePoint a)
        => new GradePoint(Math.Max(0, a.Value - 1));

    public static bool operator >(GradePoint a, GradePoint b) => a.Value > b.Value;
    public static bool operator <(GradePoint a, GradePoint b) => a.Value < b.Value;
    public static bool operator >=(GradePoint a, GradePoint b) => a.Value >= b.Value;
    public static bool operator <=(GradePoint a, GradePoint b) => a.Value <= b.Value;

    public static bool operator true(GradePoint a) => a.Value >= 8;
    public static bool operator false(GradePoint a) => a.Value < 8;

    public static implicit operator double(GradePoint g) => g.Value;
    public static implicit operator GradePoint(double v) => new GradePoint(v);

    public override string ToString() => Value.ToString("0.0");
}
