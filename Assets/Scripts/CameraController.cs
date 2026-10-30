using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _heightOffset = 1.5f;
    [SerializeField] private float _distance = 8f;
    [SerializeField] private Vector2 _pitchLimits = new Vector2(-80, 80);
    [SerializeField] private float _sensitivity = 1f;

    [SerializeField] private InputActionReference _cameraMoveAxis;

    [SerializeField] private Transform _pitchTransform;
    [SerializeField] private Transform _cameraTransform;

    private float _pitch;

    private void FixedUpdate()
    {
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _cameraTransform.localPosition = Vector3.forward * -_distance;
        _pitchTransform.localPosition = Vector3.up * _heightOffset;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Globals.GetCurrentPlayer().transform.position;
        CameraUpdate();
    }

    private void CameraUpdate()
    {
        Vector2 deltaCamera = _cameraMoveAxis.action.ReadValue<Vector2>();

        //transform.localEulerAngles += Vector3.up * (deltaCamera.y * _sensitivity);
        transform.Rotate(Vector3.up, (deltaCamera.x * _sensitivity));

        //float newPitch = Mathf.Clamp(_pitchTransform.localEulerAngles.x + (deltaCamera.y * _sensitivity), _pitchLimits.x, _pitchLimits.y);

        //_pitchTransform.localEulerAngles = new Vector3(newPitch, _pitchTransform.localEulerAngles.y, _pitchTransform.localEulerAngles.z);

        float deltaPitch = -deltaCamera.y * _sensitivity;

        _pitch = Mathf.Clamp(_pitch += deltaPitch, _pitchLimits.x, _pitchLimits.y);

        _pitchTransform.localRotation = Quaternion.Euler(_pitch, 0, 0);
    }

}
