using System.Reflection;

namespace AppLogic.HelperClasses
{
    public static class Singleton<T>
        where T : class
    {
        private static T s_Instance = null;
        private static object s_LockObject = new object();
        static Singleton()
        {
        }
        public static T Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (s_LockObject)
                    {
                        if (s_Instance == null)
                        {
                            Type typeOfT = typeof(T);

                            ConstructorInfo constructor = typeOfT.GetConstructor(
                                BindingFlags.Instance | BindingFlags.NonPublic,
                                null,
                                Type.EmptyTypes,
                                null);

                            if (constructor != null)
                            {
                                s_Instance = (T)constructor.Invoke(null);
                            }
                        }
                    }
                }

                return s_Instance;
            }
        }
    }
}
