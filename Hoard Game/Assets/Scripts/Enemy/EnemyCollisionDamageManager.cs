using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionDamageManager : MonoBehaviour
{
    [Header("Enemy Health")]
    [SerializeField] EnemyHealthManager _enemyHealth;

    [Header("Damage Options")]
    [SerializeField] float _damageScalar;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            float damageTaken = (other.gameObject.GetComponent<Bullet>().GetBulletDamage() * _damageScalar);
            Debug.Log("DAMAGE TAKEN: " + damageTaken);
            _enemyHealth.TakeDamage(damageTaken);
        }
    }
}
