using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammo;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            other.GetComponent<PlayerWeapon>().GiveAmmo(ammo);
            Destroy(this.gameObject);
        }
    }
}
