using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject explosion;

    public float explosionTime = 0.05f;

    void OnCollisionEnter(Collision other)
    {   
        if (other.gameObject.tag == "Player") {return;}
        GameObject e = Instantiate(explosion, transform.position, transform.rotation);
        Destroy(e, explosionTime);
        Destroy(this.gameObject);
    }
}
