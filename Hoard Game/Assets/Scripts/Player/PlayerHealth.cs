using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    private float _health;
    [SerializeField] private float _maxHealth;

    [SerializeField] private float _lerpSpeed;
    private float _lerpTimer;

    [SerializeField] private Image _foregroundHealth;
    [SerializeField] private Image _backgroundHealth;

    [SerializeField] private TextMeshProUGUI _healthValue;

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
        Debug.Log(_health);

        float FillFront = _foregroundHealth.fillAmount;
        float FillBack = _backgroundHealth.fillAmount;
        float HealthFraction = _health / _maxHealth;

        if(FillBack > HealthFraction)
        {
            _foregroundHealth.fillAmount = HealthFraction;
            _backgroundHealth.color = Color.red;
            _lerpTimer += Time.deltaTime;
            float PercentComplete = _lerpTimer / _lerpSpeed;
            _backgroundHealth.fillAmount = Mathf.Lerp(FillBack, HealthFraction, PercentComplete);
        }

        UpdateHealthAmount();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _lerpTimer = 0.0f;
    }

    public void RestoreHealth(float heal)
    {
        _health += heal;
        _lerpTimer = 0.0f;
    }

    private void UpdateHealthAmount()
    {
        _healthValue.text = _health.ToString();
    }
}
