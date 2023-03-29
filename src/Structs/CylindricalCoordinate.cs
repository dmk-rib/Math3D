using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct CylindricalCoordinate 
        : IEquatable< CylindricalCoordinate >
    {
        [DataMember]
        public readonly double Radius;
        [DataMember]
        public readonly double Azimuth;
        [DataMember]
        public readonly double Height;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public CylindricalCoordinate((double radius, double azimuth, double height) tuple) : this(tuple.radius, tuple.azimuth, tuple.height) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public CylindricalCoordinate(double radius, double azimuth, double height) { Radius = radius; Azimuth = azimuth; Height = height; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static CylindricalCoordinate Create(double radius, double azimuth, double height) => new CylindricalCoordinate(radius, azimuth, height);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static CylindricalCoordinate Create((double radius, double azimuth, double height) tuple) => new CylindricalCoordinate(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is CylindricalCoordinate x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(Radius.GetHashCode(), Azimuth.GetHashCode(), Height.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"CylindricalCoordinate(Radius = {Radius}, Azimuth = {Azimuth}, Height = {Height})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out double radius, out double azimuth, out double height) {radius = Radius; azimuth = Azimuth; height = Height; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(CylindricalCoordinate x) => Radius == x.Radius && Azimuth == x.Azimuth && Height == x.Height;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(CylindricalCoordinate x0, CylindricalCoordinate x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(CylindricalCoordinate x0, CylindricalCoordinate x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator CylindricalCoordinate((double radius, double azimuth, double height) tuple) => new CylindricalCoordinate(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (double radius, double azimuth, double height)(CylindricalCoordinate self) => (self.Radius, self.Azimuth, self.Height);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(CylindricalCoordinate x, float tolerance = Constants.Tolerance) => Radius.AlmostEquals(x.Radius, tolerance) && Azimuth.AlmostEquals(x.Azimuth, tolerance) && Height.AlmostEquals(x.Height, tolerance);
        public static CylindricalCoordinate Zero = new CylindricalCoordinate(default, default, default);
        public static CylindricalCoordinate MinValue = new CylindricalCoordinate(double.MinValue, double.MinValue, double.MinValue);
        public static CylindricalCoordinate MaxValue = new CylindricalCoordinate(double.MaxValue, double.MaxValue, double.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public CylindricalCoordinate SetRadius(double x) => new CylindricalCoordinate(x, Azimuth, Height);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public CylindricalCoordinate SetAzimuth(double x) => new CylindricalCoordinate(Radius, x, Height);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public CylindricalCoordinate SetHeight(double x) => new CylindricalCoordinate(Radius, Azimuth, x);
    }
}