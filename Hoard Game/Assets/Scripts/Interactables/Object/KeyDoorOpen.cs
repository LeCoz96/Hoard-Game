using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoorOpen : Interactable
{
    [SerializeField] private Animator _targetObject;
    [SerializeField] private SO_Key _targetKey;
    [SerializeField] private string _animationTitle;

    protected override void Interact()
    {
        if(_targetKey.HasKey())
        {
            _targetObject.SetTrigger(_animationTitle);
            _targetKey.ResetKeys();
            gameObject.layer = 0;
        }
    }
}
