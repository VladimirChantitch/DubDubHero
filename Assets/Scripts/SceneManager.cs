using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    /// <summary>
    /// An event for when a scene is loaded
    /// </summary>
    public EventHandler OnSceneLoaded;
    public EventHandler<float> OnSceneProgress;
    public EventHandler OnSceneLoadingStarted;
    bool _isSceneLoaded = true;
    AsyncOperation loadingOp;

    public void LoadScene(string sceneName, bool isAdditive = false)
    {
        if (_isSceneLoaded)
        {
            _isSceneLoaded = false;
            if (isAdditive)
            {
                loadingOp = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName,
                                        UnityEngine.SceneManagement.LoadSceneMode.Additive);
            }
            else
            {
                loadingOp = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName,
                                        UnityEngine.SceneManagement.LoadSceneMode.Single);
            }

            loadingOp.allowSceneActivation = false;
        }
    }

    private void Update()
    {
        if (!_isSceneLoaded)
        {
            OnSceneProgress?.Invoke(this, loadingOp.progress);
            Debug.Log($"<color=yellow> loading progress : </color>" + loadingOp.progress);
            if (loadingOp.progress >= 0.85)
            {
                loadingOp.allowSceneActivation = true;
                OnSceneLoaded?.Invoke(this, null);
            }
        }
    }

    [ContextMenu("Test change scene")]
    public void ChangeTemp()
    {
        LoadScene(StaticVar.GAME_SCENE);
    }
}
