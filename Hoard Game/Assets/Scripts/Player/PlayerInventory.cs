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

    public void AddToInventory(Collectables.CollectableType type, int quantity)
    {
        switch (type)
        {
            case Collectables.CollectableType.PistolAmmo:
                _playerUI.UpdatePistolAmmo(_pistol.AddAmmo(quantity));
                break;

            case Collectables.CollectableType.SMGAmmo:
                _playerUI.UpdateSMGAmmo(_SMG.AddAmmo(quantity));
                break;

            case Collectables.CollectableType.RifleAmmo:
                _playerUI.UpdateRifleAmmo(_rifle.AddAmmo(quantity));
                break;

            case Collectables.CollectableType.HealthKit:
                _playerStats.UpdateHealth(quantity);
                //_playerUI.UpdateHealthValue(_healthKit.UpdateStat(quantity));
                break;

            case Collectables.CollectableType.ShieldKit:
                _playerStats.UpdateShield(quantity);
                //_playerUI.UpdateShieldValue(_shield.UpdateStat(quantity));
                break;
        }
    }

    public bool CanCollect(Collectables.CollectableType type)
    {
        switch (type)
        {
            case Collectables.CollectableType.PistolAmmo:
                return _pistol.CanAddMoreAmmo();

            case Collectables.CollectableType.SMGAmmo:
                return _SMG.CanAddMoreAmmo();

            case Collectables.CollectableType.RifleAmmo:
                return _rifle.CanAddMoreAmmo();

            case Collectables.CollectableType.HealthKit:
                return _playerStats.CanHaveMoreHealth();

            case Collectables.CollectableType.ShieldKit:
                return _playerStats.CanHaveMoreShield();

            default:
                return false;

        }
    }
}
