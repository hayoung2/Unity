using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;

    void Start()
    {//오브젝트의 앞쪽 축이 z축 이므로, forward 에 스피드값을 곱해줌
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }


}
