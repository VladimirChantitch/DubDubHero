using System;
using System.Collections;
using System.Collections.Generic;
using ui.credits;
using ui.home;
using ui.selectLevel;
using ui.settings;
using ui.tutorial;
using UnityEngine;

namespace ui
{
    public class MainMenu_Presenter : MonoBehaviour, IMainPresenter
    {
        [SerializeField] SceneManager sceneManager;
        [SerializeField] Home_Presenter homePresenter;
        [SerializeField] Tutorial_Presenter tutorialPresenter;
        [SerializeField] Settings_Presenter settingsPresenter;
        [SerializeField] Credits_Presenter credits_Presenter;
        [SerializeField] SelectLevel_Presenter selectLevelPresenter;

        private static MainMenu_Presenter instance;
        public static MainMenu_Presenter Instance
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
            BindHomePresenter();
            BindTutorialPresenter();
            InitUI();
        }

        private void InitUI()
        {
            homePresenter.gameObject.SetActive(true);
            tutorialPresenter.gameObject.SetActive(false);
            settingsPresenter.gameObject.SetActive(false);
            credits_Presenter.gameObject.SetActive(false);
            selectLevelPresenter.gameObject.SetActive(false);
        }

        private void BindHomePresenter()
        {
            homePresenter.OnStartButtonClicked += () => {
                homePresenter.gameObject.SetActive(false);
                selectLevelPresenter.gameObject.SetActive(true);
            };
            homePresenter.OnTutorialButtonClicked += () => {
                homePresenter.gameObject.SetActive(false);
                tutorialPresenter.gameObject.SetActive(true);
            };
            homePresenter.OnSettingsButtonClicked += () => {
                homePresenter.gameObject.SetActive(false);
                settingsPresenter.gameObject.SetActive(true);
            };
            homePresenter.OnCreditsButtonClicked += () => {
                homePresenter.gameObject.SetActive(false);
                credits_Presenter.gameObject.SetActive(true);
            };
        }

        private void BindTutorialPresenter()
        {
            tutorialPresenter.OnBackPressed += () => {
                homePresenter.gameObject.SetActive(true);
                tutorialPresenter.gameObject.SetActive(false);
            };

            settingsPresenter.OnBackPressed += () => {
                homePresenter.gameObject.SetActive(true);
                settingsPresenter.gameObject.SetActive(false);
            };

            credits_Presenter.OnBackPressed += () =>
            {
                homePresenter.gameObject.SetActive(true);
                credits_Presenter.gameObject.SetActive(false);
            };

            selectLevelPresenter.OnBackPressed += () =>
            {
                homePresenter.gameObject.SetActive(true);
                selectLevelPresenter.gameObject.SetActive(false);
            };
        }

        public Settings_Presenter GetSettings_Presenter()
        {
            return settingsPresenter;
        }
    }
}
