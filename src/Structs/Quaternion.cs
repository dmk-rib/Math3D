using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Quaternion 
        : IEquatable< Quaternion >
    {
        [DataMember]
        public readonly float X;
        [DataMember]
        public readonly float Y;
        [DataMember]
        public readonly float Z;
        [DataMember]
        public readonly float W;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Quaternion((float x, float y, float z, float w) tuple) : this(tuple.x, tuple.y, tuple.z, tuple.w) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Quaternion(float x, float y, float z, float w) { X = x; Y = y; Z = z; W = w; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Quaternion Create(float x, float y, float z, float w) => new Quaternion(x, y, z, w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Quaternion Create((float x, float y, float z, float w) tuple) => new Quaternion(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Quaternion x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(X.GetHashCode(), Y.GetHashCode(), Z.GetHashCode(), W.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"Quaternion(X = {X}, Y = {Y}, Z = {Z}, W = {W})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out float x, out float y, out float z, out float w) {x = X; y = Y; z = Z; w = W; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Quaternion x) => X == x.X && Y == x.Y && Z == x.Z && W == x.W;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(Quaternion x0, Quaternion x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(Quaternion x0, Quaternion x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Quaternion((float x, float y, float z, float w) tuple) => new Quaternion(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (float x, float y, float z, float w)(Quaternion self) => (self.X, self.Y, self.Z, self.W);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(Quaternion x, float tolerance = Constants.Tolerance) => X.AlmostEquals(x.X, tolerance) && Y.AlmostEquals(x.Y, tolerance) && Z.AlmostEquals(x.Z, tolerance) && W.AlmostEquals(x.W, tolerance);
        public static Quaternion Zero = new Quaternion(default, default, default, default);
        public static Quaternion MinValue = new Quaternion(float.MinValue, float.MinValue, float.MinValue, float.MinValue);
        public static Quaternion MaxValue = new Quaternion(float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Quaternion SetX(float x) => new Quaternion(x, Y, Z, W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Quaternion SetY(float x) => new Quaternion(X, x, Z, W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Quaternion SetZ(float x) => new Quaternion(X, Y, x, W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Quaternion SetW(float x) => new Quaternion(X, Y, Z, x);
    }
}