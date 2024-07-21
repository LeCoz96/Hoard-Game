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

    //void Update()
    //{

    //}

    public bool HealthCheck() { return _currentHealth < _maxHealth; }

    public bool ShieldCheck() { return _currentShield < _maxShield; }


    public void UpdateHealth(int value)
    {
        Debug.Log(value);
        bool isDamage = value < 0;
        Debug.Log(isDamage);

        _currentHealth += GetCorrectValue(value, _currentHealth, _maxHealth);

        _playerUI.UpdateHealthValue(_currentHealth, isDamage);
    }


    public void UpdateShield(int value)
    {
        Debug.Log("Update Shield");
    }

    private int GetCorrectValue(int givenValue, int targetValue, int maxValue)
    {
        int temp = 0;

        if ((targetValue + givenValue) >= maxValue)
            temp = maxValue;
        else
            temp += givenValue;

        return temp;
    }
}
