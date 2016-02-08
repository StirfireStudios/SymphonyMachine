using UnityEngine;
using System.Collections;

namespace VRStandardAssets.Utils
{
    public class VRMotionInteractive : MonoBehaviour
    {
        public void OnTriggerEnter(Collider other)
        {
            VRInteractiveItem interactible = other.GetComponent<VRInteractiveItem>();
            if (interactible == null)
            {
                return;
            }
            interactible.Touch();
            
        }

        public void OnTriggerExit(Collider other)
        {
            VRInteractiveItem interactible = other.GetComponent<VRInteractiveItem>();
            if (interactible == null)
            {
                return;
            }
            interactible.Untouch();
        }
    }
}