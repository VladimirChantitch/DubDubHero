using System.Collections;
using System.Collections.Generic;
using ui;
using ui.ingame;
using ui.settings;
using UnityEngine;
using UnityEngine.Audio;

namespace audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private Settings_Presenter settingsPresenter;
        [SerializeField] AudioMixer mixer;

        const string MASTER_VOLUME = "MainVolume";
        const string MUSIC_VOLUME = "MusicVolume";
        const string SFX_VOLUME = "SFXVolume";
        const string UI_VOLUME = "UIVolume";

        private void Start()
        {
            LookForAudioSettings();
        }

        public void LookForAudioSettings()
        {
            settingsPresenter = MainMenu_Presenter.Instance?.GetSettings_Presenter();
            if (settingsPresenter == null ) { InGame_Presenter.Instance?.GetSettings_Presenter(); }
            if (settingsPresenter != null )
            {
                settingsPresenter.OnAudioChanged += (audioData) =>
                {
                    mixer.SetFloat(MASTER_VOLUME, audioData.mainValue);
                    mixer.SetFloat(MUSIC_VOLUME, audioData.musicValue);
                    mixer.SetFloat(SFX_VOLUME, audioData.vfxValue);
                    mixer.SetFloat(UI_VOLUME, audioData.uiValue);
                };
            }
        }
    }
}

