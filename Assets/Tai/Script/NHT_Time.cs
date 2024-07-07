using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NHT_Time : MonoBehaviour
{
    //CountdownPlay
    public float totalTime;
    public float timer;
    public bool boolTimer = false;
    public TextMeshProUGUI txtTime;

    //CountdownReady
    public float timerReady;
    public bool boolTimerReady = false;
    public TextMeshProUGUI txtTimeReady;

    private void Start()
    {
        boolTimer = false;
        timer = totalTime;
    }

    void Update()
    {
        if (boolTimer)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                timer = Mathf.Clamp(timer, 0, totalTime);
                DisplayTime(timer);
            }
            else
            {
                timer = 0;
                DisplayTime(timer);
                boolTimer = false;
            }
        }

        if (boolTimerReady)
        {
            if (timerReady > 0)
            {
                timerReady -= Time.deltaTime;
                timerReady = Mathf.Clamp(timerReady, 0, 5);
                DisplayTimeReady(timerReady);
            }
            else
            {
                timerReady = 0;
                boolTimerReady = false;
                boolTimer = true;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        //timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        txtTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void DisplayTimeReady(float timeToDisplay)
    {
        txtTimeReady.text = "<color=#FF0000>" + timerReady.ToString("0") + "</color><size=%0.5>s</size>";
    }
}
