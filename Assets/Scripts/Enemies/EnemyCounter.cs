using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    public Text ec;

    public int maxEnemies = 4;
    public int curEnemies;

    void Start()
    {
        curEnemies = maxEnemies;
    }

    void Update()
    {
        ec.text = "Enemies: " + curEnemies + "/" + maxEnemies;
    }

    public void KillEnemy()
    {
        curEnemies--;
    }
}
