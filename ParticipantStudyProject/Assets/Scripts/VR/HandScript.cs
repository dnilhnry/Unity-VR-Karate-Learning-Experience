using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    public enum ControllerType
    {
        LeftHand,
        RightHand,
    };

    // For copying the correct pose
    [SerializeField] ControllerType handId;
    
    void Start()
    {
        if (VRScript.IsVR() == false)
        {
            gameObject.SetActive(false);
            return;
        }
    }
}
