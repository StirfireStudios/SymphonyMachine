using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

namespace Interface
{
    public class GlowScript : MonoBehaviour
    {
        // This should probably come from some sort of manager...
        public static float glowTransitionTime = 1.0f;

        public Direction testTransitionDirection = Direction.none; 

        // Use this for initialization
        public void Start()
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

            interactiveItem.OnOver += OnGaze;
            interactiveItem.OnOut += OnGazeLeave;
            glowAmount = itemMaterial.GetFloat("_GlowAmount");
        }

        public void Update()
        {
            if (interactiveItem == null || itemMaterial == null)
            {
                return;
            }

            if (testTransitionDirection != Direction.none)
            {
                transitionDirectionTo(testTransitionDirection);
                testTransitionDirection = Direction.none;
            }

            if (transitionDirection == Direction.none)
            {
                return;
            }

            normalizedTime = (transitionEnd - Time.time) / glowTransitionTime;

            if (transitionDirection == Direction.glow)
            {
                glowAmount = Mathf.Lerp(1.0f, 0.0f, normalizedTime);
                if (glowAmount > 0.99f)
                {
                    transitionDirection = Direction.none;
                }
            }
            else
            {
                glowAmount = Mathf.Lerp(0.0f, 1.0f, normalizedTime);
                if (glowAmount < 0.01f)
                {
                    transitionDirection = Direction.none;
                }
            }

            if (transitionDirection == Direction.none)
            {
                Debug.Log("Transition Complete");
                transitionEnd = -1.0f;
            }

            itemMaterial.SetFloat("_GlowAmount", glowAmount);
        }

        public void OnGaze()
        {
            transitionDirectionTo(Direction.glow);
        }

        public void OnGazeLeave()
        {
            transitionDirectionTo(Direction.fade);
        }

        private void transitionDirectionTo(Direction newDirection)
        {
            if (transitionDirection != newDirection)
            {
                if (transitionEnd < 0.0f)
                {
                    transitionEnd = Time.time + glowTransitionTime;
                }
                else
                {
                    normalizedTime = (transitionEnd - Time.time) / glowTransitionTime;
                    normalizedTime = 1.0f - normalizedTime;
                    transitionEnd = Time.time + glowTransitionTime * normalizedTime;                    
                }
                transitionDirection = newDirection;
            }

        }

        public enum Direction { glow, fade, none };
        private Direction transitionDirection = Direction.none;
        private float normalizedTime;
        private float transitionEnd = -1.0f;
        private float glowAmount;
        private VRInteractiveItem interactiveItem;
        private Material itemMaterial;
    }
}