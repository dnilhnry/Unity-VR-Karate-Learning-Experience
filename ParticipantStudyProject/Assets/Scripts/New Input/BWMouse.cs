using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWMouse : MonoBehaviour
{
    public static bool IsLeftButton()
    {
        if (Input.GetMouseButton(0) )
        {
            return true;
        }
        return false;
    }
    public static bool IsLeftButtonDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        }
        return false;
    }

    public static bool IsRightButton()
    {
        if (Input.GetMouseButton(1))
        {
            return true;
        }
        return false;
    }

    public static bool IsRightButtonDown()
    {
        if (Input.GetMouseButtonDown(1))
        {
            return true;
        }
        return false;
    }
    public static bool IsRightButtonUp()
    {
        if (Input.GetMouseButtonUp(1))
        {
            return true;
        }
        return false;
    }

    public static bool IsMiddleButton()
    {
        if (Input.GetMouseButton(2))
        {
            return true;
        }
        return false;
    }

    public static bool IsMiddleButtonDown()
    {
        if (Input.GetMouseButtonDown(2))
        {
            return true;
        }
        return false;
    }
    public static bool IsMiddleButtonUp()
    {
        if (Input.GetMouseButtonUp(2))
        {
            return true;
        }
        return false;
    }
}
