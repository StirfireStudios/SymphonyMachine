using UnityEngine;
using System.Collections.Generic;

namespace VRStandardAssets.Utils
{
    public class VRMotionInteractive : MonoBehaviour
    {
        public int playerId;
        public int controllerId;

        public SteamVR_TrackedObject viveTracker;
        
        private List<VRInteractiveItem> touchingItems = new List<VRInteractiveItem>();
        private VRInteractiveItem lastInteracted = null;
        private VRInteractiveItem[] selfInteractible;
        private bool triggered;
        private Valve.VR.VRControllerState_t controllerState;

        public void Start()
        {
            selfInteractible = gameObject.GetComponentsInChildren<VRInteractiveItem>();
        }

        public void Update()
        {
            if (touchingItems.Count == 0)
            {
                return;
            }

            var currentInteractible = findCurrentInteractive();
            if (currentInteractible == null)
            {
                Debug.LogWarning("Current Interactible is null but we have touching items?");
                touchingItems.Clear();
                return;
            }
            
            if (currentInteractible != lastInteracted)
            {
                if (lastInteracted != null)
                {
                    lastInteracted.Untouch();
                }
                currentInteractible.Touch();
                lastInteracted = currentInteractible;
            }
            
            var triggering = controllerIsTriggering();

            if (!triggered && triggering)
            {
                currentInteractible.TouchTrigger();
                for (int i = 0; i < selfInteractible.Length; i++)
                {
                    selfInteractible[i].TouchTrigger();
                }
                triggered = true;
            }
            else if (triggered && !triggering)
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

            Debug.Log("Entering trigger: ");
            Debug.Log(other);

            if (touchingItems.Contains(interactible))
            {
                return;
            }

            touchingItems.Add(interactible);
            updateSelfInteractiveStates();
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

            Debug.Log("Exiting trigger: ");
            Debug.Log(other);

            if (!touchingItems.Contains(interactible))
            {
                return;
            }

            touchingItems.Remove(interactible);
            updateSelfInteractiveStates();
            if (touchingItems.Count == 0)
            {
                if (lastInteracted != null)
                {
                    lastInteracted.Untouch();
                    lastInteracted = null;
                }
            }
        }

        private void updateSelfInteractiveStates() 
        {
            bool activeItem = touchingItems.Count > 0;
            for (int i = 0; i < selfInteractible.Length; i++)
            {
                if (activeItem)
                    selfInteractible[i].Touch();
                else
                    selfInteractible[i].Untouch();
            } 
        }

        private VRInteractiveItem findCurrentInteractive()
        {
            var count = touchingItems.Count;
            if (count == 0)
            {
                return null;
            }

            if (count == 1)
            {
                return touchingItems[0];
            }

            var distance = 1000.0f;
            VRInteractiveItem closestItem = null;

            foreach (var interactive in touchingItems)
            {
                if (interactive == null)
                {
                    touchingItems.Remove(interactive);
                }
                else
                {
                    var itemDistance = (interactive.transform.position - this.transform.position).sqrMagnitude;
                    if (itemDistance < distance)
                    {
                        closestItem = interactive;
                        distance = itemDistance;
                    }
                }
            }

            return closestItem;
        }

        private bool controllerIsTriggering()
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