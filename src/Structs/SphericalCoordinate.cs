using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct SphericalCoordinate 
        : IEquatable< SphericalCoordinate >
    {
        [DataMember]
        public readonly double Radius;
        [DataMember]
        public readonly double Azimuth;
        [DataMember]
        public readonly double Inclination;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public SphericalCoordinate((double radius, double azimuth, double inclination) tuple) : this(tuple.radius, tuple.azimuth, tuple.inclination) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public SphericalCoordinate(double radius, double azimuth, double inclination) { Radius = radius; Azimuth = azimuth; Inclination = inclination; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static SphericalCoordinate Create(double radius, double azimuth, double inclination) => new SphericalCoordinate(radius, azimuth, inclination);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static SphericalCoordinate Create((double radius, double azimuth, double inclination) tuple) => new SphericalCoordinate(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is SphericalCoordinate x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(Radius.GetHashCode(), Azimuth.GetHashCode(), Inclination.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"SphericalCoordinate(Radius = {Radius}, Azimuth = {Azimuth}, Inclination = {Inclination})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out double radius, out double azimuth, out double inclination) {radius = Radius; azimuth = Azimuth; inclination = Inclination; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(SphericalCoordinate x) => Radius == x.Radius && Azimuth == x.Azimuth && Inclination == x.Inclination;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(SphericalCoordinate x0, SphericalCoordinate x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(SphericalCoordinate x0, SphericalCoordinate x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator SphericalCoordinate((double radius, double azimuth, double inclination) tuple) => new SphericalCoordinate(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (double radius, double azimuth, double inclination)(SphericalCoordinate self) => (self.Radius, self.Azimuth, self.Inclination);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(SphericalCoordinate x, float tolerance = Constants.Tolerance) => Radius.AlmostEquals(x.Radius, tolerance) && Azimuth.AlmostEquals(x.Azimuth, tolerance) && Inclination.AlmostEquals(x.Inclination, tolerance);
        public static SphericalCoordinate Zero = new SphericalCoordinate(default, default, default);
        public static SphericalCoordinate MinValue = new SphericalCoordinate(double.MinValue, double.MinValue, double.MinValue);
        public static SphericalCoordinate MaxValue = new SphericalCoordinate(double.MaxValue, double.MaxValue, double.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public SphericalCoordinate SetRadius(double x) => new SphericalCoordinate(x, Azimuth, Inclination);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public SphericalCoordinate SetAzimuth(double x) => new SphericalCoordinate(Radius, x, Inclination);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public SphericalCoordinate SetInclination(double x) => new SphericalCoordinate(Radius, Azimuth, x);
    }
}