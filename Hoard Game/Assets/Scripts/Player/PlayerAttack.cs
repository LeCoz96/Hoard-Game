using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerUI _playerUI;

    [SerializeField] private List<WeaponManager> _weapons = new List<WeaponManager>();

    //[SerializeField] private GameObject _explosiveSpawn;
    //[SerializeField] private GameObject _explosive;

    void Start()
    {
        _playerUI = GetComponent<PlayerUI>();
    }

    public void Attack()
    {
        GetWeaponManager().BaseAttack();
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

    //public void ThrowExplosive()
    //{
    //    Instantiate(_explosive, _explosiveSpawn.transform.position, transform.rotation);
    //}

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
