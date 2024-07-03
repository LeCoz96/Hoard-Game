using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationInteract : Interactable
{
    [SerializeField] private GameObject _targetObject;
    private bool _isAnimating;

    protected override void Interact()
    {
        _isAnimating = !_isAnimating;
        _targetObject.GetComponent<Animator>().SetBool("Animate", _isAnimating);
    }
}
