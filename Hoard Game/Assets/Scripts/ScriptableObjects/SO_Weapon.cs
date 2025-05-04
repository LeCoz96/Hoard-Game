using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon")]
public class SO_Weapon : ScriptableObject
{
    [Header("Weapon Attributes")]
    [SerializeField] private int _maxAmmo;
    [SerializeField] private int _currentClip;
    [SerializeField] private int _remainingAmmo;
    [SerializeField] private int _maxClip;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _reloadSpeed;
    [SerializeField] private float _damage;
    [SerializeField] private bool _isAutomatic;
    [SerializeField] private bool _isMelee;
    [SerializeField] private float _damageRange;
    private bool _canShoot;
    private bool _isReloading;
    [Header("Weapon UI")]
    [SerializeField] private GameObject _weaponPrefab;
    [SerializeField] private Sprite _weaponIcon;
    [SerializeField] private Material _weaponMaterial;
    [Header("Weapon Audio")]
    [SerializeField] private AudioClip _attackSound;
    [SerializeField] private AudioClip _reloadSound;

    public int GetCurrentAmmo() { return _currentClip; }
    public int GetRemainingAmmo() { return _remainingAmmo; }
    public int GetTotalAmmo() { return _currentClip + _remainingAmmo;  }
    public int GetMaxClip() { return _maxClip; }
    public float GetFireRate() { return _fireRate; }
    public float GetReloadSpeed() { return _reloadSpeed; }
    public float GetDamage() { return _damage; }
    public float GetDamageRange() { return _damageRange; }
    public bool GetIsMelee() { return _isMelee;  }
    public AudioClip GetAttackSound() { return _attackSound; }
    public AudioClip GetReloadSound() { return _reloadSound; }

    public bool CanCollect() { return _remainingAmmo < _maxAmmo; }
    public void SetCurrentClipSize(int value) { _currentClip += value; }
    public void SetRemainingAmmo(int value) { _remainingAmmo += value; }
    public bool CanReload() { return _currentClip < _maxClip && _remainingAmmo > 0; }

    public bool IsAutomatic() { return _isAutomatic; }
    public bool CanShoot() { return _canShoot; }
    public void SetCanShoot(bool value) { _canShoot = value; }
    public void ToggleCanShoot() { _canShoot = !_canShoot; }

    public void ToggleReload() { _isReloading = !_isReloading; }
    public bool IsReloading() { return _isReloading; }

    public void UpdateAmmo()
    {
        if (_remainingAmmo > 0)
        {
            if (_remainingAmmo < _maxClip)
            {
                _currentClip = _remainingAmmo;
                _remainingAmmo = 0;
            }
            else
            {
                _remainingAmmo -= (_maxClip - _currentClip);
                _currentClip = _maxClip;
            }
        }
    }

    public void AddAmmo(int value)
    {
        if((_remainingAmmo + value) >= _maxAmmo)
        {
            _remainingAmmo = _maxAmmo;
        }
        else
        {
            _remainingAmmo += value;
        }
    }
}
