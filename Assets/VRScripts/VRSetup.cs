using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class VRSetup : MonoBehaviour {

    [SerializeField]
    private float GearVRRenderScale = 1.0f;
    [SerializeField]
    private float PCRenderScale = 1.5f;
    [SerializeField]
    private GameObject MotionControlRoot = null;
    [SerializeField]
    private GameObject PlayerRoot = null;

	// Use this for initialization
	public void Start ()
    {
#if UNITY_ANDROID
        removeObjectsInLayer("GearVR Disable");
        disableBloom();
#endif
        Camera camera = gameObject.GetComponent<Camera>();
        camera.clearFlags = CameraClearFlags.Depth;
        removeObjectsInLayer("PS4 Only");

        var motionControlActive = false;

#if UNITY_PS4 && !UNITY_EDITOR
        motionControlActive = true;

#endif

        //if ((MotionControlRoot != null) && (PlayerRoot != null) && motionControlActive)
        if (true)
        {
            UnityEngine.Debug.Log("Translating player to motion control root");
            PlayerRoot.transform.localPosition = MotionControlRoot.transform.localPosition;
            VRStandardAssets.Utils.VREyeRaycaster raycaster = PlayerRoot.GetComponentInChildren<VRStandardAssets.Utils.VREyeRaycaster>();
            if (raycaster != null)
            {
                raycaster.enabled = false;
            }
        }
    }

	// Update is called once per frame
	public void Update ()
    {
        if (!vrSettingsDone)
        {
#if !UNITY_ANDROID
            VRSettings.renderScale = PCRenderScale;
#else
            VRSettings.renderScale = GearVRRenderScale;
#endif

#if UNITY_PS4 && !UNITY_EDITOR
            VRSettings.renderScale = 1.4f;
		    VRSettings.loadedDevice = VRDeviceType.Morpheus;
#endif
            vrSettingsDone = true;
        }

        if (Input.GetButtonUp("Fire2"))
        {
            Debug.Log("RECENTER!");
            InputTracking.Recenter();
        }
    }

#if UNITY_PS4 && !UNITY_EDITOR
    void OnSystemServiceEvent(UnityEngine.PS4.Utility.sceSystemServiceEventType eventType)
    {
        if(eventType == UnityEngine.PS4.Utility.sceSystemServiceEventType.RESET_VR_POSITION)
            InputTracking.Recenter();
    }
#endif

    private void disableBloom()
    {
        UnityStandardAssets.ImageEffects.BloomOptimized bloomEffect = gameObject.GetComponent<UnityStandardAssets.ImageEffects.BloomOptimized>();
        bloomEffect.enabled = false;
    }

    private GameObject[] findObjectsInLayer(string layer)
    {
        int layerIndex = LayerMask.NameToLayer(layer);
        if (layerIndex == -1)
        {
            Debug.Log("Could not find layer '" + layer + "'");
            return new GameObject[0];
        }
        GameObject[] objectArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        System.Collections.Generic.List<GameObject> layerList = new System.Collections.Generic.List<GameObject>();
        for (int i = 0; i < objectArray.Length; i++)
        {
            if (objectArray[i].layer == layerIndex)
            {
                layerList.Add(objectArray[i]);
            }
        }

        return layerList.ToArray() as GameObject[];
    }

    private void removeObjectsInLayer(string layer)
    {
        GameObject[] objects = findObjectsInLayer(layer);
        for (int i = 0; i < objects.Length; i++)
        {
            GameObject.Destroy(objects[i]);
        }
    }

    private bool vrSettingsDone = false;
}
