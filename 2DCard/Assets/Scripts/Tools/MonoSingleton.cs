using UnityEngine;

// LoadScene(1,LoadScene.Single) 첫번째꺼 가져오기. 0,1,2~ build setting 에서 
public class MonoSingleton<T> : MonoBehaviour //Component 사용하려면 MonoBehaviour 사용해야함 . 
    where T : MonoBehaviour//형식을 받는데 , MonoBehaviour인 객체만 받기 (제한 조건) where T? class 라고 하면 class 형식만 받아라 
{
    private static T instance;//이ㅣ걸  GetComponent라고 생각하기 
    private static bool isQuit = false;

    public void OnDestroy() { isQuit = true; }

    public static T Get//전역 변수 사용해서 
    {
        get
        {
            if (isQuit) return null;
            // 임계영역
            // critical section ?
            // 다른 쓰레드(작업)를 막고 이 쓰레드만 돌린다.  
            lock (new object())
            {
                //ex. GameManager  가 없으면 null 리턴
                if (instance == null)
                {
                    instance = (T)FindObjectOfType(typeof(T));//해당타입 객체 찾음 
                    if (FindObjectsOfType(typeof(T)).Length > 1) return instance;//해당 객체 찾고 2개 이상이면 처음꺼 선택 
                    if (instance == null)
                    {
                       
                        //GameManager은 MonoSingleton 이랑 MonoBehaviour 상속 모두 받음 . 
                        GameObject g = new GameObject(); //생성되어 있지 않으면 오브젝트 생성하고, 컴포넌트 부착
                        instance = g.AddComponent<T>();
                        g.name = typeof(T).Name;//그리고 이름을 해당 클래스명으로 변경
                        //typeof : 안에 있는 타입 반환. 
                        DontDestroyOnLoad(g);
                        //씬이 바뀌어도 변하지 않는  함수 사용.
                    }
                }

                return instance;//해당 객체 반환 
            }
        }
    }

}
//ex. GameManager  가 T 이면 