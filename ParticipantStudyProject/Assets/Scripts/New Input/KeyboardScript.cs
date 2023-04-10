using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardScript : MonoBehaviour
{
    // There's benefit to wrapping these here just so we can see both the differences between wasPressed isPressed
    // But also provide a layer of abstraction to all input allowing us to move to third party systems like Rewired
    // 
    public static bool Was_R_PressedThisFrame()
    {
        return Keyboard.current.rKey.wasPressedThisFrame;
    }
    public static bool Was_Delete_PressedThisFrame()
    {
        return Keyboard.current.deleteKey.wasPressedThisFrame;
    }
    public static bool Was_F12_PressedThisFrame()
    {
        return Keyboard.current.f12Key.wasPressedThisFrame;
    }
    public static bool Was_Space_PressedThisFrame()
    {
        return Keyboard.current.spaceKey.wasPressedThisFrame;
    }
    public static bool Is_A_Pressed()
    {
        return Keyboard.current.aKey.isPressed;
    }
    public static bool Is_B_Pressed()
    {
        return Keyboard.current.bKey.isPressed;
    }
    public static bool Is_D_Pressed()
    {
        return Keyboard.current.dKey.isPressed;
    }
    public static bool Was_D_PressedThisFrame()
    {
        return Keyboard.current.dKey.wasPressedThisFrame;
    }
    public static bool Is_S_Pressed()
    {
        return Keyboard.current.sKey.isPressed;
    }
    public static bool Is_W_Pressed()
    {
        return Keyboard.current.wKey.isPressed;
    }
    public static bool Is_LeftShift_Pressed()
    {
        return Keyboard.current.leftShiftKey.isPressed;
    }
    public static bool Is_F1_Pressed()
    {
        return Keyboard.current.f1Key.isPressed;
    }
    public static bool Was_F1_PressedThisFrame()
    {
        return Keyboard.current.f1Key.wasPressedThisFrame;
    } 
    public static bool Was_F1_ReleasedThisFrame()
    {
        return Keyboard.current.f1Key.wasReleasedThisFrame;
    }
}
