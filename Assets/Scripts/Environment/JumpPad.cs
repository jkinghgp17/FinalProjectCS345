using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpHeight = 10f;

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            other.GetComponent<MovementController>().changeJumpHeight(jumpHeight);
        }
    }

    void OnTriggerExit(Collider other) 
    {
        if (other.tag == "Player")
        {
            other.GetComponent<MovementController>().resetJumpHeight();
        }
    }
}
