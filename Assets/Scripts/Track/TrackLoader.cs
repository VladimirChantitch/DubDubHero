using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Track
{
    /// <summary>
    /// loads the data related to a track
    /// </summary>
    public class TrackLoader : ScriptableObject
    {
        [SerializeField] private TextAsset trackData;
        [SerializeField] private AudioClip trackMusic;
        public AudioClip Music => trackMusic;

        public void GetFormattedTrackData()
        {

        }
        //public void LoadTrack()
    }

    public class TrackLineData
    {
        
    }
}

