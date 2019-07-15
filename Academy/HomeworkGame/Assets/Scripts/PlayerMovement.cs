using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigid;
    public float rotateValue = 15f;
    public float speed;
    public float xMin, xMax;
    public ParticleSystem particle;
    private TextManager theText;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        theText = FindObjectOfType<TextManager>();
    }

   
    private void FixedUpdate()
    {
        float Horizontal = Input.GetAxis("Horizontal");//축 기준 x축 기준(x축을 잡고) 위 아래
        Vector3 movement = new Vector3(Horizontal, 0f, 0f);


        //  velocity? 속력 벡터
        //  벡터값을 넣으면 해당 방향으로 힘을 넣어준다
        rigid.velocity = movement * speed;
        rigid.position = new Vector3
        (
            //  수학 함수
            //  Clamp? x <= value >= y
            Mathf.Clamp(rigid.position.x, xMin,xMax),
            0f,
            0f
        );


        //Input.GetAxis 는 항상 0~1f 사이의 값을 받음 
        //A D로 움직임 
        //Quaternion 회전할 때 필요  축을 기준으로 각도를 주고 ,해당 축 주는 것
        Quaternion q = Quaternion.AngleAxis(Horizontal * rotateValue, Vector3.back);//z축으로 함 back -라서 반대로 
        transform.rotation = q;


    }

    private void OnTriggerEnter(Collider collider)
    {

        
        Destroy(collider.gameObject);
        Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(gameObject);

        theText.GameOver();
    }

}
