using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumables : Collectables
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

            if (inventory.CanCollect(_collectableType))
            {
                inventory.AddToInventory(_collectableType, _collectableQuantity);
                gameObject.SetActive(false);
            }
        }
    }
}
