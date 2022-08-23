﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace cpGames.core
{
    public static class ListExtensions
    {
        #region Methods
        public static T[] ToArray<T>(this IList list)
        {
            var arr = new T[list.Count];
            for (var i = 0; i < list.Count; i++)
            {
                if (typeof(T) == typeof(string))
                {
                    arr[i] = (T)(object)list[i].ToString();
                }
                else
                {
                    arr[i] = (T)list[i];
                }
            }
            return arr;
        }

        public static List<T> ToList<T>(this IEnumerable enumerable)
        {
            return (from object item in enumerable select (T)item).ToList();
        }

        public static string ToString(this IList list, string separator)
        {
            return string.Join(separator, list.ToArray<string>());
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }

        public static bool ArrayContentEquals<T>(this T[] source, T[] other)
        {
            if (other == null ||
                other.Length != source.Length)
            {
                return false;
            }

            return source.All(other.Contains);
        }

        public static T GetRandomItem<T>(this List<T> source)
        {
            var index = new Random(Guid.NewGuid().GetHashCode()).Next(0, source.Count);
            return source[index];
        }
        #endregion
    }
}