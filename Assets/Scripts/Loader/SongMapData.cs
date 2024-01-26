using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace loader
{
    public class SongMapData 
    {
        public SongMapData(float[] redBeatData, float[] blueBeatData, float[] greenBeatData)
        {
            this.redBeatData = redBeatData;
            this.blueBeatData = blueBeatData;
            this.greenBeatData = greenBeatData;
        }

        float[] redBeatData;
        float[] blueBeatData;
        float[] greenBeatData;

        public float[] RedBeatData => redBeatData;
        public float[] BlueBeatData => blueBeatData;
        public float[] GreenBeatData => greenBeatData;
    }
}
