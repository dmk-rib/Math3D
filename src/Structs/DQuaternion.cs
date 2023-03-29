using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct DQuaternion 
        : IEquatable< DQuaternion >
    {
        [DataMember]
        public readonly double X;
        [DataMember]
        public readonly double Y;
        [DataMember]
        public readonly double Z;
        [DataMember]
        public readonly double W;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DQuaternion((double x, double y, double z, double w) tuple) : this(tuple.x, tuple.y, tuple.z, tuple.w) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DQuaternion(double x, double y, double z, double w) { X = x; Y = y; Z = z; W = w; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DQuaternion Create(double x, double y, double z, double w) => new DQuaternion(x, y, z, w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static DQuaternion Create((double x, double y, double z, double w) tuple) => new DQuaternion(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is DQuaternion x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(X.GetHashCode(), Y.GetHashCode(), Z.GetHashCode(), W.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"DQuaternion(X = {X}, Y = {Y}, Z = {Z}, W = {W})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out double x, out double y, out double z, out double w) {x = X; y = Y; z = Z; w = W; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(DQuaternion x) => X == x.X && Y == x.Y && Z == x.Z && W == x.W;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(DQuaternion x0, DQuaternion x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(DQuaternion x0, DQuaternion x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator DQuaternion((double x, double y, double z, double w) tuple) => new DQuaternion(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (double x, double y, double z, double w)(DQuaternion self) => (self.X, self.Y, self.Z, self.W);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(DQuaternion x, float tolerance = Constants.Tolerance) => X.AlmostEquals(x.X, tolerance) && Y.AlmostEquals(x.Y, tolerance) && Z.AlmostEquals(x.Z, tolerance) && W.AlmostEquals(x.W, tolerance);
        public static DQuaternion Zero = new DQuaternion(default, default, default, default);
        public static DQuaternion MinValue = new DQuaternion(double.MinValue, double.MinValue, double.MinValue, double.MinValue);
        public static DQuaternion MaxValue = new DQuaternion(double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DQuaternion SetX(double x) => new DQuaternion(x, Y, Z, W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DQuaternion SetY(double x) => new DQuaternion(X, x, Z, W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DQuaternion SetZ(double x) => new DQuaternion(X, Y, x, W);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public DQuaternion SetW(double x) => new DQuaternion(X, Y, Z, x);
    }
}