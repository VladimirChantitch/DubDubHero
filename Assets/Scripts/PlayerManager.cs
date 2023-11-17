using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float maxSpeed = 5f;
    [SerializeField] InputManager inputManager;

    private void Awake()
    {
        if (inputManager == null) inputManager = GetComponent<InputManager>();
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
