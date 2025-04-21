using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private SO_Weapon _weapon;
    [SerializeField] private float _bulletLife;

    private float _speed = 1000.0f;

    private Rigidbody _rigidBody;

    public float GetBulletDamage() { return _weapon.GetDamage(); }

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_bulletLife > 0)
        {
            _bulletLife -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        _rigidBody.AddForce(transform.forward * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIT " + other.name);
        Destroy(gameObject);
    }
}
