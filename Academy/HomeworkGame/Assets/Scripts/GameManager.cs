using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    //static   전역 변수 단 하나의 변수만 존재가능. 
    //GameObject instace 는 이 클래스 안에서는 똑같은 instance 라는 객체를 생성 x
    //실제로 이 객체가 존재하지 않더라고 전역 객체는 접근 가능
    
        // Singleton pattern :싱글톤 패턴 검색 
    private static GameManager instance;
    public static GameManager Get
    {
        get
        {
            if (instance == null)
            {
                GameObject go = GameObject.FindObjectOfType(typeof(GameManager)) as GameObject;

                if (go == null)
                {
                    go = new GameObject("GameManager");
                    instance = go.AddComponent<GameManager>();

                }
                else
                {
                    instance = go.GetComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    public bool isStart = true; 

}
