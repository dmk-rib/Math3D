using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct DSphere 
        : IEquatable< DSphere >
    {
        [DataMember]
        public readonly DVector3 Center;
        [DataMember]
        public readonly double Radius;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DSphere((DVector3 center, double radius) tuple) : this(tuple.center, tuple.radius) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DSphere(DVector3 center, double radius) { Center = center; Radius = radius; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DSphere Create(DVector3 center, double radius) => new DSphere(center, radius);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DSphere Create((DVector3 center, double radius) tuple) => new DSphere(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is DSphere x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(Center.GetHashCode(), Radius.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"DSphere(Center = {Center}, Radius = {Radius})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out DVector3 center, out double radius) {center = Center; radius = Radius; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(DSphere x) => Center == x.Center && Radius == x.Radius;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(DSphere x0, DSphere x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(DSphere x0, DSphere x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator DSphere((DVector3 center, double radius) tuple) => new DSphere(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (DVector3 center, double radius)(DSphere self) => (self.Center, self.Radius);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(DSphere x, float tolerance = Constants.Tolerance) => Center.AlmostEquals(x.Center, tolerance) && Radius.AlmostEquals(x.Radius, tolerance);
        public static DSphere Zero = new DSphere(default, default);
        public static DSphere MinValue = new DSphere(DVector3.MinValue, double.MinValue);
        public static DSphere MaxValue = new DSphere(DVector3.MaxValue, double.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DSphere SetCenter(DVector3 x) => new DSphere(x, Radius);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DSphere SetRadius(double x) => new DSphere(Center, x);
    }
}