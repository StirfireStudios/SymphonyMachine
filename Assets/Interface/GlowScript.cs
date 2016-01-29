using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

namespace Interface
{
    public class GlowScript : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            interactiveItem = gameObject.GetComponent<VRInteractiveItem>();
            if (interactiveItem == null)
            {
                Debug.LogError("Could not find VR interactive item script - does this object have it?");
                return;
            }
        }

        void Update()
        {
            if (interactiveItem == null)
            {
                return;
            }

            if (interactiveItem.IsOver)
            {

            }
            else
            {
            }
        }

        private VRInteractiveItem interactiveItem;
    }
}