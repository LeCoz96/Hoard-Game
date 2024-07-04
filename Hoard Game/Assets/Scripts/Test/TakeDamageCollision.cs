using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("Player Hit");
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(Random.Range(5, 10));
        }
    }
}
