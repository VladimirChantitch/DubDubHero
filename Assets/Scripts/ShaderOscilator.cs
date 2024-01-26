using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderOscilator : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField] float test;

    void Update()
    {
        //material.SetFloat("_GridSize", test);
    }
}
