using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct ColorHDR 
        : IEquatable< ColorHDR >
    {
        [DataMember]
        public readonly float R;
        [DataMember]
        public readonly float G;
        [DataMember]
        public readonly float B;
        [DataMember]
        public readonly float A;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public ColorHDR((float r, float g, float b, float a) tuple) : this(tuple.r, tuple.g, tuple.b, tuple.a) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public ColorHDR(float r, float g, float b, float a) { R = r; G = g; B = b; A = a; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static ColorHDR Create(float r, float g, float b, float a) => new ColorHDR(r, g, b, a);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static ColorHDR Create((float r, float g, float b, float a) tuple) => new ColorHDR(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is ColorHDR x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(R.GetHashCode(), G.GetHashCode(), B.GetHashCode(), A.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"ColorHDR(R = {R}, G = {G}, B = {B}, A = {A})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out float r, out float g, out float b, out float a) {r = R; g = G; b = B; a = A; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(ColorHDR x) => R == x.R && G == x.G && B == x.B && A == x.A;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(ColorHDR x0, ColorHDR x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(ColorHDR x0, ColorHDR x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator ColorHDR((float r, float g, float b, float a) tuple) => new ColorHDR(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (float r, float g, float b, float a)(ColorHDR self) => (self.R, self.G, self.B, self.A);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(ColorHDR x, float tolerance = Constants.Tolerance) => R.AlmostEquals(x.R, tolerance) && G.AlmostEquals(x.G, tolerance) && B.AlmostEquals(x.B, tolerance) && A.AlmostEquals(x.A, tolerance);
        public static ColorHDR Zero = new ColorHDR(default, default, default, default);
        public static ColorHDR MinValue = new ColorHDR(float.MinValue, float.MinValue, float.MinValue, float.MinValue);
        public static ColorHDR MaxValue = new ColorHDR(float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public ColorHDR SetR(float x) => new ColorHDR(x, G, B, A);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public ColorHDR SetG(float x) => new ColorHDR(R, x, B, A);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public ColorHDR SetB(float x) => new ColorHDR(R, G, x, A);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public ColorHDR SetA(float x) => new ColorHDR(R, G, B, x);
    }
}