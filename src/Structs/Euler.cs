using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vim.Math3d
{
    [StructLayout(LayoutKind.Sequential, Pack=4)]
    [DataContract]
    public readonly partial struct Euler 
        : IEquatable< Euler >
            , IComparable< Euler >
    {
        [DataMember]
        public readonly float Yaw;
        [DataMember]
        public readonly float Pitch;
        [DataMember]
        public readonly float Roll;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Euler((float yaw, float pitch, float roll) tuple) : this(tuple.yaw, tuple.pitch, tuple.roll) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Euler(float yaw, float pitch, float roll) { Yaw = yaw; Pitch = pitch; Roll = roll; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Euler Create(float yaw, float pitch, float roll) => new Euler(yaw, pitch, roll);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Euler Create((float yaw, float pitch, float roll) tuple) => new Euler(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override bool Equals(object obj) => obj is Euler x && Equals(x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override int GetHashCode() => Hash.Combine(Yaw.GetHashCode(), Pitch.GetHashCode(), Roll.GetHashCode());
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public override string ToString() => $"Euler(Yaw = {Yaw}, Pitch = {Pitch}, Roll = {Roll})";
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public void Deconstruct(out float yaw, out float pitch, out float roll) {yaw = Yaw; pitch = Pitch; roll = Roll; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool Equals(Euler x) => Yaw == x.Yaw && Pitch == x.Pitch && Roll == x.Roll;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator ==(Euler x0, Euler x1) => x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator !=(Euler x0, Euler x1) => !x0.Equals(x1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator Euler((float yaw, float pitch, float roll) tuple) => new Euler(tuple);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static implicit operator (float yaw, float pitch, float roll)(Euler self) => (self.Yaw, self.Pitch, self.Roll);

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostEquals(Euler x, float tolerance = Constants.Tolerance) => Yaw.AlmostEquals(x.Yaw, tolerance) && Pitch.AlmostEquals(x.Pitch, tolerance) && Roll.AlmostEquals(x.Roll, tolerance);
        public static Euler Zero = new Euler(default, default, default);
        public static Euler MinValue = new Euler(float.MinValue, float.MinValue, float.MinValue);
        public static Euler MaxValue = new Euler(float.MaxValue, float.MaxValue, float.MaxValue);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Euler SetYaw(float x) => new Euler(x, Pitch, Roll);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Euler SetPitch(float x) => new Euler(Yaw, x, Roll);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Euler SetRoll(float x) => new Euler(Yaw, Pitch, x);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Euler operator +(Euler value1, Euler value2) => new Euler(value1.Yaw + value2.Yaw,value1.Pitch + value2.Pitch,value1.Roll + value2.Roll);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Euler operator +(Euler value1, float value2) => new Euler(value1.Yaw + value2,value1.Pitch + value2,value1.Roll + value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Euler operator +(float value1, Euler value2) => new Euler(value1 + value2.Yaw,value1 + value2.Pitch,value1 + value2.Roll);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Euler operator -(Euler value1, Euler value2) => new Euler(value1.Yaw - value2.Yaw,value1.Pitch - value2.Pitch,value1.Roll - value2.Roll);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Euler operator -(Euler value1, float value2) => new Euler(value1.Yaw - value2,value1.Pitch - value2,value1.Roll - value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Euler operator -(float value1, Euler value2) => new Euler(value1 - value2.Yaw,value1 - value2.Pitch,value1 - value2.Roll);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Euler operator *(Euler value1, Euler value2) => new Euler(value1.Yaw * value2.Yaw,value1.Pitch * value2.Pitch,value1.Roll * value2.Roll);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Euler operator *(Euler value1, float value2) => new Euler(value1.Yaw * value2,value1.Pitch * value2,value1.Roll * value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Euler operator *(float value1, Euler value2) => new Euler(value1 * value2.Yaw,value1 * value2.Pitch,value1 * value2.Roll);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Euler operator /(Euler value1, Euler value2) => new Euler(value1.Yaw / value2.Yaw,value1.Pitch / value2.Pitch,value1.Roll / value2.Roll);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Euler operator /(Euler value1, float value2) => new Euler(value1.Yaw / value2,value1.Pitch / value2,value1.Roll / value2);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Euler operator /(float value1, Euler value2) => new Euler(value1 / value2.Yaw,value1 / value2.Pitch,value1 / value2.Roll);
        public static Euler One = new Euler(1f);
        public static Euler UnitYaw = Zero.SetYaw(1f);
        public static Euler UnitPitch = Zero.SetPitch(1f);
        public static Euler UnitRoll = Zero.SetRoll(1f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public Euler(float value) : this(value, value, value) { }
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static Euler operator -(Euler value) => Zero - value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static float Dot(Euler value1, Euler value2) => value1.Yaw * value2.Yaw + value1.Pitch * value2.Pitch + value1.Roll * value2.Roll;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public float Dot(Euler value) => Euler.Dot(this, value);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AlmostZero(float tolerance = Constants.Tolerance) => Yaw.Abs() < tolerance && Pitch.Abs() < tolerance && Roll.Abs() < tolerance;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool AnyComponentNegative() => MinComponent() < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public float MinComponent() => (Yaw).Min(Pitch).Min(Roll);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public float MaxComponent() => (Yaw).Max(Pitch).Max(Roll);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public float SumComponents() => (Yaw) + (Pitch) + (Roll);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public float SumSqrComponents() => (Yaw).Sqr() + (Pitch).Sqr() + (Roll).Sqr();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public float ProductComponents() => (Yaw) * (Pitch) * (Roll);
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public float GetComponent(int n) => n == 0 ? Yaw : n == 1 ? Pitch:Roll;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double MagnitudeSquared() => SumSqrComponents();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public double Magnitude() => MagnitudeSquared().Sqrt();        
        public const int NumComponents = 3;

        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsNaN() => Yaw.IsNaN() || Pitch.IsNaN() || Roll.IsNaN();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public bool IsInfinity() => Yaw.IsInfinity() || Pitch.IsInfinity() || Roll.IsInfinity();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public int CompareTo(Euler x) => (MagnitudeSquared() - x.MagnitudeSquared()).Sign();
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <(Euler x0, Euler x1) => x0.CompareTo(x1) < 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator <=(Euler x0, Euler x1) => x0.CompareTo(x1) <= 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >(Euler x0, Euler x1) => x0.CompareTo(x1) > 0;
        [MethodImpl(MethodImplOptions.AggressiveInlining)] public static bool operator >=(Euler x0, Euler x1) => x0.CompareTo(x1) >= 0;
    }
}