using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Byte4 
        : IEquatable< Byte4 >
    {
        [DataMember]
        public readonly byte X;
        [DataMember]
        public readonly byte Y;
        [DataMember]
        public readonly byte Z;
        [DataMember]
        public readonly byte W;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Byte4((byte x, byte y, byte z, byte w) tuple) : this(tuple.x, tuple.y, tuple.z, tuple.w) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Byte4(byte x, byte y, byte z, byte w) { X = x; Y = y; Z = z; W = w; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Byte4 Create(byte x, byte y, byte z, byte w) => new Byte4(x, y, z, w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Byte4 Create((byte x, byte y, byte z, byte w) tuple) => new Byte4(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Byte4 x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(X.GetHashCode(), Y.GetHashCode(), Z.GetHashCode(), W.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"Byte4(X = {X}, Y = {Y}, Z = {Z}, W = {W})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out byte x, out byte y, out byte z, out byte w) {x = X; y = Y; z = Z; w = W; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Byte4 x) => X == x.X && Y == x.Y && Z == x.Z && W == x.W;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(Byte4 x0, Byte4 x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(Byte4 x0, Byte4 x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Byte4((byte x, byte y, byte z, byte w) tuple) => new Byte4(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (byte x, byte y, byte z, byte w)(Byte4 self) => (self.X, self.Y, self.Z, self.W);

        public static Byte4 Zero = new Byte4(default, default, default, default);
        public static Byte4 MinValue = new Byte4(byte.MinValue, byte.MinValue, byte.MinValue, byte.MinValue);
        public static Byte4 MaxValue = new Byte4(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Byte4 SetX(byte x) => new Byte4(x, Y, Z, W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Byte4 SetY(byte x) => new Byte4(X, x, Z, W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Byte4 SetZ(byte x) => new Byte4(X, Y, x, W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Byte4 SetW(byte x) => new Byte4(X, Y, Z, x);
    }
}