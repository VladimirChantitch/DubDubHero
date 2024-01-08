using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ui.pause
{
    public class PauseMenu_Presenter : MonoBehaviour
    {
        public Action OnSettingsButtonClicked;

        public Action OnResumeClicked { get; internal set; }
    }
}

