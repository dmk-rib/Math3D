using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct DAABox 
        : IEquatable< DAABox >
            , IComparable< DAABox >
    {
        [DataMember]
        public readonly DVector3 Min;
        [DataMember]
        public readonly DVector3 Max;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DAABox((DVector3 min, DVector3 max) tuple) : this(tuple.min, tuple.max) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DAABox(DVector3 min, DVector3 max) { Min = min; Max = max; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DAABox Create(DVector3 min, DVector3 max) => new DAABox(min, max);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DAABox Create((DVector3 min, DVector3 max) tuple) => new DAABox(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is DAABox x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(Min.GetHashCode(), Max.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"DAABox(Min = {Min}, Max = {Max})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out DVector3 min, out DVector3 max) {min = Min; max = Max; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(DAABox x) => Min == x.Min && Max == x.Max;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(DAABox x0, DAABox x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(DAABox x0, DAABox x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator DAABox((DVector3 min, DVector3 max) tuple) => new DAABox(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (DVector3 min, DVector3 max)(DAABox self) => (self.Min, self.Max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(DAABox x, float tolerance = Constants.Tolerance) => Min.AlmostEquals(x.Min, tolerance) && Max.AlmostEquals(x.Max, tolerance);
        public static DAABox Zero = new DAABox(default, default);
        public static DAABox MinValue = new DAABox(DVector3.MinValue, DVector3.MinValue);
        public static DAABox MaxValue = new DAABox(DVector3.MaxValue, DVector3.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DAABox SetMin(DVector3 x) => new DAABox(x, Max);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DAABox SetMax(DVector3 x) => new DAABox(Min, x);
        public DVector3 Extent => (Max - Min);
        public DVector3 Center => Min.Average(Max);   
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MagnitudeSquared() => Extent.MagnitudeSquared();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double Magnitude() => MagnitudeSquared().Sqrt();        
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DAABox Merge(DAABox other) => new DAABox(Min.Min(other.Min), Max.Max(other.Max));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DAABox Intersection(DAABox other) => new DAABox(Min.Max(other.Min), Max.Min(other.Max));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DAABox operator + (DAABox value1, DAABox value2) => value1.Merge(value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DAABox operator - (DAABox value1, DAABox value2) => value1.Intersection(value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DAABox Merge(DVector3 other) => new DAABox(Min.Min(other), Max.Max(other));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DAABox operator + (DAABox value1, DVector3 value2) => value1.Merge(value2);
        public static DAABox Empty = Create(DVector3.MaxValue, DVector3.MinValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsNaN() => Min.IsNaN() || Max.IsNaN();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsInfinity() => Min.IsInfinity() || Max.IsInfinity();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int CompareTo(DAABox x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(DAABox x0, DAABox x1) => x0.CompareTo(x1) < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(DAABox x0, DAABox x1) => x0.CompareTo(x1) <= 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(DAABox x0, DAABox x1) => x0.CompareTo(x1) > 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(DAABox x0, DAABox x1) => x0.CompareTo(x1) >= 0;
    }
}