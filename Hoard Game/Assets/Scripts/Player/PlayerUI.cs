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
    private TMP_InputField _inputField;
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

    public void UpdatePromptText(string promptMessage) { _promptText.text = promptMessage; }

    public void UpdatePistolAmmo(int value) { _pistolAmmo.text = value.ToString(); }
    public void UpdateSMGAmmo(int value) { _SMGAmmo.text = value.ToString(); }
    public void UpdateRifleAmmo(int value) { _rifleAmmo.text = value.ToString(); }

    public void SetHealth(int value) { _healthValue.text = value.ToString(); }
    public void SetShield(int value) { _shieldValue.text = value.ToString(); }

    public void UpdateHealthValue(int value, bool isDamage)
    {
        _healthValue.text = value.ToString();

        if (_healthBar.fillAmount < 0.2)
            _damageOverlay.color = new Color(_damageOverlay.color.r, _damageOverlay.color.g, _damageOverlay.color.b, 1);

        if (isDamage)
            StartCoroutine(DamagerOverlay());
        else
            Debug.Log("Healed"); // give update health overlay...maybe animations?
    }

    public void UpdateShieldValue(int value)
    {
        _shieldValue.text = value.ToString();

        if (_shieldBar.fillAmount < 0.20)
            StartCoroutine(SheildOverlay());
    }

    private IEnumerator DamagerOverlay()
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

    private IEnumerator SheildOverlay()
    {
        yield return new WaitForSeconds(1.0f);
    }
}
