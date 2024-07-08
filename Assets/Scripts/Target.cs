using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Target : MonoBehaviour
{
    //[SerializeField] private Point point;
    //[SerializeField] private float showTime = 5;
    //[SerializeField] private float spawnDistance = 5;
    public float readyTime = 4;
    public GameObject fire;
    public Transform collider;
    public Sequence sequence;
    public bool isReady;
    public float timer;

    private void Start()
    {
        //transform.DORotate(new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)), 20);
        //ChangePos();
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Explore")
    //    {
    //        if (SCManager.Instance.isPlay)
    //        {
    //            SCManager.Instance.Lose();
    //        }
    //        Destroy(gameObject);
    //    }
    //}
    private void Update()
    {
        if (SCManager.Instance.isPlay && isReady)
        {
            timer += Time.deltaTime;
            if (timer > readyTime)
            {
                SCManager.Instance.Lose(this);
            }
        }
    }
    //public void ChangePos()
    //{
    //    timer = 0;
    //    transform.position = Random.onUnitSphere * spawnDistance + new Vector3(0, 2, 0);
    //    transform.position = new Vector3(
    //        transform.position.x,
    //        Mathf.Abs(transform.position.y),
    //        transform.position.z);

    //    transform.LookAt(playerCam);
    //}
    //public void SpawnPoint(int s)
    //{
    //    Point pointSpawned = Instantiate(point, GameManager.Instance.containPoint);
    //    pointSpawned.transform.position = transform.position;
    //    pointSpawned.ShowPoint(s);
    //    ChangePos();
    //}
    public void Move(Vector3 direction)
    {
        transform.LookAt(SCManager.Instance.player);
        //GetComponent<Rigidbody>().velocity = direction;
        if (SCManager.Instance.isPlay)
        {
            sequence = DOTween.Sequence();
            sequence.Append(collider.DOLocalMove(direction, 2)).AppendCallback(() => isReady = true);
            //sequence.Append(collider.DOLocalMove(direction, 2)).AppendCallback(() => SCManager.Instance.Lose(this));
        }
    }
    public void Explore()
    {
        //mesh.material.color = Color.red;
        fire.SetActive(true);
    }
}
