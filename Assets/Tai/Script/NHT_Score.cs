using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NHT_Score : MonoBehaviour
{
    public float score;
    public TextMeshProUGUI txtScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txtScore.text = "SCORE\n" + score;
    }
}
