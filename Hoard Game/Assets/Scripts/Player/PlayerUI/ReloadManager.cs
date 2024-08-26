using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadManager : MonoBehaviour
{
    [SerializeField] private GameObject _reloadBar;
    [SerializeField] private Image _reloadForground;

    private float _current;
    private float _timer;
    private bool _isReloading;

    void Update()
    {
        if (_isReloading)
        {
            if (_current >= 0.0f)
            {
                _reloadBar.SetActive(true);

                _current -= Time.deltaTime;
                _reloadForground.fillAmount = _current / _timer;
            }
            else
            {
                _reloadBar.SetActive(false);
                _reloadForground.fillAmount = 1;

                SO_PlayerSystems.ToggleReloading();

                _isReloading = false;
            }
        }
    }

    public void TriggerReload(float time)
    {
        _timer = time;
        _current = time;
        _isReloading = true;
        SO_PlayerSystems.ToggleReloading();
    }
}
