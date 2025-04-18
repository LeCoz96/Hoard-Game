using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private List<WeaponManager> _weapons = new List<WeaponManager>();
    [SerializeField] private float _unlimitedAmmoTime;

    private bool _isAttacking = false;

    private void Update()
    {
        if (_isAttacking && GetWeaponManager().GetCurrentWeapon().IsAutomatic())
        {
            Attack();
        }
    }

    public void Attack()
    {
        _isAttacking = true;

        GetWeaponManager().BaseAttack();
    }

    public void EndAttack()
    {
        _isAttacking = false;

        if (!GetWeaponManager().GetCurrentWeapon().IsAutomatic())
        {
            GetWeaponManager().GetCurrentWeapon().SetCanShoot(true);
        }
    }

    public void Reload()
    {
        WeaponManager weapon = GetWeaponManager();

        if (!weapon.GetCurrentWeapon().IsReloading())
        {
            if (weapon.CanReload())
            {
                weapon.BaseReload();
            }
        }
    }

    private WeaponManager GetWeaponManager()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            if (_weapons[i].gameObject.activeInHierarchy)
            {
                return _weapons[i];
            }
        }

        Debug.Log("Cannot get weapon");
        return null;
    }

    public void SetUnlimitedAmmo()
    {
        StartCoroutine(UnlimitedAmmoTimer());
    }

    private IEnumerator UnlimitedAmmoTimer()
    {
        GetWeaponManager().SetUnlimitedAmmo(true);

        yield return new WaitForSeconds(_unlimitedAmmoTime);

        GetWeaponManager().SetUnlimitedAmmo(false);
    }
}
