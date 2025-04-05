using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerInput.OnFootActions OnFoot;
    
    private PlayerInput _playerInput;
    private PlayerMovement _motor;
    private PlayerLook _look;
    private PlayerAttack _attack;
    private PlayerMenus _menus;

    void Awake()
    {
        _playerInput = new PlayerInput();

        OnFoot = _playerInput.OnFoot;

        _motor = GetComponent<PlayerMovement>();
        OnFoot.Jump.performed += ctx => _motor.Jump();
        OnFoot.Crouch.performed += ctx => _motor.Crouch();
        OnFoot.Sprint.performed += ctx => _motor.Sprint();

        _look = GetComponent<PlayerLook>();

        _attack = GetComponent<PlayerAttack>();
        OnFoot.Shoot.started += ctx => _attack.Attack();
        OnFoot.Shoot.canceled += ctx => _attack.EndAttack();
        OnFoot.Reload.performed += ctx => _attack.Reload();

        _menus = GetComponent<PlayerMenus>();
        OnFoot.WeaponPanel.started += ctx => _menus.OpenWeaponPanel();
        OnFoot.WeaponPanel.canceled += ctx => _menus.CloseWeaponPanel();
    }

    void FixedUpdate()
    {
        _motor.ProcessMove(OnFoot.Movement.ReadValue<Vector2>());
    }

    void LateUpdate()
    {
        _look.ProcessLook(OnFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        OnFoot.Enable();
    }

    private void OnDisable()
    {
        OnFoot.Disable();
    }
}
