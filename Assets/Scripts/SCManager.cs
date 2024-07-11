using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class SCManager : MonoBehaviour
{
    public static SCManager Instance;
    public Target target;
    public List<Transform> spawnPos;
    public Transform player;
    public Transform containTarget;
    public GameObject startObj;
    public AudioSource shootedAudio;
    public AudioSource loseAudio;
    public Button startButton;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI startText;
    public Vector3 upVector;
    public Vector3 rightVector;
    public Vector3 leftVector;
    //public float minSpawnTime = 0.2f;
    //public float maxSpawnTime = 1f;
    public float lastSpawnTime = 0;
    public float spawnTime = 0;

    private float defaultSpawnTime;
    public bool isPlay;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        defaultSpawnTime = spawnTime;
        isPlay = false;
        startButton.onClick.AddListener(StartGame);
    }
    void Update()
    {
        if (isPlay && Time.time >= lastSpawnTime + spawnTime)
        {
            SpawnTarget();
        }
    }
    void UpdateSpawnTime()
    {
        lastSpawnTime = Time.time;
        //spawnTime = Random.Range(minSpawnTime, maxSpawnTime);
    }
    public void StartGame()
    {
        isPlay = true;
        spawnTime = defaultSpawnTime;
        startObj.SetActive(false);
        foreach (Transform child in containTarget)
        {
            Destroy(child.gameObject);
        }
        CanvasScore.Instance.RestartGame();
        titleText.text = "Crime Shooter";
        SpawnTarget();
    }
    public void SpawnTarget()
    {
        int index = Random.Range(0, spawnPos.Count - 1);
        Vector3 direction = new Vector3();

        Target tar = Instantiate(target, spawnPos[index].position, Quaternion.identity, containTarget);

        switch (spawnPos[index].GetComponent<Pos>().direction)
        {
            case 0:
                direction = upVector;
                break;
            case 1:
                direction = rightVector;
                break;
            case 2:
                direction = leftVector;
                break;
        }
        tar.Move(direction);
        UpdateSpawnTime();

        int score = CanvasScore.Instance.score;
        if (score > 5 && spawnTime > 1) spawnTime -= 0.05f;
    }
    public void Lose(Target target)
    {
        isPlay = false;
        loseAudio.Play();
        target.Explore();
        startObj.gameObject.SetActive(true);
        //startButton.onClick.AddListener(CanvasScore.Instance.RestartGame);
        startText.text = "Restart";
        titleText.text = "You have been shot!";
    }
}
