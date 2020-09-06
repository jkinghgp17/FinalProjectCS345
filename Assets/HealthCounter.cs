using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCounter : MonoBehaviour
{
    public Text health;
    public int maxHealth = 4;
    public int curHealth;

    void Start()
    {
        curHealth = maxHealth;
    }

    void Update()
    {
        health.text = "Health: " + curHealth + "/" + maxHealth;
    }

    public void KillEnemy()
    {
        curHealth--;
    }
}