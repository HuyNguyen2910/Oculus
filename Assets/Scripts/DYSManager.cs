using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DYSManager : MonoBehaviour
{
    public static DYSManager Instance;
    public AudioSource shootedAudio;
    public AudioSource blockedAudio;
    public AudioSource startAudio;
    public AudioSource loseAudio;
    public float time;
    public int count;

    [SerializeField] private Button startButton;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI startText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject startObj;
    [SerializeField] private Transform containTarget;
    [SerializeField] private float spawnTime = 4f;
    public float lastSpawnTime = 0;

    [SerializeField] private string loseString = "YOU LOSE!";
    [SerializeField] private string restartString = "Restart";
    [SerializeField] private string timerString = "Timer: ";

    public GameObject target;
    public bool isPlay;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }
    private void Update()
    {
        //if (isPlay)
        //{
        //    time += Time.deltaTime;
        //    timerText.text = timerString + Mathf.Round(time);
        //    if (time > spawnTime)
        //    {
        //        SpawnTarget();
        //        time = 0;
        //    }
        //}

        if (isPlay)
        {
            time += Time.deltaTime;
            timerText.text = timerString + Mathf.Round(time);

            if (Time.time >= lastSpawnTime + spawnTime)
            {
                SpawnTarget();
            }
        }
    }
    void UpdateSpawnTime()
    {
        lastSpawnTime = Time.time;
    }
    public void StartGame()
    {
        startAudio.Play();
        time = 0;
        count = 1;
        Time.timeScale = 1;
        isPlay = true;
        startObj.gameObject.SetActive(false);
        foreach (Transform transform in containTarget)
        {
            Destroy(transform.gameObject);
        }    
        SpawnTarget();
    }
    private void SpawnTarget()
    {
        for (int n = 0; n < count; n++)
        {
            Instantiate(target, containTarget.position, Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)), containTarget);
            UpdateSpawnTime();
        }

        if (time > 10 && time <= 20) count = 2;
        else if (time > 20 && time <= 30) count = 3;
        else if (time > 30 && time <= 40) count = 4;
        else if (time > 40 && time <= 50) count = 5;
        else if (time > 50 && time <= 60) count = 6;
        else if (time > 60 && time <= 70) count = 7;
        else if (time > 70 && time <= 80) count = 8;
        else if (time > 80 && time <= 90) count = 9;
        else if (time > 90 && time <= 100) count = 10;
        else if (time > 100 && time <= 110) count = 11;
        //StartCoroutine(WaitToSpawn());
    }
    //private IEnumerator WaitToSpawn()
    //{
    //    yield return new WaitForSeconds(spawnTime);

    //    SpawnTarget();
    //}
    public void SetButtonStart()
    {
        loseAudio.Play();
        startObj.gameObject.SetActive(true);
        startText.text = restartString;
        titleText.text = loseString;
    }
}
