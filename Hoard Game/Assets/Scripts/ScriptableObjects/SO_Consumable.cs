using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "ScriptableObjects/Consumable")]
public class SO_Consumable : ScriptableObject
{
    [SerializeField] private int _consumableValue;
}
