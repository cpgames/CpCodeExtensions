namespace cpGames.core
{
    public static class Number
    {
        #region Fields
        public const int DIGITS_IN_LONG = 19;
        public const int DIGITS_IN_INT = 10;
        #endregion

        #region Methods
        public static long GetFactor(int digits)
        {
            long n = 1;
            for (var i = 0; i < digits; i++)
            {
                n *= 10;
            }
            return n;
        }

        public static long GetFactorInverse(int digits)
        {
            return GetFactor(DIGITS_IN_LONG - digits);
        }

        public static long RemoveDigitsLeft(long value, int digits)
        {
            var m = GetFactorInverse(digits);
            var l = value / m;
            l *= m;
            return value - l;
        }

        public static long RemoveDigitsRight(long value, int digits)
        {
            var m = GetFactorInverse(digits);
            return value / m;
        }

        public static int LongToIntLSB(long l)
        {
            l = RemoveDigitsLeft(l, DIGITS_IN_INT);
            return (int)l;
        }
        #endregion
    }
}