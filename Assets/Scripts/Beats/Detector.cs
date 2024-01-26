using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace gameplay
{
    public class Detector : MonoBehaviour
    {
        [SerializeField] E_BeatState state;
        [SerializeField] LayerMask layerMask;

        private void OnTriggerEnter(Collider other)
        {
            if ((layerMask.value & (1 << other.transform.gameObject.layer)) > 0)
            {
                other.GetComponent<Beat>().SetState(state);
            }
        }
    }
}

