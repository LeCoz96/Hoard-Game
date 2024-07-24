using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Key", menuName = "ScriptableObjects/Key")]
public class SO_Key : ScriptableObject
{
    private int _collectedQuantity;

    public void CollectKey() { ++_collectedQuantity; }
    public void UseKey() { --_collectedQuantity; }

    public bool HasKey() { return _collectedQuantity > 0; }
    public bool CanCollect() { return _collectedQuantity > 0; }
}
