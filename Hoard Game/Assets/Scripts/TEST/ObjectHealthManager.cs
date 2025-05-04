using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealthManager : MonoBehaviour
{
    [SerializeField] private float _health;

    public void TakeDamage(float damage)
    {
        Debug.Log("Damage taken: " + damage);
        _health -= damage;
    }
}
