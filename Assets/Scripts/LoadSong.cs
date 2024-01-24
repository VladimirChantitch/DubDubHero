using data;
using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;


public class LoadSong : MonoBehaviour
{

    [SerializeField] private GameObject BeatRight;
    [SerializeField] private GameObject BeatCenter;
    [SerializeField] private GameObject BeatLeft;
    [SerializeField] private GameObject Board;


    // Start is called before the first frame update
    void Start()
    {
       
        SongData songData = GameManager.Instance.GetSong(0);

       if (songData.songMap != null)
        {
            string datas = songData.songMap.text;
            List<CSVDatas> donnees = ParserCSVContenu(datas);

            Debug.Log(donnees);

            List<string> tambour = new List<string>();
            List<string> cymbal = new List<string>();
            List<string> pocpoc = new List<string>();

            foreach (CSVDatas ligne in donnees)
            {

                if (!string.IsNullOrEmpty(ligne.column1))
                {
                    tambour.Add(ligne.column1);
                }
                if (!string.IsNullOrEmpty(ligne.column2))
                {
                    cymbal.Add(ligne.column2);
                }
                if (!string.IsNullOrEmpty(ligne.column3))
                {
                    pocpoc.Add(ligne.column3);
                }
            }
            
            
            foreach (string tamb in tambour)
            {
                float tambo = float.Parse(tamb);
                Vector3 position = new Vector3(-1.5f, 0, -tambo * 20f);
                CreateBeat(BeatRight, position, Board);
            }

            foreach (string cym in cymbal)
            {
                float cymb = float.Parse(cym);
                Vector3 position = new Vector3(0f, 0, -cymb * 20f);
                CreateBeat(BeatCenter, position, Board);

            }

            foreach (string poc in pocpoc)
            {
                float pocpo = float.Parse(poc);
                Vector3 position = new Vector3(1.5f, 0, -pocpo * 20f);
                CreateBeat(BeatLeft, position, Board);

            }

        }
        else
        {
            Debug.LogError("TextAsset non assigné.");
        }
    }

    private void CreateBeat(GameObject prefab,Vector3 position, GameObject parent)
    {
        GameObject beat = Instantiate(prefab, position, Quaternion.identity);
        beat.transform.parent = parent.transform;
    }

    private struct CSVDatas 
    {
        public string column1;
        public string column2;
        public string column3;
    }
    private List<CSVDatas> ParserCSVContenu(string contenuCSV)
    {
        List<CSVDatas> donnees = new List<CSVDatas>();

        string[] lignes = contenuCSV.Split('\n');

        foreach (string ligne in lignes)
        {

            if (string.IsNullOrEmpty(ligne.Trim()))
                continue;

            string[] colonnes = ligne.Split(';');

            CSVDatas nouvelleLigne = new CSVDatas();

            nouvelleLigne.column1 = colonnes[0].Trim();
            nouvelleLigne.column2 = colonnes[1].Trim();
            nouvelleLigne.column3 = colonnes[2].Trim();

            donnees.Add(nouvelleLigne);
        }

        return donnees;
    }

   
}
