using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct DRay 
        : IEquatable< DRay >
    {
        [DataMember]
        public readonly DVector3 Position;
        [DataMember]
        public readonly DVector3 Direction;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DRay((DVector3 position, DVector3 direction) tuple) : this(tuple.position, tuple.direction) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DRay(DVector3 position, DVector3 direction) { Position = position; Direction = direction; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DRay Create(DVector3 position, DVector3 direction) => new DRay(position, direction);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DRay Create((DVector3 position, DVector3 direction) tuple) => new DRay(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is DRay x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(Position.GetHashCode(), Direction.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"DRay(Position = {Position}, Direction = {Direction})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out DVector3 position, out DVector3 direction) {position = Position; direction = Direction; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(DRay x) => Position == x.Position && Direction == x.Direction;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(DRay x0, DRay x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(DRay x0, DRay x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator DRay((DVector3 position, DVector3 direction) tuple) => new DRay(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (DVector3 position, DVector3 direction)(DRay self) => (self.Position, self.Direction);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(DRay x, float tolerance = Constants.Tolerance) => Position.AlmostEquals(x.Position, tolerance) && Direction.AlmostEquals(x.Direction, tolerance);
        public static DRay Zero = new DRay(default, default);
        public static DRay MinValue = new DRay(DVector3.MinValue, DVector3.MinValue);
        public static DRay MaxValue = new DRay(DVector3.MaxValue, DVector3.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DRay SetPosition(DVector3 x) => new DRay(x, Direction);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DRay SetDirection(DVector3 x) => new DRay(Position, x);
    }
}