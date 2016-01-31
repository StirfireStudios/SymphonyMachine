using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class ClickScript : MonoBehaviour {

    public bool testActivate;
    public Jam.Actions.ActionBase actionToExecute;

    private AudioSource audio;

	// Use this for initialization
	public void Start () 
    {
        VRInteractiveItem interactiveItem = gameObject.GetComponent<VRInteractiveItem>();
        if (interactiveItem == null)
        {
            Debug.LogError("Could not find VR interactive item script - does this object have it?");
            return;
        }

        if (actionToExecute == null)
        {
            Debug.LogError("Could not find action to execute script - does this object have it?");
            return;
        }

        interactiveItem.OnClick += OnActivate;
        interactiveItem.OnUp += OnActivate;

        audio = gameObject.GetComponent<AudioSource>();
	}

    public void OnActivate()
    {
        if (actionToExecute == null)
        {
            return;
        }
        actionToExecute.action.execute = true;

        if (audio != null)
        {
            audio.Play();
        }
    }

    public void Update()
    {
        if (testActivate)
        {
            OnActivate();
            testActivate = false;
        }
    }
}
