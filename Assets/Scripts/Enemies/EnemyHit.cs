using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public EnemyCounter enemyCounter;

    public void takeHit()
    {
        enemyCounter.KillEnemy();
        Destroy(this.gameObject);
    }
}
