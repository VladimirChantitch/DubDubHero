using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ui.selectLevel
{
    public class SelectLevel_Presenter : MonoBehaviour
    {
        [SerializeField] Button backButton;
        [SerializeField] LevelSelectionWidget levelSelectionWidget;

        public event Action OnBackPressed;

        private void Awake()
        {
            BindButtons();
        }

        private void BindButtons()
        {
            backButton.onClick.AddListener(() => { OnBackPressed?.Invoke(); });
        }

        private void OnEnable()
        {
            levelSelectionWidget.Init();
        }
    }
}

