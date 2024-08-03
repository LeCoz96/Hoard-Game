using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _playerVelocity;
    private float _speed;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _sprintSpeed;
    [SerializeField] private float _crouchSpeed;

    private bool _isGrounded;
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpHeight;

    private bool _lerpCrouch;
    private bool _crouching;
    private bool _sprinting;
    private float _crouchTimer;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _speed = _moveSpeed;
    }

    void Update()
    {
        _isGrounded = _controller.isGrounded;

        if(_lerpCrouch)
        {
            _crouchTimer += Time.deltaTime;
            float p = _crouchTimer / 1;
            p *= p;

            if(_crouching)
                _controller.height = Mathf.Lerp(_controller.height, 1, p);
            else
                _controller.height = Mathf.Lerp(_controller.height, 2, p);

            if(p > 1)
            {
                _lerpCrouch = false;
                _crouchTimer = 0;
            }
        }
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 MoveDirection = Vector3.zero;
        MoveDirection.x = input.x;
        MoveDirection.z = input.y;
        _controller.Move(transform.TransformDirection(MoveDirection) * _speed * Time.deltaTime);

        _playerVelocity.y += _gravity * Time.deltaTime;

        if (_isGrounded && _playerVelocity.y < 0)
            _playerVelocity.y = -2f;

        _controller.Move(_playerVelocity * Time.deltaTime);

    }

    public void Jump()
    {
        if (_isGrounded)
            _playerVelocity.y = Mathf.Sqrt(_jumpHeight * -3.0f * _gravity);
    }

    public void Crouch()
    {
        _crouching = !_crouching;

        _crouchTimer = 0;
        _lerpCrouch = true;

        SpeedChange(_crouching, _crouchSpeed);
    }

    public void Sprint()
    {
        _sprinting = !_sprinting;

        SpeedChange(_sprinting, _sprintSpeed);
    }

    private void SpeedChange(bool action, float value)
    {
        if (action)
            _speed = value;
        else
            _speed = _moveSpeed;
    }
}
