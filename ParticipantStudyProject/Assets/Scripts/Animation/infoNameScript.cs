using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoNameScript : MonoBehaviour
{
    
    // documentation
    //-------------------------------------------------------------

    // https://docs.unity3d.com/2019.1/Documentation/ScriptReference/UI.Text.html

    //-------------------------------------------------------------


    // initialise
    //-------------------------------------------------------------

    Text Name;

    void Start()
    {
        Name = GetComponent<Text>();
    }

    //-------------------------------------------------------------


    // technique button functions
    //-------------------------------------------------------------

    public void SetAGEUKE()
    {
        Name.text = "Age-Uke";
    }

    public void SetGEDANBARAI()
    {
        Name.text = "Gedan-Barai";
    }

    public void SetSOTOUKE()
    {
        Name.text = "Soto-Uke";
    }

    public void SetUCHIUKE()
    {
        Name.text = "Uchi-Uke";
    }

    //-------------------------------------------------------------
}