using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectables : MonoBehaviour //make into single class with the on triggers from ammo and kit
{
    [Header("Collectable Attributes")]
    [SerializeField] protected Material _hueMaterial;
    [SerializeField] protected int _collectableQuantity;
    [SerializeField] protected CollectableType _collectableType;

    public enum CollectableType
    {
        PistolAmmo,
        SMGAmmo,
        RifleAmmo,
        HealthKit,
        ShieldKit
    }

    public void BaseCollect()
    {
        Collect();
    }

    protected virtual void Collect() { }
}
