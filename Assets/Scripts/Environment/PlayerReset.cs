using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReset : MonoBehaviour
{

    public Transform resetLocation;
    
    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            other.transform.rotation = resetLocation.rotation;
            other.transform.position = resetLocation.position;
        }
    }
}
