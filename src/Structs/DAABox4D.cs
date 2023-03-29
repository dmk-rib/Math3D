using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct DAABox4D 
        : IEquatable< DAABox4D >
            , IComparable< DAABox4D >
    {
        [DataMember]
        public readonly DVector4 Min;
        [DataMember]
        public readonly DVector4 Max;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DAABox4D((DVector4 min, DVector4 max) tuple) : this(tuple.min, tuple.max) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DAABox4D(DVector4 min, DVector4 max) { Min = min; Max = max; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DAABox4D Create(DVector4 min, DVector4 max) => new DAABox4D(min, max);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DAABox4D Create((DVector4 min, DVector4 max) tuple) => new DAABox4D(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is DAABox4D x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(Min.GetHashCode(), Max.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"DAABox4D(Min = {Min}, Max = {Max})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out DVector4 min, out DVector4 max) {min = Min; max = Max; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(DAABox4D x) => Min == x.Min && Max == x.Max;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(DAABox4D x0, DAABox4D x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(DAABox4D x0, DAABox4D x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator DAABox4D((DVector4 min, DVector4 max) tuple) => new DAABox4D(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (DVector4 min, DVector4 max)(DAABox4D self) => (self.Min, self.Max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(DAABox4D x, float tolerance = Constants.Tolerance) => Min.AlmostEquals(x.Min, tolerance) && Max.AlmostEquals(x.Max, tolerance);
        public static DAABox4D Zero = new DAABox4D(default, default);
        public static DAABox4D MinValue = new DAABox4D(DVector4.MinValue, DVector4.MinValue);
        public static DAABox4D MaxValue = new DAABox4D(DVector4.MaxValue, DVector4.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DAABox4D SetMin(DVector4 x) => new DAABox4D(x, Max);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DAABox4D SetMax(DVector4 x) => new DAABox4D(Min, x);
        public DVector4 Extent => (Max - Min);
        public DVector4 Center => Min.Average(Max);   
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MagnitudeSquared() => Extent.MagnitudeSquared();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double Magnitude() => MagnitudeSquared().Sqrt();        
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DAABox4D Merge(DAABox4D other) => new DAABox4D(Min.Min(other.Min), Max.Max(other.Max));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DAABox4D Intersection(DAABox4D other) => new DAABox4D(Min.Max(other.Min), Max.Min(other.Max));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DAABox4D operator + (DAABox4D value1, DAABox4D value2) => value1.Merge(value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DAABox4D operator - (DAABox4D value1, DAABox4D value2) => value1.Intersection(value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DAABox4D Merge(DVector4 other) => new DAABox4D(Min.Min(other), Max.Max(other));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DAABox4D operator + (DAABox4D value1, DVector4 value2) => value1.Merge(value2);
        public static DAABox4D Empty = Create(DVector4.MaxValue, DVector4.MinValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsNaN() => Min.IsNaN() || Max.IsNaN();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsInfinity() => Min.IsInfinity() || Max.IsInfinity();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int CompareTo(DAABox4D x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(DAABox4D x0, DAABox4D x1) => x0.CompareTo(x1) < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(DAABox4D x0, DAABox4D x1) => x0.CompareTo(x1) <= 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(DAABox4D x0, DAABox4D x1) => x0.CompareTo(x1) > 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(DAABox4D x0, DAABox4D x1) => x0.CompareTo(x1) >= 0;
    }
}