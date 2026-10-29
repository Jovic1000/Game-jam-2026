using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Rendering;

public partial class ToiletController : MonoBehaviour
{

    [Header("Player Settings")]
    [SerializeField] private float _jumpForce = 8f;
    [SerializeField] private Transform _jumpDirection;

    [SerializeField] private float _turnSpeed = 10f;
    [SerializeField] private float _lerpTime = 1f;

    [SerializeField] private float _resetRotationHeight = 3f;

    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private Transform _groundRaycast;
    [SerializeField] private float _groundRaycastLength = 0.6f;

    [SerializeField] private InputActionReference _forwardInput;
    [SerializeField] private InputActionReference _turnInput;
    [SerializeField] private InputActionReference _resetRotationInput;


    [Header("Events")]
    [SerializeField] private UnityEvent _forwardEvent;
    [SerializeField] private UnityEvent _resetRotationEvent;

    private void HookInputs()
    {
        _forwardInput.action.performed += Forward;
        //_turnInput.action.performed += Turn;
        _resetRotationInput.action.performed += ResetRotation;
    }
    private void UnhookInputs()
    {
        _forwardInput.action.performed -= Forward;
        //_turnInput.action.performed -= Turn;
        _resetRotationInput.action.performed -= ResetRotation;
    }

    private void Awake()
    {
        Globals.SetCurrentPlayer(gameObject);
    }

    private void OnEnable()
    {
        HookInputs();
    }

    private void OnDisable()
    {
        UnhookInputs();
    }


    private bool IsGrounded()
    {
        //return Physics.Raycast(_groundRaycast.position, _groundRaycast.forward, _groundRaycastLength);
        return Physics.Raycast(_groundRaycast.position, Vector3.down, _groundRaycastLength);

        //return _groundCollider.
    }

    private void Forward(InputAction.CallbackContext context)
    {
        _forwardEvent.Invoke();

        if (!IsGrounded()) return;
        _rigidbody.AddForce(_jumpForce * _jumpDirection.forward, ForceMode.Impulse);
    }

    private void ResetRotation(InputAction.CallbackContext context)
    {
        _resetRotationEvent.Invoke();

        transform.position += Vector3.up * _resetRotationHeight;
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
    }

    private void Turn()
    {
        //float value = context.ReadValue<float>();
        float value = _turnInput.action.ReadValue<float>();

        float turnAmount = value * _turnSpeed * Time.deltaTime;

        transform.localEulerAngles += new Vector3(0, turnAmount, 0);
    }

    private void RotateTowardsUp()
    {
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, transform.eulerAngles.y, 0), _lerpRatio);

        // Add code to rotate towards upwards

        Quaternion desiredRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

        Quaternion deltaRotation = Quaternion.Lerp(_rigidbody.rotation, desiredRotation, _lerpTime * Time.fixedDeltaTime);

        _rigidbody.MoveRotation(deltaRotation);

        //Debug.Log($"{desiredRotation} : {_rigidbody.rotation} : {deltaRotation}");
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
