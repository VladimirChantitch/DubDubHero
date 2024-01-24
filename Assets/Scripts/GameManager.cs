using audio;
using data;
using gameplay;
using loader;
using System;
using System.Collections;
using System.Collections.Generic;
using ui.ingame;
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
    [SerializeField] InputManager inputManager;

    float _currentScore = 0;

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
        inputManager = GetComponent<InputManager>();

        inputManager.OnTouch += HandleTouchInteraction;
    }

    private void HandleTouchInteraction(Beat beat)
    {
        float score = beat.HitTheBeatAndGetScore();
        Debug.Log(score);
        _currentScore += score;
        InGame_Presenter.Instance?.SetScore(_currentScore);

    }

    public List<LoaderData> GetSongsData()
    {
        return loader.Datas;
    }

    public SongData GetSong(int id)
    {
        return loader.GetSongById(id);
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
