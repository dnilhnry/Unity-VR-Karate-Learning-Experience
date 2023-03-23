using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BWDebug : MonoBehaviour
{
    public static BWDebug instance;
    
    private Text text;
    private string currentText;
    public static bool isDebugging = false;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        text = GetComponent<Text>();
    }

    public void AddText(string textToAdd)
    {
        currentText += textToAdd;
    }
    void Update()
    {
        // We use mouse a lot in debugging so keyboard T might be better for testing       
        if (BWKeyboard.Was_F1_PressedThisFrame())
        {
            // Toggle debugging
            isDebugging = !isDebugging;
        }
    }

    void LateUpdate()
    {
        if (text != null)
        {
            text.text = currentText;
        }

        if (isDebugging)
        {
            currentText = "Debugging mode\n";
        }
        else
        {
            currentText = "";
        }
    }
}
