using data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace loader
{
    public class Loader : MonoBehaviour
    {
        [SerializeField] List<LoaderData> datas = new List<LoaderData>();

        SongData selectedSong;
        public List<LoaderData> Datas { 
            get {
                List<LoaderData> a = new List<LoaderData>();
                a.AddRange(datas);
                return a;
            } 
        }

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

            selectedSong = songData;
            return songData;
        }

        public SongMapData ParseSongMap()
        {
            var arrays = ParseCsv(selectedSong.songMap.text);

            float[] tambourArray = arrays.Item1;
            float[] cymbalArray = arrays.Item2;
            float[] pocpocArray = arrays.Item3;

            foreach (var item in tambourArray)
            {
                Debug.Log(item);
            }
            return null;
        }

        static Tuple<float[], float[], float[]> ParseCsv(string csvData)
        {
            List<float> tambourList = new List<float>();
            List<float> cymbalList = new List<float>();
            List<float> pocpocList = new List<float>();

            string[] lines = csvData.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var line in lines.Skip(1)) 
            {
                string[] values = line.Split("\",\"");
                Debug.Log(values.Length);

                float tambourValue, cymbalValue, pocpocValue;

                if (float.TryParse(values[0].Trim('"'), NumberStyles.Float, CultureInfo.InvariantCulture, out tambourValue) &&
                    float.TryParse(values[1].Trim('"'), NumberStyles.Float, CultureInfo.InvariantCulture, out cymbalValue) &&
                    float.TryParse(values[2].Trim('"'), NumberStyles.Float, CultureInfo.InvariantCulture, out pocpocValue))
                {
                    tambourList.Add(tambourValue);
                    cymbalList.Add(cymbalValue);
                    pocpocList.Add(pocpocValue);
                }
                else
                {
                    Console.WriteLine("Error parsing line: " + line);
                }
            }

            return Tuple.Create(tambourList.ToArray(), cymbalList.ToArray(), pocpocList.ToArray());
        }

        [ContextMenu("Test parse data")]
        public void TestParseData()
        {
            GetSongById(0);
            ParseSongMap();
        }
    }
}

