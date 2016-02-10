using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

namespace Interface
{
    public class AnimateScript : MonoBehaviour
    {
        public string animation;

        // Use this for initialization
        public void Start()
        {
            interactiveItem = gameObject.GetComponent<VRInteractiveItem>();
            if (interactiveItem == null)
            {
                Debug.LogError("Could not find VR interactive item script - does this object have it?");
                return;
            }

            animator = gameObject.GetComponent<Animator>();
            if (animator == null)
            {
                Debug.LogError("Could not find animator component - does this object have it?");
                return;
            }

            interactiveItem.OnTouchTrigger += Animate;
            interactiveItem.OnTouchTriggerStop += StopAnimating;        
        }

        public void Animate()
        {
            if (animator == null)
                return;
            animator.SetBool(animation, true);
        }

        public void StopAnimating()
        {
            if (animator == null)
                return;
            animator.SetBool(animation, false);
        }

        private VRInteractiveItem interactiveItem;
        private Animator animator;
    }
}