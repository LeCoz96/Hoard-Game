using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SO_PlayerInventory : ScriptableObject
{
    private SO_Collectable _collect;
    
    public void AddToInventory(SO_Collectable.CollectableType type)
    {
        switch (type)
        {
            case SO_Collectable.CollectableType.PistolAmmo:
                break;
        }   

    }
}
