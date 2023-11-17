using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    PlayerControls inputs = null;

    private void Awake()
    {
        inputs = new PlayerControls();
    }

    public event Action<Vector3> OnMovePressed;
    Vector3 direction = Vector3.zero;

    private void OnEnable()
    {
        inputs.Enable();

        BindInputs();
    }

    private void BindInputs()
    {
        inputs.Motion.Move.performed += HandleMotion;
        inputs.Motion.Move.canceled += StopMotion;
    }

    private void OnDisable()
    {
        inputs?.Disable();
    }

    private void HandleMotion(InputAction.CallbackContext context)
    {
        Vector2 motionInfo = context.ReadValue<Vector2>();
        direction = Vector3.zero;
        direction.x = motionInfo.x;
        direction.z = motionInfo.y;
    }

    private void StopMotion(InputAction.CallbackContext context)
    {
        direction = Vector3.zero;
    }

    private void FixedUpdate()
    {
        OnMovePressed?.Invoke(direction);
    }
}
