using UnityEngine;
using System.Collections;

namespace VRStandardAssets.Utils
{
    public class VRMotionInteractive : MonoBehaviour
    {
        public int playerId;
        public int controllerId;

        private VRInteractiveItem currentInteractible;
        private bool triggered;

        public void Update()
        {
            if (currentInteractible == null)
                return;
            var buttonState = PS4Util.Move.currentButtonStates(playerId, controllerId);
            if (!triggered && buttonState.digitalButtons[PS4Util.Move.Button.BACK])
            {
                currentInteractible.TouchTrigger();
                triggered = true;
            }
            else if (triggered && !buttonState.digitalButtons[PS4Util.Move.Button.BACK])
            {
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
        }
    }
}