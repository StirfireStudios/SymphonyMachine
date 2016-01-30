using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

namespace Interface
{
    public class GlowScript : MonoBehaviour
    {
        // This should probably come from some sort of manager...
        public static float glowTransitionTime = 1.0f;
        public enum Direction { glow, fade, none };
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
            //transitioner.currentValue = itemMaterial.GetFloat("_GlowAmount");
        }

        public void Update()
        {
            if (interactiveItem == null || itemMaterial == null)
            {
                return;
            }

            transitioner.transitionTime = glowTransitionTime;

            if (testTransitionDirection != Direction.none)
            {
                transitioner.transitionDirectionTo(mapDirections(testTransitionDirection));
                testTransitionDirection = Direction.none;
            }

            if (mapStateDirections(transitioner.CurrentDirection) == Direction.none)
            {
                return;
            }

            itemMaterial.SetFloat("_GlowAmount", transitioner.updateValue());
        }

        public void OnGaze()
        {
            transitioner.transitionDirectionTo(mapDirections(Direction.glow));
        }

        public void OnGazeLeave()
        {
            transitioner.transitionDirectionTo(mapDirections(Direction.fade));
        }

        private StateTransitioner.Direction mapDirections(Direction direction)
        {
            switch (direction)
            {
                case Direction.glow:
                    return StateTransitioner.Direction.forward;
                case Direction.fade:
                    return StateTransitioner.Direction.backward;
                default:
                    return StateTransitioner.Direction.stopped;
            }
        }

        private Direction mapStateDirections(StateTransitioner.Direction direction)
        {
            switch (direction)
            {
                case StateTransitioner.Direction.forward:
                    return Direction.glow;
                case StateTransitioner.Direction.backward:
                    return Direction.fade;
                default:
                    return Direction.none;
            }
        }

        private StateTransitioner transitioner = new StateTransitioner();
        private VRInteractiveItem interactiveItem;
        private Material itemMaterial;
    }
}