using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ui.home
{
    public class Home_Presenter : MonoBehaviour
    {
        [SerializeField] Button start;
        [SerializeField] Button tutorial;
        [SerializeField] Button settings;
        [SerializeField] Button credits;
        [SerializeField] Button scoreBoard;

        public event Action OnStartButtonClicked;
        public event Action OnTutorialButtonClicked;
        public event Action OnSettingsButtonClicked;
        public event Action OnCreditsButtonClicked;
        public event Action OnScoreBoardButtonClicked;

        private void Start()
        {
            BindButtons();
        }

        private void BindButtons()
        {
            start.onClick.AddListener(() => { OnStartButtonClicked?.Invoke(); });
            tutorial.onClick.AddListener(() => { OnTutorialButtonClicked?.Invoke(); });
            settings.onClick.AddListener(() => { OnSettingsButtonClicked?.Invoke(); });
            credits.onClick.AddListener(() => { OnCreditsButtonClicked?.Invoke(); });
            scoreBoard.onClick.AddListener(() => { OnScoreBoardButtonClicked?.Invoke(); });
        }
    }
}
