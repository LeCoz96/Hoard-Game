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

    public void Shoot()
    {
        GetWeaponManager().BaseAttack();
    }

    public void Reload()
    {
        if (!SO_PlayerSystems._isReloading)
        {
            Debug.Log("Reload");
           
            WeaponManager weapon = GetWeaponManager();

            _playerUI.UpdateReloadBar(weapon.GetCurrentWeapon().GetReloadSpeed());
            weapon.BaseReload();
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
