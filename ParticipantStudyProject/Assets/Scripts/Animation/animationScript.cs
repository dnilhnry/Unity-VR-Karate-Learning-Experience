using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationScript : MonoBehaviour
{

    // documentation
    //-------------------------------------------------------------

    // https://docs.unity3d.com/ScriptReference/Animator.html

    //-------------------------------------------------------------


    // initialise
    //-------------------------------------------------------------

    Animator animatorController;

    void Start()
    {
        animatorController = GetComponent<Animator>();
    }

    //-------------------------------------------------------------


    // technique button functions
    //-------------------------------------------------------------

    public void SetAGEUKE()
    {
        animatorController.Play("Base Layer.AGE-UKE");
    }

    public void SetGEDANBARAI()
    {
        animatorController.Play("Base Layer.GEDAN-BARAI");
    }

    public void SetSOTOUKE()
    {
        animatorController.Play("Base Layer.SOTO-UKE");
    }

    public void SetUCHIUKE()
    {
        animatorController.Play("Base Layer.UCHI-UKE");
    }

    //-------------------------------------------------------------


    // playback speed button functions
    //-------------------------------------------------------------

    public void Set025()
    {
        animatorController.SetFloat("speedMultiplier", 0.25f);
    }

    public void Set050()
    {
        animatorController.SetFloat("speedMultiplier", 0.50f);
    }

    public void Set075()
    {
        animatorController.SetFloat("speedMultiplier", 0.75f);
    }

    public void Set100()
    {
        animatorController.SetFloat("speedMultiplier", 1.00f);
    }

    public void Set125()
    {
        animatorController.SetFloat("speedMultiplier", 1.25f);
    }

    public void Set150()
    {
        animatorController.SetFloat("speedMultiplier", 1.50f);
    }

    //-------------------------------------------------------------


    // lead hand button functions
    //-------------------------------------------------------------

    public void SetLeft()
    {
        animatorController.SetBool("mirrored", false);
    }

    public void SetRight()
    {
        animatorController.SetBool("mirrored", true);
    }

    //-------------------------------------------------------------

}
