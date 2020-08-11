// https://answers.unity.com/questions/242648/force-on-character-controller-knockback.html

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExplosion : MonoBehaviour
{
    public float explosionPower = 100f;

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player") {
            Debug.Log("Hit Player");
            Vector3 dir = other.transform.position - transform.position;

            float force = Mathf.Clamp(explosionPower/3, 0, 30);

            other.GetComponent<ImpactController>().AddImpact(dir, force);
        }
    }
}
