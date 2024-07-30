using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private InputManager _inputManager;

    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _bulletSpawn;

    void Start()
    {
        _inputManager = GetComponent<InputManager>();
    }

    public void Shoot()
    {
        Debug.Log("Shoot");
    }
}
