using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private float _xRotation = 0.0f;

    [SerializeField] private float xSensitivity; // DEFAULT 30
    [SerializeField] private float ySensitivity; // DEFAULT 30

    [SerializeField] private float _cameraYMax;
    [SerializeField] private float _cameraYMin;

    public void ProcessLook(Vector2 input)
    {
        float MouseX = input.x;
        float MouseY = input.y;

        _xRotation -= (MouseY * Time.deltaTime) * ySensitivity;
        _xRotation = Mathf.Clamp(_xRotation, _cameraYMin, _cameraYMax);

        _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0.0f, 0.0f);
        transform.Rotate(Vector3.up * (MouseX * Time.deltaTime) * xSensitivity);
    }
}
