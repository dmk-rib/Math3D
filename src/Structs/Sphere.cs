using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Sphere 
        : IEquatable< Sphere >
    {
        [DataMember]
        public readonly Vector3 Center;
        [DataMember]
        public readonly float Radius;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Sphere((Vector3 center, float radius) tuple) : this(tuple.center, tuple.radius) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Sphere(Vector3 center, float radius) { Center = center; Radius = radius; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Sphere Create(Vector3 center, float radius) => new Sphere(center, radius);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Sphere Create((Vector3 center, float radius) tuple) => new Sphere(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Sphere x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(Center.GetHashCode(), Radius.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"Sphere(Center = {Center}, Radius = {Radius})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out Vector3 center, out float radius) {center = Center; radius = Radius; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Sphere x) => Center == x.Center && Radius == x.Radius;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(Sphere x0, Sphere x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(Sphere x0, Sphere x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Sphere((Vector3 center, float radius) tuple) => new Sphere(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (Vector3 center, float radius)(Sphere self) => (self.Center, self.Radius);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(Sphere x, float tolerance = Constants.Tolerance) => Center.AlmostEquals(x.Center, tolerance) && Radius.AlmostEquals(x.Radius, tolerance);
        public static Sphere Zero = new Sphere(default, default);
        public static Sphere MinValue = new Sphere(Vector3.MinValue, float.MinValue);
        public static Sphere MaxValue = new Sphere(Vector3.MaxValue, float.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Sphere SetCenter(Vector3 x) => new Sphere(x, Radius);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Sphere SetRadius(float x) => new Sphere(Center, x);
    }
}