using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Line2D 
        : IEquatable< Line2D >
    {
        [DataMember]
        public readonly Vector2 A;
        [DataMember]
        public readonly Vector2 B;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Line2D((Vector2 a, Vector2 b) tuple) : this(tuple.a, tuple.b) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Line2D(Vector2 a, Vector2 b) { A = a; B = b; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Line2D Create(Vector2 a, Vector2 b) => new Line2D(a, b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Line2D Create((Vector2 a, Vector2 b) tuple) => new Line2D(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Line2D x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(A.GetHashCode(), B.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"Line2D(A = {A}, B = {B})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out Vector2 a, out Vector2 b) {a = A; b = B; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Line2D x) => A == x.A && B == x.B;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(Line2D x0, Line2D x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(Line2D x0, Line2D x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Line2D((Vector2 a, Vector2 b) tuple) => new Line2D(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (Vector2 a, Vector2 b)(Line2D self) => (self.A, self.B);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(Line2D x, float tolerance = Constants.Tolerance) => A.AlmostEquals(x.A, tolerance) && B.AlmostEquals(x.B, tolerance);
        public static Line2D Zero = new Line2D(default, default);
        public static Line2D MinValue = new Line2D(Vector2.MinValue, Vector2.MinValue);
        public static Line2D MaxValue = new Line2D(Vector2.MaxValue, Vector2.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Line2D SetA(Vector2 x) => new Line2D(x, B);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Line2D SetB(Vector2 x) => new Line2D(A, x);
    }
}