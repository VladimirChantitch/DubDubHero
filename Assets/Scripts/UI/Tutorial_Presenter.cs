using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ui.tutorial
{
    public class Tutorial_Presenter : MonoBehaviour
    {
        [SerializeField] Button backButton;
        public event Action OnBackPressed;

        private void Awake()
        {
            BindButton();
        }

        private void BindButton()
        {
            backButton.onClick.AddListener(() => { OnBackPressed?.Invoke(); });     
        }
    }
}
