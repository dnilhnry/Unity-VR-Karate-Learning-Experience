using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.XR;
using UnityEngine.XR.Management;

[DefaultExecutionOrder(-100)]
public class VRScript : MonoBehaviour
{
    [SerializeField]
    bool isVR = true;

    [SerializeField]
    bool isRoomScale = false;

    [SerializeField]
    GameViewRenderMode gameViewRenderMode = GameViewRenderMode.LeftEye;

    [SerializeField]
    float EyeHeightForNonVR = 1.6f;

    public static VRScript instance;

    public Transform player;
    public static bool isLeft;
    public static bool isRight;

    private Transform trackedHeadPose;
    private Transform trackedLeftController;
    private Transform trackedRightController;
    private Transform roomOffset;
    private InputSystemUIInputModule [] inputSystem;
     
    public class InputController
    {
        public UnityEngine.XR.InputDevice device;
        public bool isPresent;
    }

    static InputController[] controllerInput = new InputController[2];

    public static bool IsVR()
    {
        return instance.isVR;
    }
    public static bool NoVR()
    {
        return !instance.isVR;
    }
    public static bool IsVRAndRoomScale()
    {
        if (instance.isRoomScale && instance.isVR)
        {
            return true;
        }
        return false;
    }

    VRScript()
    {
        instance = this;
        controllerInput[0] = new InputController();
        controllerInput[1] = new InputController();
    }

    void Awake()
    {
        roomOffset = TransformScript.FindAlways("RoomOffset");
        trackedHeadPose = TransformScript.FindAlways("Main Camera");
        trackedLeftController = TransformScript.FindAlways("TrackedLeftController");
        trackedRightController = TransformScript.FindAlways("TrackedRightController");

        // Look at the SerializeField variable exposed in the Editor.
        // Turn VR off if we are not using VR 
        if (!isVR)
        {
            Debug.Log("XRGeneralSettings has deinitialized loader");
            XRGeneralSettings.Instance.Manager.StopSubsystems();
            XRGeneralSettings.Instance.Manager.DeinitializeLoader();            
        }

        // Find the input systems
        GameObject eventSystem1 = TransformScript.FindAlways("EventSystemVR").gameObject;
        GameObject eventSystem2 = TransformScript.FindAlways("EventSystemNoVR").gameObject;

        // Maybe we haven't got VR. Turn off our flag.
        if (!XRGeneralSettings.Instance.Manager.isInitializationComplete)
        {
            eventSystem1.SetActive(false);
            eventSystem2.SetActive(true);

            isVR = false;

            roomOffset.transform.localPosition = new Vector3(0, EyeHeightForNonVR, 0);
        }
        else
        {
            eventSystem1.SetActive(true);
            eventSystem2.SetActive(false);

            // Set the appropriate game view render mode to be able to see VR on the desktop
            XRSettings.gameViewRenderMode = gameViewRenderMode;
        }
    }

    public static InputController GetInput(HandScript.ControllerType hand)
    {
        return controllerInput[(int)hand];
    }

    private static UnityEngine.XR.InputDevice GetDevice(HandScript.ControllerType hand)
    {
        return GetInput(hand).device;
    }

    public static bool IsTrigger(HandScript.ControllerType hand)
    {
        UnityEngine.XR.InputDevice device = GetDevice(hand);

        float controlDown;
        if ((device != null) && device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.trigger, out controlDown))
        {
            return controlDown > 0.1f;            
        }
        return false;
    }

    void Update()
    {
        var values = EnumUtil.GetValues<HandScript.ControllerType>();
        foreach (HandScript.ControllerType hand in values)
        {
            InputController input = controllerInput[(int)hand];
            input.isPresent = false;
        }

        // Update the XR input devices
        List<UnityEngine.XR.InputDevice> collection = new List<UnityEngine.XR.InputDevice>();
        InputDevices.GetDevices(collection);
        foreach (UnityEngine.XR.InputDevice device in collection)
        {
            // Is it a hand held controller
            if ((device.characteristics & InputDeviceCharacteristics.Controller) == 0)
            {
                continue;
            }
            if ((device.characteristics & InputDeviceCharacteristics.HeldInHand) == 0)
            {
                continue;
            }
            
            InputController input = null;

            if ((device.characteristics & InputDeviceCharacteristics.Left) != 0)
            {
                input = controllerInput[(int)HandScript.ControllerType.LeftHand];
                input.isPresent = true;
                input.device = device;
            }
            if ((device.characteristics & InputDeviceCharacteristics.Right) != 0)
            {
                input = controllerInput[(int)HandScript.ControllerType.RightHand];
                input.isPresent = true;
                input.device = device;
            }        
        }

        // Handle toggling the different XR Mirror render modes
        if (KeyboardScript.Was_F12_PressedThisFrame() )
        {
            if (XRSettings.gameViewRenderMode == GameViewRenderMode.None)
            {
                XRSettings.gameViewRenderMode = GameViewRenderMode.LeftEye;
            }
            else
            {
                XRSettings.gameViewRenderMode = GameViewRenderMode.None;
            }
        }
    }

    void OnValidate()
    {
        // This is only ever called in the editor when a serialized field is changed
        if (isVR)
        {
            XRSettings.gameViewRenderMode = gameViewRenderMode;
        }
    }
}
