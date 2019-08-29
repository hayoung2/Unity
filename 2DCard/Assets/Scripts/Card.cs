using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private SpriteRenderer frontCardRenderer;
    private SpriteRenderer backCardRenderer;

    private AudioSource effector;
    private bool isEnable = true;

    public Color CardColor
    {
        get => backCardRenderer.color;
        set => backCardRenderer.color = value;
    }
  

    //  유니티 플로우차트
    private void Awake()
    {
        frontCardRenderer = GetComponent<SpriteRenderer>();
        backCardRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();

        effector = GetComponent<AudioSource>();

        
    }

    //비활성화 되었다가 활성화된 경우 호출
    public void Reset()
    {
        isEnable = true;
        gameObject.SetActive(true);
        transform.rotation = Quaternion.identity;
        frontCardRenderer.color = new Color(1f, 1f, 1f, 1f);

    }//restart같은 기능 

    public void RotateAnimation(bool isUp)
    {
        //짝 맞췄으면 return
        if (!isEnable) return;

        UpdateManager.Add(UpdateRotate(isUp,GameOption.CARD_ROTATE_TIME));
        effector.Play();
    }

    public void DeleteAnimation()
    {
        if (!isEnable) return;
        UpdateManager.Add(UpdateOpacity(GameOption.CARD_OPACITY_TIME));
    }


    private IEnumerator UpdateRotate(bool isUp,float time)
    {
        float currTime = Time.time;//유니티 시작과 동시에 시작하는 프레임값.
        Vector3 vecAngle = isUp ? Vector3.up : Vector3.zero; //해당 축으로 돌림 .up or zero 

        //3D 객체 회전 행렬 검색 숙제 (오른쪽 회전 왼쪽 회전 확인 ) 좌표계 공식 보기 숙제 
        //오일러 법칙? y x z 
        // unity 오른쪽 좌표계
        //회전 증가된 값으로 각도값 증가 sin 증가 cos 감소 계속 rect 변화 짐벌락 
        //Quaternion 은 회전을위해
        //unity에서는  quaternion 계산  보여주는 것은 오일러 법칙으로 보여줌. 
        Quaternion prev = isUp ? Quaternion.identity : Quaternion.Euler(0f, 180f, 0f);//현재 내가 가진 값
        Quaternion next = isUp ? Quaternion.Euler(0f, 180f, 0f) : Quaternion.identity; //변화할 값 
        //다음주 아침 행열함 
        //Quaternion.identity (전치행렬) {{1 0 0 0},{0 1 0 0},{0 0 1 0},{0 0 0 1}} 

        //10초 가정 
        while (Time.time - currTime <= time)
        {
            transform.rotation = Quaternion.Lerp(
                prev,
                next,
                (Time.time-currTime)/time
                );
            //Lerp ? (min ,max, 현재시간 백분율로 표현 )
            // 선형보간 : 나오는데  좀더 수월하게 나오게 하는 것 
            // delta.time 사용해서 잘라내서 임의 값 
            //0도에서 180도 값이 주어졌을 때 그 사이에 위치한 값을 추정하기위해
            // 직선(이라는 가정)거리에 따라 선형적으로 계산하는 방법
            
            yield return null;
        }

        //오차값이 있을 수 있으므로 해당 마지막값을 넣어줌. 

        transform.rotation = next;
        yield break;
    }

    private IEnumerator UpdateOpacity(float time)
    {
        isEnable = false;

        float currTime = Time.time;
        Color color = CardColor;

        while (Time.time - currTime <= time)
        {

            color.a = Mathf.Lerp(
            1f, 0f, (Time.time - currTime) / time);
            CardColor = color;
            frontCardRenderer.color = new Color(1f, 1f, 1f, color.a);
            yield return null;
           
              
        }

        color.a = 0f;
        CardColor = color;
        frontCardRenderer.color = new Color(1f, 1f, 1f, color.a);

        gameObject.SetActive(false);
        yield break;



    }
}
