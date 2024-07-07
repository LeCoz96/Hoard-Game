using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _interactDistance;
    [SerializeField] private LayerMask _interactLayer;

    private PlayerUI _playerUI;
    private InputManager _inputManager;

    void Start()
    {
        _playerUI = GetComponent<PlayerUI>();
        _inputManager = GetComponent<InputManager>();
    }

    void Update()
    {
        _playerUI.UpdateText(string.Empty);

        Ray ray = new Ray(_camera.transform.position, _camera.transform.forward);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, _interactDistance, _interactLayer))
        {
            if (hit.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                _playerUI.UpdateText(interactable.PromptMessage);

                if (_inputManager.OnFoot.Interact.triggered)
                    interactable.BaseInteract();
            }
        }
    }
}
