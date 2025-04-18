using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponManager : MonoBehaviour
{
    [SerializeField] protected SO_Weapon _weapon;
    [SerializeField] protected PlayerInventory _playerInventory;

    protected bool _isUnlimitedAmmo;

    public SO_Weapon GetCurrentWeapon() { return _weapon; }

    public bool GetIsMelee() { return _weapon.GetIsMelee(); }

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

    public void SetUnlimitedAmmo(bool value)
    {
        _isUnlimitedAmmo = value;
    }
}
