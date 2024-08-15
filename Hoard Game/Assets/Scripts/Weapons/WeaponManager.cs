using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponManager : MonoBehaviour
{
    [SerializeField] protected SO_Weapon _weapon;
    [SerializeField] protected PlayerInventory _playerInventory;

    public SO_Weapon GetCurrentWeapon() { return _weapon; }

    public virtual bool CanReload() { return true; }

    public void BaseAttack()
    {
        Attack();
    }
    protected virtual void Attack() { }

    public void BaseReload()
    {
        Reload();
    }
    protected virtual void Reload() { }
}
