using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Int2 
        : IEquatable< Int2 >
            , IComparable< Int2 >
    {
        [DataMember]
        public readonly int X;
        [DataMember]
        public readonly int Y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2((int x, int y) tuple) : this(tuple.x, tuple.y) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2(int x, int y) { X = x; Y = y; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 Create(int x, int y) => new Int2(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 Create((int x, int y) tuple) => new Int2(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Int2 x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(X.GetHashCode(), Y.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"Int2(X = {X}, Y = {Y})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out int x, out int y) {x = X; y = Y; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Int2 x) => X == x.X && Y == x.Y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(Int2 x0, Int2 x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(Int2 x0, Int2 x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Int2((int x, int y) tuple) => new Int2(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (int x, int y)(Int2 self) => (self.X, self.Y);

        public static Int2 Zero = new Int2(default, default);
        public static Int2 MinValue = new Int2(int.MinValue, int.MinValue);
        public static Int2 MaxValue = new Int2(int.MaxValue, int.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 SetX(int x) => new Int2(x, Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2 SetY(int x) => new Int2(X, x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator +(Int2 value1, Int2 value2) => new Int2(value1.X + value2.X,value1.Y + value2.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator +(Int2 value1, int value2) => new Int2(value1.X + value2,value1.Y + value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator +(int value1, Int2 value2) => new Int2(value1 + value2.X,value1 + value2.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator -(Int2 value1, Int2 value2) => new Int2(value1.X - value2.X,value1.Y - value2.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator -(Int2 value1, int value2) => new Int2(value1.X - value2,value1.Y - value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator -(int value1, Int2 value2) => new Int2(value1 - value2.X,value1 - value2.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator *(Int2 value1, Int2 value2) => new Int2(value1.X * value2.X,value1.Y * value2.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator *(Int2 value1, int value2) => new Int2(value1.X * value2,value1.Y * value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator *(int value1, Int2 value2) => new Int2(value1 * value2.X,value1 * value2.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator /(Int2 value1, Int2 value2) => new Int2(value1.X / value2.X,value1.Y / value2.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator /(Int2 value1, int value2) => new Int2(value1.X / value2,value1.Y / value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator /(int value1, Int2 value2) => new Int2(value1 / value2.X,value1 / value2.Y);
        public static Int2 One = new Int2(1);
        public static Int2 UnitX = Zero.SetX(1);
        public static Int2 UnitY = Zero.SetY(1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Int2(int value) : this(value, value) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int2 operator -(Int2 value) => Zero - value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static int Dot(Int2 value1, Int2 value2) => value1.X * value2.X + value1.Y * value2.Y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int Dot(Int2 value) => Int2.Dot(this, value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostZero(float tolerance = Constants.Tolerance) => X.Abs() < tolerance && Y.Abs() < tolerance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AnyComponentNegative() => MinComponent() < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int MinComponent() => (X).Min(Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int MaxComponent() => (X).Max(Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int SumComponents() => (X) + (Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int SumSqrComponents() => (X).Sqr() + (Y).Sqr();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int ProductComponents() => (X) * (Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int GetComponent(int n) => n == 0 ? X:Y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MagnitudeSquared() => SumSqrComponents();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double Magnitude() => MagnitudeSquared().Sqrt();        
        public const int NumComponents = 2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsNaN() => X.IsNaN() || Y.IsNaN();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsInfinity() => X.IsInfinity() || Y.IsInfinity();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int CompareTo(Int2 x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(Int2 x0, Int2 x1) => x0.CompareTo(x1) < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(Int2 x0, Int2 x1) => x0.CompareTo(x1) <= 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(Int2 x0, Int2 x1) => x0.CompareTo(x1) > 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(Int2 x0, Int2 x1) => x0.CompareTo(x1) >= 0;
    }
}