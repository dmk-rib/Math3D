using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Complex 
        : IEquatable< Complex >
            , IComparable< Complex >
    {
        [DataMember]
        public readonly double Real;
        [DataMember]
        public readonly double Imaginary;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Complex((double real, double imaginary) tuple) : this(tuple.real, tuple.imaginary) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Complex(double real, double imaginary) { Real = real; Imaginary = imaginary; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Complex Create(double real, double imaginary) => new Complex(real, imaginary);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Complex Create((double real, double imaginary) tuple) => new Complex(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Complex x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(Real.GetHashCode(), Imaginary.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"Complex(Real = {Real}, Imaginary = {Imaginary})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out double real, out double imaginary) {real = Real; imaginary = Imaginary; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Complex x) => Real == x.Real && Imaginary == x.Imaginary;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(Complex x0, Complex x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(Complex x0, Complex x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Complex((double real, double imaginary) tuple) => new Complex(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (double real, double imaginary)(Complex self) => (self.Real, self.Imaginary);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(Complex x, float tolerance = Constants.Tolerance) => Real.AlmostEquals(x.Real, tolerance) && Imaginary.AlmostEquals(x.Imaginary, tolerance);
        public static Complex Zero = new Complex(default, default);
        public static Complex MinValue = new Complex(double.MinValue, double.MinValue);
        public static Complex MaxValue = new Complex(double.MaxValue, double.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Complex SetReal(double x) => new Complex(x, Imaginary);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Complex SetImaginary(double x) => new Complex(Real, x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Complex operator +(Complex value1, Complex value2) => new Complex(value1.Real + value2.Real,value1.Imaginary + value2.Imaginary);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Complex operator +(Complex value1, double value2) => new Complex(value1.Real + value2,value1.Imaginary + value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Complex operator +(double value1, Complex value2) => new Complex(value1 + value2.Real,value1 + value2.Imaginary);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Complex operator -(Complex value1, Complex value2) => new Complex(value1.Real - value2.Real,value1.Imaginary - value2.Imaginary);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Complex operator -(Complex value1, double value2) => new Complex(value1.Real - value2,value1.Imaginary - value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Complex operator -(double value1, Complex value2) => new Complex(value1 - value2.Real,value1 - value2.Imaginary);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Complex operator *(Complex value1, Complex value2) => new Complex(value1.Real * value2.Real,value1.Imaginary * value2.Imaginary);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Complex operator *(Complex value1, double value2) => new Complex(value1.Real * value2,value1.Imaginary * value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Complex operator *(double value1, Complex value2) => new Complex(value1 * value2.Real,value1 * value2.Imaginary);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Complex operator /(Complex value1, Complex value2) => new Complex(value1.Real / value2.Real,value1.Imaginary / value2.Imaginary);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Complex operator /(Complex value1, double value2) => new Complex(value1.Real / value2,value1.Imaginary / value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Complex operator /(double value1, Complex value2) => new Complex(value1 / value2.Real,value1 / value2.Imaginary);
        public static Complex One = new Complex(1.0);
        public static Complex UnitReal = Zero.SetReal(1.0);
        public static Complex UnitImaginary = Zero.SetImaginary(1.0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Complex(double value) : this(value, value) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Complex operator -(Complex value) => Zero - value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static double Dot(Complex value1, Complex value2) => value1.Real * value2.Real + value1.Imaginary * value2.Imaginary;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double Dot(Complex value) => Complex.Dot(this, value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostZero(float tolerance = Constants.Tolerance) => Real.Abs() < tolerance && Imaginary.Abs() < tolerance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AnyComponentNegative() => MinComponent() < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MinComponent() => (Real).Min(Imaginary);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MaxComponent() => (Real).Max(Imaginary);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double SumComponents() => (Real) + (Imaginary);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double SumSqrComponents() => (Real).Sqr() + (Imaginary).Sqr();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double ProductComponents() => (Real) * (Imaginary);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double GetComponent(int n) => n == 0 ? Real:Imaginary;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MagnitudeSquared() => SumSqrComponents();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double Magnitude() => MagnitudeSquared().Sqrt();        
        public const int NumComponents = 2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsNaN() => Real.IsNaN() || Imaginary.IsNaN();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsInfinity() => Real.IsInfinity() || Imaginary.IsInfinity();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int CompareTo(Complex x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(Complex x0, Complex x1) => x0.CompareTo(x1) < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(Complex x0, Complex x1) => x0.CompareTo(x1) <= 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(Complex x0, Complex x1) => x0.CompareTo(x1) > 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(Complex x0, Complex x1) => x0.CompareTo(x1) >= 0;
    }
}