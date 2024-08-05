using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _explosiveLife = 3.0f;

    private Rigidbody _rigidBody;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (_explosiveLife > 0)
            _explosiveLife -= Time.deltaTime;
        else
            Destroy(gameObject);

    }

    void FixedUpdate()
    {
        _rigidBody.AddForce(transform.forward * _speed);
    }
}
