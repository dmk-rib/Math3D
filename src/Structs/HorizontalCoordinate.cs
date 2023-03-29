using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct HorizontalCoordinate 
        : IEquatable< HorizontalCoordinate >
            , IComparable< HorizontalCoordinate >
    {
        [DataMember]
        public readonly double Azimuth;
        [DataMember]
        public readonly double Inclination;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public HorizontalCoordinate((double azimuth, double inclination) tuple) : this(tuple.azimuth, tuple.inclination) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public HorizontalCoordinate(double azimuth, double inclination) { Azimuth = azimuth; Inclination = inclination; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static HorizontalCoordinate Create(double azimuth, double inclination) => new HorizontalCoordinate(azimuth, inclination);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static HorizontalCoordinate Create((double azimuth, double inclination) tuple) => new HorizontalCoordinate(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is HorizontalCoordinate x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(Azimuth.GetHashCode(), Inclination.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"HorizontalCoordinate(Azimuth = {Azimuth}, Inclination = {Inclination})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out double azimuth, out double inclination) {azimuth = Azimuth; inclination = Inclination; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(HorizontalCoordinate x) => Azimuth == x.Azimuth && Inclination == x.Inclination;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(HorizontalCoordinate x0, HorizontalCoordinate x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(HorizontalCoordinate x0, HorizontalCoordinate x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator HorizontalCoordinate((double azimuth, double inclination) tuple) => new HorizontalCoordinate(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (double azimuth, double inclination)(HorizontalCoordinate self) => (self.Azimuth, self.Inclination);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(HorizontalCoordinate x, float tolerance = Constants.Tolerance) => Azimuth.AlmostEquals(x.Azimuth, tolerance) && Inclination.AlmostEquals(x.Inclination, tolerance);
        public static HorizontalCoordinate Zero = new HorizontalCoordinate(default, default);
        public static HorizontalCoordinate MinValue = new HorizontalCoordinate(double.MinValue, double.MinValue);
        public static HorizontalCoordinate MaxValue = new HorizontalCoordinate(double.MaxValue, double.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public HorizontalCoordinate SetAzimuth(double x) => new HorizontalCoordinate(x, Inclination);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public HorizontalCoordinate SetInclination(double x) => new HorizontalCoordinate(Azimuth, x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static HorizontalCoordinate operator +(HorizontalCoordinate value1, HorizontalCoordinate value2) => new HorizontalCoordinate(value1.Azimuth + value2.Azimuth,value1.Inclination + value2.Inclination);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static HorizontalCoordinate operator +(HorizontalCoordinate value1, double value2) => new HorizontalCoordinate(value1.Azimuth + value2,value1.Inclination + value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static HorizontalCoordinate operator +(double value1, HorizontalCoordinate value2) => new HorizontalCoordinate(value1 + value2.Azimuth,value1 + value2.Inclination);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static HorizontalCoordinate operator -(HorizontalCoordinate value1, HorizontalCoordinate value2) => new HorizontalCoordinate(value1.Azimuth - value2.Azimuth,value1.Inclination - value2.Inclination);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static HorizontalCoordinate operator -(HorizontalCoordinate value1, double value2) => new HorizontalCoordinate(value1.Azimuth - value2,value1.Inclination - value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static HorizontalCoordinate operator -(double value1, HorizontalCoordinate value2) => new HorizontalCoordinate(value1 - value2.Azimuth,value1 - value2.Inclination);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static HorizontalCoordinate operator *(HorizontalCoordinate value1, HorizontalCoordinate value2) => new HorizontalCoordinate(value1.Azimuth * value2.Azimuth,value1.Inclination * value2.Inclination);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static HorizontalCoordinate operator *(HorizontalCoordinate value1, double value2) => new HorizontalCoordinate(value1.Azimuth * value2,value1.Inclination * value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static HorizontalCoordinate operator *(double value1, HorizontalCoordinate value2) => new HorizontalCoordinate(value1 * value2.Azimuth,value1 * value2.Inclination);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static HorizontalCoordinate operator /(HorizontalCoordinate value1, HorizontalCoordinate value2) => new HorizontalCoordinate(value1.Azimuth / value2.Azimuth,value1.Inclination / value2.Inclination);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static HorizontalCoordinate operator /(HorizontalCoordinate value1, double value2) => new HorizontalCoordinate(value1.Azimuth / value2,value1.Inclination / value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static HorizontalCoordinate operator /(double value1, HorizontalCoordinate value2) => new HorizontalCoordinate(value1 / value2.Azimuth,value1 / value2.Inclination);
        public static HorizontalCoordinate One = new HorizontalCoordinate(1.0);
        public static HorizontalCoordinate UnitAzimuth = Zero.SetAzimuth(1.0);
        public static HorizontalCoordinate UnitInclination = Zero.SetInclination(1.0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public HorizontalCoordinate(double value) : this(value, value) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static HorizontalCoordinate operator -(HorizontalCoordinate value) => Zero - value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static double Dot(HorizontalCoordinate value1, HorizontalCoordinate value2) => value1.Azimuth * value2.Azimuth + value1.Inclination * value2.Inclination;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double Dot(HorizontalCoordinate value) => HorizontalCoordinate.Dot(this, value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostZero(float tolerance = Constants.Tolerance) => Azimuth.Abs() < tolerance && Inclination.Abs() < tolerance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AnyComponentNegative() => MinComponent() < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MinComponent() => (Azimuth).Min(Inclination);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MaxComponent() => (Azimuth).Max(Inclination);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double SumComponents() => (Azimuth) + (Inclination);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double SumSqrComponents() => (Azimuth).Sqr() + (Inclination).Sqr();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double ProductComponents() => (Azimuth) * (Inclination);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double GetComponent(int n) => n == 0 ? Azimuth:Inclination;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MagnitudeSquared() => SumSqrComponents();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double Magnitude() => MagnitudeSquared().Sqrt();        
        public const int NumComponents = 2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsNaN() => Azimuth.IsNaN() || Inclination.IsNaN();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsInfinity() => Azimuth.IsInfinity() || Inclination.IsInfinity();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int CompareTo(HorizontalCoordinate x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(HorizontalCoordinate x0, HorizontalCoordinate x1) => x0.CompareTo(x1) < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(HorizontalCoordinate x0, HorizontalCoordinate x1) => x0.CompareTo(x1) <= 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(HorizontalCoordinate x0, HorizontalCoordinate x1) => x0.CompareTo(x1) > 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(HorizontalCoordinate x0, HorizontalCoordinate x1) => x0.CompareTo(x1) >= 0;
    }
}