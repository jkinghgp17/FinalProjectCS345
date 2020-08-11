/*
 * https://answers.unity.com/questions/242648/force-on-character-controller-knockback.html
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactController : MonoBehaviour
{
    public float mass = 3.0f;

    public Vector3 impact = Vector3.zero;

    public Vector3 continuedImpact = Vector3.zero;

    public CharacterController character;

    // Update is called once per frame
    void Update()
    {
        if (impact.magnitude > 0.2) character.Move(impact * Time.deltaTime);

        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);

        if (continuedImpact.magnitude > 0.2) character.Move(continuedImpact * Time.deltaTime);

        continuedImpact = Vector3.Lerp(continuedImpact, Vector3.zero, 5 * Time.deltaTime);
    }

    public void AddImpact(Vector3 dir, float force)
    {
        dir.Normalize();
        //if (dir.y < 0) dir.y = -dir.y;

        impact += dir.normalized * force / mass;
    }

    public void AddContinousImpact(Vector3 dir, float force) 
    {
        dir.Normalize();
        //if (dir.y < 0) dir.y = -dir.y;

        continuedImpact = dir.normalized * force / mass;
    }
}
