﻿
public class Singleton<T>
    where T : class, new()
{
    private static T instance;
    public static T Get
    {
        get
        {
            if (instance == null)
            {
                lock (new object())
                    instance = new T();
            }

            return instance;
        }
        set => instance = value;
    }
}
