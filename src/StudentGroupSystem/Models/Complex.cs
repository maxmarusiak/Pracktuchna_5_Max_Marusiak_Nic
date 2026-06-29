public class Complex
{
    public double Real { get; set; }
    public double Imag { get; set; }

    public Complex(double real, double imag)
    {
        Real = real;
        Imag = imag;
    }

    public double Magnitude() => Math.Sqrt(Real * Real + Imag * Imag);

    public override string ToString() => $"{Real} + {Imag}i";

    public static Complex operator +(Complex a, Complex b)
        => new Complex(a.Real + b.Real, a.Imag + b.Imag);

    public static Complex operator -(Complex a, Complex b)
        => new Complex(a.Real - b.Real, a.Imag - b.Imag);

    public static Complex operator *(Complex a, Complex b)
        => new Complex(
            a.Real * b.Real - a.Imag * b.Imag,
            a.Real * b.Imag + a.Imag * b.Real
        );

    public static Complex operator /(Complex a, Complex b)
    {
        double denom = b.Real * b.Real + b.Imag * b.Imag;
        return new Complex(
            (a.Real * b.Real + a.Imag * b.Imag) / denom,
            (a.Imag * b.Real - a.Real * b.Imag) / denom
        );
    }

    public static bool operator ==(Complex a, Complex b)
        => a.Magnitude() == b.Magnitude();

    public static bool operator !=(Complex a, Complex b)
        => a.Magnitude() != b.Magnitude();

    public static Complex operator ++(Complex a)
        => new Complex(a.Real + 1, a.Imag + 1);

    public static Complex operator --(Complex a)
        => new Complex(a.Real - 1, a.Imag - 1);

    public static explicit operator double(Complex a) => a.Magnitude();

    public static implicit operator Complex(double value) => new Complex(value, 0);

    public override bool Equals(object? obj)
        => obj is Complex c && this == c;

    public override int GetHashCode() => Magnitude().GetHashCode();
}
