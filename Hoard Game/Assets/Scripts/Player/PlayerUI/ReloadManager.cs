using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadManager : MonoBehaviour
{
    private float _current;
    private float _timer;

    [SerializeField] private GameObject _reloadBar;
    [SerializeField] private Image _reloadForground;

    void Update()
    {
        if (_current >= 0.0f)
        {
            SO_PlayerSystems.ToggleReloading();
            _reloadBar.SetActive(true);

            _current -= Time.deltaTime;
            _reloadForground.fillAmount = _current / _timer;
        }
        else
        {

            _reloadBar.SetActive(false);
            _reloadForground.fillAmount = 1;

            SO_PlayerSystems.ToggleReloading();
        }
    }

    public void TriggerReload(float time)
    {
        _timer = time;
        _current = time;
    }
}
