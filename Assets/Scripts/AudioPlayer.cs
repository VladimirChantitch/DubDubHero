using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace audio
{
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField] AudioClip m_Clip;
        [SerializeField] AudioSource m_Source;
        
        public void PlayAudioClip()
        {
            m_Source.PlayOneShot(m_Clip);
        }
    }
}

