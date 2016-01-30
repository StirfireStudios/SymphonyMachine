using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class VRSetup : MonoBehaviour {

    [SerializeField]
    private float GearVRRenderScale = 1.0f;
    [SerializeField]
    private float PCRenderScale = 1.5f;

	// Use this for initialization
	public void Start ()
    {
#if UNITY_ANDROID
        removeObjectsInLayer("GearVR Disable");
        disableBloom();
#endif
        Camera camera = gameObject.GetComponent<Camera>();
        camera.clearFlags = CameraClearFlags.Depth;
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
		    VRSettings.loadedDevice = VRDeviceType.Morpheus;
#endif
            vrSettingsDone = true;
        }
	}

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
