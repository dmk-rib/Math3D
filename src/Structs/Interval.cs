using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Interval 
        : IEquatable< Interval >
            , IComparable< Interval >
    {
        [DataMember]
        public readonly float Min;
        [DataMember]
        public readonly float Max;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Interval((float min, float max) tuple) : this(tuple.min, tuple.max) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Interval(float min, float max) { Min = min; Max = max; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Interval Create(float min, float max) => new Interval(min, max);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Interval Create((float min, float max) tuple) => new Interval(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Interval x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(Min.GetHashCode(), Max.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"Interval(Min = {Min}, Max = {Max})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out float min, out float max) {min = Min; max = Max; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Interval x) => Min == x.Min && Max == x.Max;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(Interval x0, Interval x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(Interval x0, Interval x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Interval((float min, float max) tuple) => new Interval(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (float min, float max)(Interval self) => (self.Min, self.Max);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(Interval x, float tolerance = Constants.Tolerance) => Min.AlmostEquals(x.Min, tolerance) && Max.AlmostEquals(x.Max, tolerance);
        public static Interval Zero = new Interval(default, default);
        public static Interval MinValue = new Interval(float.MinValue, float.MinValue);
        public static Interval MaxValue = new Interval(float.MaxValue, float.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Interval SetMin(float x) => new Interval(x, Max);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Interval SetMax(float x) => new Interval(Min, x);
        public float Extent => (Max - Min);
        public float Center => Min.Average(Max);   
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MagnitudeSquared() => Extent.MagnitudeSquared();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double Magnitude() => MagnitudeSquared().Sqrt();        
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Interval Merge(Interval other) => new Interval(Min.Min(other.Min), Max.Max(other.Max));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Interval Intersection(Interval other) => new Interval(Min.Max(other.Min), Max.Min(other.Max));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Interval operator + (Interval value1, Interval value2) => value1.Merge(value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Interval operator - (Interval value1, Interval value2) => value1.Intersection(value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Interval Merge(float other) => new Interval(Min.Min(other), Max.Max(other));
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Interval operator + (Interval value1, float value2) => value1.Merge(value2);
        public static Interval Empty = Create(float.MaxValue, float.MinValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsNaN() => Min.IsNaN() || Max.IsNaN();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsInfinity() => Min.IsInfinity() || Max.IsInfinity();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int CompareTo(Interval x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(Interval x0, Interval x1) => x0.CompareTo(x1) < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(Interval x0, Interval x1) => x0.CompareTo(x1) <= 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(Interval x0, Interval x1) => x0.CompareTo(x1) > 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(Interval x0, Interval x1) => x0.CompareTo(x1) >= 0;
    }
}