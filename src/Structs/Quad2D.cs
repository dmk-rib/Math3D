using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Quad2D 
        : IEquatable< Quad2D >
    {
        [DataMember]
        public readonly Vector2 A;
        [DataMember]
        public readonly Vector2 B;
        [DataMember]
        public readonly Vector2 C;
        [DataMember]
        public readonly Vector2 D;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Quad2D((Vector2 a, Vector2 b, Vector2 c, Vector2 d) tuple) : this(tuple.a, tuple.b, tuple.c, tuple.d) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Quad2D(Vector2 a, Vector2 b, Vector2 c, Vector2 d) { A = a; B = b; C = c; D = d; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Quad2D Create(Vector2 a, Vector2 b, Vector2 c, Vector2 d) => new Quad2D(a, b, c, d);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Quad2D Create((Vector2 a, Vector2 b, Vector2 c, Vector2 d) tuple) => new Quad2D(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Quad2D x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(A.GetHashCode(), B.GetHashCode(), C.GetHashCode(), D.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"Quad2D(A = {A}, B = {B}, C = {C}, D = {D})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out Vector2 a, out Vector2 b, out Vector2 c, out Vector2 d) {a = A; b = B; c = C; d = D; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Quad2D x) => A == x.A && B == x.B && C == x.C && D == x.D;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(Quad2D x0, Quad2D x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(Quad2D x0, Quad2D x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Quad2D((Vector2 a, Vector2 b, Vector2 c, Vector2 d) tuple) => new Quad2D(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (Vector2 a, Vector2 b, Vector2 c, Vector2 d)(Quad2D self) => (self.A, self.B, self.C, self.D);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(Quad2D x, float tolerance = Constants.Tolerance) => A.AlmostEquals(x.A, tolerance) && B.AlmostEquals(x.B, tolerance) && C.AlmostEquals(x.C, tolerance) && D.AlmostEquals(x.D, tolerance);
        public static Quad2D Zero = new Quad2D(default, default, default, default);
        public static Quad2D MinValue = new Quad2D(Vector2.MinValue, Vector2.MinValue, Vector2.MinValue, Vector2.MinValue);
        public static Quad2D MaxValue = new Quad2D(Vector2.MaxValue, Vector2.MaxValue, Vector2.MaxValue, Vector2.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Quad2D SetA(Vector2 x) => new Quad2D(x, B, C, D);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Quad2D SetB(Vector2 x) => new Quad2D(A, x, C, D);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Quad2D SetC(Vector2 x) => new Quad2D(A, B, x, D);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Quad2D SetD(Vector2 x) => new Quad2D(A, B, C, x);
    }
}