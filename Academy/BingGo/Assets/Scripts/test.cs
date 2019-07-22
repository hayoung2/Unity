using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    private int[,] result = new int[5,5];
    private int[,] copyArr = new int[5,5];
    public InputField[] Input = new InputField[25];
 
    private int score;
    public bool isRun = false;
    public Button btn;
    public int count;


    void Start()
    {
        //grids = gameObject.GetComponent<GridLayoutGroup>();


        btn.onClick.AddListener(RunTask);

        //Transform[] objList = gameObject.GetComponentsInChildren(typeof(Transform));

        //foreach (Transform child in objList)
        //{
        //    child.gameObject.GetComponent( ....);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (isRun)
            StartCoroutine(Test());

    }

    IEnumerator Test()
    {


        Debug.Log("완료");

        score=Inspect();
        Debug.Log(score);

        yield return new WaitForSeconds(5f);
    }


    public void RunTask()
    {
        

        int count = 0;
        int tmp = 0;

        for (int i = 0; i < 25; i++)
        {
            
            if (count < 5)
            {
                result[tmp,count] = int.Parse(Input[i].text);
                copyArr[tmp, count] = result[tmp, count];
                
            }
            else
            {
                count = 0;
                tmp++;
                result[tmp, count] = int.Parse(Input[i].text);
                copyArr[tmp, count] = result[tmp, count];
               
            }
           
            

            count++;

        }


        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                for (int k = 0; k < 5; k++)
                {
                    for (int e = 0; e < 5; e++)
                    {
                        if (i == k && j == e)
                        {

                        }
                        else
                        {
                            if (result[i, j] == copyArr[k, e]&& result[i,j]!=-1)
                            {
                                result[k, e] = -1;
                                copyArr[k,e] = -1;
                                if (k == 0)
                                {
                                    Input[k + e].text = "-1";
                                }
                                else if (k == 1)
                                {
                                    Input[k + e + 4].text = "-1";
                                }
                                else if (k == 2)
                                {
                                    Input[k + e + 8].text = "-1";
                                }
                                else if (k == 3)
                                {
                                    Input[k + e + 12].text = "-1";
                                }
                                else if (k == 4)
                                {
                                    Input[k + e + 16].text = "-1";
                                }
                            }
                        }
                    }
                }
            }




            //for (int k = 0; k <= tmp; k++)
            //{
            //    for (int e = 0; e < count; e++)
            //    {
            //        if (result[k, e] == copyArr[k, e])
            //        {
            //            result[k, e] = -1;
            //            copyArr[k, e] = -1;
            //            if (k == 0)
            //            {
            //                Input[k + e].text = "-1";
            //            }
            //            else if (k == 1)
            //            {
            //                Input[k + e + 4].text = "-1";
            //            }
            //            else if (k == 2)
            //            {
            //                Input[k + e + 8].text = "-1";
            //            }
            //            else if (k == 3)
            //            {
            //                Input[k + e + 12].text = "-1";
            //            }
            //            else if (k == 4)
            //            {
            //                Input[k + e + 16].text = "-1";
            //            }
            //        }
            //    }
        }
            isRun = true;
        
    }
    
  
    public int RandomCount(int i)
    {
        int[] random = new int[count];

        random[i] = Random.Range(1, 25);

        for (int j = 0; j < i; j++)
        {
            if (random[i] == random[j])
            {
                random[i] = Random.Range(1, 26);
            }
            return random[i];
        }

        return random[i];

    }

    public int Inspect()
    {
        int[] random = new int[count];
        int[,] answer = new int[5, 5];

        for (int i = 0; i < count; i++)
        {
            random[i] = RandomCount(i);

            
            for (int j = 0; j < 5; j++)
            {
                for (int k = 0; k < 5; k++)
                {
                    if (result[j, k] == random[i])
                    {
                        result[j, k] = -5;
                    }
                }
            }
            
        }

        int bingo = 0;

        for (int i = 0; i < 5; i++)
        {
            int cnt = 0;
            for (int j = 0; j < 5; j++)
            {
                if (result[i, j] != -5)
                    break;
                else
                {
                    cnt++;
                    if (cnt == 5)
                        bingo++;
                }

            }

        }

        for (int i = 0; i < 5; i++)
        {
            int cnt = 0;

            for (int j = 0; j < 5; j++)
            {
                if (result[j, i] != -5)
                    break;
                else
                {
                    cnt++;
                    if (cnt == 5)
                        bingo++;
                }
                
            }
            
        }

        for(int i = 0; i < 5; i++)
        {
            int cnt = 0;

            if (result[i, i] != -5)
                break;
            else
            {
                cnt++;
                if (cnt == 5)
                    bingo++;
            }
        }

        for (int i = 0; i < 5; i++)
        {
            int cnt = 0;

            if (result[i, 4 - i] != -5)
                break;
            else
            {
                cnt++;
                if (cnt == 5)
                    bingo++;
            }

        }
        return bingo;
    }
   

}
