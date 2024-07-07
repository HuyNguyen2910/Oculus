using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NHT_GameController : MonoBehaviour
{
    public GameObject menuObject;
    public GameObject btnPlay, btnPlayAgain;
    public GameObject timer;
    public GameObject score;
    public GameObject getReady;
    public GameObject TrainingEnded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.GetComponent<NHT_Time>().boolTimer)
        {
            getReady.SetActive(false);
            timer.GetComponent<NHT_Time>().txtTime.gameObject.SetActive(true);
            score.GetComponent<NHT_Score>().txtScore.gameObject.SetActive(true);
        }
        if (timer.GetComponent<NHT_Time>().timer == 0)
        {
            menuObject.SetActive(true);
            TrainingEnded.SetActive(true);
        }

        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            // this.gameObject.GetComponent<Gun>().BanVien1();
            print("nHAN CHUP");

            ScreenCapture.CaptureScreenshot("C:/Users/ADMIN/Desktop/AimTrainer/" + System.DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".png");
        }
    }

    public void Play()
    {
        getReady.SetActive(true);
        timer.GetComponent<NHT_Time>().boolTimerReady = true;
        btnPlay.SetActive(false);
        btnPlayAgain.SetActive(true);
    }

    public void PlayAgain()
    {
        menuObject.SetActive(false);
        TrainingEnded.SetActive(false);
        getReady.SetActive(true);
        timer.GetComponent<NHT_Time>().timerReady = 5;
        timer.GetComponent<NHT_Time>().boolTimerReady = true;
        timer.GetComponent<NHT_Time>().timer = timer.GetComponent<NHT_Time>().totalTime;
        timer.GetComponent<NHT_Time>().boolTimer = false;
        score.GetComponent<NHT_Score>().score = 0;
    }
}
