using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerInput.OnFootActions OnFoot;
    
    private PlayerInput _playerInput;
    private PlayerMotor _motor;
    private PlayerLook _look;
    private PlayerAttack _attack;

    void Awake()
    {
        _playerInput = new PlayerInput();

        OnFoot = _playerInput.OnFoot;

        _motor = GetComponent<PlayerMotor>();
        OnFoot.Jump.performed += ctx => _motor.Jump();
        OnFoot.Crouch.performed += ctx => _motor.Crouch();
        OnFoot.Sprint.performed += ctx => _motor.Sprint();

        _look = GetComponent<PlayerLook>();

        _attack = GetComponent<PlayerAttack>();
        OnFoot.Shoot.performed += ctx => _attack.Shoot();
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
