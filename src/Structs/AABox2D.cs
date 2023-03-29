using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct AABox2D 
        : IEquatable< AABox2D >
            , IComparable< AABox2D >
    {
        [DataMember]
        public readonly Vector2 Min;
        [DataMember]
        public readonly Vector2 Max;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public AABox2D((Vector2 min, Vector2 max) tuple) : this(tuple.min, tuple.max) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public AABox2D(Vector2 min, Vector2 max) { Min = min; Max = max; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static AABox2D Create(Vector2 min, Vector2 max) => new AABox2D(min, max);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static AABox2D Create((Vector2 min, Vector2 max) tuple) => new AABox2D(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is AABox2D x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(Min.GetHashCode(), Max.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"AABox2D(Min = {Min}, Max = {Max})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out Vector2 min, out Vector2 max) {min = Min; max = Max; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(AABox2D x) => Min == x.Min && Max == x.Max;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(AABox2D x0, AABox2D x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(AABox2D x0, AABox2D x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator AABox2D((Vector2 min, Vector2 max) tuple) => new AABox2D(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (Vector2 min, Vector2 max)(AABox2D self) => (self.Min, self.Max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(AABox2D x, float tolerance = Constants.Tolerance) => Min.AlmostEquals(x.Min, tolerance) && Max.AlmostEquals(x.Max, tolerance);
        public static AABox2D Zero = new AABox2D(default, default);
        public static AABox2D MinValue = new AABox2D(Vector2.MinValue, Vector2.MinValue);
        public static AABox2D MaxValue = new AABox2D(Vector2.MaxValue, Vector2.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public AABox2D SetMin(Vector2 x) => new AABox2D(x, Max);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public AABox2D SetMax(Vector2 x) => new AABox2D(Min, x);
        public Vector2 Extent => (Max - Min);
        public Vector2 Center => Min.Average(Max);   
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MagnitudeSquared() => Extent.MagnitudeSquared();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double Magnitude() => MagnitudeSquared().Sqrt();        
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public AABox2D Merge(AABox2D other) => new AABox2D(Min.Min(other.Min), Max.Max(other.Max));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public AABox2D Intersection(AABox2D other) => new AABox2D(Min.Max(other.Min), Max.Min(other.Max));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static AABox2D operator + (AABox2D value1, AABox2D value2) => value1.Merge(value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static AABox2D operator - (AABox2D value1, AABox2D value2) => value1.Intersection(value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public AABox2D Merge(Vector2 other) => new AABox2D(Min.Min(other), Max.Max(other));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static AABox2D operator + (AABox2D value1, Vector2 value2) => value1.Merge(value2);
        public static AABox2D Empty = Create(Vector2.MaxValue, Vector2.MinValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsNaN() => Min.IsNaN() || Max.IsNaN();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsInfinity() => Min.IsInfinity() || Max.IsInfinity();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int CompareTo(AABox2D x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(AABox2D x0, AABox2D x1) => x0.CompareTo(x1) < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(AABox2D x0, AABox2D x1) => x0.CompareTo(x1) <= 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(AABox2D x0, AABox2D x1) => x0.CompareTo(x1) > 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(AABox2D x0, AABox2D x1) => x0.CompareTo(x1) >= 0;
    }
}