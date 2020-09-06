using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCounter : MonoBehaviour
{
    public Text health;
    public int maxHealth = 4;
    public int curHealth;
	public Text winLoseText;

	public Timer timer;

	void Start()
    {
        curHealth = maxHealth;
    }

    void Update()
    {
		if (curHealth >= 0)
		{
			health.text = "Health: " + curHealth + "/" + maxHealth;
		}
		if (curHealth == 0)
		{
			winLoseText.text = "Lose";
			timer.timerOn = false;
		}
    }

    public void KillEnemy()
    {
        curHealth--;
    }
}