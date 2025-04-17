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
        _playerUI.SetHealth(_currentHealth);

        _currentShield = _maxShield;
        _playerUI.SetShield(_currentShield);
    }

    public bool HealthCheck() { return _currentHealth < _maxHealth; }

    public bool ShieldCheck() { return _currentShield < _maxShield; }

    public void TakeDamage(int value)
    {
        _currentHealth = GetCorrectValue(value, _currentHealth, _maxHealth);

        // DAMAGE SHEILD OR HEALTH?

        _playerUI.UpdateHealthValue(_currentHealth, _maxHealth, true);
    }

    public void IncreaseHealth(int value)
    {
        _currentHealth = GetCorrectValue(value, _currentHealth, _maxHealth);
    }
    public void IncreaseSheild(int value)
    {
        _currentShield = GetCorrectValue(value, _currentShield, _maxShield);
    }

    //public void UpdateHealth(int value)
    //{
    //    bool isDamage = value < 0;

    //    _currentHealth = GetCorrectValue(value, _currentHealth, _maxHealth);

    //    _playerUI.UpdateHealthValue(_currentHealth, _maxHealth, isDamage);
    //}

    //public void UpdateShield(int value)
    //{
    //    _currentShield = GetCorrectValue(value, _currentShield, _maxShield);

    //    if (_currentShield <= 0)
    //    {
    //        int temp = 0 + _currentShield;
    //        _currentShield = 0;
    //        _playerUI.UpdateShieldValue(_currentShield, _maxShield);
    //        UpdateHealth(temp);
    //    }

    //    _playerUI.UpdateShieldValue(_currentShield, _maxShield);
    //}

    private int GetCorrectValue(int givenValue, int targetValue, int maxValue)
    {
        if ((targetValue + givenValue) >= maxValue)
        {
            return maxValue;
        }
        else if((targetValue + givenValue) <= 0)
        {
            return 0;
        }
        else
        {
            return targetValue += givenValue;
        }
    }
}
