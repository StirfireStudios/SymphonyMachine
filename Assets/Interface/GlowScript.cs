using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

namespace Interface
{
    public class GlowScript : MonoBehaviour
    {
        // This should probably come from some sort of manager...
        private static float glowTransitionTime = 1.0f;

        // Use this for initialization
        void Start()
        {
            interactiveItem = gameObject.GetComponent<VRInteractiveItem>();
            if (interactiveItem == null)
            {
                Debug.LogError("Could not find VR interactive item script - does this object have it?");
                return;
            }

            Renderer renderer = gameObject.GetComponent<Renderer>();

            if (renderer == null)
            {
                Debug.LogError("Could not find Renderer for this item?");
                return;
            }

            itemMaterial = renderer.material;
            if (itemMaterial == null)
            {
                Debug.LogError("Could not find Material for this item?");
                return;
            }
        }

        void Update()
        {
            if (interactiveItem == null || itemMaterial == null)
            {
                return;
            }

            if (interactiveItem.IsOver && !glowState)
            {
                glowState = true;
                if (transitionStart < 0.0f)
                {
                    transitionStart = Time.time;
                }
            }
            else if (!interactiveItem.IsOver && glowState)
            {
                glowState = false;
                if (transitionStart < 0.0f)
                {
                    transitionStart = Time.time;
                }
            }

            if (glowState && glowAmount < 0.99f)
            {
                glowAmount = Mathf.Lerp(0.0f, 1.0f, Time.time - transitionStart);
            } else if (!glowState && glowAmount > 0.01f)
            {
                glowAmount = Mathf.Lerp(1.0f, 0.0f, Time.time - transitionStart);
            } else {
                transitionStart = -1.0f;
                return;
            }

            itemMaterial.SetFloat("_GlowAmount", glowAmount);
        }

        private float transitionStart;
        private bool glowState;
        private float glowAmount;
        private VRInteractiveItem interactiveItem;
        private Material itemMaterial;
    }
}