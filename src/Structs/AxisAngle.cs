using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct AxisAngle 
        : IEquatable< AxisAngle >
    {
        [DataMember]
        public readonly DVector3 Axis;
        [DataMember]
        public readonly double Angle;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public AxisAngle((DVector3 axis, double angle) tuple) : this(tuple.axis, tuple.angle) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public AxisAngle(DVector3 axis, double angle) { Axis = axis; Angle = angle; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static AxisAngle Create(DVector3 axis, double angle) => new AxisAngle(axis, angle);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static AxisAngle Create((DVector3 axis, double angle) tuple) => new AxisAngle(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is AxisAngle x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(Axis.GetHashCode(), Angle.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"AxisAngle(Axis = {Axis}, Angle = {Angle})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out DVector3 axis, out double angle) {axis = Axis; angle = Angle; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(AxisAngle x) => Axis == x.Axis && Angle == x.Angle;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(AxisAngle x0, AxisAngle x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(AxisAngle x0, AxisAngle x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator AxisAngle((DVector3 axis, double angle) tuple) => new AxisAngle(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (DVector3 axis, double angle)(AxisAngle self) => (self.Axis, self.Angle);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(AxisAngle x, float tolerance = Constants.Tolerance) => Axis.AlmostEquals(x.Axis, tolerance) && Angle.AlmostEquals(x.Angle, tolerance);
        public static AxisAngle Zero = new AxisAngle(default, default);
        public static AxisAngle MinValue = new AxisAngle(DVector3.MinValue, double.MinValue);
        public static AxisAngle MaxValue = new AxisAngle(DVector3.MaxValue, double.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public AxisAngle SetAxis(DVector3 x) => new AxisAngle(x, Angle);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public AxisAngle SetAngle(double x) => new AxisAngle(Axis, x);
    }
}