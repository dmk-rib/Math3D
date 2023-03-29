using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct ColorRGB 
        : IEquatable< ColorRGB >
    {
        [DataMember]
        public readonly byte R;
        [DataMember]
        public readonly byte G;
        [DataMember]
        public readonly byte B;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public ColorRGB((byte r, byte g, byte b) tuple) : this(tuple.r, tuple.g, tuple.b) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public ColorRGB(byte r, byte g, byte b) { R = r; G = g; B = b; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static ColorRGB Create(byte r, byte g, byte b) => new ColorRGB(r, g, b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static ColorRGB Create((byte r, byte g, byte b) tuple) => new ColorRGB(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is ColorRGB x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(R.GetHashCode(), G.GetHashCode(), B.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"ColorRGB(R = {R}, G = {G}, B = {B})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out byte r, out byte g, out byte b) {r = R; g = G; b = B; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(ColorRGB x) => R == x.R && G == x.G && B == x.B;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(ColorRGB x0, ColorRGB x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(ColorRGB x0, ColorRGB x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator ColorRGB((byte r, byte g, byte b) tuple) => new ColorRGB(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (byte r, byte g, byte b)(ColorRGB self) => (self.R, self.G, self.B);

        public static ColorRGB Zero = new ColorRGB(default, default, default);
        public static ColorRGB MinValue = new ColorRGB(byte.MinValue, byte.MinValue, byte.MinValue);
        public static ColorRGB MaxValue = new ColorRGB(byte.MaxValue, byte.MaxValue, byte.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public ColorRGB SetR(byte x) => new ColorRGB(x, G, B);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public ColorRGB SetG(byte x) => new ColorRGB(R, x, B);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public ColorRGB SetB(byte x) => new ColorRGB(R, G, x);
    }
}