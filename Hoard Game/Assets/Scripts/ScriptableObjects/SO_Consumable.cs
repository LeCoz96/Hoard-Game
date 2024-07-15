using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Consumable", menuName = "ScriptableObjects/Consumable")]
public class SO_Consumable : ScriptableObject
{
    [Header("Consumable UI")]
    [SerializeField] private GameObject _consumablePrefab;
    [SerializeField] private Sprite _consumableIcon;
    [SerializeField] private Material _consumableMaterial;
}
