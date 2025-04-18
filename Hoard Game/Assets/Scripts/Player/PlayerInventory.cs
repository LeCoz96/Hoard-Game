using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private PlayerUI _playerUI;
    private PlayerStats _playerStats;
    private PlayerAttack _playerAttack;
    private PlayerMovement _playerMovement;

    [SerializeField] private SO_Weapon _pistol;
    [SerializeField] private SO_Weapon _SMG;
    [SerializeField] private SO_Weapon _rifle;
    [SerializeField] private SO_Weapon _shotgun;
    [SerializeField] private SO_Weapon _rgp;

    [SerializeField] private SO_Consumable _healthKit;
    [SerializeField] private SO_Consumable _shieldKit;

    [SerializeField] private SO_Key _key1;
    [SerializeField] private SO_Key _key2;
    [SerializeField] private SO_Key _key3;

    private void OnEnable()
    {
        _playerStats = GetComponent<PlayerStats>();
        _playerUI = GetComponent<PlayerUI>();
        _playerAttack = GetComponent<PlayerAttack>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    public void AddToInventory(Collectable.CollectableType type, int quantity)
    {
        switch (type)
        {
            case Collectable.CollectableType.PistolAmmo:
                _pistol.AddAmmo(quantity);
                _playerUI.UpdateCurrentWeaponAmmo(_pistol.GetCurrentAmmo(), _pistol.GetRemainingAmmo());
                break;

            case Collectable.CollectableType.SMGAmmo:
                _SMG.AddAmmo(quantity);
                _playerUI.UpdateCurrentWeaponAmmo(_SMG.GetCurrentAmmo(), _SMG.GetRemainingAmmo());
                break;

            case Collectable.CollectableType.RifleAmmo:
                _rifle.AddAmmo(quantity);
                _playerUI.UpdateCurrentWeaponAmmo(_rifle.GetCurrentAmmo(), _rifle.GetRemainingAmmo());
                break;

            case Collectable.CollectableType.HealthKit:
                _playerStats.IncreaseHealth(quantity);
                break;

            case Collectable.CollectableType.ShieldKit:
                _playerStats.IncreaseSheild(quantity);
                break;

            case Collectable.CollectableType.Damage:
                //_playerStats.IncreaseSheild(quantity);
                break;
            
            case Collectable.CollectableType.Speed:
                _playerMovement.SetSpeedBuff(quantity);
                break;
            
            case Collectable.CollectableType.Ammo:
                _playerAttack.SetAmmoBuff(quantity);
                break;

            case Collectable.CollectableType.Key1:
                _key1.CollectKey();
                _playerUI.UpdateKeys(1);
                break;

            case Collectable.CollectableType.Key2:
                _key2.CollectKey();
                _playerUI.UpdateKeys(2);
                break;

            case Collectable.CollectableType.Key3:
                _key3.CollectKey();
                _playerUI.UpdateKeys(3);
                break;

            default:
                break;
        }
    }

    public bool CanCollect(Collectable.CollectableType type)
    {
        switch (type)
        {
            case Collectable.CollectableType.PistolAmmo:
                return _pistol.CanCollect();

            case Collectable.CollectableType.SMGAmmo:
                return _SMG.CanCollect();

            case Collectable.CollectableType.RifleAmmo:
                return _rifle.CanCollect();

            case Collectable.CollectableType.HealthKit:
                return _playerStats.HealthCheck();

            case Collectable.CollectableType.ShieldKit:
                return _playerStats.ShieldCheck();

            case Collectable.CollectableType.Damage:
                return true;

            case Collectable.CollectableType.Speed:
                return true;

            case Collectable.CollectableType.Ammo:
                return true;

            case Collectable.CollectableType.Key1:
                return _key1.CanCollect();

            case Collectable.CollectableType.Key2:
                return _key2.CanCollect();

            case Collectable.CollectableType.Key3:
                return _key3.CanCollect();

            default:
                return false;

        }
    }
}
