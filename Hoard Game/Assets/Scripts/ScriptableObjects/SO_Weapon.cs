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
    [SerializeField] private int _currentAmmo;
    [SerializeField] private int _totalAmmo;
    [SerializeField] private int _maxClip;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _reloadSpeed;
    [SerializeField] private bool _isAutomatic;
    [SerializeField] private bool _isMelee;
    private bool _canShoot;
    private bool _isReloading;
    [Header("Weapon UI")]
    [SerializeField] private GameObject _weaponPrefab;
    [SerializeField] private Sprite _weaponIcon;
    [SerializeField] private Material _weaponMaterial;

    public int GetCurrentAmmo() { return _currentAmmo; }
    public int GetTotalAmmo() { return _totalAmmo; }
    public int GetMaxClip() { return _maxClip; }
    public float GetFireRate() { return _fireRate; }
    public float GetReloadSpeed() { return _reloadSpeed; }

    public bool CanCollect() { return _currentAmmo < _maxAmmo; }
    public void SetCurrentClipSize(int value) { _currentAmmo += value; }
    public void SetTotalAmmo(int value) { _totalAmmo += value; }
    public bool CanReload() { return _currentAmmo < _maxClip && _totalAmmo > 0; }

    public bool IsAutomatic() { return _isAutomatic; }
    public bool CanShoot() { return _canShoot; }
    public void SetCanShoot(bool value) { _canShoot = value; }
    public void ToggleCanShoot() { _canShoot = !_canShoot; }

    public void ToggleReload() { _isReloading = !_isReloading; }
    public bool IsReloading() { return _isReloading; }

    public void UpdateAmmo()
    {
        if (_totalAmmo > 0)
        {
            if (_totalAmmo < _maxClip)
            {
                _currentAmmo = _totalAmmo;
                _totalAmmo = 0;
            }
            else
            {
                _totalAmmo -= (_maxClip - _currentAmmo);
                _currentAmmo = _maxClip;
            }
        }
    }

    public int AddAmmo(int value)
    {
        if ((_currentAmmo + value) >= _maxAmmo)
            return _currentAmmo = _maxAmmo;
        else
        {
            _currentAmmo += value;
            return _currentAmmo;
        }
    }
}
