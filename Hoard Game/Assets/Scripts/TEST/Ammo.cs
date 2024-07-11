using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : Collectables
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerInventory>().AddToInventory(_collectableType, _collectableQuantity);
            gameObject.SetActive(false);
        }
    }
}
