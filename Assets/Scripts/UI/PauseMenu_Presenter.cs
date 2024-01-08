using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ui.pause
{
    public class PauseMenu_Presenter : MonoBehaviour
    {
        [SerializeField] Button settingsButton;
        [SerializeField] Button resumeButton;

        public Action OnSettingsButtonClicked;
        public Action OnResumeClicked;

        private void Awake()
        {
            settingsButton.onClick.AddListener(() => { OnSettingsButtonClicked?.Invoke(); });
            resumeButton.onClick.AddListener(() => { OnResumeClicked?.Invoke(); });
        }
    }
}

