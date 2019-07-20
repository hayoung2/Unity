using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{

    public Vector3 direction;
    public float velocity;
    private Transform target;

    public float accelaration = 0.1f;

    public float fireRate;

    private float frameRate = 0f;
    public GameObject bolt;


    private AudioSource source;
    public void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;


    }

    public void Update()
    {
        if (target != null)
        {
            if (direction.x < 1f && Time.time > frameRate)
            {
                frameRate = Time.time + fireRate;
                //  Instantiate?
                //  객체를 생성하는 함수
                Instantiate(bolt, transform.position, transform.rotation, transform);



            }



            direction = new Vector3(target.position.x - transform.position.x, 0, 0);
            velocity = (velocity + accelaration * Time.deltaTime);
            this.transform.position = new Vector3(transform.position.x + (direction.x * velocity),
                                                       transform.position.y,
                                                         transform.position.z);
        }

    }





}