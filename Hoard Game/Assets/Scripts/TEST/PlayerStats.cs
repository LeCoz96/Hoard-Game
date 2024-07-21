using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _maxShield;

    private int _currentHealth;
    private int _currentShield;

    private PlayerUI _playerUI;

    void Start()
    {
        _playerUI = GetComponent<PlayerUI>();

        _currentHealth = _maxHealth;
        _playerUI.UpdateHealthValue(_currentHealth);

        _currentShield = _maxShield;
        _playerUI.UpdateShieldValue(_currentShield);
    }

    void Update()
    {

    }

    public void UpdateHealth(int value)
    {
        _currentHealth += value;
        _playerUI.UpdateHealthValue(value);
    }

    public bool CanHaveMoreHealth() { return _currentHealth < _maxHealth; }
    public bool CanHaveMoreShield() { return _currentShield < _maxShield; }

    public void UpdateShield(int value)
    {
        _currentShield += value;
        _playerUI.UpdateShieldValue(value);
    }
}
