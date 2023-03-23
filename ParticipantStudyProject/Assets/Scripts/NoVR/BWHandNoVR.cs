using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BWHandNoVR : MonoBehaviour
{
    // Fuctional
    Vector3 direction;
    Vector3 screenPos;

    // Start is called before the first frame update
    void Start()
    {
        if (BWVR.IsVR() == true)
        {
            gameObject.SetActive(false);
            return;
        }

        // Let's position the hand height at 1.8m * 2/3
        // The average person is 1.8m and a hand is 2/3 up (roughly)
        transform.localPosition = new Vector3( 0, 1.8f * 2.0f / 3.0f, 0);
    }

    public bool GetWorldDestinationFromMouseScreenPos(out Vector3 direction)
    {
        // Set the clip plane here to be 0.5m (a sort of arm length)
        // This will then tells us 
        screenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

        Vector3 point = Camera.main.ScreenToWorldPoint(screenPos);

        // Ensure the point is valid. The mouse may be offscreen
        if (point.y > 0)
        {
            direction = point - Camera.main.transform.position;
            direction = direction.normalized;

            float verticalFov = Camera.main.fieldOfView;
            float horizontalFov = Camera.main.fieldOfView * Camera.main.aspect;
            // direction.xy spans between -horizontalFov and horizontalFov
            // direction.y spans between -verticalFov and verticalFov 
            // 
            // if we want our mouse point to be able to go between 0 and 90 degrees we should scale y
            // 
            direction.y *= 3.0f;
            return true;
        }
        direction = Vector3.zero;
        return false;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
