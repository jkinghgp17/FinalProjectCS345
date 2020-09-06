using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lazer : MonoBehaviour
{

    public Text ammoCounter;
    public Transform muzzlePoint;

    public ImpactController playerImpact;

    public GameObject singleShotEffect;

    public GameObject continuousShotEffect;

    public FMODUnity.StudioEventEmitter singleShotEmitter;
    public FMODUnity.StudioEventEmitter countinousShotEmitter;

    private float singleShotEffectTime;
    private float continuousShotEffectTime;

    public int ammo;

    public LayerMask shotLayerMask;

    private bool isShooting = false;

    void shootRay() {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0));
        RaycastHit hit;

        if (Physics.Raycast(ray,out hit))
        {
            if (hit.collider.tag == "Enemy")
            {
                Debug.Log("Hit Enemy");
                hit.collider.GetComponent<EnemyHit>().takeHit();
            }
        }
    }

    void Start()
    {
        singleShotEffectTime = 0;
        continuousShotEffectTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ammoCounter.text = "Ammo: " + ammo;
        if (singleShotEffectTime <= 0) {
            singleShotEffect.SetActive(false);
        } else {
            singleShotEffectTime -= Time.deltaTime;
        }
        if (continuousShotEffectTime <= 0) {
            continuousShotEffect.SetActive(false);
        } else {
            continuousShotEffectTime -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire1") && ammo >= 5) {
            playerImpact.AddImpact(-transform.forward, 100);
            singleShotEffectTime = 0.25f;
            singleShotEffect.SetActive(true);
            singleShotEmitter.Play();
            ammo -= 5;
            shootRay();
        } else if (Input.GetButton("Fire2") && ammo >= 1) {
            playerImpact.AddContinousImpact(-transform.forward, 100);
            continuousShotEffectTime = 0.25f;
            continuousShotEffect.SetActive(true);
            ammo -= 1;

            if (!isShooting) {
                isShooting = true;
                countinousShotEmitter.Play();
            }

            RaycastHit hit;
            if (Physics.Raycast(muzzlePoint.position, muzzlePoint.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, shotLayerMask)) {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Hit " + hit.collider.tag);
                if (hit.collider.tag == "PhysicsObject") {
                    hit.rigidbody.AddForce((hit.transform.position - transform.position) * 100);
                }
            }  else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                //Debug.Log("Did not Hit");
            }
            shootRay();
        } else {
            isShooting = false;
        }
    }
}
