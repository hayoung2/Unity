using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 SpawnValue;
    public int hazardCount;
   

    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    private bool isGameOver;
    private bool isRestart;

    //접근자,설정자 (getter, setter ) 
    //다른 객체에서 Score라는 값을 읽거나 쓸 수 있음 간단하게 값을 변경 또는 얻을 수 있음.
    public int Score { get; set; }//직렬화 [Serialized] 못함 유니티에서 못함. //가상의 값임. 보안이 높음
    

    private void Start()
    {
        isGameOver = false;
        isRestart = false;


        scoreText.text = "";
        restartText.text = "";
        gameOverText.text = "";

        Score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());

    }

    // 반복자 (반복할 수 있도록 지원)
    //숙제 1 yield 구문 알아보기 (C#말고  unity ) or unity Coroutine
    //int num[] [0] [1]...
    //GameObject hazard= Random.Range(0,hazards,Length)는 G =hazards[random];
    IEnumerator SpawnWaves()
    {//무한이면 while 사용 제한되어 있는 반복문이면 for 문 사용 
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            //{중괄호 안에 행해야 할 코드 반복됨.} i++진행.
            for(int i = 0; i < hazardCount; ++i)
            {

                

                GameObject go = hazards[Random.Range(0, hazards.Length)];//0부터 크기만큼 주는 것 ex. 3개 였으니까 그 중에서 하나 선택해서 함

                Vector3 spawnPosition = new Vector3(Random.Range(-SpawnValue.x, SpawnValue.x), SpawnValue.y, SpawnValue.z);//임의의 값을 넣어줌 최솟값 최댓값

                Instantiate(go, spawnPosition, Quaternion.identity);

               

                yield return new WaitForSeconds(spawnWait);
                if (isGameOver)
                {
                    restartText.text = "Press 'R' for Restart ";
                    isRestart = true;

                    break;
                }
            }

            yield return new WaitForSeconds(waveWait);//WaitForSeconds 대기 하는 것 

            if (isGameOver)
            {
                restartText.text = "Press 'R' for Restart ";
                isRestart = true;

                break;
            }//죽었을 때 바로 나오게 하고 싶으면 for문에 넣고 여기에도 넣어줘야함. 아니면 다 사라지고는 위에 꺼 삭제하면 됨

            //int random = Random.Range(0, hazards.Length);
            //GameObject hazard = hazards[random];   ctrl+k+c 주석처리  
            //ctrl +k+u 주석 풀기 




        }

  
    }


    private void Update()
    {
        //만약 isRestart가 false 이면 아무것도 없이 return 하면 종료
        if (!isRestart) return;//return 은 종료로 생각 

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//SceneManager 유니티에서 제공하는 씬 관리  GetAcitiveScene 활성화 되어있는 씬 가져오기 


    }

    public void AddScore(int number)
    {
        Score += number;
        UpdateScore();
    }

    //lambda 선택. 편하게 만듦 간결하게 만들어서 가독성 좋아짐. 
    //private void UpdateScore()=>scoreText.text = "Score : " +Score
    private void UpdateScore()
    {
        scoreText.text = "Score : " + Score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!\n Result : "+Score;
        isGameOver = true;
    }





}
