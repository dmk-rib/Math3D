using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct AABox 
        : IEquatable< AABox >
            , IComparable< AABox >
    {
        [DataMember]
        public readonly Vector3 Min;
        [DataMember]
        public readonly Vector3 Max;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public AABox((Vector3 min, Vector3 max) tuple) : this(tuple.min, tuple.max) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public AABox(Vector3 min, Vector3 max) { Min = min; Max = max; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static AABox Create(Vector3 min, Vector3 max) => new AABox(min, max);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static AABox Create((Vector3 min, Vector3 max) tuple) => new AABox(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is AABox x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(Min.GetHashCode(), Max.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"AABox(Min = {Min}, Max = {Max})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out Vector3 min, out Vector3 max) {min = Min; max = Max; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(AABox x) => Min == x.Min && Max == x.Max;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(AABox x0, AABox x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(AABox x0, AABox x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator AABox((Vector3 min, Vector3 max) tuple) => new AABox(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (Vector3 min, Vector3 max)(AABox self) => (self.Min, self.Max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(AABox x, float tolerance = Constants.Tolerance) => Min.AlmostEquals(x.Min, tolerance) && Max.AlmostEquals(x.Max, tolerance);
        public static AABox Zero = new AABox(default, default);
        public static AABox MinValue = new AABox(Vector3.MinValue, Vector3.MinValue);
        public static AABox MaxValue = new AABox(Vector3.MaxValue, Vector3.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public AABox SetMin(Vector3 x) => new AABox(x, Max);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public AABox SetMax(Vector3 x) => new AABox(Min, x);
        public Vector3 Extent => (Max - Min);
        public Vector3 Center => Min.Average(Max);   
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MagnitudeSquared() => Extent.MagnitudeSquared();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double Magnitude() => MagnitudeSquared().Sqrt();        
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public AABox Merge(AABox other) => new AABox(Min.Min(other.Min), Max.Max(other.Max));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public AABox Intersection(AABox other) => new AABox(Min.Max(other.Min), Max.Min(other.Max));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static AABox operator + (AABox value1, AABox value2) => value1.Merge(value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static AABox operator - (AABox value1, AABox value2) => value1.Intersection(value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public AABox Merge(Vector3 other) => new AABox(Min.Min(other), Max.Max(other));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static AABox operator + (AABox value1, Vector3 value2) => value1.Merge(value2);
        public static AABox Empty = Create(Vector3.MaxValue, Vector3.MinValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsNaN() => Min.IsNaN() || Max.IsNaN();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsInfinity() => Min.IsInfinity() || Max.IsInfinity();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int CompareTo(AABox x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(AABox x0, AABox x1) => x0.CompareTo(x1) < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(AABox x0, AABox x1) => x0.CompareTo(x1) <= 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(AABox x0, AABox x1) => x0.CompareTo(x1) > 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(AABox x0, AABox x1) => x0.CompareTo(x1) >= 0;
    }
}