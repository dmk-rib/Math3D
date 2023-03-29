using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct DInterval 
        : IEquatable< DInterval >
            , IComparable< DInterval >
    {
        [DataMember]
        public readonly double Min;
        [DataMember]
        public readonly double Max;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DInterval((double min, double max) tuple) : this(tuple.min, tuple.max) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DInterval(double min, double max) { Min = min; Max = max; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DInterval Create(double min, double max) => new DInterval(min, max);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DInterval Create((double min, double max) tuple) => new DInterval(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is DInterval x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(Min.GetHashCode(), Max.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"DInterval(Min = {Min}, Max = {Max})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out double min, out double max) {min = Min; max = Max; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(DInterval x) => Min == x.Min && Max == x.Max;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(DInterval x0, DInterval x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(DInterval x0, DInterval x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator DInterval((double min, double max) tuple) => new DInterval(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (double min, double max)(DInterval self) => (self.Min, self.Max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(DInterval x, float tolerance = Constants.Tolerance) => Min.AlmostEquals(x.Min, tolerance) && Max.AlmostEquals(x.Max, tolerance);
        public static DInterval Zero = new DInterval(default, default);
        public static DInterval MinValue = new DInterval(double.MinValue, double.MinValue);
        public static DInterval MaxValue = new DInterval(double.MaxValue, double.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DInterval SetMin(double x) => new DInterval(x, Max);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DInterval SetMax(double x) => new DInterval(Min, x);
        public double Extent => (Max - Min);
        public double Center => Min.Average(Max);   
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MagnitudeSquared() => Extent.MagnitudeSquared();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double Magnitude() => MagnitudeSquared().Sqrt();        
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DInterval Merge(DInterval other) => new DInterval(Min.Min(other.Min), Max.Max(other.Max));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DInterval Intersection(DInterval other) => new DInterval(Min.Max(other.Min), Max.Min(other.Max));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DInterval operator + (DInterval value1, DInterval value2) => value1.Merge(value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DInterval operator - (DInterval value1, DInterval value2) => value1.Intersection(value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DInterval Merge(double other) => new DInterval(Min.Min(other), Max.Max(other));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DInterval operator + (DInterval value1, double value2) => value1.Merge(value2);
        public static DInterval Empty = Create(double.MaxValue, double.MinValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsNaN() => Min.IsNaN() || Max.IsNaN();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsInfinity() => Min.IsInfinity() || Max.IsInfinity();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int CompareTo(DInterval x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(DInterval x0, DInterval x1) => x0.CompareTo(x1) < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(DInterval x0, DInterval x1) => x0.CompareTo(x1) <= 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(DInterval x0, DInterval x1) => x0.CompareTo(x1) > 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(DInterval x0, DInterval x1) => x0.CompareTo(x1) >= 0;
    }
}