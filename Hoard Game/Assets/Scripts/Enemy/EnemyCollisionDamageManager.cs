using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionDamageManager : MonoBehaviour
{
    [Header("Enemy Health")]
    [SerializeField] EnemyHealthManager _enemyHealth;

    [Header("Damage Options")]
    [SerializeField] float _damageScalar;

    public void TakeDamage(float damage)
    {
        float damageTaken = damage * _damageScalar;

        _enemyHealth.TakeDamage(damageTaken);
    }
}
