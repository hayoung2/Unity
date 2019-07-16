using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  유니티의 에디터 상 에서 보여주기 위해 걸어준다
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

//  MonoBehaviour?
//  유니티상에서 부품화를 가능하게 해준다
//  gameObject  - 자기 자신
//  transform   - 자기의 위치, 구조
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
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //  Input? 말 그래도 입력 담당 클래스
        //  Input.GetKey        -   사용자가 이 키를 눌렀을 때 true
        //  Input.GetKeyDown    -   위랑 동일하나 단 한번만 true
        if (Input.GetKey(KeyCode.Space) && Time.time > frameRate)
        {
                frameRate = Time.time + fireRate;
                //  Instantiate?
                //  객체를 생성하는 함수
                Instantiate(bolt, transform.position, transform.rotation, transform);

            source.Play();
        }
    }




    private void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveH, 0f, moveV);
        
        //  velocity? 속력 벡터
        //  벡터값을 넣으면 해당 방향으로 힘을 넣어준다
        rigid.velocity = movement * speed;
        rigid.position = new Vector3
        (
            //  수학 함수
            //  Clamp? x <= value >= y
            Mathf.Clamp(rigid.position.x, boundary.xMin, boundary.xMax),
            0f,
            Mathf.Clamp(rigid.position.z, boundary.zMin, boundary.zMax)
        );

        rigid.rotation = Quaternion.Euler(0f, 0f, rigid.velocity.x * -tilt);
    }

}
