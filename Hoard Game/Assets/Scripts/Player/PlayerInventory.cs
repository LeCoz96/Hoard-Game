using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private PlayerUI _playerUI;
    private PlayerStats _playerStats;

    [SerializeField] private SO_Weapon _pistol;
    [SerializeField] private SO_Weapon _SMG;
    [SerializeField] private SO_Weapon _rifle;

    [SerializeField] private SO_Consumable _healthKit;
    [SerializeField] private SO_Consumable _shieldKit;

    void Start()
    {
        _playerUI = GetComponent<PlayerUI>();
        _playerStats = GetComponent<PlayerStats>();
    }

    public void AddToInventory(Collectable.CollectableType type, int quantity)
    {
        switch (type)
        {
            case Collectable.CollectableType.PistolAmmo:
                _playerUI.UpdatePistolAmmo(_pistol.AddAmmo(quantity));
                break;

            case Collectable.CollectableType.SMGAmmo:
                _playerUI.UpdateSMGAmmo(_SMG.AddAmmo(quantity));
                break;

            case Collectable.CollectableType.RifleAmmo:
                _playerUI.UpdateRifleAmmo(_rifle.AddAmmo(quantity));
                break;

            case Collectable.CollectableType.HealthKit:
                _playerStats.UpdateHealth(quantity);
                //_playerUI.UpdateHealthValue(_healthKit.UpdateStat(quantity));
                break;

            case Collectable.CollectableType.ShieldKit:
                _playerStats.UpdateShield(quantity);
                //_playerUI.UpdateShieldValue(_shield.UpdateStat(quantity));
                break;
        }
    }

    public bool CanCollect(Collectable.CollectableType type)
    {
        switch (type)
        {
            case Collectable.CollectableType.PistolAmmo:
                return _pistol.CanAddMoreAmmo();

            case Collectable.CollectableType.SMGAmmo:
                return _SMG.CanAddMoreAmmo();

            case Collectable.CollectableType.RifleAmmo:
                return _rifle.CanAddMoreAmmo();

            case Collectable.CollectableType.HealthKit:
                return _playerStats.HealthCheck();

            case Collectable.CollectableType.ShieldKit:
                return _playerStats.ShieldCheck();

            default:
                return false;

        }
    }
}
