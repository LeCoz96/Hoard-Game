using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : WeaponManager
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _bulletSpawn;

    [SerializeField] private PlayerUI _playerUI;

    protected override void Attack()
    {
        if (_weapon.GetCurrentAmmo() <= 0)
            Reload();
        else
        {
            Instantiate(_bullet, _bulletSpawn.transform.position, transform.rotation);

            _weapon.SetCurrentClipSize(-1);

            if (_weapon.GetCurrentAmmo() <= 0)
                Reload();
            else
                _playerInventory.UpdateCurrentAmmo(_weapon.GetCurrentAmmo(), _weapon.GetTotalAmmo());
        }

    }

    protected override void Reload()
    {
        if (_weapon.CanReload())
        {
            UpdateClip();

            _playerInventory.UpdateCurrentAmmo(_weapon.GetCurrentAmmo(), _weapon.GetTotalAmmo());
        }
        //else
        //    // play animation
    }

    public override bool CanReload()
    {
        return _weapon.CanReload();
    }

    private void OnEnable()
    {
        _playerInventory.SetCurrentWeapon(_weapon);
    }

    private void UpdateClip()
    {
        _weapon.SetTotalAmmo(_weapon.GetCurrentAmmo() - _weapon.GetMaxClip());
        _weapon.SetCurrentClipSize(_weapon.GetMaxClip() - _weapon.GetCurrentAmmo());
    }
}
