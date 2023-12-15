using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] SceneManager sceneManager;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            sceneManager.OnSceneLoadingStarted += HandleSceneLoading;
            sceneManager.OnSceneProgress += HandleSceneProgress;
            sceneManager.OnSceneLoaded += HandleSceneLoaded;
        }

        private void HandleSceneLoading(object sender, EventArgs e)
        {
              
        }

        private void HandleSceneProgress(object sender, float e)
        {
            throw new NotImplementedException();
        }

        private void HandleSceneLoaded(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public E_UIState state;

        public void ChangeState (E_UIState state)
        {
            switch (state)
            {
                case E_UIState.Main:
                    break;
                case E_UIState.Start:
                    break;
                case E_UIState.Settings:
                    break;
                case E_UIState.MainGame:
                    break;
                default :
                    Debug.Log($"<color=blue> this game state is not handled</color>");
                    break;
            }
        }
    }
}
