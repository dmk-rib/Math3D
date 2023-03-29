using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct DVector2 
        : IEquatable< DVector2 >
            , IComparable< DVector2 >
    {
        [DataMember]
        public readonly double X;
        [DataMember]
        public readonly double Y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DVector2((double x, double y) tuple) : this(tuple.x, tuple.y) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DVector2(double x, double y) { X = x; Y = y; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector2 Create(double x, double y) => new DVector2(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector2 Create((double x, double y) tuple) => new DVector2(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is DVector2 x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(X.GetHashCode(), Y.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"DVector2(X = {X}, Y = {Y})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out double x, out double y) {x = X; y = Y; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(DVector2 x) => X == x.X && Y == x.Y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(DVector2 x0, DVector2 x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(DVector2 x0, DVector2 x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator DVector2((double x, double y) tuple) => new DVector2(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (double x, double y)(DVector2 self) => (self.X, self.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(DVector2 x, float tolerance = Constants.Tolerance) => X.AlmostEquals(x.X, tolerance) && Y.AlmostEquals(x.Y, tolerance);
        public static DVector2 Zero = new DVector2(default, default);
        public static DVector2 MinValue = new DVector2(double.MinValue, double.MinValue);
        public static DVector2 MaxValue = new DVector2(double.MaxValue, double.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DVector2 SetX(double x) => new DVector2(x, Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DVector2 SetY(double x) => new DVector2(X, x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector2 operator +(DVector2 value1, DVector2 value2) => new DVector2(value1.X + value2.X,value1.Y + value2.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector2 operator +(DVector2 value1, double value2) => new DVector2(value1.X + value2,value1.Y + value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector2 operator +(double value1, DVector2 value2) => new DVector2(value1 + value2.X,value1 + value2.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector2 operator -(DVector2 value1, DVector2 value2) => new DVector2(value1.X - value2.X,value1.Y - value2.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector2 operator -(DVector2 value1, double value2) => new DVector2(value1.X - value2,value1.Y - value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector2 operator -(double value1, DVector2 value2) => new DVector2(value1 - value2.X,value1 - value2.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector2 operator *(DVector2 value1, DVector2 value2) => new DVector2(value1.X * value2.X,value1.Y * value2.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector2 operator *(DVector2 value1, double value2) => new DVector2(value1.X * value2,value1.Y * value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector2 operator *(double value1, DVector2 value2) => new DVector2(value1 * value2.X,value1 * value2.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector2 operator /(DVector2 value1, DVector2 value2) => new DVector2(value1.X / value2.X,value1.Y / value2.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector2 operator /(DVector2 value1, double value2) => new DVector2(value1.X / value2,value1.Y / value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector2 operator /(double value1, DVector2 value2) => new DVector2(value1 / value2.X,value1 / value2.Y);
        public static DVector2 One = new DVector2(1.0);
        public static DVector2 UnitX = Zero.SetX(1.0);
        public static DVector2 UnitY = Zero.SetY(1.0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DVector2(double value) : this(value, value) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DVector2 operator -(DVector2 value) => Zero - value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static double Dot(DVector2 value1, DVector2 value2) => value1.X * value2.X + value1.Y * value2.Y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double Dot(DVector2 value) => DVector2.Dot(this, value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostZero(float tolerance = Constants.Tolerance) => X.Abs() < tolerance && Y.Abs() < tolerance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AnyComponentNegative() => MinComponent() < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MinComponent() => (X).Min(Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MaxComponent() => (X).Max(Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double SumComponents() => (X) + (Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double SumSqrComponents() => (X).Sqr() + (Y).Sqr();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double ProductComponents() => (X) * (Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double GetComponent(int n) => n == 0 ? X:Y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MagnitudeSquared() => SumSqrComponents();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double Magnitude() => MagnitudeSquared().Sqrt();        
        public const int NumComponents = 2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsNaN() => X.IsNaN() || Y.IsNaN();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsInfinity() => X.IsInfinity() || Y.IsInfinity();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int CompareTo(DVector2 x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(DVector2 x0, DVector2 x1) => x0.CompareTo(x1) < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(DVector2 x0, DVector2 x1) => x0.CompareTo(x1) <= 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(DVector2 x0, DVector2 x1) => x0.CompareTo(x1) > 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(DVector2 x0, DVector2 x1) => x0.CompareTo(x1) >= 0;
    }
}