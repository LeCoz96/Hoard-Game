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
    [SerializeField] private Image _healthDamageOverlay;
    [SerializeField] private float _healthFadeTime;
    private float _healthFadePerSecond;
    private float _healthAlphaValue;
    private float _healthLocalFadeTime;
    private bool _startHealthOverlayFade;

    [Header("Sheild")]
    [SerializeField] private TextMeshProUGUI _sheildValue;
    [SerializeField] private Image _sheildBar;
    [SerializeField] private SO_Consumable _sheild;
    [SerializeField] private Image _sheildDamageOverlay;
    [SerializeField] private float _sheildFadeTime;
    private float _sheildFadePerSecond;
    private float _sheildAlphaValue;
    private float _sheildLocalFadeTime;
    private bool _startShieldOverlayFade;

    void Start()
    {
        _healthFadePerSecond = 1 / _healthFadeTime;
        _sheildFadePerSecond = 1 / _sheildFadeTime;
    }

    void Update()
    {
        if (_startHealthOverlayFade == true)
        {
            if (_healthLocalFadeTime > 0)
            {
                Debug.Log("Reducing Health");
                _healthAlphaValue -= _healthFadePerSecond * Time.deltaTime;
                _healthDamageOverlay.color = new Color(_healthDamageOverlay.color.r, _healthDamageOverlay.color.g, _healthDamageOverlay.color.b, _healthAlphaValue);
                _healthLocalFadeTime -= Time.deltaTime;
            }
            else
            {
                _startHealthOverlayFade = false;
            }
        }

        if (_startShieldOverlayFade == true)
        {
            if (_sheildLocalFadeTime > 0)
            {
                Debug.Log("Reducing Sheild");
                _sheildAlphaValue -= _sheildFadePerSecond * Time.deltaTime;
                _sheildDamageOverlay.color = new Color(_sheildDamageOverlay.color.r, _sheildDamageOverlay.color.g, _sheildDamageOverlay.color.b, _sheildAlphaValue);
                _sheildLocalFadeTime -= Time.deltaTime;
            }
            else
            {
                _startShieldOverlayFade = false;
            }
        }
    }

    public void SetHealth(int targetValue, int maxValue)
    {
        _healthValue.text = targetValue.ToString();

        _healthBar.fillAmount = (float)targetValue / (float)maxValue;

        if (_healthBar.fillAmount > 0.25)
        {
            _healthLocalFadeTime = _healthFadeTime;
            _startHealthOverlayFade = true;
        }
    }

    public void SetShield(int targetValue, int maxValue)
    {
        _sheildValue.text = targetValue.ToString();

        _sheildBar.fillAmount = (float)targetValue / (float)maxValue;
    }

    public void TriggerHealthOverlay(int targetValue, int maxValue)
    {
        SetHealth(targetValue, maxValue);

        _healthDamageOverlay.color = new Color(_healthDamageOverlay.color.r, _healthDamageOverlay.color.g, _healthDamageOverlay.color.b, 1);
        _healthAlphaValue = _healthDamageOverlay.color.a;

        if (_healthBar.fillAmount > 0.25)
        {
            _healthLocalFadeTime = _healthFadeTime;
            _startHealthOverlayFade = true;
        }
    }

    public void TriggerSheildOverlay(int targetValue, int maxValue)
    {
        SetShield(targetValue, maxValue);

        if (_sheildBar.fillAmount <= 0)
        {
            _sheildDamageOverlay.color = new Color(_sheildDamageOverlay.color.r, _sheildDamageOverlay.color.g, _sheildDamageOverlay.color.b, 0);
        }
        else
        {
            _sheildDamageOverlay.color = new Color(_sheildDamageOverlay.color.r, _sheildDamageOverlay.color.g, _sheildDamageOverlay.color.b, 1);
            _sheildAlphaValue = _sheildDamageOverlay.color.a;
            _sheildLocalFadeTime = _sheildFadeTime;
            _startShieldOverlayFade = true;
        }
    }
}
