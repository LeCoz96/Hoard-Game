using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [Header("Collectable Attributes")]
    [SerializeField] protected Material _hueMaterial;
    [SerializeField] protected int _collectableQuantity;
    [SerializeField] protected CollectableType _collectableType;

    [Header("Animation Attributes")]
    [SerializeField] private float _spinSpeed;

    public enum CollectableType
    {
        PistolAmmo,
        SMGAmmo,
        RifleAmmo,
        HealthKit,
        ShieldKit,
        Damage,
        Speed,
        Ammo,
        Key1,
        Key2,
        Key3
    }

    void Start()
    {
        transform.GetComponentInChildren<Light>().color = _hueMaterial.color;
    }

    void Update()
    {
        transform.Rotate(0.0f, _spinSpeed * Time.deltaTime, 0.0f);
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
