using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Vector2 
        : IEquatable< Vector2 >
        , IComparable< Vector2 >
    {
        [DataMember]
        public readonly float X;
        [DataMember]
        public readonly float Y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Vector2((float x, float y) tuple) : this(tuple.x, tuple.y) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Vector2(float x, float y) { X = x; Y = y; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector2 Create(float x, float y) => new Vector2(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector2 Create((float x, float y) tuple) => new Vector2(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Vector2 x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(X.GetHashCode(), Y.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"Vector2(X = {X}, Y = {Y})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out float x, out float y) {x = X; y = Y; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Vector2 x) => X == x.X && Y == x.Y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(Vector2 x0, Vector2 x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(Vector2 x0, Vector2 x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Vector2((float x, float y) tuple) => new Vector2(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (float x, float y)(Vector2 self) => (self.X, self.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(Vector2 x, float tolerance = Constants.Tolerance) => X.AlmostEquals(x.X, tolerance) && Y.AlmostEquals(x.Y, tolerance);
        public static Vector2 Zero = new Vector2(default, default);
        public static Vector2 MinValue = new Vector2(float.MinValue, float.MinValue);
        public static Vector2 MaxValue = new Vector2(float.MaxValue, float.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Vector2 SetX(float x) => new Vector2(x, Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Vector2 SetY(float x) => new Vector2(X, x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector2 operator +(Vector2 value1, Vector2 value2) => new Vector2(value1.X + value2.X,value1.Y + value2.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector2 operator +(Vector2 value1, float value2) => new Vector2(value1.X + value2,value1.Y + value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector2 operator +(float value1, Vector2 value2) => new Vector2(value1 + value2.X,value1 + value2.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector2 operator -(Vector2 value1, Vector2 value2) => new Vector2(value1.X - value2.X,value1.Y - value2.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector2 operator -(Vector2 value1, float value2) => new Vector2(value1.X - value2,value1.Y - value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector2 operator -(float value1, Vector2 value2) => new Vector2(value1 - value2.X,value1 - value2.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector2 operator *(Vector2 value1, Vector2 value2) => new Vector2(value1.X * value2.X,value1.Y * value2.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector2 operator *(Vector2 value1, float value2) => new Vector2(value1.X * value2,value1.Y * value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector2 operator *(float value1, Vector2 value2) => new Vector2(value1 * value2.X,value1 * value2.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector2 operator /(Vector2 value1, Vector2 value2) => new Vector2(value1.X / value2.X,value1.Y / value2.Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector2 operator /(Vector2 value1, float value2) => new Vector2(value1.X / value2,value1.Y / value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector2 operator /(float value1, Vector2 value2) => new Vector2(value1 / value2.X,value1 / value2.Y);
        public static Vector2 One = new Vector2(1f);
        public static Vector2 UnitX = Zero.SetX(1f);
        public static Vector2 UnitY = Zero.SetY(1f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Vector2(float value) : this(value, value) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Vector2 operator -(Vector2 value) => Zero - value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Dot(Vector2 value1, Vector2 value2) => value1.X * value2.X + value1.Y * value2.Y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public float Dot(Vector2 value) => Vector2.Dot(this, value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostZero(float tolerance = Constants.Tolerance) => X.Abs() < tolerance && Y.Abs() < tolerance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AnyComponentNegative() => MinComponent() < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public float MinComponent() => (X).Min(Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public float MaxComponent() => (X).Max(Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public float SumComponents() => (X) + (Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public float SumSqrComponents() => (X).Sqr() + (Y).Sqr();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public float ProductComponents() => (X) * (Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public float GetComponent(int n) => n == 0 ? X:Y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MagnitudeSquared() => SumSqrComponents();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double Magnitude() => MagnitudeSquared().Sqrt();        
        public const int NumComponents = 2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsNaN() => X.IsNaN() || Y.IsNaN();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsInfinity() => X.IsInfinity() || Y.IsInfinity();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int CompareTo(Vector2 x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(Vector2 x0, Vector2 x1) => x0.CompareTo(x1) < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(Vector2 x0, Vector2 x1) => x0.CompareTo(x1) <= 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(Vector2 x0, Vector2 x1) => x0.CompareTo(x1) > 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(Vector2 x0, Vector2 x1) => x0.CompareTo(x1) >= 0;
    }
}
