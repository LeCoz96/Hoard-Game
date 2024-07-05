using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("Player Heal");
            other.gameObject.GetComponent<PlayerHealth>().RestoreHealth(Random.Range(5, 10));
        }
    }
}
