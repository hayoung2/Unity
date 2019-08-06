using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movemove : MonoBehaviour
{
    bool move, _combine;
    int x_des, y_des;
    public float[] x_pos = { -21f, 3f, 27f, 51f };
    public float[] y_pos = { 144f, 120f, 96f, 72f };
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    // 동작 중에 프레임마다 박스가 이동하게 해주는 
    void Update() { if (move) Move(x_des, y_des, _combine); }


    //동작중에 프레임마다 계속 이동 or 도착했으면 move를 false로 바꿔 함수실행을 정지하고 결함이엿으면 객체 삭제해줌 (객체가 삭제되기 전이나  후에 이미 새로운거 생성~ 됫음)
    public void Move(int x2, int y2, bool combine)
    {
        //밑에 4개는 최초로 게임메니저에서 실행해준뒤, 객체 update함수를 계속 실행해주기위해 변수 저장 
        move = true;
        x_des = x2;
        y_des = y2;
        _combine = combine;

        // 객체 이동 한칸 - 24차이 6씩이동 4 프레임에 한칸~
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(x_pos[x2], y_pos[y2], 0), 6f);
        // 만약 객체 도착 ->  이동정지(update중지), 결함이엿을경우 객체 삭제~
        if (transform.position == new Vector3(x_pos[x2], y_pos[y2], 0))
        {
            move = false;
            if (combine) { _combine = false; Destroy(gameObject); }
        }
    }
}