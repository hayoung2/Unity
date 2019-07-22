using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BinGoManager : MonoBehaviour
{
    private int[] result = new int[25];
    private int[] copyArr = new int[25];
    public InputField[] Input = new InputField[25];
    public int count;
    public bool isRun=false;
    public Button btn;

    // Start is called before the first frame update
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
        if(isRun)
            StartCoroutine(Test());
    
    }

    private void RunTask()
    {
        for (int i = 0; i < 25; i++)
        {


            result[i] = int.Parse(Input[i].text);
            copyArr[i] = result[i];

            for (int j = 0; j < i; j++)
            {
                if (result[i] == copyArr[j])
                {
                    Input[i].text = "-1";
                }
               
            }


            result[i] = int.Parse(Input[i].text);
            copyArr[i] = result[i];

            Debug.Log(result[i]);

        }

        

        isRun = true; ;
    }

    IEnumerator Test()
    {
        yield return new WaitForSeconds(5f);

                Debug.Log("완료");
     

        yield return new WaitForSeconds(5f);
    }

    public int Randomr(int i)
    {
        int[] random = new int[count];

        random[i] = Random.Range(1, 25);

        for (int j = 0; j < i; j++)
         {
            if (random[i] == random[j])
            {
                random[i] = Random.Range(1, 25);
            }
            return random[i];
         }

        return random[i];

    }


    public void Inspect()
    {
        int[] random = new int[count];
        int[,] answer = new int[5, 5];

       for(int i = 0; i < count; i++)
        {
            random[i] = Randomr(i);


            for (int j = 0; j < 25; j++)
            {
                if (result[j] == random[i])
                {
                    
                }
            }
        }


    }

 

   
}
