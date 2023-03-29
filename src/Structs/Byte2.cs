using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Byte2 
        : IEquatable< Byte2 >
    {
        [DataMember]
        public readonly byte X;
        [DataMember]
        public readonly byte Y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Byte2((byte x, byte y) tuple) : this(tuple.x, tuple.y) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Byte2(byte x, byte y) { X = x; Y = y; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Byte2 Create(byte x, byte y) => new Byte2(x, y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Byte2 Create((byte x, byte y) tuple) => new Byte2(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Byte2 x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(X.GetHashCode(), Y.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"Byte2(X = {X}, Y = {Y})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out byte x, out byte y) {x = X; y = Y; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Byte2 x) => X == x.X && Y == x.Y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(Byte2 x0, Byte2 x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(Byte2 x0, Byte2 x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Byte2((byte x, byte y) tuple) => new Byte2(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (byte x, byte y)(Byte2 self) => (self.X, self.Y);

        public static Byte2 Zero = new Byte2(default, default);
        public static Byte2 MinValue = new Byte2(byte.MinValue, byte.MinValue);
        public static Byte2 MaxValue = new Byte2(byte.MaxValue, byte.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Byte2 SetX(byte x) => new Byte2(x, Y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Byte2 SetY(byte x) => new Byte2(X, x);
    }
}