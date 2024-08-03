using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponManager : MonoBehaviour
{
    [SerializeField] protected SO_Weapon _weapon;

    [SerializeField] protected bool _isGun;

    public SO_Weapon GetCurrentWeapon() { return _weapon; }

    public void BaseAttack()
    {
        Attack();
    }
    protected virtual void Attack() { }

    public void BaseReload()
    {
        Reload(); // play animation of not a gun
    }
    protected virtual void Reload() { }
}
