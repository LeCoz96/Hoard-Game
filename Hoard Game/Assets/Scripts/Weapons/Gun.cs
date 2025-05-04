using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : WeaponManager
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _player;
    [SerializeField] private PlayerUI _playerUI;
    [SerializeField] private PlayerAudioManager _playerAudio;

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

        Debug.DrawRay(_camera.transform.position, (_camera.transform.forward * _weapon.GetDamageRange()), Color.green);
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

        RaycastHit hit;

        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _weapon.GetDamageRange()))
        {
            switch (hit.transform.gameObject.layer)
            {
                case 3:
                    hit.transform.GetComponent<EnemyCollisionDamageManager>().TakeDamage(_weapon.GetDamage());
                    break;
                case 7:
                    hit.transform.GetComponent<BasicCollisionDamageManager>().TakeDamage(_weapon.GetDamage());
                    break;
                default:
                    break;
            }
        }

        _playerAudio.PlaySound(_weapon.GetAttackSound(), _player);

        //if (_isAmmoBuffed == false) // UNCOMMENT WHEN DEBUGGING IS COMPLETE
        //{
        //    _weapon.SetCurrentClipSize(-1);
        //    _playerUI.UpdateCurrentAmmo(_weapon.GetCurrentAmmo());
        //}

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

        _playerAudio.PlaySound(_weapon.GetReloadSound(), gameObject);

        yield return new WaitForSeconds(_weapon.GetReloadSpeed());

        UpdateClip();

        _weapon.ToggleReload();
    }
}
