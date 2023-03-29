using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Int3 
        : IEquatable< Int3 >
            , IComparable< Int3 >
    {
        [DataMember]
        public readonly int X;
        [DataMember]
        public readonly int Y;
        [DataMember]
        public readonly int Z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3((int x, int y, int z) tuple) : this(tuple.x, tuple.y, tuple.z) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3(int x, int y, int z) { X = x; Y = y; Z = z; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Create(int x, int y, int z) => new Int3(x, y, z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 Create((int x, int y, int z) tuple) => new Int3(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Int3 x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(X.GetHashCode(), Y.GetHashCode(), Z.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"Int3(X = {X}, Y = {Y}, Z = {Z})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out int x, out int y, out int z) {x = X; y = Y; z = Z; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Int3 x) => X == x.X && Y == x.Y && Z == x.Z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(Int3 x0, Int3 x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(Int3 x0, Int3 x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Int3((int x, int y, int z) tuple) => new Int3(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (int x, int y, int z)(Int3 self) => (self.X, self.Y, self.Z);

        public static Int3 Zero = new Int3(default, default, default);
        public static Int3 MinValue = new Int3(int.MinValue, int.MinValue, int.MinValue);
        public static Int3 MaxValue = new Int3(int.MaxValue, int.MaxValue, int.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 SetX(int x) => new Int3(x, Y, Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 SetY(int x) => new Int3(X, x, Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3 SetZ(int x) => new Int3(X, Y, x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator +(Int3 value1, Int3 value2) => new Int3(value1.X + value2.X,value1.Y + value2.Y,value1.Z + value2.Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator +(Int3 value1, int value2) => new Int3(value1.X + value2,value1.Y + value2,value1.Z + value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator +(int value1, Int3 value2) => new Int3(value1 + value2.X,value1 + value2.Y,value1 + value2.Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator -(Int3 value1, Int3 value2) => new Int3(value1.X - value2.X,value1.Y - value2.Y,value1.Z - value2.Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator -(Int3 value1, int value2) => new Int3(value1.X - value2,value1.Y - value2,value1.Z - value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator -(int value1, Int3 value2) => new Int3(value1 - value2.X,value1 - value2.Y,value1 - value2.Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator *(Int3 value1, Int3 value2) => new Int3(value1.X * value2.X,value1.Y * value2.Y,value1.Z * value2.Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator *(Int3 value1, int value2) => new Int3(value1.X * value2,value1.Y * value2,value1.Z * value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator *(int value1, Int3 value2) => new Int3(value1 * value2.X,value1 * value2.Y,value1 * value2.Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator /(Int3 value1, Int3 value2) => new Int3(value1.X / value2.X,value1.Y / value2.Y,value1.Z / value2.Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator /(Int3 value1, int value2) => new Int3(value1.X / value2,value1.Y / value2,value1.Z / value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator /(int value1, Int3 value2) => new Int3(value1 / value2.X,value1 / value2.Y,value1 / value2.Z);
        public static Int3 One = new Int3(1);
        public static Int3 UnitX = Zero.SetX(1);
        public static Int3 UnitY = Zero.SetY(1);
        public static Int3 UnitZ = Zero.SetZ(1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Int3(int value) : this(value, value, value) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Int3 operator -(Int3 value) => Zero - value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static int Dot(Int3 value1, Int3 value2) => value1.X * value2.X + value1.Y * value2.Y + value1.Z * value2.Z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int Dot(Int3 value) => Int3.Dot(this, value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostZero(float tolerance = Constants.Tolerance) => X.Abs() < tolerance && Y.Abs() < tolerance && Z.Abs() < tolerance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AnyComponentNegative() => MinComponent() < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int MinComponent() => (X).Min(Y).Min(Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int MaxComponent() => (X).Max(Y).Max(Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int SumComponents() => (X) + (Y) + (Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int SumSqrComponents() => (X).Sqr() + (Y).Sqr() + (Z).Sqr();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int ProductComponents() => (X) * (Y) * (Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int GetComponent(int n) => n == 0 ? X : n == 1 ? Y:Z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MagnitudeSquared() => SumSqrComponents();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double Magnitude() => MagnitudeSquared().Sqrt();        
        public const int NumComponents = 3;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsNaN() => X.IsNaN() || Y.IsNaN() || Z.IsNaN();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsInfinity() => X.IsInfinity() || Y.IsInfinity() || Z.IsInfinity();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int CompareTo(Int3 x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(Int3 x0, Int3 x1) => x0.CompareTo(x1) < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(Int3 x0, Int3 x1) => x0.CompareTo(x1) <= 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(Int3 x0, Int3 x1) => x0.CompareTo(x1) > 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(Int3 x0, Int3 x1) => x0.CompareTo(x1) >= 0;
    }
}