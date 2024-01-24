using System;
using System.Collections;
using System.Collections.Generic;
using ui.credits;
using ui.home;
using ui.pause;
using ui.selectLevel;
using ui.settings;
using ui.tutorial;
using UnityEngine;

namespace ui.ingame
{
    public class InGame_Presenter : MonoBehaviour, IMainPresenter
    {
        [SerializeField] SceneManager sceneManager;
        [SerializeField] Settings_Presenter settings_Presenter;
        [SerializeField] MainIngame_Presenter mainIngamePresenter;
        [SerializeField] PauseMenu_Presenter pauseMenuPresenter;

        private static InGame_Presenter instance;
        public static InGame_Presenter Instance
        {
            get
            {
                return instance;
            }
        }

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            BindPresenter();
            InitUI();
        }

        private void InitUI()
        {
            mainIngamePresenter.gameObject.SetActive(true);
            pauseMenuPresenter.gameObject.SetActive(false);
            settings_Presenter.gameObject.SetActive(false);
        }

        private void BindPresenter()
        {
            mainIngamePresenter.OnPauseButtonClicked += () => {
                mainIngamePresenter.gameObject.SetActive(false);
                pauseMenuPresenter.gameObject.SetActive(true);
            };
            pauseMenuPresenter.OnSettingsButtonClicked += () => {
                pauseMenuPresenter.gameObject.SetActive(false);
                settings_Presenter.gameObject.SetActive(true);
            };
            settings_Presenter.OnBackPressed += () => {
                settings_Presenter.gameObject.SetActive(false);
                pauseMenuPresenter.gameObject.SetActive(true);
            };
            pauseMenuPresenter.OnResumeClicked += () =>
            {
                pauseMenuPresenter.gameObject.SetActive(false);
                mainIngamePresenter.gameObject.SetActive(true);
            };
        }

        public Settings_Presenter GetSettings_Presenter()
        {
            return settings_Presenter;
        }

        internal void SetScore(float currentScore)
        {
            mainIngamePresenter.SetScore(currentScore);
        }
    }
}

