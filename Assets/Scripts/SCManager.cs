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
    public float lastSpawnTime = 0;
    public float spawnTime = 0;

    public bool isPlay;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
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
    public void StartGame()
    {
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
}
