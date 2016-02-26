using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class ClickScript : MonoBehaviour {

    public bool testActivate;
    public Jam.Actions.ActionBase actionToExecute;
    public bool playAudio = true;

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

        findActionToExecute();

        if (actionToExecute == null)
        {
            Debug.LogError("Could not find action to execute script - does this object have it? "+gameObject.name);
            return;
        }

        interactiveItem.OnClick += OnActivate;
        interactiveItem.OnUp += OnActivate;
        interactiveItem.OnTouchTrigger += OnActivate;

        audio = gameObject.GetComponent<AudioSource>();
	}

    private void findActionToExecute()
    {
        if (actionToExecute != null) return;

        actionToExecute = gameObject.GetComponent<Jam.Actions.ActionBase>();
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
