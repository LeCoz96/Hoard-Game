using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private PlayerUI _playerUI;

    [SerializeField] private SO_Weapon _pistol;
    [SerializeField] private SO_Weapon _SMG;
    [SerializeField] private SO_Weapon _rifle;

    [SerializeField] private SO_PlayerStats _healthKit;
    [SerializeField] private SO_PlayerStats _shield;

    void Start()
    {
        _playerUI = GetComponent<PlayerUI>();
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
                _playerUI.UpdateHealthValue(_healthKit.UpdateStat(quantity));
                break;

            case Collectables.CollectableType.Shield:
                _playerUI.UpdateShieldValue(_shield.UpdateStat(quantity));
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
                return _healthKit.CanConsume();

            case Collectables.CollectableType.Shield:
                return _shield.CanConsume();

            default:
                return false;

        }
    }
}
