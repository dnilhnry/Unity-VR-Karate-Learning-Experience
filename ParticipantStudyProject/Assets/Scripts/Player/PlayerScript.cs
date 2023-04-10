using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Transform mainCam;
    private Transform head;

    [SerializeField]
    float MovementSpeed = 1.0f;

    [SerializeField]
    float MouseRotationSpeed = 10.0f;

    // Private fields
    [SerializeField]
    private Vector3 mouseRotation;          // this is summed to allow user to rotate with the mouse

    private Vector3 lastMousePosition;      // we use this to allow the user to touch and relase on the screen
    private float rightStickYaw = 0;        // these are summed to allow user to rotate with the stick
    private float rightStickPitch = 0;      // these are summed to allow user to rotate with the stick
    private float snapLook = 0;

    // For keyboard targeting of a dettination
    Vector3 destination;

    public void LoadPrefs()
    {
        mouseRotation.x = PlayerPrefs.GetFloat("mouseRotation.x");
        mouseRotation.y = PlayerPrefs.GetFloat("mouseRotation.y");
        snapLook = PlayerPrefs.GetFloat("snapLook");

        Vector3 camPos = new Vector3();
        camPos.x = PlayerPrefs.GetFloat("camPos.x", 0);
        camPos.y = PlayerPrefs.GetFloat("camPos.y", 0);
        camPos.z = PlayerPrefs.GetFloat("camPos.z", 0);
        transform.position = camPos;
    }

    public void SavePrefs()
    {
        PlayerPrefs.SetFloat("mouseRotation.x", mouseRotation.x);
        PlayerPrefs.SetFloat("mouseRotation.y", mouseRotation.y);
        PlayerPrefs.SetFloat("snapLook", snapLook);

        Vector3 camPos = transform.position;
        PlayerPrefs.SetFloat("camPos.x", camPos.x);
        PlayerPrefs.SetFloat("camPos.y", camPos.y);
        PlayerPrefs.SetFloat("camPos.z", camPos.z);
    }

    // Start is called before the first frame update
    void Awake()
    {
        mainCam = TransformScript.FindAlways("Main Camera");
        head = TransformScript.FindAlways("Head");
    }

    void Start()
    {
        // Load the last position
        LoadPrefs();
    }

    private void DoMovement(float timeIncrement)
    {
        if (VRScript.IsVRAndRoomScale())
        {
            // If we are doing room scale - it is a little meaningless to 
            // to allow the XR rig to be moved around as our reference
            // point to the room is lost
            // So we might not allow movement here
            return;
        }

        Vector3 headRot = head.transform.eulerAngles;
        headRot.x = 0;
        headRot.z = 0;
        Quaternion q = new Quaternion();
        q.eulerAngles = headRot;

        // Move the player using either left stick or keyboard WASD

        // Calculate the amount of movement using the left or right stick
        Vector3 movement = Vector3.zero;
        transform.position += movement * timeIncrement * MovementSpeed;

        // Are they speeding up movement
        float speed = timeIncrement;
        if (KeyboardScript.Is_LeftShift_Pressed())
        {
            speed *= 5.0f;
        }

        // Navigate by keyboard WASD
        if (KeyboardScript.Is_W_Pressed())
        {
            movement = q * new Vector3(0, 0, 1.0f);
            transform.position += movement * speed;
        }
        if (KeyboardScript.Is_S_Pressed())
        {
            movement = q * new Vector3(0, 0, -1.0f);
            transform.position += movement * speed;
        }
        if (KeyboardScript.Is_A_Pressed())
        {
            movement = q * new Vector3(-1.0f, 0, 0);
            transform.position += movement * speed;
        }
        if (KeyboardScript.Is_D_Pressed())
        {
            movement = q * new Vector3(1.0f, 0, 0);
            transform.position += movement * speed;
        }
    }

    private void DoMouseLook(float timeIncrement)
    {
        // We only move when the mouse button is pressed and use the delta position
        if (MouseScript.IsRightButton())
        {
            if (lastMousePosition != Vector3.zero)
            {
                Vector3 mouse = Input.mousePosition;
                Vector3 delta = mouse - lastMousePosition;

                mouseRotation += delta * timeIncrement * MouseRotationSpeed;
            }
            lastMousePosition = Input.mousePosition;
        }
        else if (MouseScript.IsRightButtonUp())
        {
            lastMousePosition = Vector3.zero;
        }

        // Optional to stop pitch control on the mouse in VR
        if (VRScript.IsVR() == true)
        {
            mouseRotation.y = 0;
        }
    }

    // maybe i need this later
    //
    private void DoXRLook(float timeIncrement)
    {
        var controllers = EnumUtil.GetValues<HandScript.ControllerType>();
        foreach (HandScript.ControllerType controllerId in controllers)
        {
            VRScript.InputController input = VRScript.GetInput(controllerId);
        }
    }

    private void DoMovementAndLook()
    {
        float timeIncrement = Time.deltaTime;

        // Calculate the movement
        DoMovement(timeIncrement);

        // Rotate using the mouse
        DoMouseLook(timeIncrement);

        // Rotate using XR
        DoXRLook(timeIncrement);

        // Rotate the view and add this to the camera parent
        float pitch = rightStickPitch + mouseRotation.y;
        float yaw = rightStickYaw + mouseRotation.x + snapLook;
        head.rotation = Quaternion.Euler(-pitch, yaw, 0);
    }

    void Update()
    {
        // If we're in the scene view don't update anything
        if (!Application.isFocused)
        {
            return;
        }

        // This saves the player position
        if (KeyboardScript.Was_Delete_PressedThisFrame())
        {
            PlayerPrefs.DeleteAll();
        }

        // This resets the player to 0
        if (KeyboardScript.Was_R_PressedThisFrame())
        {
            // Reset the player
            mouseRotation = Vector3.zero;
            snapLook = 0;
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
        }

        DoMovementAndLook();
    }

    private void OnDestroy()
    {
        SavePrefs();
    }
}
