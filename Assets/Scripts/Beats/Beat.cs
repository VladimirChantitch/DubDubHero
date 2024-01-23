using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beat : MonoBehaviour
{
    [SerializeField] ParticleSystem particuleSystem;
    [SerializeField] Renderer beatGraphism;

    [SerializeField] E_BeatState state;
    [SerializeField] Collider _collider;

    private void Awake()
    {
        particuleSystem.Pause();
    }

    public float HitTheBeatAndGetScore()
    {
        if (state == E_BeatState.Nope) return 0;

        beatGraphism.enabled = false;
        _collider.enabled = false;
        HandleParticules();
        return GetScore();
    }

    public void SetState(E_BeatState state)
    {
        this.state = state;
    }

    private void HandleParticules()
    {
        particuleSystem.Play();
    }

    private float GetScore()
    {
        float score = 0;

        switch (state)
        {
            case E_BeatState.Bad:
                score = 10;
                break;
            case E_BeatState.Good:
                score = 25;
                break;
            case E_BeatState.Perfect:
                score = 50;
                break;
        }

        return score;
    }
}

public enum E_BeatState { Nope, Bad, Good, Perfect}
