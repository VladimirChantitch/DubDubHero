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
            float master = PlayerPrefs.GetFloat(MASTER_VOLUME);
            float music = PlayerPrefs.GetFloat(MUSIC_VOLUME);
            float sfx = PlayerPrefs.GetFloat(SFX_VOLUME);
            float ui = PlayerPrefs.GetFloat(UI_VOLUME);

            mixer.SetFloat(MASTER_VOLUME, PlayerPrefs.GetFloat(MASTER_VOLUME));
            mixer.SetFloat(MUSIC_VOLUME, PlayerPrefs.GetFloat(MUSIC_VOLUME));
            mixer.SetFloat(SFX_VOLUME, PlayerPrefs.GetFloat(SFX_VOLUME));
            mixer.SetFloat(UI_VOLUME, PlayerPrefs.GetFloat(UI_VOLUME));

            settingsPresenter.InitUI(new AudioData()
            {
                mainValue = master,
                vfxValue = sfx,
                uiValue = ui,
                musicValue = music,
            });
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

                    PlayerPrefs.SetFloat(MASTER_VOLUME, audioData.mainValue);
                    PlayerPrefs.SetFloat(MUSIC_VOLUME, audioData.musicValue);
                    PlayerPrefs.SetFloat(SFX_VOLUME, audioData.vfxValue);
                    PlayerPrefs.SetFloat(UI_VOLUME, audioData.uiValue);
                };
            }
        }
    }
}

