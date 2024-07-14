using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Info")]
    [SerializeField] private float _maxHealth;
    [SerializeField] private Material _takeDamageMaterial;
    [SerializeField] private Material _healMaterial;
    [SerializeField] private float _lerpSpeed;
    [SerializeField] private Image _foregroundHealth;
    [SerializeField] private Image _backgroundHealth;
    [SerializeField] private TextMeshProUGUI _healthValue;
    private float _health;
    private float _lerpTimer;

    [Header("Damage Info")]
    [SerializeField] private Image _damageOverlay;
    [SerializeField] private float _fadeDelay;
    [SerializeField] private float _fadeSpeed;
    [SerializeField] private float _healthMinValue;
    private bool _damageOverlayIsComplete = true;

    void Start()
    {
        _health = _maxHealth;
        _healthValue.text = _health.ToString();
    }

    void Update()
    {
        _health = Mathf.Clamp(_health, 0, _maxHealth);

        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {
        float FillFront = _foregroundHealth.fillAmount;
        float FillBack = _backgroundHealth.fillAmount;
        float HealthFraction = _health / _maxHealth;

        if (FillBack > HealthFraction)
            UpdateHealthBar(_foregroundHealth, _backgroundHealth, HealthFraction, _takeDamageMaterial, FillBack, HealthFraction);
        if (FillFront < HealthFraction)
            UpdateHealthBar(_backgroundHealth, _foregroundHealth, HealthFraction, _healMaterial, FillFront, _backgroundHealth.fillAmount);

        UpdateHealthAmount();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _lerpTimer = 0.0f;

        if (_health > _healthMinValue)
        {
            if (_damageOverlayIsComplete)
                StartCoroutine(DamageOverlayDelay());
        }
        else
            _damageOverlay.color = new Color(_damageOverlay.color.r, _damageOverlay.color.g, _damageOverlay.color.b, 1);
    }

    public void RestoreHealth(float heal)
    {
        _health += heal;
        _lerpTimer = 0.0f;

        if (_health > _healthMinValue)
            _damageOverlay.color = new Color(_damageOverlay.color.r, _damageOverlay.color.g, _damageOverlay.color.b, 0);
    }

    private void UpdateHealthAmount()
    {
        _healthValue.text = _health.ToString();
    }

    private void UpdateHealthBar(Image TargetBar, Image LerpBar, float Fraction, Material TargetMaterial, float FillBar, float FillValue)
    {
        TargetBar.fillAmount = Fraction;
        _backgroundHealth.material = TargetMaterial;
        _lerpTimer += Time.deltaTime;
        float PercentComplete = _lerpTimer / _lerpSpeed;
        PercentComplete = PercentComplete * PercentComplete;
        LerpBar.fillAmount = Mathf.Lerp(FillBar, FillValue, PercentComplete);
    }

    private IEnumerator DamageOverlayDelay()
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