using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Text timerText;
    int timerStartValue = 120;

    // Start is called before the first frame update
    void Start()
    {
        countDownTimer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void countDownTimer()
    {
        if (timerStartValue > 0)
        {
            TimeSpan spanTime = TimeSpan.FromSeconds(timerStartValue);
            timerText.text = "Time left: " + spanTime.Minutes + " : " + spanTime.Seconds;
            timerStartValue--;
            Invoke("countDownTimer", 1.0f);
        }
        else
        {
            SceneManager.LoadScene(3);
        }
    }    
}
