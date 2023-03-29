using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Quad 
        : IEquatable< Quad >
    {
        [DataMember]
        public readonly Vector3 A;
        [DataMember]
        public readonly Vector3 B;
        [DataMember]
        public readonly Vector3 C;
        [DataMember]
        public readonly Vector3 D;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Quad((Vector3 a, Vector3 b, Vector3 c, Vector3 d) tuple) : this(tuple.a, tuple.b, tuple.c, tuple.d) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Quad(Vector3 a, Vector3 b, Vector3 c, Vector3 d) { A = a; B = b; C = c; D = d; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Quad Create(Vector3 a, Vector3 b, Vector3 c, Vector3 d) => new Quad(a, b, c, d);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Quad Create((Vector3 a, Vector3 b, Vector3 c, Vector3 d) tuple) => new Quad(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Quad x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(A.GetHashCode(), B.GetHashCode(), C.GetHashCode(), D.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"Quad(A = {A}, B = {B}, C = {C}, D = {D})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out Vector3 a, out Vector3 b, out Vector3 c, out Vector3 d) {a = A; b = B; c = C; d = D; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Quad x) => A == x.A && B == x.B && C == x.C && D == x.D;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(Quad x0, Quad x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(Quad x0, Quad x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Quad((Vector3 a, Vector3 b, Vector3 c, Vector3 d) tuple) => new Quad(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (Vector3 a, Vector3 b, Vector3 c, Vector3 d)(Quad self) => (self.A, self.B, self.C, self.D);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(Quad x, float tolerance = Constants.Tolerance) => A.AlmostEquals(x.A, tolerance) && B.AlmostEquals(x.B, tolerance) && C.AlmostEquals(x.C, tolerance) && D.AlmostEquals(x.D, tolerance);
        public static Quad Zero = new Quad(default, default, default, default);
        public static Quad MinValue = new Quad(Vector3.MinValue, Vector3.MinValue, Vector3.MinValue, Vector3.MinValue);
        public static Quad MaxValue = new Quad(Vector3.MaxValue, Vector3.MaxValue, Vector3.MaxValue, Vector3.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Quad SetA(Vector3 x) => new Quad(x, B, C, D);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Quad SetB(Vector3 x) => new Quad(A, x, C, D);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Quad SetC(Vector3 x) => new Quad(A, B, x, D);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Quad SetD(Vector3 x) => new Quad(A, B, C, x);
    }
}