using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShieldManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _shieldValue;
    [SerializeField] private Image _shieldBar;
    [SerializeField] private SO_Consumable _shield;

    public void SetShield(int value)
    {
        _shieldValue.text = value.ToString();
    }

    public void TriggerShield(int targetValue, int maxValue)
    {
        _shieldValue.text = targetValue.ToString();

        _shieldBar.fillAmount = (float)targetValue / (float)maxValue;
    }
}
