using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class game_manager : MonoBehaviour
{
    public GameObject[] box_base;
    public bool move, over_;
    int score, highscore;
    public float[] x_pos = { -21f, 3f, 27f, 51f };
    public float[] y_pos = { 144f, 120f, 96f, 72f };
    public int box_count = 0, box_matchcount;
    GameObject[,] box = new GameObject[4, 4];
    bool[,] combine = new bool[4, 4];
    public Text highscore_t;
    public Text score_t;
    public GameObject endText;
    private bool end;

    int j; //이름 찾기 위한for문
    int x, y;
    // Start is called before the first frame update
    void Start()
    {
        //맨처음 박스 두개 생성
        score = 0;
        over_ = false;
        Spawn_box();
        Spawn_box();
        for (x = 0; x < 4; x++) for (y = 0; y < 4; y++) combine[x, y] = false;
        highscore_t.text = highscore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        // 문지름
        /* if (Input.GetMouseButtonDown(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            wait = true;
            firstPos = Input.GetMouseButtonDown(0) ? Input.mousePosition : (Vector3)Input.GetTouch(0).position;
        }

        if (Input.GetMouseButton(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved))
        {
            gap = (Input.GetMouseButton(0) ? Input.mousePosition : (Vector3)Input.GetTouch(0).position) - firstPos;
            if (gap.magnitude < 100) return;
            gap.Normalize();
        }
        */

        if (over_ || Input.GetKeyDown(KeyCode.R))
        {
            Invoke("Restart", 4);
            return;
        }



        if (!move)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) for (x = 0; x < 4; x++) for (y = 3; y >= 1; y--) for (int i = 1; i <= y; i++) combine_move(x, i, x, i - 1);
            else if (Input.GetKeyDown(KeyCode.DownArrow)) for (x = 0; x < 4; x++) for (y = 0; y <= 3; y++) for (int i = 2; i >= y; i--) combine_move(x, i, x, i + 1);
            else if (Input.GetKeyDown(KeyCode.LeftArrow)) for (y = 0; y < 4; y++) for (x = 3; x >= 1; x--) for (int i = 1; i <= x; i++) combine_move(i, y, i - 1, y);
            else if (Input.GetKeyDown(KeyCode.RightArrow)) for (y = 0; y < 4; y++) for (x = 0; x <= 3; x++) for (int i = 2; i >= x; i--) combine_move(i, y, i + 1, y);
            else return;
        }

        if (move) //움직이면 움직였으면 + 점수 계산 + 이제 안움직이고 있음 
        {
            move = false;

            if (highscore < score) highscore = score;
            score_t.text = score.ToString();
            highscore_t.text = highscore.ToString();




            Spawn_box();
            box_count = 0;
            // 채워져 있는 칸수 세기
            for (x = 0; x < 4; x++) for (y = 0; y < 4; y++) if (box[x, y] != null) box_count++;

            if (box_count == 16)
            {

                box_matchcount = 0;
                //가로 세로 일치하는 칸 세기  하나도없으면 게임 끝
                for (x = 0; x < 4; x++) for (y = 0; y < 3; y++) if (box[x, y].name == box[x, y + 1].name) box_matchcount++;
                for (y = 0; y < 4; y++) for (x = 0; x < 3; x++) if (box[x, y].name == box[x + 1, y].name) box_matchcount++;
                if (box_matchcount == 0) over_ = true;
            }
            //결합된 것을 또 결합 되지 않게 해주던 것 바꿈
            for (x = 0; x < 4; x++) for (y = 0; y < 4; y++) combine[x, y] = false;



            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if (box[i, j] == null)
                        break;
                    else if (i == 3 & j == 3)
                        end = true; 
                }
                break;
              
            }

            if (end)
                endText.SetActive(true);

        }

    }


    public void Restart() { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }




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
                move = true; //움직이는 듕~
                box[x_start, y_start].GetComponent<ObjectMove>().Move(x_des, y_des, false); //객체 이동 시작 
                box[x_des, y_des] = box[x_start, y_start];   //너는 이제 도착칸이다
                box[x_start, y_start] = null;   //시작칸 초기화~
            }
            //도착지가 비워져있지 않지만 스타트칸과 이름이 같으면 + 한싸이클에서 결합을 한 적이 없으면
            else if (box[x_des, y_des].name == box[x_start, y_start].name && combine[x_start, y_start] == false && combine[x_des, y_des] == false)
            {
                move = true; //지금 움직이고 있어요~~

                //여러번 결합 되지 않기 위해 한번 이동 싸이클에서 이미 결합했다고 말해줌 
                combine[x_start, y_start] = true; combine[x_des, y_des] = true;

                for (j = 0; j <= 16; j++) if (box[x_start, y_start].name == box_base[j].name + "(Clone)") break;  //결합하여 2배 박스 생성을 위해ㅣ  이박스의 크기를 찾아주는 for문 
                box[x_start, y_start].GetComponent<ObjectMove>().Move(x_des, y_des, true); //객체 이동 시작 
                Destroy(box[x_des, y_des]);   // 칸에 객체 제거 ~
                box[x_start, y_start] = null;   //시작칸 초기화~
                box[x_des, y_des] = Instantiate(box_base[j + 1], new Vector3(x_pos[x_des], y_pos[y_des]), Quaternion.identity); //새로 2배 된 박스 생성 
                score += (int)Mathf.Pow(2, j + 2);
            }
        }
    }
}
