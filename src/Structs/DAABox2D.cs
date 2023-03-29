using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct DAABox2D 
        : IEquatable< DAABox2D >
            , IComparable< DAABox2D >
    {
        [DataMember]
        public readonly DVector2 Min;
        [DataMember]
        public readonly DVector2 Max;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DAABox2D((DVector2 min, DVector2 max) tuple) : this(tuple.min, tuple.max) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DAABox2D(DVector2 min, DVector2 max) { Min = min; Max = max; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DAABox2D Create(DVector2 min, DVector2 max) => new DAABox2D(min, max);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DAABox2D Create((DVector2 min, DVector2 max) tuple) => new DAABox2D(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is DAABox2D x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(Min.GetHashCode(), Max.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"DAABox2D(Min = {Min}, Max = {Max})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out DVector2 min, out DVector2 max) {min = Min; max = Max; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(DAABox2D x) => Min == x.Min && Max == x.Max;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(DAABox2D x0, DAABox2D x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(DAABox2D x0, DAABox2D x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator DAABox2D((DVector2 min, DVector2 max) tuple) => new DAABox2D(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (DVector2 min, DVector2 max)(DAABox2D self) => (self.Min, self.Max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(DAABox2D x, float tolerance = Constants.Tolerance) => Min.AlmostEquals(x.Min, tolerance) && Max.AlmostEquals(x.Max, tolerance);
        public static DAABox2D Zero = new DAABox2D(default, default);
        public static DAABox2D MinValue = new DAABox2D(DVector2.MinValue, DVector2.MinValue);
        public static DAABox2D MaxValue = new DAABox2D(DVector2.MaxValue, DVector2.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DAABox2D SetMin(DVector2 x) => new DAABox2D(x, Max);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DAABox2D SetMax(DVector2 x) => new DAABox2D(Min, x);
        public DVector2 Extent => (Max - Min);
        public DVector2 Center => Min.Average(Max);   
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MagnitudeSquared() => Extent.MagnitudeSquared();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double Magnitude() => MagnitudeSquared().Sqrt();        
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DAABox2D Merge(DAABox2D other) => new DAABox2D(Min.Min(other.Min), Max.Max(other.Max));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DAABox2D Intersection(DAABox2D other) => new DAABox2D(Min.Max(other.Min), Max.Min(other.Max));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DAABox2D operator + (DAABox2D value1, DAABox2D value2) => value1.Merge(value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DAABox2D operator - (DAABox2D value1, DAABox2D value2) => value1.Intersection(value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DAABox2D Merge(DVector2 other) => new DAABox2D(Min.Min(other), Max.Max(other));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DAABox2D operator + (DAABox2D value1, DVector2 value2) => value1.Merge(value2);
        public static DAABox2D Empty = Create(DVector2.MaxValue, DVector2.MinValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsNaN() => Min.IsNaN() || Max.IsNaN();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsInfinity() => Min.IsInfinity() || Max.IsInfinity();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int CompareTo(DAABox2D x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(DAABox2D x0, DAABox2D x1) => x0.CompareTo(x1) < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(DAABox2D x0, DAABox2D x1) => x0.CompareTo(x1) <= 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(DAABox2D x0, DAABox2D x1) => x0.CompareTo(x1) > 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(DAABox2D x0, DAABox2D x1) => x0.CompareTo(x1) >= 0;
    }
}