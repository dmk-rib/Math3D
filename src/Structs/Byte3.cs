using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Byte3 
        : IEquatable< Byte3 >
    {
        [DataMember]
        public readonly byte X;
        [DataMember]
        public readonly byte Y;
        [DataMember]
        public readonly byte Z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Byte3((byte x, byte y, byte z) tuple) : this(tuple.x, tuple.y, tuple.z) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Byte3(byte x, byte y, byte z) { X = x; Y = y; Z = z; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Byte3 Create(byte x, byte y, byte z) => new Byte3(x, y, z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Byte3 Create((byte x, byte y, byte z) tuple) => new Byte3(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Byte3 x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(X.GetHashCode(), Y.GetHashCode(), Z.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"Byte3(X = {X}, Y = {Y}, Z = {Z})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out byte x, out byte y, out byte z) {x = X; y = Y; z = Z; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Byte3 x) => X == x.X && Y == x.Y && Z == x.Z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(Byte3 x0, Byte3 x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(Byte3 x0, Byte3 x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Byte3((byte x, byte y, byte z) tuple) => new Byte3(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (byte x, byte y, byte z)(Byte3 self) => (self.X, self.Y, self.Z);

        public static Byte3 Zero = new Byte3(default, default, default);
        public static Byte3 MinValue = new Byte3(byte.MinValue, byte.MinValue, byte.MinValue);
        public static Byte3 MaxValue = new Byte3(byte.MaxValue, byte.MaxValue, byte.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Byte3 SetX(byte x) => new Byte3(x, Y, Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Byte3 SetY(byte x) => new Byte3(X, x, Z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Byte3 SetZ(byte x) => new Byte3(X, Y, x);
    }
}