using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Target : MonoBehaviour
{
    [SerializeField] private Point point;
    [SerializeField] private Transform playerCam;
    [SerializeField] private float showTime = 5;
    [SerializeField] private float ymin = 0.5f;
    [SerializeField] private float ymax = 12;
    [SerializeField] private float xpos = 12;
    [SerializeField] private float zpos = -12;

    private float timer;

    private void Start()
    {
        ChangePos();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > showTime)
        {
            ChangePos();
        }
    }
    public void ChangePos()
    {
        timer = 0;
        transform.position = new Vector3(Random.Range(-xpos, xpos), Random.Range(ymin, ymax), zpos);
        transform.LookAt(playerCam);
    }
    public void SpawnPoint(int s)
    {
        Point pointSpawned = Instantiate(point, GameManager.Instance.containPoint);
        pointSpawned.transform.position = transform.position;
        pointSpawned.ShowPoint(s);
        ChangePos();
    }
}
