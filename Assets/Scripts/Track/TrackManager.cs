using DG.Tweening;
using loader;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Track
{
    public class TrackManager : MonoBehaviour
    {
        bool canMove;

        public void LaunchTrack()
        {
            canMove = true;
        }

        private void Update()
        {
            if (canMove)
            {
                Vector3 motionAmount = transform.position;
                motionAmount.z += Time.deltaTime * 10;
                transform.position = motionAmount;
            }
        }
    }
}

