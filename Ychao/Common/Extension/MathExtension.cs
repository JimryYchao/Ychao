using System;

namespace Ychao
{
    public static class MathExtension

    {
        #region Math Abs
        public static sbyte Abs(this sbyte value) => Math.Abs(value);
        public static short Abs(this short value) => Math.Abs(value);
        public static int Abs(this int value) => Math.Abs(value);
        public static long Abs(this long value) => Math.Abs(value);
        public static float Abs(this float value) => Math.Abs(value);
        public static double Abs(this double value) => Math.Abs(value);
        public static decimal Abs(this decimal value) => Math.Abs(value);
        #endregion Math Abs

        #region Trigonometric and anti-trigonometric
        public static double Acos(this double d) => Math.Acos(d);
        public static double Acosh(this double d) => Math.Acosh(d);
        public static double Asin(this double d) => Math.Asin(d);
        public static double Asinh(this double d) => Math.Asinh(d);
        public static double Atan(this double d) => Math.Atan(d);
        public static double Atan2(this double y, double x) => Math.Atan2(y, x);
        public static double Atanh(this double d) => Math.Atanh(d);

        #endregion Trigonometric and anti-trigonometric


    }
}
