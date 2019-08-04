using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEngine.Transform;


public class BoxController : MonoBehaviour
{
    
    public GameObject[] Box;
    private GameObject[] boxArr=new GameObject[16];
    private GameObject boxCheck;
    private float[] x = { -21f,3f,27f,51f};
    private float[] y = {144f,120f,96f,72f };
    private GameObject[,] Background=new GameObject[4,4];
    private bool move = false;
    private bool check = false;
    private int xNum, yNum;
    private float xResult,yResult;
    private float xAxis, yAxis;
    private int count = 0;
    

    void Start()
    {


        //boxPosition = new Vector3(-21.0f, 72.0f,0f);

        //tf.position = boxPosition;

        //RandomBox();

        xNum = Random.Range(0, 4);
        yNum = Random.Range(0, 4);

        xResult = x[xNum];
        yResult = y[yNum];
        

        boxArr[count] =Instantiate(Box[0], new Vector3(xResult,yResult,0f), Quaternion.identity);
        Background[yNum, xNum] = boxArr[count];
        //왜 함수로 하면 안될까 생각, 앞에 변수 GameObject 넣어줘야 되는 것 생각.
        Debug.Log(yNum);
        Debug.Log(xNum);

        Debug.Log(xResult);
        Debug.Log(yResult);



        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            //Movement()
            
            for (int k = 0; k < boxArr.Length; k++)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    Debug.Log("위에 클릭 함 ");

                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (Background[i, j] != null)
                            {
                               
                                if (Background[i, 0] == null || j==0)
                                {
                                    Background[i, 0] = Background[i, j];
                                    boxArr[k].transform.position = new Vector3(boxArr[k].transform.position.x, 144f, 0f);
                                    Background[i, j] = null;
                                    break;
                                }
                                else if (Background[i, 1] == null && j >= 1)
                                {
                                    Background[i, 1] = Background[i, j];
                                    boxArr[k].transform.position = new Vector3(boxArr[k].transform.position.x, 120f, 0f);
                                    Background[i, j] = null;
                                    break;
                                }
                                else if (Background[i, 2] == null && j >= 2)
                                {
                                    Background[i, 2] = Background[i, j];
                                    boxArr[k].transform.position = new Vector3(boxArr[k].transform.position.x,96f, 0f);
                                    Background[i, j] = null;
                                    break;
                                }
                                else if (Background[i, 3] == null && j >=3)
                                {
                                    Background[i, 3] = Background[i, j];
                                    boxArr[k].transform.position = new Vector3(boxArr[k].transform.position.x,72f, 0f);
                                    Background[i, j] = null;
                                    break;
                                }
                                
                            }

                         
                        }
                    }
                    //check = false;
                    Debug.Log("위에 클릭 함 ");
                    move = false;
                    RandomBox();
                    
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    Debug.Log("아래 클릭 함 ");

                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (Background[i, j] != null)
                            {
                                
                                if (Background[i, 3] == null || j==3)
                                {
                                    Background[i, 3] = Background[i, j];
                                    boxArr[k].transform.position = new Vector3(boxArr[k].transform.position.x, 72f, 0f);
                                    Background[i, j] = null;
                                    break;
                                }
                                else if (Background[i, 2] == null && j <= 2)
                                {
                                    Background[i, 2] = Background[i, j];
                                    boxArr[k].transform.position = new Vector3(boxArr[k].transform.position.x, 96f, 0f);
                                    Background[i, j] = null;
                                    break;
                                }
                                else if (Background[i, 1] == null && j <= 1)
                                {
                                    Background[i, 1] = Background[i, j];
                                    boxArr[k].transform.position = new Vector3(boxArr[k].transform.position.x, 120f, 0f);
                                    Background[i, j] = null;
                                    break;
                                }
                                else if (Background[i, 0] == null && j <= 0)
                                {
                                    Background[i, 0] = Background[i, j];
                                    boxArr[k].transform.position = new Vector3(boxArr[k].transform.position.x, 144f, 0f);
                                    Background[i, j] = null;
                                    break;
                                }
                            }
                        }
                    }

                    //check = false;
                    Debug.Log("아래 클릭 함 ");
                    //move = false;
                    move = false;
                    RandomBox();
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    Debug.Log("오른쪽 클릭 함 ");
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (Background[i, j] == Box[k])
                            {
                                

                                if (Background[3, j] == null || i==3)
                                {
                                    Background[3, j] = Background[i, j];
                                    boxArr[k].transform.position = new Vector3(51f, boxArr[k].transform.position.y, 0f);
                                    Background[i, j] = null;
                                    break;
                                }
                                else if (Background[2, j] == null && i <= 2)
                                {
                                    Background[2, j] = Background[i, j];
                                    boxArr[k].transform.position = new Vector3(27f, boxArr[k].transform.position.y, 0f);
                                    Background[i, j] = null;
                                    break;
                                }
                                else if (Background[1, j] == null && i <= 1)
                                {
                                    Background[1, j] = Background[i, j];
                                    boxArr[k].transform.position = new Vector3(3f, boxArr[k].transform.position.y, 0f);
                                    Background[i, j] = null;
                                    break;
                                }
                                else if (Background[0, j] == null && i <= 0)
                                {
                                    Background[0, j] = Background[i, j];
                                    boxArr[k].transform.position = new Vector3(-21f, boxArr[k].transform.position.y, 0f);
                                    Background[i, j] = null;
                                    break;
                                }
                                
                            }
                        }

                    }
                    Debug.Log("오른쪽 클릭 함 ");
                    //move = false;
                    move = false;
                    //check = false;
                    RandomBox();

                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    Debug.Log("왼쪽 클릭 함 ");

                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (Background[i, j] != null)
                            {
                                

                                if (Background[0, j] == null|| i==0)
                                {
                                    Background[0, j] = Background[i, j];
                                    boxArr[k].transform.position = new Vector3(-21f, boxArr[k].transform.position.y, 0f);
                                    Background[i, j] = null;
                                    break;
                                }
                                else if (Background[1, j] == null && i >= 1)
                                {
                                    Background[1, j] = Background[i, j];
                                    boxArr[k].transform.position = new Vector3(3f, boxArr[k].transform.position.y, 0f);
                                    Background[i, j] = null;
                                    break;
                                }
                                else if (Background[2, j] == null && i >= 2)
                                {
                                    Background[2, j] = Background[i, j];
                                    boxArr[k].transform.position = new Vector3(27f, boxArr[k].transform.position.y, 0f);
                                    Background[i, j] = null;
                                    break;
                                }
                                else if (Background[3, j] == null && i >= 3)
                                {
                                    Background[3, j] = Background[i, j];
                                    boxArr[k].transform.position = new Vector3(51f, boxArr[k].transform.position.y, 0f);
                                    Background[i, j] = null;
                                    break;
                                }
                            }
                        }

                    }
                    //check = false;
                    Debug.Log("왼쪽 클릭 함 ");
                    //move = false;
                    move = false;
                    RandomBox();
                }
                //if(check)
                //    BoxCreate();
            }
        }

    }

    void RandomBox()
    {
        //GameObject result = Box[Random.Range(0,2)];
        //yResult = y[Random.Range(0, 4)];
        //xResult = x[Random.Range(0, 4)];
        //boxPosition= new Vector3(-21.0f, 72.0f,0f);

        //tf.position = boxPosition;
        
        bool random = true;
        count++;

        while (random)
        {
            xNum = Random.Range(0, 4);
            yNum = Random.Range(0, 4);

            xResult = x[xNum];
            yResult = y[yNum];

            if (Background[yNum, xNum] != null)
            {
                continue;
            }

            random = false;
        }

       
            boxArr[count] = Instantiate(Box[1], new Vector3(xResult, yResult, 0f), Quaternion.identity);
            Background[yNum, xNum] = boxArr[count];
           
            move = true;
       



    }

    void Movement()
    {
        //move = false;
        //bool check = true;
        //while (check){

       
    }
        
               
    
    //void BoxCreate()
    //{
    //    xNum = Random.Range(0, 4);
    //    yNum = Random.Range(0, 4);

    //    xResult = x[xNum];
    //    yResult = y[yNum];

    
    //    GameObject box = Instantiate(Box[Random.Range(0, 2)], new Vector3(xResult, yResult, 0f), Quaternion.identity);
    //}

}
