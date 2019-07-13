using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigid;
    public float rotateValue = 15f;

    private void Start()
    {
        rigid.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");//축 기준 x축 기준(x축을 잡고) 위 아래
        
        //Input.GetAxis 는 항상 0~1f 사이의 값을 받음 
        //A D로 움직임 
        //Quaternion 회전할 때 필요  축을 기준으로 각도를 주고 ,해당 축 주는 것
        Quaternion q = Quaternion.AngleAxis(Horizontal * rotateValue, Vector3.back);//z축으로 함 back -라서 반대로 
        transform.rotation = q;
    }

    private void OnTriggerEnter(Collider collider)
    {
        Destroy(collider.gameObject);
        Destroy(gameObject);
    }

}
