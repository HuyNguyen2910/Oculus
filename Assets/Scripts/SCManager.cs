using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class SCManager : MonoBehaviour
{
    public static SCManager Instance;
    public GameObject target;
    public List<Transform> spawnPos;
    public Transform containTarget;
    public GameObject startObj;
    public AudioSource shootedAudio;
    public AudioSource loseAudio;
    public Button startButton;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI startText;
    public TextMeshProUGUI timerText;
    public float lastSpawnTime = 0;
    public float spawnTime = 0;
    public float timer;

    public bool isPlay;

    private string timerString = "Time :\n";
    private float defaultTimer;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        defaultTimer = timer;
        isPlay = false;
        startButton.onClick.AddListener(StartGame);
    }
    void Update()
    {
        if (isPlay)
        {
            timer -= Time.deltaTime;
            timerText.text = timerString + Mathf.Round(timer);
            if (Time.time >= lastSpawnTime + spawnTime)
            {
                SpawnTarget();
            }
            if (timer < 0)
            {
                TimeOver();
            }
        }
    }
    public void StartGame()
    {
        timer = defaultTimer;
        isPlay = true;
        startObj.SetActive(false);
        DestroyTarget();
        CanvasScore.Instance.RestartGame();
        SpawnTarget();
    }
    public void SpawnTarget()
    {
        DestroyTarget();
        foreach (Transform transform in spawnPos)
        {
            Instantiate(target, transform.position, Quaternion.identity, containTarget);
        }
        //tar.Scale();
        lastSpawnTime = Time.time;
    }
    public void DestroyTarget()
    {
        foreach (Transform child in containTarget)
        {
            Destroy(child.gameObject);
        }
    }
    public void Lose(Target target)
    {
        DOTween.Clear();
        //target.Explore();
        isPlay = false;
        loseAudio.Play();
        startObj.gameObject.SetActive(true);
        //startButton.onClick.AddListener(CanvasScore.Instance.RestartGame);
        startText.text = "Restart";
        titleText.text = "You lose!";
    }
    public void TimeOver()
    {
        isPlay = false;
        timerText.text = timerString + 0;
        loseAudio.Play();
        startObj.gameObject.SetActive(true);
        DestroyTarget();
        //startButton.onClick.AddListener(CanvasScore.Instance.RestartGame);
        startText.text = "Restart";
        titleText.text = "Time Over!";
    }
}
