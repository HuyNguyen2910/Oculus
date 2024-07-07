using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NHT_SpawnAim : MonoBehaviour
{
    public GameObject[] spawnPoint;
    public GameObject aim;
    public GameObject prefabAim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (aim.transform.childCount < 4)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        int point = Random.Range(0, spawnPoint.Length);
        Instantiate(prefabAim, spawnPoint[point].transform.position, Quaternion.identity, aim.transform);
    }
}
