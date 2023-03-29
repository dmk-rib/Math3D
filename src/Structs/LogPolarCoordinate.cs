using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct LogPolarCoordinate 
        : IEquatable< LogPolarCoordinate >
    {
        [DataMember]
        public readonly double Rho;
        [DataMember]
        public readonly double Azimuth;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public LogPolarCoordinate((double rho, double azimuth) tuple) : this(tuple.rho, tuple.azimuth) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public LogPolarCoordinate(double rho, double azimuth) { Rho = rho; Azimuth = azimuth; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static LogPolarCoordinate Create(double rho, double azimuth) => new LogPolarCoordinate(rho, azimuth);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static LogPolarCoordinate Create((double rho, double azimuth) tuple) => new LogPolarCoordinate(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is LogPolarCoordinate x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(Rho.GetHashCode(), Azimuth.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"LogPolarCoordinate(Rho = {Rho}, Azimuth = {Azimuth})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out double rho, out double azimuth) {rho = Rho; azimuth = Azimuth; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(LogPolarCoordinate x) => Rho == x.Rho && Azimuth == x.Azimuth;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(LogPolarCoordinate x0, LogPolarCoordinate x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(LogPolarCoordinate x0, LogPolarCoordinate x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator LogPolarCoordinate((double rho, double azimuth) tuple) => new LogPolarCoordinate(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (double rho, double azimuth)(LogPolarCoordinate self) => (self.Rho, self.Azimuth);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(LogPolarCoordinate x, float tolerance = Constants.Tolerance) => Rho.AlmostEquals(x.Rho, tolerance) && Azimuth.AlmostEquals(x.Azimuth, tolerance);
        public static LogPolarCoordinate Zero = new LogPolarCoordinate(default, default);
        public static LogPolarCoordinate MinValue = new LogPolarCoordinate(double.MinValue, double.MinValue);
        public static LogPolarCoordinate MaxValue = new LogPolarCoordinate(double.MaxValue, double.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public LogPolarCoordinate SetRho(double x) => new LogPolarCoordinate(x, Azimuth);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public LogPolarCoordinate SetAzimuth(double x) => new LogPolarCoordinate(Rho, x);
    }
}