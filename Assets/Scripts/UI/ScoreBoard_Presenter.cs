using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Realms;
using Assets.Scripts.Models;
using System.Linq;
using data;
using loader;

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
            try
            {

                _realm = Realm.GetInstance();
                _scoreModel = _realm.All<ScoreModel>();
                if (_scoreModel != null)
                {
                    _scoreModel = new List<ScoreModel>(this._scoreModel);
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
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
        [ContextMenu("testData")]
        private void InitTestDataRealm()
        {
            try
            {
                _realm = Realm.GetInstance();
                Console.WriteLine(_realm.ToString());
                System.Random random = new System.Random();
                List<LoaderData>songDatas = GameManager.Instance.GetSongsData();

                for (int i = 0; i < 25; i++)
                {
                    ScoreModel scoreModel = new ScoreModel();
                    scoreModel.scoreId = i + 1;
                    scoreModel.playerName = GenerateRandomString(random, 8);
                    scoreModel.score = (float)random.NextDouble() * 100;
                    scoreModel.level_image = songDatas[0].Sprite; 
                    _scoreModel.ToList().Add(scoreModel);
                    Console.WriteLine(_scoreModel.Select(x=> x.playerName));

                }
                if (_realm != null)
                {
                    _realm.Add<ScoreModel>(_scoreModel);
                }
            }
            catch (Exception e) { Debug.LogError(e); }
        }

        // Méthode pour générer une chaîne aléatoire de longueur spécifiée
        private string GenerateRandomString(System.Random random, int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }



    }
}
