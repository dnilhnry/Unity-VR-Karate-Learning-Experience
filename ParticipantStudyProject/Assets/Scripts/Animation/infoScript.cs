using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class infoScript : MonoBehaviour
{
    
    // documentation
    //-------------------------------------------------------------

    // https://docs.unity3d.com/2019.1/Documentation/ScriptReference/UI.Text.html

    //-------------------------------------------------------------


    // initialise
    //-------------------------------------------------------------

    [SerializeField] private Text Name;
    [SerializeField] private Text Description;

    void Start()
    {
    }

    //-------------------------------------------------------------


    // technique button functions
    //-------------------------------------------------------------

    public void SetAGEUKE()
    {
        Name.text = "Age-Uke";
        Description.text = "Age-Uke can be understood as 'rising block' in English";
    }

    public void SetGEDANBARAI()
    {
        Name.text = "Gedan-Barai";
        Description.text = "Gedan-Barai can be understood as 'low block' in English";
    }

    public void SetSOTOUKE()
    {
        Name.text = "Soto-Uke";
        Description.text = "Soto-Uke can be understood as 'outer block' in English";
    }

    public void SetUCHIUKE()
    {
        Name.text = "Uchi-Uke";
        Description.text = "Uchi-Uke can be understood as 'inner block' in English";
    }

    //-------------------------------------------------------------
}