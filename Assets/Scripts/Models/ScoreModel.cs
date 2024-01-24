using Realms;
using System;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class ScoreModel : RealmObject
    {
        [Realms.PrimaryKey]
        public int scoreId { get; set; }
        public string playerName { get; set; }
        public float score { get; set; }

        public ScoreModel()
        {
        }

        public ScoreModel(int scoreId, string playerName, float score, byte[] level_imageBytes)
        {
            this.scoreId = scoreId;
            this.playerName = playerName;
            this.score = score;
            this.level_imageBytes = level_imageBytes;
        }



        //Si je veux convertir Un Sprite en byte array je dois => Sprite to Texture2D to byte[]
        private byte[] level_imageBytes { get; set; }

        [Ignore] // Ignorer sauvegarde Realm
        public Sprite level_image
        {
            get
            {
                if (level_imageBytes != null && level_imageBytes.Length > 0)
                {
                    return ConvertByteArrayToSprite(level_imageBytes);
                }
                return null;
            }
        }

        private Sprite ConvertByteArrayToSprite(byte[] byteArray)
        {
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(byteArray);
            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        }

        public void SetLevelImage(Sprite sprite)
        {
            level_imageBytes = ConvertSpriteToByteArray(sprite);
        }

        private byte[] ConvertSpriteToByteArray(Sprite sprite)
        {
            Texture2D texture = sprite.texture;
            return texture.EncodeToPNG();
        }
    }
}
