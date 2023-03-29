using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct DVector3 
        : IEquatable< DVector3 >
            , IComparable< DVector3 >
    {
        [DataMember]
        public readonly double X;
        [DataMember]
        public readonly double Y;
        [DataMember]
        public readonly double Z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DVector3((double x, double y, double z) tuple) : this(tuple.x, tuple.y, tuple.z) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DVector3(double x, double y, double z) { X = x; Y = y; Z = z; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector3 Create(double x, double y, double z) => new DVector3(x, y, z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector3 Create((double x, double y, double z) tuple) => new DVector3(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is DVector3 x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(X.GetHashCode(), Y.GetHashCode(), Z.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"DVector3(X = {X}, Y = {Y}, Z = {Z})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out double x, out double y, out double z) {x = X; y = Y; z = Z; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(DVector3 x) => X == x.X && Y == x.Y && Z == x.Z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(DVector3 x0, DVector3 x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(DVector3 x0, DVector3 x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator DVector3((double x, double y, double z) tuple) => new DVector3(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (double x, double y, double z)(DVector3 self) => (self.X, self.Y, self.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(DVector3 x, float tolerance = Constants.Tolerance) => X.AlmostEquals(x.X, tolerance) && Y.AlmostEquals(x.Y, tolerance) && Z.AlmostEquals(x.Z, tolerance);
        public static DVector3 Zero = new DVector3(default, default, default);
        public static DVector3 MinValue = new DVector3(double.MinValue, double.MinValue, double.MinValue);
        public static DVector3 MaxValue = new DVector3(double.MaxValue, double.MaxValue, double.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DVector3 SetX(double x) => new DVector3(x, Y, Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DVector3 SetY(double x) => new DVector3(X, x, Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DVector3 SetZ(double x) => new DVector3(X, Y, x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector3 operator +(DVector3 value1, DVector3 value2) => new DVector3(value1.X + value2.X,value1.Y + value2.Y,value1.Z + value2.Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector3 operator +(DVector3 value1, double value2) => new DVector3(value1.X + value2,value1.Y + value2,value1.Z + value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector3 operator +(double value1, DVector3 value2) => new DVector3(value1 + value2.X,value1 + value2.Y,value1 + value2.Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector3 operator -(DVector3 value1, DVector3 value2) => new DVector3(value1.X - value2.X,value1.Y - value2.Y,value1.Z - value2.Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector3 operator -(DVector3 value1, double value2) => new DVector3(value1.X - value2,value1.Y - value2,value1.Z - value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector3 operator -(double value1, DVector3 value2) => new DVector3(value1 - value2.X,value1 - value2.Y,value1 - value2.Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector3 operator *(DVector3 value1, DVector3 value2) => new DVector3(value1.X * value2.X,value1.Y * value2.Y,value1.Z * value2.Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector3 operator *(DVector3 value1, double value2) => new DVector3(value1.X * value2,value1.Y * value2,value1.Z * value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector3 operator *(double value1, DVector3 value2) => new DVector3(value1 * value2.X,value1 * value2.Y,value1 * value2.Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector3 operator /(DVector3 value1, DVector3 value2) => new DVector3(value1.X / value2.X,value1.Y / value2.Y,value1.Z / value2.Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector3 operator /(DVector3 value1, double value2) => new DVector3(value1.X / value2,value1.Y / value2,value1.Z / value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector3 operator /(double value1, DVector3 value2) => new DVector3(value1 / value2.X,value1 / value2.Y,value1 / value2.Z);
        public static DVector3 One = new DVector3(1.0);
        public static DVector3 UnitX = Zero.SetX(1.0);
        public static DVector3 UnitY = Zero.SetY(1.0);
        public static DVector3 UnitZ = Zero.SetZ(1.0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DVector3(double value) : this(value, value, value) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector3 operator -(DVector3 value) => Zero - value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static double Dot(DVector3 value1, DVector3 value2) => value1.X * value2.X + value1.Y * value2.Y + value1.Z * value2.Z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double Dot(DVector3 value) => DVector3.Dot(this, value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostZero(float tolerance = Constants.Tolerance) => X.Abs() < tolerance && Y.Abs() < tolerance && Z.Abs() < tolerance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AnyComponentNegative() => MinComponent() < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MinComponent() => (X).Min(Y).Min(Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MaxComponent() => (X).Max(Y).Max(Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double SumComponents() => (X) + (Y) + (Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double SumSqrComponents() => (X).Sqr() + (Y).Sqr() + (Z).Sqr();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double ProductComponents() => (X) * (Y) * (Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double GetComponent(int n) => n == 0 ? X : n == 1 ? Y:Z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MagnitudeSquared() => SumSqrComponents();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double Magnitude() => MagnitudeSquared().Sqrt();        
        public const int NumComponents = 3;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsNaN() => X.IsNaN() || Y.IsNaN() || Z.IsNaN();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsInfinity() => X.IsInfinity() || Y.IsInfinity() || Z.IsInfinity();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int CompareTo(DVector3 x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(DVector3 x0, DVector3 x1) => x0.CompareTo(x1) < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(DVector3 x0, DVector3 x1) => x0.CompareTo(x1) <= 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(DVector3 x0, DVector3 x1) => x0.CompareTo(x1) > 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(DVector3 x0, DVector3 x1) => x0.CompareTo(x1) >= 0;
    }
}