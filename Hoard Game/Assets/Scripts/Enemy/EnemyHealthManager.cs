using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    [SerializeField] private float _health;

    public void TakeDamage(float damage)
    {
        _health -= damage;
        HealthCheck();
    }

    private void HealthCheck()
    {
        Debug.Log("Enemy Health: " + _health);
        if (_health <= 0)
        {
            Debug.Log("Enemy is dead");
            gameObject.SetActive(false);
        }
    }
}
