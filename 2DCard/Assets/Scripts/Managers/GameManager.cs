using System;
using System.Collections.Generic;

using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public Vector2Int cardSize;     //  카드 X Y 비율
    public GameObject prefabCard;   //  카드 프리팹

    private Card[] cards = null;    //  사용하고 있는 카드를 담을 배열
    private bool isStart = false;   //  시작했는가?

    private void Awake()
    {
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
    {
        if (GUI.Button(
            new Rect(Screen.width - (24f + 96f),
                    Screen.height - (24f + 68f),
                    96f,
                    68f),
            isStart ? "ReStart" : "Restart"))
        {
            GameStart();
        }
        
    }

    private void GameStart()
    {
        List<Color> colors = new List<Color>(cardSize.x * cardSize.y);
        RandomColor(colors, cards.Length / 2);

        colors.AddRange(colors);
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
