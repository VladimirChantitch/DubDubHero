using data;
using loader;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    [SerializeField] public SceneManager sceneManager;
    [SerializeField] Loader loader;

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
    }

    public List<LoaderData> GetSongsData()
    {
        return loader.Datas;
    }

    public SongData GetSong(int id)
    {
        return loader.GetSongById(id);
    }
}
