using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OverlaysManager : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private TextMeshProUGUI _healthValue;
    [SerializeField] private Image _healthBar;
    [SerializeField] private SO_Consumable _health;

    [Header("Damage")]
    [SerializeField] private Image _healthDamageOverlay;
    [SerializeField] private float _healthFadeTime;
    private float _healthFadePerSecond;
    private float _healthAlphaValue;
    private float _healthLocalFadeTime;
    private bool _healthOverlayIsComplete = true;
    private bool _healthDamageTaken;

    void Start()
    {
        _healthFadePerSecond = 1 / _healthFadeTime;
    }

    void Update()
    {
        if (_healthDamageTaken == true)
        {
            _healthOverlayIsComplete = false;

            if (_healthLocalFadeTime > 0)
            {
                Debug.Log("Reducing");
                _healthAlphaValue -= _healthFadePerSecond * Time.deltaTime;
                _healthDamageOverlay.color = new Color(_healthDamageOverlay.color.r, _healthDamageOverlay.color.g, _healthDamageOverlay.color.b, _healthAlphaValue);
                _healthLocalFadeTime -= Time.deltaTime;
            }
            else
            {
                _healthOverlayIsComplete = true;
            }
        }
    }

    public void TriggerHealth(int targetValue, int maxValue, bool isDamage)
    {
        _healthValue.text = targetValue.ToString();

        _healthBar.fillAmount = (float)targetValue / (float)maxValue;

        if (isDamage == true)
        {
            if (_healthOverlayIsComplete == true)
            {
                _healthDamageOverlay.color = new Color(_healthDamageOverlay.color.r, _healthDamageOverlay.color.g, _healthDamageOverlay.color.b, 1);
                _healthAlphaValue = _healthDamageOverlay.color.a;

                if (_healthBar.fillAmount > 0.25)
                {
                    _healthLocalFadeTime = _healthFadeTime;
                    _healthDamageTaken = true;
                }
            }
        }
        else
        {
            _healthDamageTaken = false;

            if (_healthBar.fillAmount > 0.25)
            {
                _healthDamageOverlay.color = new Color(_healthDamageOverlay.color.r, _healthDamageOverlay.color.g, _healthDamageOverlay.color.b, 0);
            }
        }
    }
}
