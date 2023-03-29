using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Line 
        : IEquatable< Line >
    {
        [DataMember]
        public readonly Vector3 A;
        [DataMember]
        public readonly Vector3 B;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Line((Vector3 a, Vector3 b) tuple) : this(tuple.a, tuple.b) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Line(Vector3 a, Vector3 b) { A = a; B = b; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Line Create(Vector3 a, Vector3 b) => new Line(a, b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Line Create((Vector3 a, Vector3 b) tuple) => new Line(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Line x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(A.GetHashCode(), B.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"Line(A = {A}, B = {B})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out Vector3 a, out Vector3 b) {a = A; b = B; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Line x) => A == x.A && B == x.B;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(Line x0, Line x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(Line x0, Line x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Line((Vector3 a, Vector3 b) tuple) => new Line(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (Vector3 a, Vector3 b)(Line self) => (self.A, self.B);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(Line x, float tolerance = Constants.Tolerance) => A.AlmostEquals(x.A, tolerance) && B.AlmostEquals(x.B, tolerance);
        public static Line Zero = new Line(default, default);
        public static Line MinValue = new Line(Vector3.MinValue, Vector3.MinValue);
        public static Line MaxValue = new Line(Vector3.MaxValue, Vector3.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Line SetA(Vector3 x) => new Line(x, B);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Line SetB(Vector3 x) => new Line(A, x);
    }
}