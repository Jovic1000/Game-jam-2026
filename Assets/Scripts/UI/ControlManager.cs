using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static ControlManager;

public class ControlManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset _inputActionAsset;

    [Serializable]
    public struct InputData
    {
        public string _inputMap;
        public string _inputName;

        public string _displayName;

        public enum InputType { BUTTON, VECTOR2_UP, VECTOR2_DOWN, VECTOR2_LEFT, VECTOR2_RIGHT }

        public InputType _inputType;
    }


    [SerializeField] private InputData _inputData;
    [SerializeField] private TextMeshProUGUI _textMesh;


    private void Awake()
    {
        ReloadBindingUIButton();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void RebindKey()
    {
        RebindAction(_inputActionAsset.FindActionMap(_inputData._inputMap).FindAction(_inputData._inputName), GetIndex(_inputData._inputType));
    }


    private int GetIndex(InputData.InputType inputType)
    {
        switch (inputType)
        {
            case InputData.InputType.BUTTON:
                return 0;
            case InputData.InputType.VECTOR2_UP:
                return 1;
            case InputData.InputType.VECTOR2_DOWN:
                return 2;
            case InputData.InputType.VECTOR2_LEFT:
                return 3;
            case InputData.InputType.VECTOR2_RIGHT:
                return 4;
            default:
                return 0;
        }
    }

    private string GetCurrentKey()
    {
        return _inputActionAsset.FindActionMap(_inputData._inputMap).FindAction(_inputData._inputName).GetBindingDisplayString(GetIndex(_inputData._inputType));
    }

    private void ReloadBindingUIButton()
    {
        string displayName = _inputData._inputName;
        if (_inputData._displayName != "" && _inputData._displayName != null) displayName = _inputData._displayName;

        string text = $"{displayName}: {GetCurrentKey()}";

        _textMesh.text = text;
    }

    private void RebindAction(InputAction inputAction, int index = 1)
    {
        inputAction.actionMap.Disable();

        inputAction.PerformInteractiveRebinding(index)
            .WithControlsExcluding("Mouse")
            .OnMatchWaitForAnother(0.1f)
            .WithCancelingThrough("<keyboard>/escape")
            .OnCancel(op =>
            {
                Debug.Log("Rebind Canceled");
                inputAction.actionMap.Enable();
                ReloadBindingUIButton();
                op.Dispose();
            })
            .OnComplete(op =>
            {
                inputAction.actionMap.Enable();
                ReloadBindingUIButton();
                op.Dispose();
            })
            .Start();

    }
}