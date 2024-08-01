using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : WeaponManager
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _bulletSpawn;

    protected override void Attack()
    {
        Instantiate(_bullet, _bulletSpawn.transform.position, transform.rotation);
    }

    protected override void Reload()
    {
        base.Reload();
    }
}
