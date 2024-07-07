using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NHT_GunController : MonoBehaviour
{
    public GameObject gun;

    bool ban;

    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float f = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);
        if (f > 0.5f && ban)
        {
            Fire();
            ban = false;
        }
        if (f <= 0.5f)
            ban = true;
    }

    void Fire()
    {
        //gameObject.GetComponent<AudioSource>().clip = audioClipFire;
        gameObject.GetComponent<AudioSource>().Play();
    }
}
