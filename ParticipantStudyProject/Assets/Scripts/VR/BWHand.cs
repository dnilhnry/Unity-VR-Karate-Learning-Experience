using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWHand : MonoBehaviour
{
    public enum BWControllerType
    {
        LeftHand,
        RightHand,
    };

    // For copying the correct pose
    [SerializeField]
    BWControllerType handId;
    
    void Start()
    {
        if (BWVR.IsVR() == false)
        {
            gameObject.SetActive(false);
            return;
        }
    }
}
