using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ui.ingame
{
    public class MainIngame_Presenter : MonoBehaviour
    {
        [SerializeField] Button pauseButton;
        [SerializeField] TextMeshProUGUI score;

        public Action OnPauseButtonClicked;

        private void Awake()
        {
            pauseButton.onClick.AddListener(() => { OnPauseButtonClicked?.Invoke(); });
        }
    }
}

