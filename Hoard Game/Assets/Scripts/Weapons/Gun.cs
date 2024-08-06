using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : WeaponManager
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _bulletSpawn;

    protected override void Attack()
    {
        if (_weapon.GetCurrentAmmo() <= 0)
        {
            Reload();
        }
        else
        {
            Instantiate(_bullet, _bulletSpawn.transform.position, transform.rotation);

            _weapon.SetCurrentClipSize(_weapon.GetCurrentAmmo() - 1);

            _playerInventory.UpdateCurrentAmmo(_weapon.GetCurrentAmmo(), _weapon.GetTotalAmmo());
        }

    }

    protected override void Reload()
    {
        Debug.Log(gameObject.name + " is reloading");

        UpdateClip();

        _playerInventory.UpdateCurrentAmmo(_weapon.GetCurrentAmmo(), _weapon.GetTotalAmmo());
    }

    private void OnEnable()
    {
        _playerInventory.SetCurrentWeapon(_weapon);
    }

    private void UpdateClip()
    {
        // update total ammo to -(currentclip - maxclip) size
        // udapte current clip to max clip
    }
}
