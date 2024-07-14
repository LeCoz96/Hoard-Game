using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Collectables;

public class PlayerInventory : MonoBehaviour
{
    private PlayerUI _playerUI;
    [SerializeField] private SO_Weapon _pistol;
    [SerializeField] private SO_Weapon _SMG;
    [SerializeField] private SO_Weapon _rifle;

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
                _playerUI.UpdatePistolAmmo(_SMG.AddAmmo(quantity));
                break;
            case Collectables.CollectableType.RifleAmmo:
                _playerUI.UpdatePistolAmmo(_rifle.AddAmmo(quantity));
                break;
            case Collectables.CollectableType.HealthKit:
                break;
            case Collectables.CollectableType.Shield:
                break;
        }
    }

    public bool CanBeCollected(Collectables.CollectableType type, int quantity)
    {
        switch (type)
        {
            case CollectableType.PistolAmmo:
                return CollectCheck((_pistol.GetCurrentClipSize() + quantity), _pistol.GetMaxClipSize());

            case CollectableType.SMGAmmo:
                return CollectCheck((_SMG.GetCurrentClipSize() + quantity), _SMG.GetMaxClipSize());

            case CollectableType.RifleAmmo:
                return CollectCheck((_rifle.GetCurrentClipSize() + quantity), _rifle.GetMaxClipSize());

            default:
                return false;

            //case CollectableType.HealthKit:
            //    return true;
            //case CollectableType.Shield:
            //    return true;
        }
    }

    public void SetToMaxCapacity(Collectables.CollectableType type)
    {
        switch (type)
        {
            case CollectableType.PistolAmmo:
                _pistol.SetCurrentClipSize(_pistol.GetMaxClipSize());
                break;
            case CollectableType.SMGAmmo:
                _SMG.SetCurrentClipSize(_pistol.GetMaxClipSize());
                break;

            case CollectableType.RifleAmmo:
                _pistol.SetCurrentClipSize(_pistol.GetMaxClipSize());

                break;
            //case CollectableType.HealthKit:
            //    break;
            //case CollectableType.Shield:
            //    break;
            default:
                break;
        }
    }

    private ScriptableObject GetCollectableType(CollectableType type)
    {
        switch(type)
        {
            case CollectableType.PistolAmmo:
                return _pistol;
            default:
                return null;
        }
    }

    private bool CollectCheck(float value1, float value2)
    {
        if (value1 < value2)
            return true;
        else
            return false;
    }
}
