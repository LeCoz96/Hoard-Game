using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponManager : MonoBehaviour
{
    [SerializeField] private SO_Weapon _weapon;

    [SerializeField] protected bool _isGun;

    public void BaseAttack()
    {
        Attack();
    }
    protected virtual void Attack() { }

    public void BaseReload()
    {
        if (_isGun)
            Reload();
        //else
        //{
        //    // play animation
        //}
    }
    protected virtual void Reload() { }
}
