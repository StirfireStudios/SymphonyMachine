using UnityEngine;
using System.Collections.Generic;

namespace VRStandardAssets.Utils
{
    public class VRMotionInteractive : MonoBehaviour
    {
        public int playerId;
        public int controllerId;

        private VRInteractiveItem[] selfInteractible;
        private VRInteractiveItem currentInteractible;
        private bool triggered;

        public void Start()
        {
            selfInteractible = gameObject.GetComponentsInChildren<VRInteractiveItem>();
        }

        public void Update()
        {
            if (currentInteractible == null)
            {
                return;
            }
            var buttonState = PS4Util.Move.currentButtonStates(playerId, controllerId);
            if (!triggered && buttonState.digitalButtons[PS4Util.Move.Button.BACK])
            {
                currentInteractible.TouchTrigger();
                for (int i = 0; i < selfInteractible.Length; i++)
                {
                    selfInteractible[i].TouchTrigger();
                }
                triggered = true;
            }
            else if (triggered && !buttonState.digitalButtons[PS4Util.Move.Button.BACK])
            {
                currentInteractible.TouchTriggerStop();
                for (int i = 0; i < selfInteractible.Length; i++)
                {
                    selfInteractible[i].TouchTriggerStop();
                }
                triggered = false;
            }
        }
        
        public void OnTriggerEnter(Collider other)
        {
            VRInteractiveItem interactible = other.GetComponent<VRInteractiveItem>();
            if (interactible == null)
            {
                return;
            }
            currentInteractible = interactible;
            interactible.Touch();
            for (int i = 0; i < selfInteractible.Length; i++)
            {
                selfInteractible[i].Touch();
            }            
        }

        public void OnTriggerExit(Collider other)
        {
            VRInteractiveItem interactible = other.GetComponent<VRInteractiveItem>();
            if (interactible == null)
            {
                return;
            }
            if (currentInteractible == interactible)
            {
                currentInteractible = null;
            }
            interactible.Untouch();
            for (int i = 0; i < selfInteractible.Length; i++)
            {
                selfInteractible[i].Untouch();
            }
        }
    }
}