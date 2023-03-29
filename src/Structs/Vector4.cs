using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Vector4 
        : IEquatable< Vector4 >
            , IComparable< Vector4 >
    {
        [DataMember]
        public readonly float X;
        [DataMember]
        public readonly float Y;
        [DataMember]
        public readonly float Z;
        [DataMember]
        public readonly float W;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Vector4((float x, float y, float z, float w) tuple) : this(tuple.x, tuple.y, tuple.z, tuple.w) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Vector4(float x, float y, float z, float w) { X = x; Y = y; Z = z; W = w; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector4 Create(float x, float y, float z, float w) => new Vector4(x, y, z, w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector4 Create((float x, float y, float z, float w) tuple) => new Vector4(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Vector4 x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(X.GetHashCode(), Y.GetHashCode(), Z.GetHashCode(), W.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"Vector4(X = {X}, Y = {Y}, Z = {Z}, W = {W})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out float x, out float y, out float z, out float w) {x = X; y = Y; z = Z; w = W; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Vector4 x) => X == x.X && Y == x.Y && Z == x.Z && W == x.W;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(Vector4 x0, Vector4 x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(Vector4 x0, Vector4 x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Vector4((float x, float y, float z, float w) tuple) => new Vector4(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (float x, float y, float z, float w)(Vector4 self) => (self.X, self.Y, self.Z, self.W);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(Vector4 x, float tolerance = Constants.Tolerance) => X.AlmostEquals(x.X, tolerance) && Y.AlmostEquals(x.Y, tolerance) && Z.AlmostEquals(x.Z, tolerance) && W.AlmostEquals(x.W, tolerance);
        public static Vector4 Zero = new Vector4(default, default, default, default);
        public static Vector4 MinValue = new Vector4(float.MinValue, float.MinValue, float.MinValue, float.MinValue);
        public static Vector4 MaxValue = new Vector4(float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Vector4 SetX(float x) => new Vector4(x, Y, Z, W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Vector4 SetY(float x) => new Vector4(X, x, Z, W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Vector4 SetZ(float x) => new Vector4(X, Y, x, W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Vector4 SetW(float x) => new Vector4(X, Y, Z, x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector4 operator +(Vector4 value1, Vector4 value2) => new Vector4(value1.X + value2.X,value1.Y + value2.Y,value1.Z + value2.Z,value1.W + value2.W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector4 operator +(Vector4 value1, float value2) => new Vector4(value1.X + value2,value1.Y + value2,value1.Z + value2,value1.W + value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector4 operator +(float value1, Vector4 value2) => new Vector4(value1 + value2.X,value1 + value2.Y,value1 + value2.Z,value1 + value2.W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector4 operator -(Vector4 value1, Vector4 value2) => new Vector4(value1.X - value2.X,value1.Y - value2.Y,value1.Z - value2.Z,value1.W - value2.W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector4 operator -(Vector4 value1, float value2) => new Vector4(value1.X - value2,value1.Y - value2,value1.Z - value2,value1.W - value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector4 operator -(float value1, Vector4 value2) => new Vector4(value1 - value2.X,value1 - value2.Y,value1 - value2.Z,value1 - value2.W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector4 operator *(Vector4 value1, Vector4 value2) => new Vector4(value1.X * value2.X,value1.Y * value2.Y,value1.Z * value2.Z,value1.W * value2.W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector4 operator *(Vector4 value1, float value2) => new Vector4(value1.X * value2,value1.Y * value2,value1.Z * value2,value1.W * value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector4 operator *(float value1, Vector4 value2) => new Vector4(value1 * value2.X,value1 * value2.Y,value1 * value2.Z,value1 * value2.W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector4 operator /(Vector4 value1, Vector4 value2) => new Vector4(value1.X / value2.X,value1.Y / value2.Y,value1.Z / value2.Z,value1.W / value2.W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector4 operator /(Vector4 value1, float value2) => new Vector4(value1.X / value2,value1.Y / value2,value1.Z / value2,value1.W / value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector4 operator /(float value1, Vector4 value2) => new Vector4(value1 / value2.X,value1 / value2.Y,value1 / value2.Z,value1 / value2.W);
        public static Vector4 One = new Vector4(1f);
        public static Vector4 UnitX = Zero.SetX(1f);
        public static Vector4 UnitY = Zero.SetY(1f);
        public static Vector4 UnitZ = Zero.SetZ(1f);
        public static Vector4 UnitW = Zero.SetW(1f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Vector4(float value) : this(value, value, value, value) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector4 operator -(Vector4 value) => Zero - value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Dot(Vector4 value1, Vector4 value2) => value1.X * value2.X + value1.Y * value2.Y + value1.Z * value2.Z + value1.W * value2.W;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public float Dot(Vector4 value) => Vector4.Dot(this, value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostZero(float tolerance = Constants.Tolerance) => X.Abs() < tolerance && Y.Abs() < tolerance && Z.Abs() < tolerance && W.Abs() < tolerance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AnyComponentNegative() => MinComponent() < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public float MinComponent() => (X).Min(Y).Min(Z).Min(W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public float MaxComponent() => (X).Max(Y).Max(Z).Max(W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public float SumComponents() => (X) + (Y) + (Z) + (W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public float SumSqrComponents() => (X).Sqr() + (Y).Sqr() + (Z).Sqr() + (W).Sqr();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public float ProductComponents() => (X) * (Y) * (Z) * (W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public float GetComponent(int n) => n == 0 ? X : n == 1 ? Y : n == 2 ? Z:W;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MagnitudeSquared() => SumSqrComponents();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double Magnitude() => MagnitudeSquared().Sqrt();        
        public const int NumComponents = 4;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsNaN() => X.IsNaN() || Y.IsNaN() || Z.IsNaN() || W.IsNaN();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsInfinity() => X.IsInfinity() || Y.IsInfinity() || Z.IsInfinity() || W.IsInfinity();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int CompareTo(Vector4 x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(Vector4 x0, Vector4 x1) => x0.CompareTo(x1) < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(Vector4 x0, Vector4 x1) => x0.CompareTo(x1) <= 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(Vector4 x0, Vector4 x1) => x0.CompareTo(x1) > 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(Vector4 x0, Vector4 x1) => x0.CompareTo(x1) >= 0;
    }
}