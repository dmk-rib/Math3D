using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Triangle 
        : IEquatable< Triangle >
    {
        [DataMember]
        public readonly Vector3 A;
        [DataMember]
        public readonly Vector3 B;
        [DataMember]
        public readonly Vector3 C;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Triangle((Vector3 a, Vector3 b, Vector3 c) tuple) : this(tuple.a, tuple.b, tuple.c) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Triangle(Vector3 a, Vector3 b, Vector3 c) { A = a; B = b; C = c; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Triangle Create(Vector3 a, Vector3 b, Vector3 c) => new Triangle(a, b, c);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Triangle Create((Vector3 a, Vector3 b, Vector3 c) tuple) => new Triangle(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Triangle x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(A.GetHashCode(), B.GetHashCode(), C.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"Triangle(A = {A}, B = {B}, C = {C})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out Vector3 a, out Vector3 b, out Vector3 c) {a = A; b = B; c = C; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Triangle x) => A == x.A && B == x.B && C == x.C;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(Triangle x0, Triangle x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(Triangle x0, Triangle x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Triangle((Vector3 a, Vector3 b, Vector3 c) tuple) => new Triangle(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (Vector3 a, Vector3 b, Vector3 c)(Triangle self) => (self.A, self.B, self.C);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(Triangle x, float tolerance = Constants.Tolerance) => A.AlmostEquals(x.A, tolerance) && B.AlmostEquals(x.B, tolerance) && C.AlmostEquals(x.C, tolerance);
        public static Triangle Zero = new Triangle(default, default, default);
        public static Triangle MinValue = new Triangle(Vector3.MinValue, Vector3.MinValue, Vector3.MinValue);
        public static Triangle MaxValue = new Triangle(Vector3.MaxValue, Vector3.MaxValue, Vector3.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Triangle SetA(Vector3 x) => new Triangle(x, B, C);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Triangle SetB(Vector3 x) => new Triangle(A, x, C);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Triangle SetC(Vector3 x) => new Triangle(A, B, x);
    }
}