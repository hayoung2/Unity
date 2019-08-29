using UnityEngine;
using System.Collections;

public class UserController : MonoSingleton<UserController>
{

    private Camera mainCamera = null;
    private Card select = null;

    //비활성화 된 상태에서 활성화 될 때 사용 
    public void Reset()
    {
        select = null;
        UpdateManager.Add(UpdateControl());
    }

    //생성 할때 단 한번만 호출되는 함수 
    private void Awake()
    {
        mainCamera = Camera.main;
        UpdateManager.Add(UpdateControl());
    }

    private IEnumerator UpdateControl()
    {
        while (true)
        {
            yield return null;

            //0은 mouse left 1 right 
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                //ray : (벡터로 생각) 해당 screen 값을 ray로 변경. 
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity); // (본래, 방향 ,어디까지 검색할건지) 파라미터

                if (hit.collider == null) continue;
                else if (select != null && hit.collider.gameObject.Equals(select.gameObject))
                {
                    select.RotateAnimation(false);
                    select = null;
                }
                else if (hit.collider.gameObject.GetComponent<Card>() is Card newCard) {

                    newCard.RotateAnimation(true);

                    float time = Time.time;
                    float waitTime = select == null ? GameOption.CARD_ROTATE_TIME * .5f : GameOption.CARD_OPACITY_TIME;

                    while (Time.time - waitTime <= time)
                        yield return null;

                    if (select == null)
                    {
                        select = newCard;
                    }else if (newCard.CardColor.Equals(select.CardColor))
                    {
                        select.DeleteAnimation();
                        newCard.DeleteAnimation();
                    }
                    else
                    {
                        select.RotateAnimation(false);
                        newCard.RotateAnimation(false);
                        select = null;
                    }
                }//앞에 카드가 Card 자료형인 newCard로 변환할 수 있다면 실행 
                //if (hit.collider.gameObject.GetComponent<Card>()!=null{Card newCard=hit.collider.gameObject.GetComponent<Card>();} 와 같은 말 
            }
        }

        yield break; 
    }
}
