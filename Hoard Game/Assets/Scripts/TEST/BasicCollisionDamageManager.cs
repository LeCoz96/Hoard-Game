using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCollisionDamageManager : MonoBehaviour
{
    [Header("Enemy Health")]
    [SerializeField] ObjectHealthManager _objectHealth;

    [Header("Damage Options")]
    [SerializeField] float _damageScalar;

    public void TakeDamage(float damage)
    {
        float damageTaken = damage * _damageScalar;

        _objectHealth.TakeDamage(damageTaken);
    }
}
