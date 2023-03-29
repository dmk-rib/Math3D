using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct PolarCoordinate 
        : IEquatable< PolarCoordinate >
    {
        [DataMember]
        public readonly double Radius;
        [DataMember]
        public readonly double Azimuth;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public PolarCoordinate((double radius, double azimuth) tuple) : this(tuple.radius, tuple.azimuth) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public PolarCoordinate(double radius, double azimuth) { Radius = radius; Azimuth = azimuth; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static PolarCoordinate Create(double radius, double azimuth) => new PolarCoordinate(radius, azimuth);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static PolarCoordinate Create((double radius, double azimuth) tuple) => new PolarCoordinate(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is PolarCoordinate x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(Radius.GetHashCode(), Azimuth.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"PolarCoordinate(Radius = {Radius}, Azimuth = {Azimuth})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out double radius, out double azimuth) {radius = Radius; azimuth = Azimuth; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(PolarCoordinate x) => Radius == x.Radius && Azimuth == x.Azimuth;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(PolarCoordinate x0, PolarCoordinate x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(PolarCoordinate x0, PolarCoordinate x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator PolarCoordinate((double radius, double azimuth) tuple) => new PolarCoordinate(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (double radius, double azimuth)(PolarCoordinate self) => (self.Radius, self.Azimuth);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(PolarCoordinate x, float tolerance = Constants.Tolerance) => Radius.AlmostEquals(x.Radius, tolerance) && Azimuth.AlmostEquals(x.Azimuth, tolerance);
        public static PolarCoordinate Zero = new PolarCoordinate(default, default);
        public static PolarCoordinate MinValue = new PolarCoordinate(double.MinValue, double.MinValue);
        public static PolarCoordinate MaxValue = new PolarCoordinate(double.MaxValue, double.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public PolarCoordinate SetRadius(double x) => new PolarCoordinate(x, Azimuth);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public PolarCoordinate SetAzimuth(double x) => new PolarCoordinate(Radius, x);
    }
}