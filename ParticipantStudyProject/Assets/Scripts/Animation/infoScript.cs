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
        Description.text = "Age-Uke translates to 'rising block' in English. \n\n";
        Description.text = Description.text + "This technique is used to block an attack aimed at your head. \n\n";
        Description.text = Description.text + "It is important that the forearm used to block the attack is positioned above your head. \n";
    }

    public void SetGEDANBARAI()
    {
        Name.text = "Gedan-Barai";
        Description.text = "Gedan-Barai translates to 'low block' in English. \n\n";
        Description.text = Description.text + "This technique is used to block an attack aimed at your lower body. \n\n";
        Description.text = Description.text + "It is important that the forearm used to block the attack is positioned far to the side of your body. \n";
    }

    public void SetSOTOUKE()
    {
        Name.text = "Soto-Uke";
        Description.text = "Soto-Uke translates to 'outer block' in English. \n\n";
        Description.text = Description.text + "This technique is used to block an attack aimed at your chest. \n\n";
        Description.text = Description.text + "It is important that the forearm used to block the attack comes all the way across your body. \n";
    }

    public void SetUCHIUKE()
    {
        Name.text = "Uchi-Uke";
        Description.text = "Uchi-Uke translates to 'inner block' in English. \n\n";
        Description.text = Description.text + "This technique is used to block an attack aimed at your chest. \n\n";
        Description.text = Description.text + "It is important that the forearm used to block the attack comes from the inside, across your body. \n";
    }

    //-------------------------------------------------------------
}