using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Track
{
    public class TrackManager : MonoBehaviour
    {
        [SerializeField] private FloorHandler floorHandler;
        [SerializeField] private TrackLoader loader;
        /// <summary>
        /// Track speed in meter per second
        /// </summary>
        [SerializeField, Tooltip("track speed in meter per second")] float trackSpeed = 10f;
        /// <summary>
        /// In meters
        /// </summary>
        [SerializeField] float trackLength = 1500;

        private void Awake()
        {
            if (floorHandler == null) floorHandler = GetComponent<FloorHandler>();
        }

        void Start()
        {
            transform.DOMove(Vector3.forward * trackLength, trackLength / trackSpeed);
        }
    }
}

