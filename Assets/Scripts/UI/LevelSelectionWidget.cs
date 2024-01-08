using loader;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ui.selectLevel
{
    public class LevelSelectionWidget : MonoBehaviour
    {
        [SerializeField] Image songCover;
        [SerializeField] Button startLevelButton;
        [SerializeField] Button nextSong;
        [SerializeField] Button previous;
        [SerializeField] TextMeshProUGUI title;

        List<LoaderData> songDatas = new List<LoaderData>();

        int id = 0;

        private void Awake()
        {
            nextSong.onClick.AddListener(() => { Debug.Log("next"); });
            previous.onClick.AddListener(() => { Debug.Log("previous"); });
            startLevelButton.onClick.AddListener(() => {
                GameManager.Instance.GetSongByIDAndRun(id);
            });
        }

        internal void Init()
        {
            songDatas = GameManager.Instance.GetSongsData();

            id = 0;
            songCover.sprite = songDatas[id].Sprite;         
            title.text = songDatas[id].name;
        }
    }
}

