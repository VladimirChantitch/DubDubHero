using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    PlayerControls inputs = null;
    [SerializeField] Camera mainCam;
    [SerializeField] LayerMask beatMask;
    [SerializeField] float maxDistance;

    private void Awake()
    {
        inputs = new PlayerControls();
    }

    public event Action<Beat> OnTouch;

    private void OnEnable()
    {
        inputs.Enable();

        BindInputs();
    }

    private void BindInputs()
    {
        inputs.Touch.Touch.performed += i => HandleTouch(i.ReadValue<Vector2>());
    }

    private void HandleTouch(Vector2 position)
    {
        RaycastHit hit;

        Ray ray = mainCam.ScreenPointToRay(position);
        if (Physics.Raycast(ray, out hit, maxDistance, beatMask))
        {
            Debug.Log("found " + hit.collider.gameObject.name + " at distance: " + hit.distance);
            Beat beat = hit.collider.gameObject.GetComponent<Beat>();
            OnTouch?.Invoke(beat);
        }
    }

    private void OnDisable()
    {
        inputs?.Disable();
    }
}
