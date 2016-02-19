using UnityEngine;
using System.Collections.Generic;

namespace VRStandardAssets.Utils
{
    public class VRMotionInteractive : MonoBehaviour
    {
        public int playerId;
        public int controllerId;

        public SteamVR_TrackedObject viveTracker;
        private VRInteractiveItem[] selfInteractible;
        private VRInteractiveItem currentInteractible;
        private bool triggered;
        private Valve.VR.VRControllerState_t controllerState;

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
            var interacting = isInteracting();

            if (!triggered && interacting)
            {
                currentInteractible.TouchTrigger();
                for (int i = 0; i < selfInteractible.Length; i++)
                {
                    selfInteractible[i].TouchTrigger();
                }
                triggered = true;
            }
            else if (triggered && !interacting)
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
            if (other.GetComponent<VRMotionInteractive>() != null)
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
            if (other.GetComponent<VRMotionInteractive>() != null)
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

        private bool isInteracting()
        {
#if UNITY_PS4
            var buttonState = PS4Util.Move.currentButtonStates(playerId, controllerId);
            return buttonState.digitalButtons[PS4Util.Move.Button.BACK];
#else
            if (viveTracker == null)
            {
                return false;
            }
            SteamVR.instance.hmd.GetControllerState((uint)viveTracker.index, ref controllerState);
            ulong trigger = controllerState.ulButtonPressed & (1UL << ((int)Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger));
            return trigger > 0L;

#endif
        }
    }
}