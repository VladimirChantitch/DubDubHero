using audio;
using data;
using loader;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    [SerializeField] public SceneManager sceneManager;
    [SerializeField] Loader loader;
    [SerializeField] string PlaySceneToLoad;
    [SerializeField] string uiToLoad;
    [SerializeField] AudioManager audioManager;

    SongData selectedSongData;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null) { 
            instance = this;
        }
        else
        {
            Destroy(instance.gameObject);
            instance = this;
        }

        sceneManager = GetComponentInChildren<SceneManager>();
        loader = GetComponentInChildren<Loader>();
        audioManager = GetComponentInChildren<AudioManager>();
    }

    public List<LoaderData> GetSongsData()
    {
        return loader.Datas;
    }

    public void GetSongByIDAndRun(int id)
    {
        selectedSongData = loader.GetSongById(id);
        sceneManager.LoadScene(uiToLoad);
        UnityEngine.SceneManagement.SceneManager.LoadScene(PlaySceneToLoad, UnityEngine.SceneManagement.LoadSceneMode.Additive);
        audioManager.LookForAudioSettings();
    }

    public SongData GetSelectedSongData()
    {
        return selectedSongData;
    }
}
