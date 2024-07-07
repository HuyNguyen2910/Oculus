using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NHT_PlayerController : MonoBehaviour
{
    public GameObject gameController;
    public GameObject timer, score;
    public GameObject gunController;
    public GameObject gun;
    public GameObject startPos, endPos;
    bool ban;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        float f = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);
        print(f);
        if (f > 0f && ban && timer.GetComponent<NHT_Time>().boolTimer)
        {
            Fire();
            print("A");
            ban = false;
        }
        if (f == 0f)
            ban = true;
    }

    public void Fire()
    {
        Ray ray = new Ray(gun.transform.position, Direction());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "Point") // default layer
            {
                Destroy(hit.collider.gameObject);
                score.GetComponent<NHT_Score>().score++;
            }
        }
    }

    public Vector3 Direction()
    {
        return endPos.transform.position - startPos.transform.position;
    }
}
