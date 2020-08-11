using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public Transform muzzlePoint;

    public ImpactController playerImpact;

    public GameObject singleShotEffect;

    public GameObject continuousShotEffect;

    private float singleShotEffectTime;
    private float continuousShotEffectTime;

    void Start()
    {
        singleShotEffectTime = 0;
        continuousShotEffectTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
        if (Input.GetButtonDown("Fire1")) {
            playerImpact.AddImpact(-transform.forward, 100);
            singleShotEffectTime = 0.25f;
            singleShotEffect.SetActive(true);
        } else if (Input.GetButton("Fire2")) {
            playerImpact.AddContinousImpact(-transform.forward, 100);
            continuousShotEffectTime = 0.25f;
            continuousShotEffect.SetActive(true);
        }
    }
}
