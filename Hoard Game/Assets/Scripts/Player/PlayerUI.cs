using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [Header("Interaction")]
    [SerializeField] private TextMeshProUGUI _promptText;

    [Header("Weapons")]
    [SerializeField] private TextMeshProUGUI _pistolAmmo;
    [SerializeField] private TextMeshProUGUI _SMGAmmo;
    [SerializeField] private TextMeshProUGUI _rifleAmmo;

    [Header("Stats - Health")]
    [SerializeField] private TextMeshProUGUI _healthValue;
    [SerializeField] private Image _healthBar;
    [SerializeField] private SO_Consumable _health;

    [Header("Stats - Shield")]
    [SerializeField] private TextMeshProUGUI _shieldValue;
    [SerializeField] private Image _shieldBar;
    [SerializeField] private SO_Consumable _shield;

    [Header("Damage")]
    [SerializeField] private Image _damageOverlay;
    [SerializeField] private float _fadeDelay;
    [SerializeField] private float _fadeSpeed;
    private bool _damageOverlayIsComplete = true;

    [Header("Key")]
    [SerializeField] private GameObject _key1UI;
    [SerializeField] private GameObject _key2UI;
    [SerializeField] private GameObject _key3UI;

    [Header("Reload")]
    [SerializeField] private Image _reloadBar;

    public void UpdatePromptText(string promptMessage) { _promptText.text = promptMessage; }

    public void UpdatePistolAmmo(int value) { _pistolAmmo.text = value.ToString(); }
    public void UpdateSMGAmmo(int value) { _SMGAmmo.text = value.ToString(); }
    public void UpdateRifleAmmo(int value) { _rifleAmmo.text = value.ToString(); }

    public void SetHealth(int value) { _healthValue.text = value.ToString(); }
    public void SetShield(int value) { _shieldValue.text = value.ToString(); }

    public void UpdateHealthValue(int targetValue, int maxValue, bool isDamage)
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

    public void UpdateShieldValue(int targetValue, int maxValue)
    {
        _shieldValue.text = targetValue.ToString();

        _shieldBar.fillAmount = (float)targetValue / (float)maxValue;
    }

    public void UpdateKeys(int keyIndex)
    {
        switch (keyIndex)
        {
            case 1:
                _key1UI.SetActive(true);
                break;

            case 2:
                _key2UI.SetActive(true);
                break;

            case 3:
                _key3UI.SetActive(true);
                break;

            default:
                break;
        }
    }

    public void UpdateReloadBar(float delay)
    {

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

    private IEnumerator ReloadBarFill(float value)
    {
        yield return new WaitForSeconds(value);

        for (float i = 1f; i >= 0; i -= 0.1f)
        {
            _damageOverlay.color = new Color(_damageOverlay.color.r, _damageOverlay.color.g, _damageOverlay.color.b, i);
            yield return new WaitForSeconds(_fadeSpeed);
        }
    }
}
