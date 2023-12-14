using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace loader
{
    [CreateAssetMenu(menuName = "loader/data")]
    public class LoaderData : ScriptableObject
    {
        [SerializeField, TextArea, Tooltip("the name of the song")] private string resourceName;
        [SerializeField, Tooltip("the icon of the song")] private Sprite sprite;

        public string ResourceName => resourceName;
        public Sprite Sprite => sprite;
    }
}

