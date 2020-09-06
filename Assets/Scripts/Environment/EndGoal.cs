using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGoal : MonoBehaviour
{
    public Text winLoseText;

    public Timer timer;

    public EnemyCounter enemyCounter;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && enemyCounter.curEnemies == 0) 
        {
            winLoseText.text = "Win";
            timer.timerOn = false;
        }
    }
}
