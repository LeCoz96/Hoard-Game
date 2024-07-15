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
                _playerUI.UpdateHealthValue(_playerStats.UpdateHealth(quantity));
                break;
            case Collectables.CollectableType.Shield:
                _playerUI.UpdateShieldValue(_playerStats.UpdateShield(quantity));
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
                return _playerStats.CanConsumeHealth();

            case Collectables.CollectableType.Shield:
                return _playerStats.CanConsumeShield();

            default:
                return false;

        }
    }
}
