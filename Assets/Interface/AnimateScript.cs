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

//            interactiveItem.OnOver += AddTouch;
//            interactiveItem.OnOut += SubTouch;
            interactiveItem.OnTouchTrigger += AddTouch;
            interactiveItem.OnTouchTriggerStop += SubTouch;        
        }

        public void AddTouch()
        {
            if (animator == null)
                return;
            animator.SetBool(animation, ++touches > 0);
        }

        public void SubTouch()
        {
            if (animator == null)
                return;
            animator.SetBool(animation, --touches > 0);
        }

        private VRInteractiveItem interactiveItem;
        private Animator animator;
        private int touches = 0;
    }
}