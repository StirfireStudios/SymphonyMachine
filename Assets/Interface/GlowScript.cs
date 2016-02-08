using UnityEngine;
using System.Collections.Generic;
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

            Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();

            if (renderers.Length == 0)
            {
                Debug.LogError("Could not find Renderer for this item or it's children?");
                return;
            }

            List<Material> materials = new List<Material>();

            for (int i = 0; i < renderers.Length; i++)
            {
                if (renderers[i].material != null)
                {
                    materials.Add(renderers[i].material);
                }
            }

            if (materials.Count == 0)
            {
                Debug.LogError("Could not find Materials for this item or it's children?");
                return;
            }

            itemMaterials = materials.ToArray();

            interactiveItem.OnOver += GlowStart;
            interactiveItem.OnOut += GlowStop;
            interactiveItem.OnTouch += GlowStart;
            interactiveItem.OnUntouch += GlowStop;
        }

        public void Update()
        {
            if (interactiveItem == null || itemMaterials.Length == 0)
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

            for (int i = 0; i < itemMaterials.Length; i++)
            {
                itemMaterials[i].SetFloat("_GlowAmount", transitioner.updateValue());
            }
        }

        public void GlowStart()
        {
            transitioner.transitionDirectionTo(mapDirections(Direction.glow));
        }

        public void GlowStop()
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
        private Material[] itemMaterials = new Material[0];
    }
}