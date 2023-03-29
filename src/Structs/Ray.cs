using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Ray 
        : IEquatable< Ray >
    {
        [DataMember]
        public readonly Vector3 Position;
        [DataMember]
        public readonly Vector3 Direction;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Ray((Vector3 position, Vector3 direction) tuple) : this(tuple.position, tuple.direction) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Ray(Vector3 position, Vector3 direction) { Position = position; Direction = direction; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Ray Create(Vector3 position, Vector3 direction) => new Ray(position, direction);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Ray Create((Vector3 position, Vector3 direction) tuple) => new Ray(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Ray x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(Position.GetHashCode(), Direction.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"Ray(Position = {Position}, Direction = {Direction})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out Vector3 position, out Vector3 direction) {position = Position; direction = Direction; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Ray x) => Position == x.Position && Direction == x.Direction;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(Ray x0, Ray x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(Ray x0, Ray x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Ray((Vector3 position, Vector3 direction) tuple) => new Ray(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (Vector3 position, Vector3 direction)(Ray self) => (self.Position, self.Direction);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(Ray x, float tolerance = Constants.Tolerance) => Position.AlmostEquals(x.Position, tolerance) && Direction.AlmostEquals(x.Direction, tolerance);
        public static Ray Zero = new Ray(default, default);
        public static Ray MinValue = new Ray(Vector3.MinValue, Vector3.MinValue);
        public static Ray MaxValue = new Ray(Vector3.MaxValue, Vector3.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Ray SetPosition(Vector3 x) => new Ray(x, Direction);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Ray SetDirection(Vector3 x) => new Ray(Position, x);
    }
}