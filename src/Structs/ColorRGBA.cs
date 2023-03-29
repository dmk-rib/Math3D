using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct ColorRGBA 
        : IEquatable< ColorRGBA >
    {
        [DataMember]
        public readonly byte R;
        [DataMember]
        public readonly byte G;
        [DataMember]
        public readonly byte B;
        [DataMember]
        public readonly byte A;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public ColorRGBA((byte r, byte g, byte b, byte a) tuple) : this(tuple.r, tuple.g, tuple.b, tuple.a) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public ColorRGBA(byte r, byte g, byte b, byte a) { R = r; G = g; B = b; A = a; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static ColorRGBA Create(byte r, byte g, byte b, byte a) => new ColorRGBA(r, g, b, a);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static ColorRGBA Create((byte r, byte g, byte b, byte a) tuple) => new ColorRGBA(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is ColorRGBA x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(R.GetHashCode(), G.GetHashCode(), B.GetHashCode(), A.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"ColorRGBA(R = {R}, G = {G}, B = {B}, A = {A})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out byte r, out byte g, out byte b, out byte a) {r = R; g = G; b = B; a = A; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(ColorRGBA x) => R == x.R && G == x.G && B == x.B && A == x.A;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(ColorRGBA x0, ColorRGBA x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(ColorRGBA x0, ColorRGBA x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator ColorRGBA((byte r, byte g, byte b, byte a) tuple) => new ColorRGBA(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (byte r, byte g, byte b, byte a)(ColorRGBA self) => (self.R, self.G, self.B, self.A);

        public static ColorRGBA Zero = new ColorRGBA(default, default, default, default);
        public static ColorRGBA MinValue = new ColorRGBA(byte.MinValue, byte.MinValue, byte.MinValue, byte.MinValue);
        public static ColorRGBA MaxValue = new ColorRGBA(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public ColorRGBA SetR(byte x) => new ColorRGBA(x, G, B, A);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public ColorRGBA SetG(byte x) => new ColorRGBA(R, x, B, A);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public ColorRGBA SetB(byte x) => new ColorRGBA(R, G, x, A);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public ColorRGBA SetA(byte x) => new ColorRGBA(R, G, B, x);
    }
}