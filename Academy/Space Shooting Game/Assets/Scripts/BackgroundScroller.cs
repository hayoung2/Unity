using System.Collections;
using System.Collections.Generic;
using UnityEngine;//import 와 똑같. 라이브러리나 패키지 가져옴.
                  //unityEngine 기능 사용.
                  //숙제1 tanks Assets 받아서  project 듣기
                  //숙제2 영타 250 노력
                  //접근제한자 숙제 알아오기 

public class BackgroundScroller : MonoBehaviour
{
    //public : 누구나 접근 가능
    //protected : 상속된 객체만 가능. 그 외에는 불가
    //private : 같은 클래스 내에서만 가능 set get 으로 가능

    //변수 ? : 
    //선언하는 방법 ?
    //접근 제한자 + 변수타입 + 변수명 
    //public 객체는 자동으로 유니티와 연결된다 


    //[SerializeField]//보호된 객체 직렬화 방법
    //private float number = 0.05f;//최적화를 위해 f 넣기 


    public float speed = 0.05f;

    private Material mtrl;
    private Vector2 loopVec = Vector2.zero;
    
    //한번 실행되는 함수 Start 보다 더 빨리 실행함.(한번만 실행, 초기화)
    private void Awake()
    {
        mtrl = GetComponent<MeshRenderer>().material;
    }
    //이 객체가 삭제될 때 실행됨.
    private void OnDestroy()
    {
        mtrl.SetTextureOffset("_MainTex", Vector2.zero);
    }

    //계속 호출.
    private void Update()
    {
        //Time 클래스 에서 delataTime 사용 (Unity 에서 제공하는 클래스 ) 매 화면이 갱신되는 타이머
        loopVec.y += speed * Time.deltaTime;//화면에서 다른 화면으로 이동할 때 바로 바꾸는 게 아니라 화면을 그리고 전화해줘야함. 버퍼링이 있어야 함
        loopVec.x += speed * Time.deltaTime;
        //화면 전환 속도

        //배경 텍스처의 위치 값을 설정해줌.
        mtrl.SetTextureOffset("_MainTex", loopVec);

        if (loopVec.y > 1f)
        {
            loopVec = Vector2.zero;
        }

    }



}
