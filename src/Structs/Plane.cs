using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Plane 
        : IEquatable< Plane >
    {
        [DataMember]
        public readonly Vector3 Normal;
        [DataMember]
        public readonly float D;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Plane((Vector3 normal, float d) tuple) : this(tuple.normal, tuple.d) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Plane(Vector3 normal, float d) { Normal = normal; D = d; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Plane Create(Vector3 normal, float d) => new Plane(normal, d);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Plane Create((Vector3 normal, float d) tuple) => new Plane(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Plane x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(Normal.GetHashCode(), D.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"Plane(Normal = {Normal}, D = {D})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out Vector3 normal, out float d) {normal = Normal; d = D; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Plane x) => Normal == x.Normal && D == x.D;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(Plane x0, Plane x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(Plane x0, Plane x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Plane((Vector3 normal, float d) tuple) => new Plane(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (Vector3 normal, float d)(Plane self) => (self.Normal, self.D);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(Plane x, float tolerance = Constants.Tolerance) => Normal.AlmostEquals(x.Normal, tolerance) && D.AlmostEquals(x.D, tolerance);
        public static Plane Zero = new Plane(default, default);
        public static Plane MinValue = new Plane(Vector3.MinValue, float.MinValue);
        public static Plane MaxValue = new Plane(Vector3.MaxValue, float.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Plane SetNormal(Vector3 x) => new Plane(x, D);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Plane SetD(float x) => new Plane(Normal, x);
    }
}