using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Lazer weapon;

    public void GiveAmmo(int ammo)
    {
        weapon.ammo += ammo;
        Destroy(this);
    }
}
