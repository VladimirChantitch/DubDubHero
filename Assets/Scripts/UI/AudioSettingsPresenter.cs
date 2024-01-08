using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ui.settings
{
    public class AudioSettingsPresenter : MonoBehaviour
    {
        [SerializeField] Slider mainAudioSlider;
        [SerializeField] Slider vfxSlider;
        [SerializeField] Slider musicSlider;
        [SerializeField] Slider uiSlider;

        public event Action<AudioData> OnAudioSettingsChanged;
        private AudioData _AudioData;

        private void Awake()
        {
            _AudioData = GetAudioData();
            BindUI();
        }

        private void BindUI()
        {
            mainAudioSlider.onValueChanged.AddListener((value) => { _AudioData.mainValue = value; OnAudioSettingsChanged?.Invoke(_AudioData); });
            vfxSlider.onValueChanged.AddListener((value) => { _AudioData.vfxValue = value; OnAudioSettingsChanged?.Invoke(_AudioData); });
            musicSlider.onValueChanged.AddListener((value) => { _AudioData.musicValue = value; OnAudioSettingsChanged?.Invoke(_AudioData); });
            uiSlider.onValueChanged.AddListener((value) => { _AudioData.uiValue = value; OnAudioSettingsChanged?.Invoke(_AudioData); });
        }

        private AudioData GetAudioData()
        {
            return new AudioData()
            {
                mainValue = mainAudioSlider.value,
                vfxValue = vfxSlider.value,
                musicValue = musicSlider.value,
                uiValue = uiSlider.value,
            };
        }
    }

    public class AudioData
    {
        public float mainValue = 0;
        public float vfxValue = 0;
        public float musicValue = 0;
        public float uiValue = 0;
    }
}

