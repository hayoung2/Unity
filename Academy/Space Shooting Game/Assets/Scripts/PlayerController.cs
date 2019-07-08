using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//유니티의 에디터 상에서 보여주기 위해서 만들어줌
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;

}
// 컴포넌트화 할 때 도움줌 monobehaviour 꼭 상속 
//MonoBehaviour 유니티상에서 부품화를 가능하게 함.
//gameObject- 자기 자신 ,transform-위치,구조 이 외에 기능 다수 
public class PlayerController : MonoBehaviour
{
    public Boundary boundary;
    public Rigidbody rigid;
    public float speed;
    public float tilt;

    public GameObject bolt;
    public Transform shotSpawn;
    public float fireRate;

    private float frameRate = 0f;

    //총알 발사 구현
    private void Update()
    {//Input(입력 담당 클래스).GetKey(사용자가 이 키를 눌렀을 때 true) GetKeyDown(위랑 동일하나 한번만 true)
        //getKey를 하면 계속 true이기때문에 쭉 누루면 나옴 
        if (Input.GetKeyDown(KeyCode.Z))
        {   
            // TIme.time 게임이 시작될 때 부터 흐르는 시간
            if (Time.time > frameRate)
            {
                frameRate = Time.time + fireRate;
                //Instantiage?
                //객체를 생성하는 함수. ex. bolt 앞에 맨앞 생성, 
                Instantiate(bolt, transform.position, transform.rotation, transform);
            }
           
        }   

    }

    //불특정 업데이트. 항상 고정된 시간에 호출. multiple 게임 하면 구린 컴퓨터 방지. 일정한 시간에 한번씩 실행
    private void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveH, 0f, moveV);

        //velocity 속력 벡터
        //벡터값을 넣으면 해당 방향으로 이동
        //Mathf 수학함수.Clamp 는 x<=value >=y 바운더리에 x가 크면 xmax값 주고 작으면 xmin
        rigid.velocity = movement * speed;
        rigid.position = new Vector3
            (Mathf.Clamp(rigid.position.x,boundary.xMin,boundary.xMax),0f, Mathf.Clamp(rigid.position.z, boundary.zMin, boundary.zMax));

        //Quaternion은 
        rigid.rotation = Quaternion.Euler(0f, 0f, rigid.velocity.x * -tilt);


    }

}
