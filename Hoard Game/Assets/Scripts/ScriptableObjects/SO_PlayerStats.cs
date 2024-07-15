using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "ScriptableObjects/Consumable")]
public class SO_PlayerStats : ScriptableObject
{
    [SerializeField] private int _maxValue;
    [SerializeField] private int _minValue;

    private int _currentValue;

    public bool CanConsume() { return _currentValue < _maxValue; }
    public int GetConsumableMinimum() { return _minValue; }

    public int UpdateStat(int value)
    {
        _currentValue = Mathf.Clamp(_currentValue, 0, _maxValue);

        if ((_currentValue + value) >= _maxValue)
            return _currentValue = _maxValue;
        else
        {
            _currentValue += _maxValue;
            return _currentValue;
        }
    }
}
