using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerUI _playerUI;

    [SerializeField] private List<WeaponManager> _weapons = new List<WeaponManager>();

    void Start()
    {
        _playerUI = GetComponent<PlayerUI>();
    }

    public void Attack()
    {
        if (GetWeaponManager().GetCurrentWeapon().CanShoot())
        {
            GetWeaponManager().BaseAttack();
        }
    }

    public void EndAttack()
    {
        GetWeaponManager().GetCurrentWeapon().SetCanShoot(true);
    }

    public void Reload()
    {
        if (!SO_PlayerSystems._isReloading)
        {
            WeaponManager weapon = GetWeaponManager();

            if (weapon.CanReload())
            {
                _playerUI.UpdateReloadBar(weapon.GetCurrentWeapon().GetReloadSpeed());

                weapon.BaseReload();
            }
        }
    }

    private WeaponManager GetWeaponManager()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            if (_weapons[i].gameObject.activeInHierarchy)
                return _weapons[i];
        }

        Debug.Log("Cannot get weapon");
        return null;
    }
}
