using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoDescriptionScript : MonoBehaviour
{
    
    // documentation
    //-------------------------------------------------------------

    // https://docs.unity3d.com/2019.1/Documentation/ScriptReference/UI.Text.html

    //-------------------------------------------------------------


    // initialise
    //-------------------------------------------------------------

    Text Description;

    void Start()
    {
        Description = GetComponent<Text>();
    }

    //-------------------------------------------------------------


    // technique button functions
    //-------------------------------------------------------------

    public void SetAGEUKE()
    {
        Description.text = "Rising block";
    }

    public void SetGEDANBARAI()
    {
        Description.text = "Low block";
    }

    public void SetSOTOUKE()
    {
        Description.text = "Outer block";
    }

    public void SetUCHIUKE()
    {
        Description.text = "Inner block";
    }

    //-------------------------------------------------------------
}