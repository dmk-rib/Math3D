using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Int4 
        : IEquatable< Int4 >
            , IComparable< Int4 >
    {
        [DataMember]
        public readonly int X;
        [DataMember]
        public readonly int Y;
        [DataMember]
        public readonly int Z;
        [DataMember]
        public readonly int W;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4((int x, int y, int z, int w) tuple) : this(tuple.x, tuple.y, tuple.z, tuple.w) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4(int x, int y, int z, int w) { X = x; Y = y; Z = z; W = w; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 Create(int x, int y, int z, int w) => new Int4(x, y, z, w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 Create((int x, int y, int z, int w) tuple) => new Int4(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Int4 x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(X.GetHashCode(), Y.GetHashCode(), Z.GetHashCode(), W.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"Int4(X = {X}, Y = {Y}, Z = {Z}, W = {W})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out int x, out int y, out int z, out int w) {x = X; y = Y; z = Z; w = W; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Int4 x) => X == x.X && Y == x.Y && Z == x.Z && W == x.W;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(Int4 x0, Int4 x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(Int4 x0, Int4 x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Int4((int x, int y, int z, int w) tuple) => new Int4(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (int x, int y, int z, int w)(Int4 self) => (self.X, self.Y, self.Z, self.W);

        public static Int4 Zero = new Int4(default, default, default, default);
        public static Int4 MinValue = new Int4(int.MinValue, int.MinValue, int.MinValue, int.MinValue);
        public static Int4 MaxValue = new Int4(int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 SetX(int x) => new Int4(x, Y, Z, W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 SetY(int x) => new Int4(X, x, Z, W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 SetZ(int x) => new Int4(X, Y, x, W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4 SetW(int x) => new Int4(X, Y, Z, x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator +(Int4 value1, Int4 value2) => new Int4(value1.X + value2.X,value1.Y + value2.Y,value1.Z + value2.Z,value1.W + value2.W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator +(Int4 value1, int value2) => new Int4(value1.X + value2,value1.Y + value2,value1.Z + value2,value1.W + value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator +(int value1, Int4 value2) => new Int4(value1 + value2.X,value1 + value2.Y,value1 + value2.Z,value1 + value2.W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator -(Int4 value1, Int4 value2) => new Int4(value1.X - value2.X,value1.Y - value2.Y,value1.Z - value2.Z,value1.W - value2.W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator -(Int4 value1, int value2) => new Int4(value1.X - value2,value1.Y - value2,value1.Z - value2,value1.W - value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator -(int value1, Int4 value2) => new Int4(value1 - value2.X,value1 - value2.Y,value1 - value2.Z,value1 - value2.W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator *(Int4 value1, Int4 value2) => new Int4(value1.X * value2.X,value1.Y * value2.Y,value1.Z * value2.Z,value1.W * value2.W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator *(Int4 value1, int value2) => new Int4(value1.X * value2,value1.Y * value2,value1.Z * value2,value1.W * value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator *(int value1, Int4 value2) => new Int4(value1 * value2.X,value1 * value2.Y,value1 * value2.Z,value1 * value2.W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator /(Int4 value1, Int4 value2) => new Int4(value1.X / value2.X,value1.Y / value2.Y,value1.Z / value2.Z,value1.W / value2.W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator /(Int4 value1, int value2) => new Int4(value1.X / value2,value1.Y / value2,value1.Z / value2,value1.W / value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator /(int value1, Int4 value2) => new Int4(value1 / value2.X,value1 / value2.Y,value1 / value2.Z,value1 / value2.W);
        public static Int4 One = new Int4(1);
        public static Int4 UnitX = Zero.SetX(1);
        public static Int4 UnitY = Zero.SetY(1);
        public static Int4 UnitZ = Zero.SetZ(1);
        public static Int4 UnitW = Zero.SetW(1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Int4(int value) : this(value, value, value, value) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int4 operator -(Int4 value) => Zero - value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static int Dot(Int4 value1, Int4 value2) => value1.X * value2.X + value1.Y * value2.Y + value1.Z * value2.Z + value1.W * value2.W;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int Dot(Int4 value) => Int4.Dot(this, value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostZero(float tolerance = Constants.Tolerance) => X.Abs() < tolerance && Y.Abs() < tolerance && Z.Abs() < tolerance && W.Abs() < tolerance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AnyComponentNegative() => MinComponent() < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int MinComponent() => (X).Min(Y).Min(Z).Min(W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int MaxComponent() => (X).Max(Y).Max(Z).Max(W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int SumComponents() => (X) + (Y) + (Z) + (W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int SumSqrComponents() => (X).Sqr() + (Y).Sqr() + (Z).Sqr() + (W).Sqr();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int ProductComponents() => (X) * (Y) * (Z) * (W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int GetComponent(int n) => n == 0 ? X : n == 1 ? Y : n == 2 ? Z:W;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MagnitudeSquared() => SumSqrComponents();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double Magnitude() => MagnitudeSquared().Sqrt();        
        public const int NumComponents = 4;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsNaN() => X.IsNaN() || Y.IsNaN() || Z.IsNaN() || W.IsNaN();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsInfinity() => X.IsInfinity() || Y.IsInfinity() || Z.IsInfinity() || W.IsInfinity();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int CompareTo(Int4 x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(Int4 x0, Int4 x1) => x0.CompareTo(x1) < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(Int4 x0, Int4 x1) => x0.CompareTo(x1) <= 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(Int4 x0, Int4 x1) => x0.CompareTo(x1) > 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(Int4 x0, Int4 x1) => x0.CompareTo(x1) >= 0;
    }
}