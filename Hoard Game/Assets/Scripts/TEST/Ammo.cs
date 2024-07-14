using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : Collectables
{
    void Start()
    {
        transform.GetComponentInChildren<Light>().color = _hueMaterial.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInventory inventory = other.gameObject.GetComponent<PlayerInventory>();

            if (inventory.CanBeCollected(_collectableType, _collectableQuantity))
            {
                inventory.AddToInventory(_collectableType, _collectableQuantity);
                gameObject.SetActive(false);
            }
            else
            {
                // need to collect and set to max. if at max, dont collect
                inventory.SetToMaxCapacity(_collectableType);
            }
        }
    }
}
