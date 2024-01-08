using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    [SerializeField] public SceneManager sceneManager;

    private void Awake()
    {
        if (instance == null) { 
            instance = this;
        }
        else
        {
            Destroy(instance.gameObject);
            instance = this;
        }
    }
}
