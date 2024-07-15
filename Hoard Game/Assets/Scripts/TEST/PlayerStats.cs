using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _maxShield;

    private int _currentHealth;
    private int _currentShield;

    void Start()
    {
        _currentHealth = _maxHealth;
        _currentShield = _maxShield;
    }

    void Update()
    {
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        _currentShield = Mathf.Clamp(_currentShield, 0, _maxShield);
    }

    public int UpdateHealth(int value)
    {
        if ((_currentHealth + value) >= _maxHealth)
            return _currentHealth = _maxHealth;
        else
        {
            _currentHealth += value;
            return _currentHealth;
        }
    }

    public int UpdateShield(int value) 
    {
        if ((_currentShield + value) >= _maxShield)
            return _currentShield = _maxShield;
        else
        {
            _currentShield += value;
            return _currentShield;
        }
    }

    public bool CanConsumeHealth() { return _currentHealth < _maxHealth; }
    public bool CanConsumeShield() { return _currentShield < _maxShield; }
}
