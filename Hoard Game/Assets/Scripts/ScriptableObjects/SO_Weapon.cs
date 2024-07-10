using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SO_Weapon : ScriptableObject
{
    [Header("Weapon Attributes")]
    [SerializeField] private int _maxClipSize;
    [SerializeField] private int _currentClipSize;
    [SerializeField] private int _ammoCapasity;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _reloadSpeed;
    [Header("Weapon UI")]
    [SerializeField] private GameObject _weaponPrefab;
    [SerializeField] private Image _weaponIcon;
    [SerializeField] private Material _weaponMaterial;

    public int GetMaxClipSize() { return _maxClipSize; }
    public int GetCurrentClipSize() { return _currentClipSize; }
    public int GetAmmoCapasity() { return _ammoCapasity; }
    public float GetFireRate() { return _fireRate; }
    public float GetReloadSpeed() { return _reloadSpeed; }
}
