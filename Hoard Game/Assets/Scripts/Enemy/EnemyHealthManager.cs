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
        if (_health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
