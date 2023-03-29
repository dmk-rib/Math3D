using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct AABox4D 
        : IEquatable< AABox4D >
            , IComparable< AABox4D >
    {
        [DataMember]
        public readonly Vector4 Min;
        [DataMember]
        public readonly Vector4 Max;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public AABox4D((Vector4 min, Vector4 max) tuple) : this(tuple.min, tuple.max) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public AABox4D(Vector4 min, Vector4 max) { Min = min; Max = max; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static AABox4D Create(Vector4 min, Vector4 max) => new AABox4D(min, max);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static AABox4D Create((Vector4 min, Vector4 max) tuple) => new AABox4D(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is AABox4D x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(Min.GetHashCode(), Max.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"AABox4D(Min = {Min}, Max = {Max})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out Vector4 min, out Vector4 max) {min = Min; max = Max; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(AABox4D x) => Min == x.Min && Max == x.Max;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(AABox4D x0, AABox4D x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(AABox4D x0, AABox4D x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator AABox4D((Vector4 min, Vector4 max) tuple) => new AABox4D(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (Vector4 min, Vector4 max)(AABox4D self) => (self.Min, self.Max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(AABox4D x, float tolerance = Constants.Tolerance) => Min.AlmostEquals(x.Min, tolerance) && Max.AlmostEquals(x.Max, tolerance);
        public static AABox4D Zero = new AABox4D(default, default);
        public static AABox4D MinValue = new AABox4D(Vector4.MinValue, Vector4.MinValue);
        public static AABox4D MaxValue = new AABox4D(Vector4.MaxValue, Vector4.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public AABox4D SetMin(Vector4 x) => new AABox4D(x, Max);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public AABox4D SetMax(Vector4 x) => new AABox4D(Min, x);
        public Vector4 Extent => (Max - Min);
        public Vector4 Center => Min.Average(Max);   
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MagnitudeSquared() => Extent.MagnitudeSquared();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double Magnitude() => MagnitudeSquared().Sqrt();        
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public AABox4D Merge(AABox4D other) => new AABox4D(Min.Min(other.Min), Max.Max(other.Max));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public AABox4D Intersection(AABox4D other) => new AABox4D(Min.Max(other.Min), Max.Min(other.Max));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static AABox4D operator + (AABox4D value1, AABox4D value2) => value1.Merge(value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static AABox4D operator - (AABox4D value1, AABox4D value2) => value1.Intersection(value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public AABox4D Merge(Vector4 other) => new AABox4D(Min.Min(other), Max.Max(other));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static AABox4D operator + (AABox4D value1, Vector4 value2) => value1.Merge(value2);
        public static AABox4D Empty = Create(Vector4.MaxValue, Vector4.MinValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsNaN() => Min.IsNaN() || Max.IsNaN();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsInfinity() => Min.IsInfinity() || Max.IsInfinity();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int CompareTo(AABox4D x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(AABox4D x0, AABox4D x1) => x0.CompareTo(x1) < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(AABox4D x0, AABox4D x1) => x0.CompareTo(x1) <= 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(AABox4D x0, AABox4D x1) => x0.CompareTo(x1) > 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(AABox4D x0, AABox4D x1) => x0.CompareTo(x1) >= 0;
    }
}