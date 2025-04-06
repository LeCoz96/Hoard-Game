using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private TextMeshProUGUI _healthValue;
    [SerializeField] private Image _healthBar;
    [SerializeField] private SO_Consumable _health;

    [Header("Damage")]
    [SerializeField] private Image _damageOverlay;
    [SerializeField] private float _fadeTime;
    private float _fadePerSecond;
    private float _alphaValue;
    private float _localFadeTime;

    private bool _damageOverlayIsComplete = true;
    private bool _damageTaken;

    void Start()
    {
        _fadePerSecond = 1 / _fadeTime;
    }

    void Update()
    {
        if (_damageTaken == true)
        {
            _damageOverlayIsComplete = false;

            if (_localFadeTime > 0)
            {
                Debug.Log("Reducing");
                _alphaValue -= _fadePerSecond * Time.deltaTime;
                _damageOverlay.color = new Color(_damageOverlay.color.r, _damageOverlay.color.g, _damageOverlay.color.b, _alphaValue);
                _localFadeTime -= Time.deltaTime;
            }
            else
            {
                _damageOverlayIsComplete = true;
            }
        }
    }

    public void SetHealth(int value)
    {
        _healthValue.text = value.ToString();
    }

    public void TriggerHealth(int targetValue, int maxValue, bool isDamage)
    {
        _healthValue.text = targetValue.ToString();

        _healthBar.fillAmount = (float)targetValue / (float)maxValue;

        if (isDamage == true)
        {
            if (_damageOverlayIsComplete == true)
            {
                _damageOverlay.color = new Color(_damageOverlay.color.r, _damageOverlay.color.g, _damageOverlay.color.b, 1);
                _alphaValue = _damageOverlay.color.a;

                if (_healthBar.fillAmount > 0.25)
                {
                    _localFadeTime = _fadeTime;
                    _damageTaken = true;
                }
            }
        }
        else
        {
            _damageTaken = false;

            if (_healthBar.fillAmount > 0.25)
            {
                _damageOverlay.color = new Color(_damageOverlay.color.r, _damageOverlay.color.g, _damageOverlay.color.b, 0);
            }
        }
    }
}
