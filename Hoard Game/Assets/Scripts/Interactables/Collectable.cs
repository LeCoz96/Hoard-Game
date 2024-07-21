using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour //make into single class with the on triggers from ammo and kit
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

    void Start()
    {
        transform.GetComponentInChildren<Light>().color = _hueMaterial.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInventory inventory = other.gameObject.GetComponent<PlayerInventory>();

            if (inventory.CanCollect(_collectableType))
            {
                inventory.AddToInventory(_collectableType, _collectableQuantity);
                gameObject.SetActive(false);
            }
        }
    }
}
