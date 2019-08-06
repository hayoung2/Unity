using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class game_manage : MonoBehaviour
{
    public GameObject[] box_base;
    bool move;
    public float[] x_pos = { -21f, 3f, 27f, 51f };
    public float[] y_pos = { 144f, 120f, 96f, 72f };
    GameObject[,] box = new GameObject[4, 4];

    int x, y, score;
    // Start is called before the first frame update
    void Start()
    {
        //맨처음 박스 두개 생성
        Spawn_box();
        Spawn_box();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            for (x = 0; x < 4; x++)
                for (y = 3; y > 1; y--)
                    for (int i = 1; i <= y; i++)
                        combine_move(x, i, x, i-1);
        else if(Input.GetKey(KeyCode.DownArrow))
    }







    void Spawn_box()
    {
        while (true)
        {
            x = Random.Range(0, 4); y = Random.Range(0, 4); if (box[x, y] == null) break; //생성될 칸 랜덤~
        }
        //생성칸에 2또는 4 객체 생성 
        box[x, y] = Instantiate(Random.Range(0, 2) > 0 ? box_base[0] : box_base[1], new Vector3(x_pos[x], y_pos[y], 0), Quaternion.identity);

    }

    void combine_move(int x_start, int y_start, int x_des, int y_des)
    {
        //스타트 하는 칸이 객체가 있을때만 실행
        if (box[x_start, y_start] != null)
        {
            //도착지 칸이 비워져 있으면 
            if (box[x_des, y_des] == null)
            {
                box[x_start, y_start].GetComponent<movemove>().Move(x_des, y_des, false); //객체 이동 시작 
                box[x_des, y_des] = box[x_start, y_start];   //너는 이제 도착칸이다
                box[x_start, y_start] = null;   //시작칸 초기화~
            }
            else if (box[x_des, y_des].name == box[x_start, y_start].name)
            {

            }


        }
    }

}

