using data;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace loader
{
    public class Loader : MonoBehaviour
    {
        [SerializeField] List<LoaderData> datas = new List<LoaderData>();

        private void Start()
        {
            Debug.Assert(datas.Count != 0, $"<color=blue>Well there are no song in this game</color>");
        }

        public SongData GetSongById(int id)
        {
            LoaderData data = datas[id];
            SongData songData = new SongData();
            songData.songIcon = data.Sprite;
            songData.songMap = (TextAsset)Resources.Load(data.ResourceName + "-data");
            songData.song = (AudioClip)Resources.Load(data.ResourceName);

            return songData;
        }
    }
}

