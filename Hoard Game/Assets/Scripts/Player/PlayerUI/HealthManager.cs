using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthManager : MonoBehaviour
{
    [Header("Heath")]
    [SerializeField] private TextMeshProUGUI _healthValue;
    [SerializeField] private Image _healthBar;
    [SerializeField] private SO_Consumable _health;

    [Header("Damage")]
    [SerializeField] private Image _damageOverlay;
    [SerializeField] private float _fadeDelay;
    [SerializeField] private float _fadeSpeed;
    private bool _damageOverlayIsComplete = true;

    public void SetHealth(int value)
    {
        _healthValue.text = value.ToString();
    }

    public void TriggerHealth(int targetValue, int maxValue, bool isDamage)
    {
        _healthValue.text = targetValue.ToString();

        _healthBar.fillAmount = (float)targetValue / (float)maxValue;

        if (isDamage)
        {
            if (_damageOverlayIsComplete)
            {
                if (_healthBar.fillAmount < 0.25)
                    _damageOverlay.color = new Color(_damageOverlay.color.r, _damageOverlay.color.g, _damageOverlay.color.b, 1);
                else
                    StartCoroutine(DamageOverlay());
            }
        }
        else
        {
            if (_healthBar.fillAmount > 0.25)
                _damageOverlay.color = new Color(_damageOverlay.color.r, _damageOverlay.color.g, _damageOverlay.color.b, 0);
        }
    }

    private IEnumerator DamageOverlay()
    {
        _damageOverlayIsComplete = false;

        _damageOverlay.color = new Color(_damageOverlay.color.r, _damageOverlay.color.g, _damageOverlay.color.b, 1);

        yield return new WaitForSeconds(_fadeDelay);

        for (float i = 1f; i >= 0; i -= 0.1f)
        {
            _damageOverlay.color = new Color(_damageOverlay.color.r, _damageOverlay.color.g, _damageOverlay.color.b, i);
            yield return new WaitForSeconds(_fadeSpeed);
        }

        _damageOverlay.color = new Color(_damageOverlay.color.r, _damageOverlay.color.g, _damageOverlay.color.b, 0);

        _damageOverlayIsComplete = true;
    }
}
