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
        [SerializeField] Button nextSong;
        [SerializeField] Button previous;
        [SerializeField] TextMeshProUGUI title;

        List<LoaderData> songDatas = new List<LoaderData>();

        internal void Init()
        {
            songDatas = GameManager.Instance.GetSongsData();

        }
    }
}

