using System;
using System.Collections;
using System.Collections.Generic;
using ui.credits;
using ui.home;
using ui.settings;
using ui.tutorial;
using UnityEngine;

namespace ui
{
    public class MainMenu_Presenter : MonoBehaviour
    {
        [SerializeField] SceneManager sceneManager;
        [SerializeField] Home_Presenter homePresenter;
        [SerializeField] Tutorial_Presenter tutorialPresenter;
        [SerializeField] Settings_Presenter settingsPresenter;
        [SerializeField] Credits_Presenter credits_Presenter;

        private void Start()
        {
            sceneManager.OnSceneLoadingStarted += HandleSceneLoading;
            sceneManager.OnSceneProgress += HandleSceneProgress;
            sceneManager.OnSceneLoaded += HandleSceneLoaded;

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
        }

        private void BindHomePresenter()
        {
            homePresenter.OnStartButtonClicked += () => { };
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
        }

        private void HandleSceneLoading(object sender, EventArgs e)
        {

        }

        private void HandleSceneProgress(object sender, float e)
        {
            throw new NotImplementedException();
        }

        private void HandleSceneLoaded(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }

}
