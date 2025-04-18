using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : WeaponManager
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _bulletSpawn;
    [SerializeField] private PlayerUI _playerUI;

    private float _shotWaitTime = 0.0f;

    void Update()
    {
        if (!CheckCanShoot() && _weapon.IsAutomatic())
        {
            if (_shotWaitTime >= 0.0f)
            {
                _shotWaitTime -= Time.deltaTime;
            }
            else
            {
                EnableShoot();
            }
        }
    }

    protected override void Attack()
    {
        if (!_weapon.IsReloading() && CheckCanShoot())
        {
            if (HasAmmo())
            {
                Shoot();
            }
            else
            {
                Debug.Log("NO AMMO PLAY EMPTY CLIP SOUND");
            }
        }
    }

    protected override void Reload()
    {
        if (_weapon.CanReload())
        {
            _playerUI.UpdateReloadBar(_weapon.GetReloadSpeed());
            StartCoroutine(ReloadDelay());
        }
    }

    public override bool CanReload()
    {
        return _weapon.CanReload();
    }

    private bool HasAmmo()
    {
        return _weapon.GetCurrentAmmo() > 0;
    }

    private void Shoot()
    {
        _weapon.SetCanShoot(false);

        Instantiate(_bullet, _bulletSpawn.transform.position, transform.rotation); // add accuracy further into the project
        /*
         * float x  = Random.Range(-horizontalSpread, horizontalSpread);
         * float y  = Random.Range(-verticalSpread, verticalSpread);    
         * 
         * transform.rotation + new Vector3(x, y, 0);
         * 
         * Not sure this will work, but something like this
         */
        if (_isAmmoBuffed == false)
        {
            _weapon.SetCurrentClipSize(-1);
            _playerUI.UpdateCurrentAmmo(_weapon.GetCurrentAmmo());
        }

        _shotWaitTime = _weapon.GetFireRate();
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
        _playerUI.UpdateCurrentWeaponAmmo(_weapon.GetCurrentAmmo(), _weapon.GetRemainingAmmo());
    }

    private void UpdateClip()
    {
        _weapon.UpdateAmmo();

        _playerUI.UpdateCurrentWeaponAmmo(_weapon.GetCurrentAmmo(), _weapon.GetRemainingAmmo());
    }

    private IEnumerator ReloadDelay()
    {
        _weapon.ToggleReload();

        yield return new WaitForSeconds(_weapon.GetReloadSpeed());

        UpdateClip();

        _weapon.ToggleReload();
    }
}
