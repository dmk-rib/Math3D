using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Vector3 
        : IEquatable< Vector3 >
            , IComparable< Vector3 >
    {
        [DataMember]
        public readonly float X;
        [DataMember]
        public readonly float Y;
        [DataMember]
        public readonly float Z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Vector3((float x, float y, float z) tuple) : this(tuple.x, tuple.y, tuple.z) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Vector3(float x, float y, float z) { X = x; Y = y; Z = z; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector3 Create(float x, float y, float z) => new Vector3(x, y, z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector3 Create((float x, float y, float z) tuple) => new Vector3(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Vector3 x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(X.GetHashCode(), Y.GetHashCode(), Z.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"Vector3(X = {X}, Y = {Y}, Z = {Z})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out float x, out float y, out float z) {x = X; y = Y; z = Z; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Vector3 x) => X == x.X && Y == x.Y && Z == x.Z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(Vector3 x0, Vector3 x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(Vector3 x0, Vector3 x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Vector3((float x, float y, float z) tuple) => new Vector3(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (float x, float y, float z)(Vector3 self) => (self.X, self.Y, self.Z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(Vector3 x, float tolerance = Constants.Tolerance) => X.AlmostEquals(x.X, tolerance) && Y.AlmostEquals(x.Y, tolerance) && Z.AlmostEquals(x.Z, tolerance);
        public static Vector3 Zero = new Vector3(default, default, default);
        public static Vector3 MinValue = new Vector3(float.MinValue, float.MinValue, float.MinValue);
        public static Vector3 MaxValue = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Vector3 SetX(float x) => new Vector3(x, Y, Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Vector3 SetY(float x) => new Vector3(X, x, Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Vector3 SetZ(float x) => new Vector3(X, Y, x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector3 operator +(Vector3 value1, Vector3 value2) => new Vector3(value1.X + value2.X,value1.Y + value2.Y,value1.Z + value2.Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector3 operator +(Vector3 value1, float value2) => new Vector3(value1.X + value2,value1.Y + value2,value1.Z + value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector3 operator +(float value1, Vector3 value2) => new Vector3(value1 + value2.X,value1 + value2.Y,value1 + value2.Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector3 operator -(Vector3 value1, Vector3 value2) => new Vector3(value1.X - value2.X,value1.Y - value2.Y,value1.Z - value2.Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector3 operator -(Vector3 value1, float value2) => new Vector3(value1.X - value2,value1.Y - value2,value1.Z - value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector3 operator -(float value1, Vector3 value2) => new Vector3(value1 - value2.X,value1 - value2.Y,value1 - value2.Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector3 operator *(Vector3 value1, Vector3 value2) => new Vector3(value1.X * value2.X,value1.Y * value2.Y,value1.Z * value2.Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector3 operator *(Vector3 value1, float value2) => new Vector3(value1.X * value2,value1.Y * value2,value1.Z * value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector3 operator *(float value1, Vector3 value2) => new Vector3(value1 * value2.X,value1 * value2.Y,value1 * value2.Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector3 operator /(Vector3 value1, Vector3 value2) => new Vector3(value1.X / value2.X,value1.Y / value2.Y,value1.Z / value2.Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector3 operator /(Vector3 value1, float value2) => new Vector3(value1.X / value2,value1.Y / value2,value1.Z / value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector3 operator /(float value1, Vector3 value2) => new Vector3(value1 / value2.X,value1 / value2.Y,value1 / value2.Z);
        public static Vector3 One = new Vector3(1f);
        public static Vector3 UnitX = Zero.SetX(1f);
        public static Vector3 UnitY = Zero.SetY(1f);
        public static Vector3 UnitZ = Zero.SetZ(1f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Vector3(float value) : this(value, value, value) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector3 operator -(Vector3 value) => Zero - value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Dot(Vector3 value1, Vector3 value2) => value1.X * value2.X + value1.Y * value2.Y + value1.Z * value2.Z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public float Dot(Vector3 value) => Vector3.Dot(this, value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostZero(float tolerance = Constants.Tolerance) => X.Abs() < tolerance && Y.Abs() < tolerance && Z.Abs() < tolerance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AnyComponentNegative() => MinComponent() < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public float MinComponent() => (X).Min(Y).Min(Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public float MaxComponent() => (X).Max(Y).Max(Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public float SumComponents() => (X) + (Y) + (Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public float SumSqrComponents() => (X).Sqr() + (Y).Sqr() + (Z).Sqr();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public float ProductComponents() => (X) * (Y) * (Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public float GetComponent(int n) => n == 0 ? X : n == 1 ? Y:Z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MagnitudeSquared() => SumSqrComponents();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double Magnitude() => MagnitudeSquared().Sqrt();        
        public const int NumComponents = 3;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsNaN() => X.IsNaN() || Y.IsNaN() || Z.IsNaN();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsInfinity() => X.IsInfinity() || Y.IsInfinity() || Z.IsInfinity();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int CompareTo(Vector3 x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(Vector3 x0, Vector3 x1) => x0.CompareTo(x1) < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(Vector3 x0, Vector3 x1) => x0.CompareTo(x1) <= 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(Vector3 x0, Vector3 x1) => x0.CompareTo(x1) > 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(Vector3 x0, Vector3 x1) => x0.CompareTo(x1) >= 0;
    }
}