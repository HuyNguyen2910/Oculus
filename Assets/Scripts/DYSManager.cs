using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DYSManager : MonoBehaviour
{
    public static DYSManager Instance;
    public Transform player;
    public AudioSource shootedAudio;
    public AudioSource blockedAudio;
    public AudioSource loseAudio;
    public float time;

    [SerializeField] private Collider shield;
    [SerializeField] private Button startButton;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI startText;
    [SerializeField] private GameObject startObj;
    [SerializeField] private List<GameObject> target;
    [SerializeField] private Transform containTarget;
    [SerializeField] private float spawnTime = 4f;
    [SerializeField] private float ymin = 0.5f;
    [SerializeField] private float ymax = 12;
    [SerializeField] private float xpos = 12;
    [SerializeField] private float zpos = -12;

    [SerializeField] private string loseString = "YOU LOSE!";
    [SerializeField] private string restartString = "Restart";
    private float saveSpawnTime;
    
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        saveSpawnTime = spawnTime;
        startButton.onClick.AddListener(StartGame);
    }
    private void Update()
    {
        if (time > 0)
        {
            time += Time.deltaTime;
            if (time > spawnTime)
            {
                SpawnTarget();
                if (spawnTime > 1) spawnTime -= 0.01f;
                time = 0.001f;
            }
        }
    }
    public void StartGame()
    {
        spawnTime = saveSpawnTime;
        player.GetComponent<Collider>().enabled = true;
        shield.enabled = true;
        DYSCanvas.Instance.RestartGame();
        Time.timeScale = 1;
        startObj.gameObject.SetActive(false);
        foreach (Transform transform in containTarget)
        {
            Destroy(transform.gameObject);
        }    
        SpawnTarget();
    }
    private void SpawnTarget()
    {
        GameObject targetObj = target[Random.Range(0, target.Count - 1)];
        targetObj.transform.position = new Vector3(Random.Range(-xpos, xpos), Random.Range(ymin, ymax), zpos);

        targetObj.transform.LookAt(containTarget);
        Instantiate(targetObj, containTarget);
        time = 0.001f;
        //StartCoroutine(WaitToSpawn());
    }
    //private IEnumerator WaitToSpawn()
    //{
    //    yield return new WaitForSeconds(spawnTime);

    //    SpawnTarget();
    //}
    public void Lose()
    {
        player.GetComponent<Collider>().enabled = false;
        shield.enabled = false;
        loseAudio.Play();
        time = 0;
        startObj.gameObject.SetActive(true);
        //startButton.onClick.AddListener(DYSCanvas.Instance.RestartGame);
        startText.text = restartString;
        titleText.text = loseString;
    }
}
