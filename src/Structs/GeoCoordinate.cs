using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct GeoCoordinate 
        : IEquatable< GeoCoordinate >
            , IComparable< GeoCoordinate >
    {
        [DataMember]
        public readonly double Latitude;
        [DataMember]
        public readonly double Longitude;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public GeoCoordinate((double latitude, double longitude) tuple) : this(tuple.latitude, tuple.longitude) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public GeoCoordinate(double latitude, double longitude) { Latitude = latitude; Longitude = longitude; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static GeoCoordinate Create(double latitude, double longitude) => new GeoCoordinate(latitude, longitude);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static GeoCoordinate Create((double latitude, double longitude) tuple) => new GeoCoordinate(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is GeoCoordinate x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(Latitude.GetHashCode(), Longitude.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"GeoCoordinate(Latitude = {Latitude}, Longitude = {Longitude})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out double latitude, out double longitude) {latitude = Latitude; longitude = Longitude; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(GeoCoordinate x) => Latitude == x.Latitude && Longitude == x.Longitude;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(GeoCoordinate x0, GeoCoordinate x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(GeoCoordinate x0, GeoCoordinate x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator GeoCoordinate((double latitude, double longitude) tuple) => new GeoCoordinate(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (double latitude, double longitude)(GeoCoordinate self) => (self.Latitude, self.Longitude);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(GeoCoordinate x, float tolerance = Constants.Tolerance) => Latitude.AlmostEquals(x.Latitude, tolerance) && Longitude.AlmostEquals(x.Longitude, tolerance);
        public static GeoCoordinate Zero = new GeoCoordinate(default, default);
        public static GeoCoordinate MinValue = new GeoCoordinate(double.MinValue, double.MinValue);
        public static GeoCoordinate MaxValue = new GeoCoordinate(double.MaxValue, double.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public GeoCoordinate SetLatitude(double x) => new GeoCoordinate(x, Longitude);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public GeoCoordinate SetLongitude(double x) => new GeoCoordinate(Latitude, x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static GeoCoordinate operator +(GeoCoordinate value1, GeoCoordinate value2) => new GeoCoordinate(value1.Latitude + value2.Latitude,value1.Longitude + value2.Longitude);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static GeoCoordinate operator +(GeoCoordinate value1, double value2) => new GeoCoordinate(value1.Latitude + value2,value1.Longitude + value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static GeoCoordinate operator +(double value1, GeoCoordinate value2) => new GeoCoordinate(value1 + value2.Latitude,value1 + value2.Longitude);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static GeoCoordinate operator -(GeoCoordinate value1, GeoCoordinate value2) => new GeoCoordinate(value1.Latitude - value2.Latitude,value1.Longitude - value2.Longitude);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static GeoCoordinate operator -(GeoCoordinate value1, double value2) => new GeoCoordinate(value1.Latitude - value2,value1.Longitude - value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static GeoCoordinate operator -(double value1, GeoCoordinate value2) => new GeoCoordinate(value1 - value2.Latitude,value1 - value2.Longitude);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static GeoCoordinate operator *(GeoCoordinate value1, GeoCoordinate value2) => new GeoCoordinate(value1.Latitude * value2.Latitude,value1.Longitude * value2.Longitude);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static GeoCoordinate operator *(GeoCoordinate value1, double value2) => new GeoCoordinate(value1.Latitude * value2,value1.Longitude * value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static GeoCoordinate operator *(double value1, GeoCoordinate value2) => new GeoCoordinate(value1 * value2.Latitude,value1 * value2.Longitude);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static GeoCoordinate operator /(GeoCoordinate value1, GeoCoordinate value2) => new GeoCoordinate(value1.Latitude / value2.Latitude,value1.Longitude / value2.Longitude);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static GeoCoordinate operator /(GeoCoordinate value1, double value2) => new GeoCoordinate(value1.Latitude / value2,value1.Longitude / value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static GeoCoordinate operator /(double value1, GeoCoordinate value2) => new GeoCoordinate(value1 / value2.Latitude,value1 / value2.Longitude);
        public static GeoCoordinate One = new GeoCoordinate(1.0);
        public static GeoCoordinate UnitLatitude = Zero.SetLatitude(1.0);
        public static GeoCoordinate UnitLongitude = Zero.SetLongitude(1.0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public GeoCoordinate(double value) : this(value, value) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static GeoCoordinate operator -(GeoCoordinate value) => Zero - value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static double Dot(GeoCoordinate value1, GeoCoordinate value2) => value1.Latitude * value2.Latitude + value1.Longitude * value2.Longitude;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double Dot(GeoCoordinate value) => GeoCoordinate.Dot(this, value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostZero(float tolerance = Constants.Tolerance) => Latitude.Abs() < tolerance && Longitude.Abs() < tolerance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AnyComponentNegative() => MinComponent() < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MinComponent() => (Latitude).Min(Longitude);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MaxComponent() => (Latitude).Max(Longitude);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double SumComponents() => (Latitude) + (Longitude);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double SumSqrComponents() => (Latitude).Sqr() + (Longitude).Sqr();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double ProductComponents() => (Latitude) * (Longitude);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double GetComponent(int n) => n == 0 ? Latitude:Longitude;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MagnitudeSquared() => SumSqrComponents();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double Magnitude() => MagnitudeSquared().Sqrt();        
        public const int NumComponents = 2;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsNaN() => Latitude.IsNaN() || Longitude.IsNaN();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsInfinity() => Latitude.IsInfinity() || Longitude.IsInfinity();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int CompareTo(GeoCoordinate x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(GeoCoordinate x0, GeoCoordinate x1) => x0.CompareTo(x1) < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(GeoCoordinate x0, GeoCoordinate x1) => x0.CompareTo(x1) <= 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(GeoCoordinate x0, GeoCoordinate x1) => x0.CompareTo(x1) > 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(GeoCoordinate x0, GeoCoordinate x1) => x0.CompareTo(x1) >= 0;
    }
}