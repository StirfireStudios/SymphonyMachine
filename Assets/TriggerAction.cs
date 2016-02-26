using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class TriggerAction : MonoBehaviour {

    public RotateAction triggerable;
    public Direction directionToSend = Direction.forward;
    public enum Direction { forward, backward }

    public void Start()
    {        
        if (triggerable == null)
        {
            Debug.Log("No triggerable set, bailing");
            return;
        }

        var interactiveItem = gameObject.GetComponent<VRInteractiveItem>();
        if (interactiveItem == null)
        {
            Debug.LogError("Could not find VR interactive item script - does this object have it?");
            return;
        }

        if (directionToSend == Direction.forward)
        {
            interactiveItem.OnTouchTrigger += triggerable.OnTriggerRotateLeft;
        }
        else
        {
            interactiveItem.OnTouchTrigger += triggerable.OnTriggerRotateRight;
        }
    }

}
