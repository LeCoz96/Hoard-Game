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
    [SerializeField] private TextMeshProUGUI _weaponCurrentClip;
    [SerializeField] private TextMeshProUGUI _weaponRemainingAmmo;

    [Header("Stats - Health")]
    [SerializeField] private HealthManager _healthManager;

    [Header("Stats - Shield")]
    [SerializeField] private ShieldManager _shieldManager;

    [Header("Key")]
    [SerializeField] private GameObject _key1UI;
    [SerializeField] private GameObject _key2UI;
    [SerializeField] private GameObject _key3UI;

    [Header("Reload")]
    [SerializeField] private ReloadManager _reloadManager;

    public void UpdatePromptText(string promptMessage) { _promptText.text = promptMessage; }

    public void UpdateCurrentAmmo(int currentClip)
    {
        _weaponCurrentClip.text = currentClip.ToString();
    }

    public void UpdateCurrentWeaponAmmo(int currentClip, int _remainingAmmo)
    {
        _weaponCurrentClip.text = currentClip.ToString();
        _weaponRemainingAmmo.text = _remainingAmmo.ToString();
    }

    public void SetHealth(int value)
    {
        _healthManager.SetHealth(value);
    }

    public void SetShield(int value)
    {
        _shieldManager.SetShield(value);
    }

    public void UpdateHealthValue(int targetValue, int maxValue, bool isDamage)
    {
        _healthManager.TriggerHealth(targetValue, maxValue, isDamage);
    }

    public void UpdateShieldValue(int targetValue, int maxValue)
    {
        _shieldManager.TriggerShield(targetValue, maxValue);
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
        _reloadManager.TriggerReload(delay);
    }
}
