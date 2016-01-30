using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class ClickScript : MonoBehaviour {

    public bool testActivate;
    public Jam.Actions.ActionBase actionToExecute;

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
	
	}

    public void OnActivate()
    {
        if (actionToExecute == null)
        {
            return;
        }
        actionToExecute.action.execute = true;
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
