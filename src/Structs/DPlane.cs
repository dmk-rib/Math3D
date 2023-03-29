using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct DPlane 
        : IEquatable< DPlane >
    {
        [DataMember]
        public readonly DVector3 Normal;
        [DataMember]
        public readonly double D;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DPlane((DVector3 normal, double d) tuple) : this(tuple.normal, tuple.d) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DPlane(DVector3 normal, double d) { Normal = normal; D = d; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DPlane Create(DVector3 normal, double d) => new DPlane(normal, d);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DPlane Create((DVector3 normal, double d) tuple) => new DPlane(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is DPlane x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(Normal.GetHashCode(), D.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"DPlane(Normal = {Normal}, D = {D})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out DVector3 normal, out double d) {normal = Normal; d = D; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(DPlane x) => Normal == x.Normal && D == x.D;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(DPlane x0, DPlane x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(DPlane x0, DPlane x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator DPlane((DVector3 normal, double d) tuple) => new DPlane(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (DVector3 normal, double d)(DPlane self) => (self.Normal, self.D);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(DPlane x, float tolerance = Constants.Tolerance) => Normal.AlmostEquals(x.Normal, tolerance) && D.AlmostEquals(x.D, tolerance);
        public static DPlane Zero = new DPlane(default, default);
        public static DPlane MinValue = new DPlane(DVector3.MinValue, double.MinValue);
        public static DPlane MaxValue = new DPlane(DVector3.MaxValue, double.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DPlane SetNormal(DVector3 x) => new DPlane(x, D);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DPlane SetD(double x) => new DPlane(Normal, x);
    }
}