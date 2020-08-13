using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;

    public Text timerText;

    public Text winLostText;

    public bool timerOn;

    void Start()
    {
        timerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn) time -= Time.deltaTime;
        if (time < 0) {
            time = 0;
            winLostText.text = "lost";
        }

        timerText.text = "Time: " + Mathf.Floor(time);
    }
}
