using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private PlayerUI _playerUI;

    void Start()
    {
        _playerUI = GetComponent<PlayerUI>();
    }

    public void AddToInventory(SO_Collectable.CollectableType type, int quantity)
    {
        switch (type)
        {
            case SO_Collectable.CollectableType.PistolAmmo:
                _playerUI.UpdatePistolAmmo(quantity);
                break;
            case SO_Collectable.CollectableType.SMGAmmo:
                break;
            case SO_Collectable.CollectableType.RifleAmmo:
                break;
            case SO_Collectable.CollectableType.Health:
                break;
            case SO_Collectable.CollectableType.Sheild:
                break;
        }

    }
}
