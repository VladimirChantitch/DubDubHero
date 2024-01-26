using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DirectionalLightRandomizer : MonoBehaviour
{
    [SerializeField] Light light;
    [SerializeField] float speed = 10;

    Color color;
    [SerializeField] float timer;
    float currentTime;

    private void Start()
    {
        light.color = color = GetrandomColor();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if (timer < currentTime)
        {
            currentTime = 0;
            color = GetrandomColor();
        }

        light.color = Color.Lerp(light.color, color, Time.deltaTime * speed);
    }

    private Color GetrandomColor()
    {
        Color color = new Color();
        color.a = 1;
        color.b = UnityEngine.Random.Range(25, 255);
        color.g = UnityEngine.Random.Range(25, 255);
        color.r = UnityEngine.Random.Range(25, 255);

        return color;
    }
}
