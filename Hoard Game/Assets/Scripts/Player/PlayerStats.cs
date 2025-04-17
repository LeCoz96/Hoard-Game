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
        _playerUI.SetHealth(_currentHealth, _maxHealth);

        _currentShield = _maxShield;
        _playerUI.SetShield(_currentShield, _maxShield);
    }

    public bool HealthCheck() { return _currentHealth < _maxHealth; }

    public bool ShieldCheck() { return _currentShield < _maxShield; }

    public void TakeDamage(int value)
    {
        if(_currentShield > 0)
        {
            if((_currentShield - value) < 0)
            {
                _currentHealth -= (value - _currentShield);

                _currentShield = 0;

                _playerUI.SetShield(_currentShield, _maxShield);

                _playerUI.UpdateHealthOverlay(_currentHealth, _maxHealth);
            }
            else
            {
                _currentShield -= value;

                _playerUI.SetShield(_currentShield, _maxShield);

                _playerUI.UpdateShieldOverlay(_currentShield, _maxShield);
            }
        }
        else
        {
            if ((_currentHealth - value) < 0)
            {
                _currentHealth = 0;

                _playerUI.SetHealth(_currentHealth, _maxHealth);

                Debug.Log("PLAYER IS DEAD");
            }
            else
            {
                _currentHealth -= value;

                _playerUI.SetHealth(_currentHealth, _maxHealth);

                _playerUI.UpdateHealthOverlay(_currentHealth, _maxHealth);
            }
        }
    }

    public void IncreaseHealth(int value)
    {
        _currentHealth = GetCorrectValue(value, _currentHealth, _maxHealth);

        _playerUI.SetHealth(_currentHealth, _maxHealth);
    }
    public void IncreaseSheild(int value)
    {
        _currentShield = GetCorrectValue(value, _currentShield, _maxShield);

        _playerUI.SetShield(_currentShield, _maxShield);
    }

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
