using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Target : MonoBehaviour
{
    public float reachTime = 2;
    public float readyTime = 3;
    public Transform endValue;
    public GameObject target;

    private float timer;
    private bool ready;
    private void Start()
    {
        transform.DOShakePosition(readyTime, 0.1f);
    }
    private void Update()
    {
        if (!ready)
        {
            timer += Time.deltaTime;
            if (timer > readyTime)
            {
                DOTween.Sequence().Append(transform.DOMove(endValue.position, reachTime)).AppendCallback(() => Destroy(target));
                ready = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Killed!");
            Time.timeScale = 0;
            DYSManager.Instance.SetButtonStart();
            //DYSCanvas.Instance.Lose();
        }
    }
}
