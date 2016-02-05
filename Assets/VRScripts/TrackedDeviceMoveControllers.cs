using UnityEngine;
using UnityEngine.VR;
using System.Collections;
#if UNITY_PS4
using UnityEngine.PS4;
using UnityEngine.PS4.VR;
#endif

public class TrackedDeviceMoveControllers : MonoBehaviour {
	public Transform primaryController;
	public Transform secondaryController;
#if UNITY_PS4
	private int m_primaryHandle = -1;
	private int m_secondaryHandle = -1;
	private Vector3 primaryPosition = Vector3.zero;
	private Quaternion primaryOrientation = Quaternion.identity;
	private Vector3 secondaryPosition = Vector3.zero;
	private Quaternion secondaryOrientation = Quaternion.identity;

    public enum Button { BACK = 0, MIDDLE, START, TRIANGLE, CIRCLE, CROSS, SQUARE, NONE};
    private static readonly int[] BitmaskPosition = { 2, 4, 8, 16, 32, 64, 128, 0 };
    private bool[,] buttonIsDown = new bool[2,7];

	IEnumerator Start()
	{
		if(!primaryController || !secondaryController || !primaryController.gameObject.activeSelf || !secondaryController.gameObject.activeSelf)
		{
			Debug.LogWarning("A controller is either null or inactive!");
			this.enabled = false;
		}

		// Keep waiting until we have a VR Device available
		while(!UnityEngine.VR.VRDevice.isPresent)
			yield return new WaitForSeconds(1.0f);

		// Make sure the device we now have is PlayStation VR
        if (VRSettings.loadedDevice != VRDeviceType.Morpheus)
		{
			Debug.LogWarning("Tracking only works for PS4!");
			this.enabled = false;
		}
		else
		{
			ResetControllerTracking();
		}
	}

    private bool currentButtonState(int controller, int bitmask, Button button)
    {
        var buttonIndex = (int)button;
        return (bitmask & BitmaskPosition[buttonIndex]) != 0;
    }

    private void checkButtonState(int controller, int newBitmask, Button button) 
    {
        var buttonIndex = (int)button;
        var newState = (newBitmask & BitmaskPosition[buttonIndex]) != 0;
        var currentState = buttonIsDown[controller,buttonIndex];
        var outputState = currentState;
        if (currentState && !newState)
        {
            UnityEngine.Debug.Log(button + " released");
            outputState = false;
        } else if (!currentState && newState)
        {
            UnityEngine.Debug.Log(button + " pressed");
            outputState = true;
        }

        buttonIsDown[controller,buttonIndex] = outputState;
    }

    public void Update()
	{
        if (UnityEngine.VR.VRDevice.isPresent && VRSettings.loadedDevice == VRDeviceType.Morpheus)
		{
            var primaryTrigger = UnityEngine.PS4.PS4Input.MoveGetAnalogButton(0, 0);
            var secondaryTrigger = UnityEngine.PS4.PS4Input.MoveGetAnalogButton(0, 1);
            var primaryButtons = UnityEngine.PS4.PS4Input.MoveGetButtons(0, 0);
            var secondaryButtons = UnityEngine.PS4.PS4Input.MoveGetButtons(0, 1);

/*            checkButtonState(0, primaryButtons, Button.BACK);
            checkButtonState(0, primaryButtons, Button.MIDDLE);
            checkButtonState(0, primaryButtons, Button.START);
            checkButtonState(0, primaryButtons, Button.TRIANGLE);
            checkButtonState(0, primaryButtons, Button.CIRCLE);
            checkButtonState(0, primaryButtons, Button.CROSS);
            checkButtonState(0, primaryButtons, Button.SQUARE);

            checkButtonState(1, secondaryButtons, Button.BACK);
            checkButtonState(1, secondaryButtons, Button.MIDDLE);
            checkButtonState(1, secondaryButtons, Button.START);
            checkButtonState(1, secondaryButtons, Button.TRIANGLE);
            checkButtonState(1, secondaryButtons, Button.CIRCLE);
            checkButtonState(1, secondaryButtons, Button.CROSS);
            checkButtonState(1, secondaryButtons, Button.SQUARE);*/


//            UnityEngine.Debug.Log("Primary Move: " + primaryTrigger + " ButtonMask: " + primaryButtons);
//            UnityEngine.Debug.Log("Secondary Move: " + secondaryTrigger + " ButtonMask: " + secondaryButtons);

//            UnityEngine.PS4.PS4Input.MoveSetVibration(0, 0, primaryTrigger);
//            UnityEngine.PS4.PS4Input.MoveSetVibration(0, 1, secondaryTrigger);

			// if both middle buttons are pressed, reset
            var middleController1 = currentButtonState(0, primaryButtons, Button.MIDDLE);
            var middleController2 = currentButtonState(1, primaryButtons, Button.MIDDLE);

			if(middleController1 && middleController2)
			{
				ResetControllerTracking();
			}

			// Perform tracking for the primary controller, if we've got a handle
			if(m_primaryHandle >= 0)
			{
				if( Tracker.GetTrackedDevicePosition(m_primaryHandle, out primaryPosition) == PlayStationVRResult.Ok )
					primaryController.localPosition = primaryPosition;

                if (Tracker.GetTrackedDeviceOrientation(m_primaryHandle, out primaryOrientation) == PlayStationVRResult.Ok)
					primaryController.localRotation = primaryOrientation;
			}

			// Perform tracking for the secondary controller, if we've got a handle
			if(secondaryController && m_secondaryHandle >= 0)
			{
                if (Tracker.GetTrackedDevicePosition(m_secondaryHandle, out secondaryPosition) == PlayStationVRResult.Ok)
					secondaryController.localPosition = secondaryPosition;

                if (Tracker.GetTrackedDeviceOrientation(m_secondaryHandle, out secondaryOrientation) == PlayStationVRResult.Ok)
					secondaryController.localRotation = secondaryOrientation;
			}
		}
	}

	// Unregister and re-register the controllers to reset them
	public void ResetControllerTracking()
	{
		UnregisterMoveControllers();
		RegisterMoveControllers();
	}

	// Register a Move device to track
	void RegisterMoveControllers()
	{
		int [] primaryHandles = new int[1];
		int [] secondaryHandles = new int[1];
		PS4Input.MoveGetUsersMoveHandles(1, primaryHandles, secondaryHandles);
		m_primaryHandle = primaryHandles[0];
		m_secondaryHandle = secondaryHandles[0];

		Tracker.RegisterTrackedDevice(PlayStationVRTrackedDevice.DeviceMove, primaryHandles[0], PlayStationVRTrackingType.Absolute);

		if(secondaryController)
            Tracker.RegisterTrackedDevice(PlayStationVRTrackedDevice.DeviceMove, secondaryHandles[0], PlayStationVRTrackingType.Absolute);
	}

	// Remove the registered devices from tracking and reset the transform
	void UnregisterMoveControllers()
	{
		int[] primaryHandles = new int[1];
		int[] secondaryHandles = new int[1];
		PS4Input.MoveGetUsersMoveHandles(1, primaryHandles, secondaryHandles);
		m_primaryHandle = -1;
		m_secondaryHandle = -1;

		Tracker.UnregisterTrackedDevice(primaryHandles[0]);
		primaryController.localPosition = Vector3.zero;
		primaryController.localRotation = Quaternion.identity;

		if(secondaryController)
		{
			Tracker.UnregisterTrackedDevice(secondaryHandles[0]);
			secondaryController.localPosition = Vector3.zero;
			secondaryController.localRotation = Quaternion.identity;
		}
	}
#endif
}
