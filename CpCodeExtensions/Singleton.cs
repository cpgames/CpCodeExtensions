using System;
using System.Reflection;

namespace cpGames.core
{
    public class Singleton<T>
    {
        #region Fields
        private static T? _instance;
        #endregion

        #region Properties
        public static T Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                var ctor =
                    typeof(T).GetConstructor(
                        BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,
                        null, Type.EmptyTypes, null);
                if (ctor != null)
                {
                    _instance = (T)ctor.Invoke(null);
                }
                else
                {
                    throw new Exception($"{typeof(T).Name} has no parameterless constructor");
                }
                return _instance;
            }
        }
        #endregion
    }
}