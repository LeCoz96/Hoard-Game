using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private PlayerUI _playerUI;
    [SerializeField] private SO_Weapon _pistol;

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
                break;
            case Collectables.CollectableType.RifleAmmo:
                break;
            case Collectables.CollectableType.HealthKit:
                break;
            case Collectables.CollectableType.Shield:
                break;
        }

    }
}
