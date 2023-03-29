using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Transform 
        : IEquatable< Transform >
    {
        [DataMember]
        public readonly Vector3 Position;
        [DataMember]
        public readonly Quaternion Orientation;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Transform((Vector3 position, Quaternion orientation) tuple) : this(tuple.position, tuple.orientation) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Transform(Vector3 position, Quaternion orientation) { Position = position; Orientation = orientation; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Transform Create(Vector3 position, Quaternion orientation) => new Transform(position, orientation);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Transform Create((Vector3 position, Quaternion orientation) tuple) => new Transform(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Transform x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(Position.GetHashCode(), Orientation.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"Transform(Position = {Position}, Orientation = {Orientation})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out Vector3 position, out Quaternion orientation) {position = Position; orientation = Orientation; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Transform x) => Position == x.Position && Orientation == x.Orientation;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(Transform x0, Transform x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(Transform x0, Transform x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Transform((Vector3 position, Quaternion orientation) tuple) => new Transform(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (Vector3 position, Quaternion orientation)(Transform self) => (self.Position, self.Orientation);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(Transform x, float tolerance = Constants.Tolerance) => Position.AlmostEquals(x.Position, tolerance) && Orientation.AlmostEquals(x.Orientation, tolerance);
        public static Transform Zero = new Transform(default, default);
        public static Transform MinValue = new Transform(Vector3.MinValue, Quaternion.MinValue);
        public static Transform MaxValue = new Transform(Vector3.MaxValue, Quaternion.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Transform SetPosition(Vector3 x) => new Transform(x, Orientation);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Transform SetOrientation(Quaternion x) => new Transform(Position, x);
    }
}