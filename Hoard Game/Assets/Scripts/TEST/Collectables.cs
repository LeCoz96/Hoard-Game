using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectables : MonoBehaviour
{
    [Header("Collectable Attributes")]
    [SerializeField] private Material _hueMaterial;
    [SerializeField] private GameObject _colletablePrefab;
    [SerializeField] protected int _collectableQuantity;
    [SerializeField] protected CollectableType _collectableType;

    public enum CollectableType
    {
        PistolAmmo,
        SMGAmmo,
        RifleAmmo,
        HealthKit,
        Shield
    }

    public void BaseCollect()
    {
        Collect();
    }

    protected virtual void Collect() { }
}
