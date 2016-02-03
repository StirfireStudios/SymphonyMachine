using UnityEngine;
using UnityEngine.VR;

public class RotateWithPlayer : MonoBehaviour
{
    public Camera target;

    public bool disabled = false;
    public void Update()
    {
        if (!disabled && !VRDevice.isPresent)
        {
            var rp = Quaternion.LookRotation(new Vector3(0f, 1f, 0f), new Vector3(1f, 0f, 0f));
            var cameraAngleLeftRight = target.transform.rotation.eulerAngles.y;
            rp *= Quaternion.AngleAxis(-cameraAngleLeftRight, new Vector3(0f, 0f, 1f));
            gameObject.transform.rotation = rp;
        }
    }
}
