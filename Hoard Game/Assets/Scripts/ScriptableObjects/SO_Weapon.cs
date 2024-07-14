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
    [SerializeField] private int _ammoCapacity;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _reloadSpeed;
    [SerializeField] private bool _automatic;
    [Header("Weapon UI")]
    [SerializeField] private GameObject _weaponPrefab;
    [SerializeField] private Sprite _weaponIcon;
    [SerializeField] private Material _weaponMaterial;

    public int GetMaxClipSize() { return _maxAmmo; }
    public int GetCurrentClipSize() { return _currentAmmo; }
    public int GetAmmoCapasity() { return _ammoCapacity; }
    public float GetFireRate() { return _fireRate; }
    public float GetReloadSpeed() { return _reloadSpeed; }
    
    public int AddAmmo(int value)
    {
        if ((_currentAmmo + value) >= _maxAmmo)
            return _maxAmmo;
        else
        {
            _currentAmmo += value;
            return _currentAmmo;
        }
    }
}
