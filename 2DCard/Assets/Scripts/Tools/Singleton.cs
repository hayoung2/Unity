
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
       
    }
}
//위에 Singleton은 
//DonDestroyOnLoad 파괴 ㄴㄴ(씬 바뀌어도)  ~ singleton 단 하나의 객체만 유지시키기 위해 만듦 유지시킴
//score db 같은 경우 사용 

