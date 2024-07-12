using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class ButtonOVR : MonoBehaviour
{
    public Button btn;
    public bool score;
    public float timer;
    public GameObject bomb;
    public GameObject point;
    private void Start()
    {
        score = Random.value > 0.5f;
        if (point != null) point.SetActive(score);
        if (bomb != null) bomb.SetActive(!score);
        if (btn != null)
        {
            GetComponent<BoxCollider>().size = GetComponent<RectTransform>().rect.size;
        }
    }
    private void Update()
    {
        if (btn == null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    public void OnRaycastClick()
    {
        if (btn != null)
        {
            //transform.DOScale(new Vector3(.8f, .8f, .8f), .1f).onComplete += () =>
            //{
            //    transform.DOScale(new Vector3(1, 1, 1), .1f).onComplete += () => btn.onClick.Invoke();
            //};
            btn.onClick.Invoke();
        }
        else
        {
            if (SCManager.Instance.isPlay)
            {
                Debug.Log("Shoot!");
                CanvasScore.Instance.AddScore(score ? (int)Mathf.Floor((1 - timer) * 10) : -5);
                if (score) SCManager.Instance.shootedAudio.Play();
                else SCManager.Instance.bombAudio.Play();
                //target.SpawnPoint(score);
                //GetComponent<Target>().sequence.Kill();
                //SCManager.Instance.SpawnTarget();
                Destroy(gameObject);
            }
        }
    }
}
