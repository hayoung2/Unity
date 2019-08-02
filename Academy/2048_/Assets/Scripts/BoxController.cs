using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEngine.Transform;


public class BoxController : MonoBehaviour
{
    
    public GameObject[] Box;
    private GameObject boxCheck;
    private float[] x = { -21f,3f,27f,51f};
    private float[] y = {144f,120f,96f,72f };
    private GameObject[,] Background=new GameObject[4,4];
    private bool move = false;
    private int xNum, yNum;
    private float xResult,yResult;
    private float xAxis, yAxis;

    

    void Start()
    {


        //boxPosition = new Vector3(-21.0f, 72.0f,0f);

        //tf.position = boxPosition;

        //RandomBox();

        xNum = Random.Range(0, 4);
        yNum = Random.Range(0, 4);

        xResult = x[xNum];
        yResult = y[yNum];
        

        GameObject box =Instantiate(Box[0], new Vector3(xResult,yResult,0f), Quaternion.identity);
        //왜 함수로 하면 안될까 생각, 앞에 변수 GameObject 넣어줘야 되는 것 생각.
        Debug.Log(xNum);
        Debug.Log(yNum);

        Background[yNum, xNum] = box;
        move = true;
    }

    // Update is called once per frame
    void Update()
    {


        if (move)
            Movement();

    }

    void RandomBox()
    {
        //GameObject result = Box[Random.Range(0,2)];
        //yResult = y[Random.Range(0, 4)];
        //xResult = x[Random.Range(0, 4)];
        //boxPosition= new Vector3(-21.0f, 72.0f,0f);

        //tf.position = boxPosition;

    }

    void Movement()
    {
        move = false;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if (Background[i, j] != null)
                    {
                        if (Background[4, j] == null)
                        {
                            Background[4, j] = Background[i, j];
                            Background[i, j] = null;
                            break;
                        }else if (Background[3, j])
                        {
                            Background[4, j] = Background[i, j];
                            Background[i, j] = null;
                            break;
                        }
                    }
                }
            }
        }else if (Input.GetKey(KeyCode.DownArrow))
        {

        }else if (Input.GetKey(KeyCode.RightArrow))
        {

        }else if (Input.GetKey(KeyCode.LeftArrow))
        {

        }
    }
}
