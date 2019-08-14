using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    private bool isStart = false;


    private void OnGUI()
    {
         

        if (GUI.Button(
                  new Rect(Screen.width - (24f + 96f),
                          Screen.height - (24f + 68f),
                          96f,
                          68f),
                  isStart ? "ReStart" : "Start"))
        {
            SceneManager.LoadScene("GameView");
        }
        
    }
}
