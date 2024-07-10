using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    

public class SO_Collectable : ScriptableObject
{
    [SerializeField] private CollectableType _collectableType;
    [SerializeField] private string _name;
    [SerializeField] private int _quantity;

    public enum CollectableType
    {
        PistolAmmo,
        SMGAmmo,
        RifleAmmo,
        Health,
        Sheild
    }

    protected void CollectItem()
    {
        // Add to player inventory
        // player.getcomp<inventory>
    }

}
