using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGoal : MonoBehaviour
{
    public Text winLoseText;

    public Timer timer;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            winLoseText.text = "Win";
            timer.timerOn = false;
        }
    }
}
