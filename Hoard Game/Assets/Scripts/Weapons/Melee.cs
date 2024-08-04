using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : WeaponManager
{
    protected override void Attack()
    {
        Debug.Log("Katana attack");
    }

    protected override void Reload()
    {
        // play animation
        Debug.Log(gameObject.name + " is reloading");
    }
}
