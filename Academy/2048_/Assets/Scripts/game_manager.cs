using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class game_manager : MonoBehaviour
{
    public GameObject[] box_base;

    bool wait, move, stop;
    Vector3 firstPos, gap;

    Vector3 v1 = new Vector3();

    GameObject[,] box = new GameObject[5, 5];
    int x, y, i, j, k, l, score;
    // Start is called before the first frame update
    void Start()
    {
        Spawn_box();
        Spawn_box();

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

        wait = false;
        // 위
        if (Input.GetKey(KeyCode.UpArrow)) for (x = 0; x <= 3; x++) for (y = 0; y <= 2; y++) for (i = 3; i >= y + 1; i--) spawn_combine(x, i - 1, x, i);
        // 아래
        else if (Input.GetKey(KeyCode.DownArrow)) for (x = 0; x <= 3; x++) for (y = 3; y >= 1; y--) for (i = 0; i <= y - 1; i++) spawn_combine(x, i + 1, x, i);
        // 오른쪽
        else if (Input.GetKey(KeyCode.RightArrow)) for (y = 0; y <= 3; y++) for (x = 0; x <= 2; x++) for (i = 3; i >= x + 1; i--) spawn_combine(i - 1, y, i, y);
        // 왼쪽
        else if (Input.GetKey(KeyCode.LeftArrow)) for (y = 0; y <= 3; y++) for (x = 3; x >= 1; x--) for (i = 0; i <= x - 1; i++) spawn_combine(i + 1, y, i, y);
        else return;




    }
    void spawn_combine(int xs, int ys, int xf, int yf)
    {

        if (box[xs, ys] != null)
        {
            Vector3 position_s = box[xs, ys].transform.position;
            Vector3 position_f = new Vector3(24f * xf - 21f, -24f * yf + 144, 0);
            if (box[xf, yf] == null && position_f != position_s)
            {
                box[xs, ys].transform.position = Vector3.MoveTowards(box[xs, ys].transform.position, position_f, 24f);
                box[xf, yf] = box[xs, ys];
                Destroy(box[xs, ys]);
            }
            else if (box[xs, ys].name == box[xf, yf].name)
            {
                for (int j = 0; j < 17; j++) { if (box[xs, ys].name == box_base[j].name) break; }
                box[xs, ys].transform.position = Vector3.MoveTowards(box[xs, ys].transform.position, position_f, 24f);
                Destroy(box[xs, ys]);
                Destroy(box[xf, yf]);
                box[xf, xf] = Instantiate(box_base[j], new Vector3(24f * xf - 21f, -24f * yf + 144, 0), Quaternion.identity);


            }
        }
    }

    void Spawn_box()
    {
        while (true)
        {
            x = Random.Range(0, 4); y = Random.Range(0, 4); if (box[x, y] == null) break;
        }
        box[x, y] = Instantiate(Random.Range(0, 2) > 0 ? box_base[0] : box_base[1], new Vector3(24f * x - 21f, -24f * y + 144, 0), Quaternion.identity);

    }

}