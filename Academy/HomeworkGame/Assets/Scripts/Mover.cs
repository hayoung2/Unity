using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private Rigidbody rigid;
    public float minSpeed;
    public float maxSpeed;


    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = Vector3.back * Random.Range(minSpeed, maxSpeed);
    }


}
