using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScalars", menuName = "ScriptableObjects/PlayerScalars")]
public class SO_PlayerScalars : ScriptableObject
{
    [SerializeField] private float _speedBuff;
    [SerializeField] private float _damageBuff;

    public float GetSpeedBuff() { return _speedBuff; }
    public float GetDamageBuff() { return _damageBuff; }
}
