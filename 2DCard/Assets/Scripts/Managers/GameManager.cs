using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

//Manager만들어주는 것 중요 ( 관리하는 객체 만들기) 
public class GameManager : MonoSingleton<GameManager>
{
    public Vector2Int cardSize;     //  카드 X Y 비율 
    public GameObject prefabCard;   //  카드 프리팹

    private Card[] cards = null;    //  사용하고 있는 카드를 담을 배열
    private bool isStart = false;   //  시작했는가?

    private void Awake()
    {

        UserController.Get.enabled = true;

        //씬이 바뀌어도 해당 오브젝트를 파괴 시키지 X려면 아래처럼 코드 구현
        //Get.enabled=true;
        //또는 아래처럼 
        DontDestroyOnLoad(this);
        //GameManger 를 사용하면 손쉽게 Get.Destroy 로 삭제 가능. 
        cards = new Card[cardSize.x * cardSize.y];
       
    }
    private void Start()
    {
        GameStart();
    }

    //  OnGuI?
    //  유니티 게임 뷰에서만 나타나는 UI
    //  일반 함수와 다르게 GUI class 를 이용하여 사용해야한다
    private void OnGUI()
    {// 현재창의 넓이  해상도의 넓이 
        if (GUI.Button(
            new Rect(Screen.width - (24f + 96f), 
                    Screen.height - (24f + 68f),
                    96f,
                    68f),"Restart"))
        {
            SceneManager.LoadScene("GameView");
        }

        //if(GUI.Button(new Rect(250f, 250f, 100f, 25f), "Change!"))
        //{
        //    UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        //}//씬 0번째껄로 바뀜 처음화면 나옴 build setting 에 있는 걸로 나옴  chagne  클릭하면 0번째 씬 나옴. 


        Rect scoreRc = new Rect(Screen.width * .5f - 100f, Screen.height - 32f, 128f, 32f);
        GUI.Label(scoreRc,"Score : "+ Database.Get.Score.ToString());
        
    }

    

    private void GameStart()
    {
        List<Color> colors = new List<Color>(cardSize.x * cardSize.y);
        RandomColor(colors, cards.Length / 2);

        colors.AddRange(colors);//배열의 끝에 값 첨가.
        Shuffle(colors, colors.Count);

        int i = 0;
        for (int y = 0; y < cardSize.y; ++y)
        {
            for (int x = 0; x < cardSize.x; ++x)
            {
                if (cards[i] == null)
                {
                    GameObject go = Instantiate(prefabCard, transform);
                    go.transform.localPosition = new Vector3(x * 2f, y * -2.25f);

                    cards[i] = go.GetComponent<Card>();
                }

                cards[i].CardColor = colors[i++];
            }
        }

        isStart = true;
    }
    
    private void RandomColor(List<Color> list, int count)
    {
        if (count == 0) return;

        Color color = new Color(
            UnityEngine.Random.Range(0f, 1f),   //  0   ~   255
            UnityEngine.Random.Range(0f, 1f),
            UnityEngine.Random.Range(0f, 1f)
            );

        //  List.Exists? 있는지 없는지 확인
        if (list.Exists(x => x.Equals(color))) RandomColor(list, count);
        else
        {
            list.Add(color);
            RandomColor(list, count - 1);
        }
    }

    //  Fisher-Yates shuffle
    //  https://en.wikipedia.org/wiki/Fisher–Yates_shuffle
    private void Shuffle(List<Color> list, int count)
    {
        while (count-- > 1)
        {
            int i = UnityEngine.Random.Range(0, count);

            Color color = list[i];
            list[i] = list[count];
            list[count] = color;
        }
    }

}
