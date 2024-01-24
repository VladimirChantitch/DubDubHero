using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ui.settings
{
    public class Settings_Presenter : MonoBehaviour
    {
        [SerializeField] AudioSettingsPresenter audioSettings;
        [SerializeField] Button backButton;

        public event Action OnBackPressed;
        public event Action<AudioData> OnAudioChanged;

        internal void InitUI(AudioData audioData)
        {
            audioSettings.InitUI(audioData);
        }

        private void Awake()
        {
            audioSettings.OnAudioSettingsChanged += (audioSettings) =>
            {
                OnAudioChanged?.Invoke(audioSettings);
            };

            backButton.onClick.AddListener(() => { OnBackPressed?.Invoke(); });
        }
    }
}

