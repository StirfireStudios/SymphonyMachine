using UnityEngine;
using System.Collections;

public class VRSetup : MonoBehaviour {

    [SerializeField]
    private float GearVRRenderScale = 1.0f;
    [SerializeField]
    private float PCRenderScale = 1.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!vrSettingsDone)
        {
            UnityEngine.VR.VRSettings.renderScale = PCRenderScale;
            vrSettingsDone = true;
        }
	}

    private bool vrSettingsDone = false;
}
