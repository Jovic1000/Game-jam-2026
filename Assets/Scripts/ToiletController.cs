using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Rendering;

public class ToiletController : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 8f;
    [SerializeField] private Transform _jumpDirection;

    [SerializeField] private float _turnSpeed = 10f;
    [SerializeField] private float _lerpRatio = 0.05f;

    [SerializeField] private float _resetRotationHeight = 3f;

    [SerializeField] private Rigidbody _rigidbody;


    [SerializeField] private InputActionReference _forwardEvent;
    [SerializeField] private InputActionReference _turnEvent;
    [SerializeField] private InputActionReference _resetRotationEvent;


    private void HookInputs()
    {
        _forwardEvent.action.performed += Forward;
        //_turnEvent.action.performed += Turn;
        _resetRotationEvent.action.performed += ResetRotation;
    }
    private void UnhookInputs()
    {
        _forwardEvent.action.performed -= Forward;
        //_turnEvent.action.performed -= Turn;
        _resetRotationEvent.action.performed -= ResetRotation;
    }
    private void OnEnable()
    {
        HookInputs();
    }

    private void OnDisable()
    {
        UnhookInputs();
    }


    private void Forward(InputAction.CallbackContext context)
    {
        _rigidbody.AddForce(_jumpForce * _jumpDirection.forward, ForceMode.Impulse);
    }

    private void ResetRotation(InputAction.CallbackContext context)
    {
        transform.position += Vector3.up * _resetRotationHeight;
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
    }

    private void Turn()
    {
        //float value = context.ReadValue<float>();
        float value = _turnEvent.action.ReadValue<float>();

        float turnAmount = value * _turnSpeed * Time.deltaTime;

        transform.localEulerAngles += new Vector3(0, turnAmount, 0);
    }

    private void RotateTowardsUp()
    {
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, transform.eulerAngles.y, 0), _lerpRatio);

        // Add code to rotate towards upwards

        Quaternion desiredRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

        Quaternion deltaRotation = Quaternion.Lerp(_rigidbody.rotation, desiredRotation, _lerpRatio);

        _rigidbody.MoveRotation(deltaRotation);

        Debug.Log($"{desiredRotation} : {_rigidbody.rotation} : {deltaRotation}");
        //print("hello world");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Turn();
        //RotateTowardsUp();
    }








}
