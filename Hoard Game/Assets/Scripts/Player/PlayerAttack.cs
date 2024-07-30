using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private InputManager _inputManager;

    [SerializeField] private List<WeaponManager> _weapons = new List<WeaponManager>();

    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _bulletSpawn;

    void Start()
    {
        _inputManager = GetComponent<InputManager>();
    }

    public void Shoot()
    {
        GetWeaponManager().BaseAttack();
    }

    public void Reload()
    {
        GetWeaponManager().BaseReload();
    }

    private WeaponManager GetWeaponManager()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            if (_weapons[i].gameObject.activeInHierarchy)
                return _weapons[i];
        }

        Debug.Log("Cannot get weapon");
        return null;
    }
}
