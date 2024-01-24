using DG.Tweening;
using loader;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Track
{
    public class TrackManager : MonoBehaviour
    {
        /// <summary>
        /// Track speed in meter per second
        /// </summary>
        [SerializeField, Tooltip("track speed in meter per second")] float trackSpeed = 10f;


        public void LaunchTrack(float trackLenght)
        {
            float duration = trackLenght / 10;
            transform.DOMove(Vector3.forward * trackLenght, duration);
        }
    }
}

