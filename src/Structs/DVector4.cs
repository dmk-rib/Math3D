using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct DVector4 
        : IEquatable< DVector4 >
            , IComparable< DVector4 >
    {
        [DataMember]
        public readonly double X;
        [DataMember]
        public readonly double Y;
        [DataMember]
        public readonly double Z;
        [DataMember]
        public readonly double W;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DVector4((double x, double y, double z, double w) tuple) : this(tuple.x, tuple.y, tuple.z, tuple.w) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DVector4(double x, double y, double z, double w) { X = x; Y = y; Z = z; W = w; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector4 Create(double x, double y, double z, double w) => new DVector4(x, y, z, w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector4 Create((double x, double y, double z, double w) tuple) => new DVector4(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is DVector4 x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(X.GetHashCode(), Y.GetHashCode(), Z.GetHashCode(), W.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"DVector4(X = {X}, Y = {Y}, Z = {Z}, W = {W})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out double x, out double y, out double z, out double w) {x = X; y = Y; z = Z; w = W; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(DVector4 x) => X == x.X && Y == x.Y && Z == x.Z && W == x.W;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(DVector4 x0, DVector4 x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(DVector4 x0, DVector4 x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator DVector4((double x, double y, double z, double w) tuple) => new DVector4(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (double x, double y, double z, double w)(DVector4 self) => (self.X, self.Y, self.Z, self.W);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(DVector4 x, float tolerance = Constants.Tolerance) => X.AlmostEquals(x.X, tolerance) && Y.AlmostEquals(x.Y, tolerance) && Z.AlmostEquals(x.Z, tolerance) && W.AlmostEquals(x.W, tolerance);
        public static DVector4 Zero = new DVector4(default, default, default, default);
        public static DVector4 MinValue = new DVector4(double.MinValue, double.MinValue, double.MinValue, double.MinValue);
        public static DVector4 MaxValue = new DVector4(double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DVector4 SetX(double x) => new DVector4(x, Y, Z, W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DVector4 SetY(double x) => new DVector4(X, x, Z, W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DVector4 SetZ(double x) => new DVector4(X, Y, x, W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DVector4 SetW(double x) => new DVector4(X, Y, Z, x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector4 operator +(DVector4 value1, DVector4 value2) => new DVector4(value1.X + value2.X,value1.Y + value2.Y,value1.Z + value2.Z,value1.W + value2.W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector4 operator +(DVector4 value1, double value2) => new DVector4(value1.X + value2,value1.Y + value2,value1.Z + value2,value1.W + value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector4 operator +(double value1, DVector4 value2) => new DVector4(value1 + value2.X,value1 + value2.Y,value1 + value2.Z,value1 + value2.W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector4 operator -(DVector4 value1, DVector4 value2) => new DVector4(value1.X - value2.X,value1.Y - value2.Y,value1.Z - value2.Z,value1.W - value2.W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector4 operator -(DVector4 value1, double value2) => new DVector4(value1.X - value2,value1.Y - value2,value1.Z - value2,value1.W - value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector4 operator -(double value1, DVector4 value2) => new DVector4(value1 - value2.X,value1 - value2.Y,value1 - value2.Z,value1 - value2.W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector4 operator *(DVector4 value1, DVector4 value2) => new DVector4(value1.X * value2.X,value1.Y * value2.Y,value1.Z * value2.Z,value1.W * value2.W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector4 operator *(DVector4 value1, double value2) => new DVector4(value1.X * value2,value1.Y * value2,value1.Z * value2,value1.W * value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector4 operator *(double value1, DVector4 value2) => new DVector4(value1 * value2.X,value1 * value2.Y,value1 * value2.Z,value1 * value2.W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector4 operator /(DVector4 value1, DVector4 value2) => new DVector4(value1.X / value2.X,value1.Y / value2.Y,value1.Z / value2.Z,value1.W / value2.W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector4 operator /(DVector4 value1, double value2) => new DVector4(value1.X / value2,value1.Y / value2,value1.Z / value2,value1.W / value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector4 operator /(double value1, DVector4 value2) => new DVector4(value1 / value2.X,value1 / value2.Y,value1 / value2.Z,value1 / value2.W);
        public static DVector4 One = new DVector4(1.0);
        public static DVector4 UnitX = Zero.SetX(1.0);
        public static DVector4 UnitY = Zero.SetY(1.0);
        public static DVector4 UnitZ = Zero.SetZ(1.0);
        public static DVector4 UnitW = Zero.SetW(1.0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DVector4(double value) : this(value, value, value, value) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector4 operator -(DVector4 value) => Zero - value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static double Dot(DVector4 value1, DVector4 value2) => value1.X * value2.X + value1.Y * value2.Y + value1.Z * value2.Z + value1.W * value2.W;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double Dot(DVector4 value) => DVector4.Dot(this, value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostZero(float tolerance = Constants.Tolerance) => X.Abs() < tolerance && Y.Abs() < tolerance && Z.Abs() < tolerance && W.Abs() < tolerance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AnyComponentNegative() => MinComponent() < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MinComponent() => (X).Min(Y).Min(Z).Min(W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MaxComponent() => (X).Max(Y).Max(Z).Max(W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double SumComponents() => (X) + (Y) + (Z) + (W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double SumSqrComponents() => (X).Sqr() + (Y).Sqr() + (Z).Sqr() + (W).Sqr();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double ProductComponents() => (X) * (Y) * (Z) * (W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double GetComponent(int n) => n == 0 ? X : n == 1 ? Y : n == 2 ? Z:W;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MagnitudeSquared() => SumSqrComponents();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double Magnitude() => MagnitudeSquared().Sqrt();        
        public const int NumComponents = 4;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsNaN() => X.IsNaN() || Y.IsNaN() || Z.IsNaN() || W.IsNaN();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsInfinity() => X.IsInfinity() || Y.IsInfinity() || Z.IsInfinity() || W.IsInfinity();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int CompareTo(DVector4 x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(DVector4 x0, DVector4 x1) => x0.CompareTo(x1) < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(DVector4 x0, DVector4 x1) => x0.CompareTo(x1) <= 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(DVector4 x0, DVector4 x1) => x0.CompareTo(x1) > 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(DVector4 x0, DVector4 x1) => x0.CompareTo(x1) >= 0;
    }
}