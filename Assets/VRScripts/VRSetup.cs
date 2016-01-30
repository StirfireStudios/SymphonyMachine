using UnityEngine;
using System.Collections;
using UnityEngine.VR;

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
#if !UNITY_ANDROID
            VRSettings.renderScale = PCRenderScale;
#else
            VRSettings.renderScale = GearVRRenderScale;
#endif

#if UNITY_PS4 && !UNITY_EDITOR
		    VRSettings.loadedDevice = VRDeviceType.Morpheus;
#endif
            vrSettingsDone = true;
        }
	}

    private bool vrSettingsDone = false;
}
