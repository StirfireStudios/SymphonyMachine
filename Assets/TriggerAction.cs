using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class TriggerAction : MonoBehaviour {

    public RotateAction triggerable;
    public Direction directionToSend = Direction.forward;
    public enum Direction { forward, backward }
    public bool playAudio = true;

    private AudioSource audio;
    private RealSpace3D.RealSpace3D_AudioSource audio3d;

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

        interactiveItem.OnTouchTrigger += Trigger;

        audio = gameObject.GetComponent<AudioSource>();
        audio3d = gameObject.GetComponent<RealSpace3D.RealSpace3D_AudioSource>();
    }

    public void Trigger()
    {
        if (directionToSend == Direction.forward)
        {
            triggerable.OnTriggerRotateLeft();
        }
        else
        {
            triggerable.OnTriggerRotateRight();
        }

        if (audio != null && playAudio)
        {
            audio.Play();
        }

        if (audio3d != null && playAudio)
        {
            audio3d.rs3d_PlaySound();
        }
    }

}
