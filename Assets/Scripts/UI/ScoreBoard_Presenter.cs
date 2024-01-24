using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Realms;
using Assets.Scripts.Models;

namespace ui.credits
{
    public class ScoreBoard_Presenter : MonoBehaviour
    {
        [SerializeField] Button backButton;
        [SerializeField] GameObject rowPrefab;
        [SerializeField] Transform contentTransform;
        
        public event Action OnBackPressed;

        private Realm _realm;
        private IEnumerable<ScoreModel> _scoreModel;

        void OnEnabled()
        {
            _realm = Realm.GetInstance();  
            _scoreModel = _realm.All<ScoreModel>();
            if(_scoreModel != null)
            {
                _scoreModel = new List<ScoreModel>(this._scoreModel);
            }
        }
        void OnDisable()
        {
            _realm.Dispose();
        }

        private void Awake()
        {
            backButton.onClick.AddListener(() => { OnBackPressed?.Invoke(); });
            BindScoreBoardData();
        }

        private void BindScoreBoardData()
        {
            throw new NotImplementedException();
        }

        //Instancie des datas de tests en bdd 
        private void InitDataRealm()
        {
            
        }
    }
}
