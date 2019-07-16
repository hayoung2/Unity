using System.Collections;               //  내가 이것을 사용하겠다 라는 선언
using System.Collections.Generic;


//  나는 유니티 엔진 기능을 사용하겠다
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    //  숙제 1
    //  영타 250 노력해보기

    //  숙제 2
    //  Tank! Assets 받아서 구현해보기!

    //  접근 제한자 - 숙제 
    //  public, protected, private
    //  public      : 누구나 접근할 수 있고 누구나 값을 변경할 수 있다
    //  protected   : 상속된 객체만 접근할 수 있고 그 외에는 접근 불가 (변경도 동일)
    //  private     : 나만 접근 및 값을 변경할 수 있다

    //  자료형 ?
    //  int     :   자연수 (소수점이 없는)
    //  float   :   소수점 6자리까지 사용 가능한 정수
    //  bool    :   ture 또는 false 값 중 하나만 갖고있는 조건변수

    //  변수 ?
    //  선언하는 방법 ?
    //  접근 제한자 + 자료형 + 선언할 이름
    //  private int number;
    //  자기자신만 볼 수 있고 설정 가능한 자연수 number 를 선언

    //  보호된 객체 직렬화 방법
    //[SerializeField] private float number = 0.05f;

    //  퍼블릭 객체는 자동으로 유니티와 연결된다
    public float speed = 0.05f;

    private Material mtrl;
    Vector2 loopVec = Vector2.zero;

    //  시작할 때 단 한번만 실행된다!
    private void Awake()
    {
        mtrl = GetComponent<MeshRenderer>().material;
    }

    //  이 객체가 삭제될 떄 실행된다!
    private void OnDestroy()
    {
        mtrl.SetTextureOffset("_MainTex", Vector2.zero);
    }

    //  계속 호출된다!
    private void Update()
    {
        //  Time ? Time class
        //  Unity 에서 제공하는 클래스
        //  Time.deltatime? 매 화면이 갱신되는 타이머
        loopVec.y += speed * Time.deltaTime;

        //  배경 텍스처의 위치 값을 설정해준다
        mtrl.SetTextureOffset("_MainTex", loopVec);

        if (loopVec.y > 1f)
        {
            loopVec = Vector2.zero;
        }
    }

}

//  if ? 조건문
//  ==  같다면
//  !=  같지 않다면
//  >   ~보다 크면
//  >=  ~보다 크거가 같다면

//  if (120 == 110)
//  {
//      "맞습니다" 출력
//  }
//  else if (120 != 120)
//  {
//      "맞아요" 출력
//  }
//  else if (120 == 140)
//  {
//      "맞아요" 출력
//  }
//  else 
//  {
//      "아닙니다" 출력
//  }

//  int x = 10;
//  if (x == 10) { "OK" }
//  else { "No" }