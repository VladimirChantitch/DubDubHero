using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ui.credits
{
    public class Credits_Presenter : MonoBehaviour
    {
        [SerializeField] Button backButton;

        public event Action OnBackPressed;

        private void Awake()
        {
            backButton.onClick.AddListener(() => { OnBackPressed?.Invoke(); });
        }
    }

}
