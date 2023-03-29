using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Triangle2D 
        : IEquatable< Triangle2D >
    {
        [DataMember]
        public readonly Vector2 A;
        [DataMember]
        public readonly Vector2 B;
        [DataMember]
        public readonly Vector2 C;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Triangle2D((Vector2 a, Vector2 b, Vector2 c) tuple) : this(tuple.a, tuple.b, tuple.c) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Triangle2D(Vector2 a, Vector2 b, Vector2 c) { A = a; B = b; C = c; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Triangle2D Create(Vector2 a, Vector2 b, Vector2 c) => new Triangle2D(a, b, c);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Triangle2D Create((Vector2 a, Vector2 b, Vector2 c) tuple) => new Triangle2D(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Triangle2D x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(A.GetHashCode(), B.GetHashCode(), C.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"Triangle2D(A = {A}, B = {B}, C = {C})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out Vector2 a, out Vector2 b, out Vector2 c) {a = A; b = B; c = C; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Triangle2D x) => A == x.A && B == x.B && C == x.C;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(Triangle2D x0, Triangle2D x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(Triangle2D x0, Triangle2D x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Triangle2D((Vector2 a, Vector2 b, Vector2 c) tuple) => new Triangle2D(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (Vector2 a, Vector2 b, Vector2 c)(Triangle2D self) => (self.A, self.B, self.C);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(Triangle2D x, float tolerance = Constants.Tolerance) => A.AlmostEquals(x.A, tolerance) && B.AlmostEquals(x.B, tolerance) && C.AlmostEquals(x.C, tolerance);
        public static Triangle2D Zero = new Triangle2D(default, default, default);
        public static Triangle2D MinValue = new Triangle2D(Vector2.MinValue, Vector2.MinValue, Vector2.MinValue);
        public static Triangle2D MaxValue = new Triangle2D(Vector2.MaxValue, Vector2.MaxValue, Vector2.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Triangle2D SetA(Vector2 x) => new Triangle2D(x, B, C);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Triangle2D SetB(Vector2 x) => new Triangle2D(A, x, C);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Triangle2D SetC(Vector2 x) => new Triangle2D(A, B, x);
    }
}