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
            Shoot();

            Instantiate(_bullet, _bulletSpawn.transform.position, transform.rotation);

            _weapon.SetCurrentClipSize(-1);

            if (_weapon.GetCurrentAmmo() <= 0)
                Reload();
            else
            {
                Invoke("Shoot", _weapon.GetFireRate());

                _playerInventory.UpdateCurrentAmmo(_weapon.GetCurrentAmmo(), _weapon.GetTotalAmmo());
            }

            if (_weapon.CanShoot())
            {
                _weapon.SetCanShoot(false);
            }
        }
    }

    protected override void Reload()
    {
        if (_weapon.CanReload())
        {
            Invoke("UpdateClip", _weapon.GetReloadSpeed());
        }
        //else
        //    // play animation
    }

    public override bool CanReload()
    {
        return _weapon.CanReload();
    }

    private void Shoot()
    {
        _weapon.ToggleCanShoot();
    }

    private void OnEnable()
    {
        _playerInventory.SetCurrentWeapon(_weapon);
    }

    private void UpdateClip()
    {
        _weapon.SetTotalAmmo(_weapon.GetCurrentAmmo() - _weapon.GetMaxClip());
        _weapon.SetCurrentClipSize(_weapon.GetMaxClip() - _weapon.GetCurrentAmmo());

        _playerInventory.UpdateCurrentAmmo(_weapon.GetCurrentAmmo(), _weapon.GetTotalAmmo());
    }
}
