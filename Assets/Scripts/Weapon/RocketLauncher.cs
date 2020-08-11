using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{

    public Transform muzzlePoint;

    public GameObject bullet;

    public float timeBetweenShots = 0.25f;

    public float bulletLifetime = 5f;

    private float timeSinceLastShot;

    void Start()
    {
        timeSinceLastShot = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot -= Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && timeSinceLastShot <= 0) {
            timeSinceLastShot = timeBetweenShots;

            GameObject b = Instantiate(bullet, muzzlePoint.position, muzzlePoint.rotation);
            b.GetComponent<Rigidbody>().AddForce(1000 * b.transform.forward);
            Destroy(b, bulletLifetime);
        }
    }
}
