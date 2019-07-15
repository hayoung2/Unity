using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextManager : MonoBehaviour
{
    public Text GameoverText;
    public Text RestartText;
    public int startWait;

    private bool isGameOver;
    private bool isRestart;


    void Start()
    {
        isGameOver = false;
        isRestart = false;

        GameoverText.text = "";
        RestartText.text = "";

        
    }

    IEnumerator SpawnWaves()
    {
 

        if (isGameOver)
        {
            isRestart = true;
            RestartText.text = "Press 'R' for Restart ";
           

        }
        yield return new WaitForSeconds(startWait);
    }

    void Update()
    {
        if (!isRestart)
            return;

        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public void GameOver()
    {
        isGameOver = true;
        GameoverText.text = "Game Over! ";
        

        StartCoroutine(SpawnWaves());
    }

   
}
