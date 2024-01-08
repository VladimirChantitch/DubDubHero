using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ui.ingame
{
    public class MainIngame_Presenter : MonoBehaviour
    {
        [SerializeField] Button pauseButton;

        public Action OnPauseButtonClicked;
    }
}

