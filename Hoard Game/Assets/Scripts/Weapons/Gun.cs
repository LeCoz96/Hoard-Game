using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : WeaponManager
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _bulletSpawn;
    [SerializeField] private PlayerUI _playerUI;

    private float _current = 0.0f;

    void Update()
    {
        if (!CheckCanShoot() && _weapon.IsAutomatic())
        {

            if (_current >= 0.0f)
                _current -= Time.deltaTime;
            else
                EnableShoot();
        }
    }

    protected override void Attack()
    {
        if (!IsReloading() && CheckCanShoot())
        {
            if (HasAmmo())
            {
                Shoot();

                if (!HasAmmo())
                    Reload();
            }
            else
                Reload();
        }
    }

    protected override void Reload()
    {
        if (_weapon.CanReload())
        {
            _playerUI.UpdateReloadBar(_weapon.GetReloadSpeed());
            Invoke("UpdateClip", _weapon.GetReloadSpeed());
        }
        //else
        //    // play animation
    }

    public override bool CanReload()
    {
        return _weapon.CanReload();
    }

    private bool IsReloading()
    {
        return SO_PlayerSystems.GetIsReloading();
    }

    private bool HasAmmo()
    {
        return _weapon.GetCurrentAmmo() > 0;
    }

    private void Shoot()
    {
        _weapon.SetCanShoot(false);

        Instantiate(_bullet, _bulletSpawn.transform.position, transform.rotation);

        _weapon.SetCurrentClipSize(-1);

        _playerUI.UpdateCurrentWeaponAmmo(_weapon.GetCurrentAmmo(), _weapon.GetTotalAmmo());

        _current = _weapon.GetFireRate();
    }

    private void EnableShoot()
    {
        _weapon.SetCanShoot(true);
    }

    private bool CheckCanShoot()
    {
        return _weapon.CanShoot();
    }

    private void OnEnable()
    {
        _playerUI.UpdateCurrentWeaponAmmo(_weapon.GetCurrentAmmo(), _weapon.GetTotalAmmo());
    }

    private void UpdateClip()
    {
        _weapon.UpdateAmmo();

        _playerUI.UpdateCurrentWeaponAmmo(_weapon.GetCurrentAmmo(), _weapon.GetTotalAmmo());
    }
}
