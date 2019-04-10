using System;
using System.Text;

namespace cpGames.core
{
    public static class StringExtensions
    {
        #region Methods
        public static string[] Split(this string s, int size)
        {
            if (s == null || s.Length <= size)
            {
                return new[] { s };
            }

            var n = s.Length / size + 1;
            var arr = new string[n];
            for (var i = 0; i < n; i++)
            {
                arr[i] = s.Substring(i * size, Math.Min(size, s.Length - i * size));
            }
            return arr;
        }

        public static string Capitalize(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public static string IncrementIndex(this string s)
        {
            var builder = new StringBuilder();
            var letterPart = "";
            for (var i = s.Length - 1; i >= 0; i--)
            {
                if (!char.IsDigit(s[i]))
                {
                    letterPart = s.Substring(0, i + 1);
                    break;
                }
                builder.Insert(0, s[i]);
            }

            var index = 0;
            if (builder.Length > 0)
            {
                index = int.Parse(builder.ToString());
            }
            index++;
            letterPart += index.ToString();
            return letterPart;
        }
        #endregion
    }
}