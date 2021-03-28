using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public float gameTimer;
    public bool gameInSession = false;
    public Text timerText;
    void Start()
    {
        timerText.text = "Timer - ";
        gameTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameInSession)
        {
            gameTimer += Time.deltaTime;

            timerText.text = "Timer - " + gameTimer.ToString("0.00");
        }
    }
}
