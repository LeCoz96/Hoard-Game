using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private InputManager _inputManager;

    void Start()
    {
        _inputManager = GetComponent<InputManager>();
    }

    public void Shoot()
    {
        Debug.Log("Shoot");
    }
}
