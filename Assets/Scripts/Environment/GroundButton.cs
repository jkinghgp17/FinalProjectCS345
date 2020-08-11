using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundButton : MonoBehaviour
{
    public Material onMaterial;

    public Material offMaterial;

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player") {
            GetComponent<MeshRenderer>().material = onMaterial;
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player") {
            GetComponent<MeshRenderer>().material = offMaterial;
        }
    }
}
